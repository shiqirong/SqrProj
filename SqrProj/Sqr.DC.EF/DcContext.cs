using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Sqr.DC.EF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DcContext: DbContext
    {
        public DcContext() : this("DC") { }
        public DcContext(string connectionKey)
            : base(string.Format("name={0}", connectionKey))
        {
            
            //Database.SetInitializer(new EFInitializer());
            Database.SetInitializer<DcContext>(null);
        }
    }
}
