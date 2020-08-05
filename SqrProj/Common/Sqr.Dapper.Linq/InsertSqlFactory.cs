using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class InsertSqlFactory<T>:Linq2SqlFactory
    {
        protected string _columnNames = string.Empty;
        protected string _valueNames = string.Empty;

        public override string Sql
        {
            get
            {
                return $"INSERT INTO {_from} ({_columnNames}) values({_valueNames})";
            }
        }

        public virtual InsertSqlFactory<T> Insert(T entity)
        {
            var type = typeof(T);
            _from = $" {type.Name} ";

            var i = 0;
            var ps = type.GetProperties();
            foreach(var p in ps)
            {
                if (i == 0)
                {
                    _columnNames += p.Name;
                    _valueNames += $"{Linq2SqlHelper._paramPrix}{p.Name}";
                    _paramsList.Add(new KeyValuePair<string, object>(p.Name, p.GetValue(entity)));
                }
                else
                {
                    _columnNames += $",{p.Name}";
                    _valueNames += $",{Linq2SqlHelper._paramPrix}{p.Name}";
                    _paramsList.Add(new KeyValuePair<string, object>(p.Name, p.GetValue(entity)));
                }
                i++;
            }
            return this;
        }
    }
}
