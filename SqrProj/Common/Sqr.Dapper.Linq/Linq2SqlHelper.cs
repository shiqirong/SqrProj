using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Sqr.Dapper.Linq
{
    public class Linq2SqlHelper
    {
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

        public static string DealMemberExpresion(Expression exp)
        {
            return DealOrderbyExpress(exp);
        }
        /// <summary>
        /// 排序语句
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string DealOrderbyExpress(Expression exp)
        {
            if (exp is LambdaExpression)
            {
                LambdaExpression l_exp = exp as LambdaExpression;
                return DealExpress(l_exp.Body);
            }
            if (exp is BinaryExpression)
            {
                return DealBinaryExpression(exp as BinaryExpression);
            }
            if (exp is MemberExpression)
            {
                return DealMemberExpression(exp as MemberExpression);
            }
            if (exp is ConstantExpression)
            {
                return DealConstantExpression(exp as ConstantExpression);
            }
            if (exp is UnaryExpression)
            {
                return DealUnaryExpression(exp as UnaryExpression);
            }
            return "";
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
        public static string DealExpress(Expression exp)
        {
            if (exp is LambdaExpression)
            {
                LambdaExpression l_exp = exp as LambdaExpression;
                return DealExpress(l_exp.Body);
            }
            if (exp is BinaryExpression)
            {
                return DealBinaryExpression(exp as BinaryExpression);
            }
            if (exp is MemberExpression)
            {
                return DealMemberExpression(exp as MemberExpression);
            }
            if (exp is ConstantExpression)
            {
                return DealConstantExpression(exp as ConstantExpression);
            }
            if (exp is UnaryExpression)
            {
                return DealUnaryExpression(exp as UnaryExpression);
            }
            if(exp is NewExpression)
            {
                return DealNewExpression(exp as NewExpression);
            }
            return "";
        }

        public static string DealNewExpression(NewExpression exp)
        {
            string[] members = new string[exp.Arguments.Count];
            var i = 0;
            foreach(var a in exp.Arguments)
            {
                members[i++] = DealExpress(a);
            }
            return $" {string.Join(",", members)}";
        }
        public static string DealUnaryExpression(UnaryExpression exp)
        {
            return DealExpress(exp.Operand);
        }
        public static string DealConstantExpression(ConstantExpression exp)
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
        public static string DealBinaryExpression(BinaryExpression exp)
        {

            string left = DealExpress(exp.Left);
            string oper = GetOperStr(exp.NodeType);
            string right = DealExpress(exp.Right);
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
        public static string DealMemberExpression(MemberExpression exp)
        {
            return $" {exp.ToString()} ";
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
