using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace Sqr.Dapper.Linq
{
    public static class DapperExtension
    {
        //public bool Insert<T>(this IDbConnection connection, T mo)
        //{
        //    new Linq2Sql<T>()
        //}

        public static T QuerySigle<T,T1>(Action<SelectSqlFactory<T1>> act)
        {
            var linq2Sql = new SelectSqlFactory<T1>();
            act(linq2Sql);
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(""))
            {
                return connection.Query<T>(linq2Sql.Sql, linq2Sql.ParamsList).Single();
            }

        }

        public static void Test()
        {
            QuerySigle<KeyValuePair<string, string>, TMo>(c => c.From<TMo>().Where(a => a.id == ""));
        }

    }
    public class TMo
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}
