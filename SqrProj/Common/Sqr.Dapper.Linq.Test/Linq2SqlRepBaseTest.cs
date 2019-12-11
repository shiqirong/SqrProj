using Sqr.Dapper.Linq.Test.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sqr.Dapper.Linq.Test
{
    public class Linq2SqlRepBaseTest:TestBase
    {
        [Fact]
        public void Select()
        {
            var rep = new Linq2SqlRepBase(_connectionString);
           var actionInfo= rep.QuerySingleOrDefault<Actioninfo, Actioninfo>(c => 
            c.Select(s =>s)
             .From<Actioninfo>()
             .Where(w => w.Id > 0));
            Assert.NotNull(actionInfo);
        }

        [Fact]
        public void Update()
        {
            var rep = new Linq2SqlRepBase(_connectionString);
            var r=rep.Update<Actioninfo>(c => new { Name = "test1" }, c => c.Id == 90);
            Assert.True(r >= 1);
        }
    }
}
