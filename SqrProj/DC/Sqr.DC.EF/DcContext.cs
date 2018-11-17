using MySql.Data.Entity;
using Sqr.DC.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.EF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class DcContext: DbContext
    {
        public DcContext() : this("DC") { }
        public DcContext(string connectionKey)
            : base(string.Format("name={0}", connectionKey))
        {
            this.Database.Log = (c =>
            {
                log4net.LogManager.GetLogger("RollingLogFileAppender").Debug(c);
            });
                
            //Database.SetInitializer(new EFInitializer());
            Database.SetInitializer<DcContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            OnBeforeSaving();
            return base.SaveChangesAsync();
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
