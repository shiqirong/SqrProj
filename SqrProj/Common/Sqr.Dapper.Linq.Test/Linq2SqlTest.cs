using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sqr.Dapper.Linq.Test
{
    public class Linq2SqlTest:TestBase
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int Grede { get; set; }
        }

        public class Lession
        {
            public int Id { get; set; }
            public int StudentId { get; set; }

            public string Name { get; set; }
        }

        public class Greade
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
        [Fact]
        public void Select()
        {
            List<string> lstStr = new List<string>();
            lstStr.Add("1");
            lstStr.Add("2");
            KeyValuePair<string, int> kv = new KeyValuePair<string, int>("1",1);
            var l2s = new SelectSqlFactory<Student, Greade, Lession>();
            var sql=l2s.Select((s, g, l) => new { s.Id, s.Name, GreadeName = g.Name, LessionName = l.Name })
                .From<Student>()
                .LeftJoin<Lession>((s,l, g) => s.Grede==g.Id).Where((s,l,g)=>s.Id==1 
                && l.Id==kv.Value 
                && l.Id.ToString()==l.Name 
                && lstStr.Contains(l.Id.ToString())
                && l.Name.StartsWith("hello")
                ).Sql;
            var siu = sql;
        }

        [Fact]
        public void Update()
        {
            var l2s = new UpdateSqlFactory<Student>()
                .Update(c => new {Id=90,Name=c.Id }, c => c.Id == 1);
            
        }
    }
}
