using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sqr.Dapper.Linq.Common
{
    public static class Linq2SqlMethod
    {
        public static bool WhereIf<T>(bool ifCondition,Expression<Func<T,bool>> ifWhereExp)
        {
            return true;
        }
    }
}
