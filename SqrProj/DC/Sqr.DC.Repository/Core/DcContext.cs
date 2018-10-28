
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Sqr.DC.Repository.Core
{
    internal class DcContext: DbContext
    {
        //public DcContext(DbContextOptions<DcContext> options)
        //    :base(options)// new MySqlConnectionFactory().CreateConnection("Server=localhost;database=Compay;uid=root;pwd=root;"),true
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Compay;user=root;password=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
