using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sqr.Dapper.Linq.Test
{
    public class Linq2SqlTest
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
            KeyValuePair<string, int> kv = new KeyValuePair<string, int>("1", 1);
            var l2s = new Linq2Sql<Student, Greade, Lession>();
            var sql=l2s.Select((s, g, l) => new { s.Id, s.Name, GreadeName = g.Name, LessionName = l.Name })
                .From<Student>()
                .LeftJoin<Lession>((s,l, g) => s.Grede==g.Id).Where((s,l,g)=>s.Id==1 && l.Id==kv.Value).Excute();
            
        }
    }
}
