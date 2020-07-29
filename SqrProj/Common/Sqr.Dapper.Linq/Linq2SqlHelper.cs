using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Sqr.Dapper.Linq
{
    public enum CommandType
    {
        SELECT,
        UPDATE,
        DELETE
    }

    public class Linq2SqlHelper
    {
        public static string _paramPrix = "@";

        public static string CreateInsertSql<T>(T model)
        {
            string sql = "Insert into {0}({1}) Values({2})";
            string table = string.Empty;            //表名
            List<string> member = new List<string>(); //全部列名
            List<string> member_value = new List<string>(); //全部的值
            Type type = typeof(T);
            table = type.Name;
            foreach (PropertyInfo item in type.GetProperties())
            {
                string name = item.Name;
                member.Add(name);
                object vaule = item.GetValue(model);
                string v_str = string.Empty;
                if (vaule is string)
                {
                    v_str = string.Format("'{0}'", vaule.ToString());
                }
                else if (vaule is DateTime)
                {
                    DateTime time = (DateTime)vaule;
                    v_str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    v_str = vaule.ToString();
                }
                member_value.Add(v_str);
            }
            sql = string.Format(sql, table, string.Join(",", member), string.Join(",", member_value));
            return sql;
        }

        public static string CreateSelectSql(Dictionary<string,string> tblAlias, Expression whereExpression)
        {
            //Type type = typeof(T);
            //string tableName = type.Name;            //表名
            //List<string> member = new List<string>(); //全部列名

            //foreach (PropertyInfo item in type.GetProperties())
            //{
            //    string name = item.Name;
            //    member.Add(name);
            //}

            //string whereCondition = DealExpress(whereExpression);
            //string orderbyCondition = DealOrderbyExpress(orderExpression);

            //var sql = $"select {string.Join(",",member)} from {tableName} where {whereCondition} order by {orderbyCondition}";

            //return sql;
            return string.Empty;
        }

        public static string CreateDeleteSql<T>(T model)
        {
            return string.Empty;
        }

        public static string CreateUpdateSql<T>(T model)
        {
            return string.Empty;
        }

        public static string DealMemberExpresion(Expression exp, IList<KeyValuePair<string, object>> paramsList)
        {
            return DealOrderbyExpress(exp, paramsList);
        }

        /// <summary>
        /// 排序语句
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string DealOrderbyExpress(Expression exp,IList<KeyValuePair<string,object>> paramsList,CommandType commandType= CommandType.SELECT)
        {
                return DealExpress(exp, paramsList, commandType);
           
        }

        /// <summary>
        /// 更新语句
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string GetExpressStr(MemberInitExpression exp)
        {

            string result = string.Empty;
            List<string> member = new List<string>();
            foreach (MemberAssignment item in exp.Bindings)
            {
                string update = item.Member.Name + "=" + GetConstantStr((ConstantExpression)item.Expression);
                member.Add(update);
            }
            result = string.Join(",", member);
            return result;
        }

        public static string GetConstantStr(ConstantExpression exp)
        {
            object vaule = exp.Value;
            string v_str = string.Empty;
            if (vaule is string)
            {
                v_str = string.Format("'{0}'", vaule.ToString());
            }
            else if (vaule is DateTime)
            {
                DateTime time = (DateTime)vaule;
                v_str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                v_str = vaule.ToString();
            }
            return v_str;
        }
        public static string DealExpress(Expression exp,IList<KeyValuePair<string,object>> paramsList, CommandType commandType= CommandType.SELECT )
        {
            if (exp is LambdaExpression)
            {
                LambdaExpression l_exp = exp as LambdaExpression;
                if (l_exp.Body is ConstantExpression)
                {
                    if ("true".Equals((l_exp.Body as ConstantExpression).Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                        return " 1 = 1 ";
                    else
                        return " 1 = 2 ";
                }
                return DealExpress(l_exp.Body, paramsList, commandType);
            }
            if (exp is BinaryExpression)
            {
                return DealBinaryExpression(exp as BinaryExpression, paramsList, commandType);
            }
            if (exp is MemberExpression)
            {
                return DealMemberExpression(exp as MemberExpression, paramsList, commandType);
            }
            if (exp is ConstantExpression)
            {
                return DealConstantExpression(exp as ConstantExpression, paramsList, commandType);
            }
            if (exp is UnaryExpression)
            {
                return DealUnaryExpression(exp as UnaryExpression, paramsList, commandType);
            }
            if(exp is NewExpression)
            {
                return DealNewExpression(exp as NewExpression, paramsList, commandType);
            }
            if(exp is MethodCallExpression)
            {
                return DealCallExpression(exp as MethodCallExpression, paramsList, commandType);
            }
            if(exp is ParameterExpression)
            {
                return DealParameterExpression(exp as ParameterExpression, paramsList, commandType);
            }
            return "";
        }

        private static string DealParameterExpression(ParameterExpression parameterExpression, IList<KeyValuePair<string, object>> paramsList, CommandType commandType)
        {
            var ps=parameterExpression.Type.GetProperties();
            return string.Join(",", ps.Select(c => $" {parameterExpression.Name}.{ c.Name} "));
        }

        public static string DealCallExpression(MethodCallExpression exp, IList<KeyValuePair<string, object>> paramsList, CommandType commandType = CommandType.SELECT)
        {
          
            switch (exp.Method.Name)
            {
                case "ToString":
                    return $" CAST({DealExpress(exp.Object, paramsList, commandType)},CHAR) ";
                case "StartsWith":
                    var para1= DealExpress(exp.Object, paramsList, commandType);
                    var para2 = DealExpress(exp.Arguments[0], paramsList, commandType);
                    return $"  {para1} like {para2.Insert(para2.Length - 1, "%")}) ";
                case "EndWith":
                    var endWithP1 = DealExpress(exp.Object, paramsList, commandType);
                    var endWithP2 = DealExpress(exp.Arguments[0], paramsList, commandType);
                    return $"  {endWithP1} like {endWithP2.Insert(1,"%")}) ";
                case "Contains":
                    var containsP1 = DealExpress(exp.Object, paramsList, commandType);
                    var paramName = $"{_paramPrix}p_{paramsList.Count + 1}";
                    paramsList.Add(new KeyValuePair<string, object>(paramName, containsP1));
                    return $" {DealExpress(exp.Arguments[0], paramsList, commandType)} in({paramName})  ";
                case "WhereIf":
                    var ifWhereArg1 = Convert.ToBoolean( DealExpress(exp.Arguments[0], paramsList, commandType));
                    if (ifWhereArg1)
                        return DealExpress(exp.Arguments[1], paramsList, commandType);
                    else
                        return " 1=1 ";
                default:
                    throw new NotSupportedException($"not Supported method:{exp.Method.Name}.");


            }
            
        }
        public static  string DealNewExpression(NewExpression exp, IList<KeyValuePair<string, object>> paramsList, CommandType commandType=CommandType.SELECT)
        {
            string[] members = new string[exp.Arguments.Count];
            var i = 0;
            if (commandType == CommandType.UPDATE)
            {
                foreach (var a in exp.Arguments)
                {
                    members[i] = exp.Members[i].Name + "=" + DealExpress(a, paramsList, commandType);
                    i++;
                }
            }
            else
            {
                foreach (var a in exp.Arguments)
                {
                    members[i++] =  DealExpress(a, paramsList,commandType);
                }
            }
            return $" {string.Join(",", members)}";
        }
        public static string DealUnaryExpression(UnaryExpression exp, IList<KeyValuePair<string, object>> paramsList, CommandType commandType = CommandType.SELECT)
        {
            return DealExpress(exp.Operand,paramsList, commandType);
        }
        public static string DealConstantExpression(ConstantExpression exp, IList<KeyValuePair<string, object>> paramsList, CommandType commandType = CommandType.SELECT)
        {
            object vaule = exp.Value;
            string v_str = string.Empty;
            if (vaule == null)
            {
                return "NULL";
            }
            if (vaule is string)
            {
                v_str = string.Format("'{0}'", vaule.ToString());
            }
            else if (vaule is DateTime)
            {
                DateTime time = (DateTime)vaule;
                v_str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                v_str = vaule.ToString();
            }
            return v_str;
        }
        public static string DealBinaryExpression(BinaryExpression exp, IList<KeyValuePair<string, object>> paramsList, CommandType commandType = CommandType.SELECT)
        {
            string left = DealExpress(exp.Left,paramsList, commandType);
            string oper = GetOperStr(exp.NodeType);
            string right = DealExpress(exp.Right,paramsList, commandType);
            if (right == "NULL")
            {
                if (oper == "=")
                {
                    oper = " is ";
                }
                else
                {
                    oper = " is not ";
                }
            }
            return left + oper + right;
        }
        public static string DealMemberExpression(MemberExpression exp,IList<KeyValuePair<string,object>> paramsList, CommandType commandType = CommandType.SELECT)
        {
            if (exp.Expression.NodeType == ExpressionType.Parameter)
                return $" {exp.ToString()} ";
            else
            {
                var cast = Expression.Convert(exp, typeof(object));
                object c = Expression.Lambda<Func<object>>(cast).Compile().Invoke();
                var paramName = $"{_paramPrix}p_{paramsList.Count+1}";
                paramsList.Add(new KeyValuePair<string, object>(paramName, c));
                return paramName;
            }
        }
        public static string GetOperStr(ExpressionType e_type)
        {
            switch (e_type)
            {
                case ExpressionType.OrElse: return " OR ";
                case ExpressionType.Or: return "|";
                case ExpressionType.AndAlso: return " AND ";
                case ExpressionType.And: return "&";
                case ExpressionType.GreaterThan: return ">";
                case ExpressionType.GreaterThanOrEqual: return ">=";
                case ExpressionType.LessThan: return "<";
                case ExpressionType.LessThanOrEqual: return "<=";
                case ExpressionType.NotEqual: return "<>";
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Multiply: return "*";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Modulo: return "%";
                case ExpressionType.Equal: return "=";
            }
            return "";
        }


    }
}
