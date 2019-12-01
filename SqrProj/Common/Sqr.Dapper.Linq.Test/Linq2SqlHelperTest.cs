using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Sqr.Dapper.Linq.Test
{
    public class Linq2SqlHelperTest
    {
        public class Student
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
        [Fact]
        public void Test1()
        {
            Student tableA = new Student()
            {
                Name = "º«Ã·Ã·",
                Age = 19
            };
            Student tableB = new Student()
            {
                Name = "º«Ã·Ã·",
                Age = 19
            };

            Student tableC = new Student()
            {
                Name = "º«Ã·Ã·",
                Age = 19
            };

            Expression<Func<Student, Student>> la = n => new Student { Name = n.Name+"ÀîËÄ", Age = 60 };
            Expression<Func<Student, dynamic>> expression = (c => new { Name="º«Ã·Ã·",Age=19});
            Linq2SqlHelper.GetExpressStr(la.Body as MemberInitExpression);
        }

        [Fact]
        public void CreateSelectSqlTest()
        {
            //Student tableA = new Student()
            //{
            //    Name = "º«Ã·Ã·",
            //    Age = 19
            //};
            //List<Student> lst = new List<Student>();
            //lst.OrderBy(c=>c.Age);
            //Expression<Func<Student, bool>> whereExpression = n => n.Age>=19;
            //IOrderedEnumerable<Student> orderbyExpression = (c => c.Age);
            //Linq2SqlHelper.CreateSelectSql<Student>( la.Body as MemberInitExpression);
        }
    }
}
