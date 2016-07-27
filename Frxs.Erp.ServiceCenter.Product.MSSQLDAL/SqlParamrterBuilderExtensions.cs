/*********************************************************
 * zhangliang@frxs.com 11/01 10:04:21 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using System.Linq;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ADO参数构造扩展方法
    /// </summary>
    public static class SqlParamrterBuilderExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlParameterBuilder"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParamrterBuilder Append(this SqlParamrterBuilder sqlParameterBuilder, string name, SqlDbType dbType, int size, object value)
        {
            sqlParameterBuilder.Add(name, dbType, value);
            return sqlParameterBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlParameterBuilder"></param>
        /// <param name="name">参数名称，不要加@</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static SqlParamrterBuilder Append(this SqlParamrterBuilder sqlParameterBuilder, string name, SqlDbType dbType, object value)
        {
            sqlParameterBuilder.Add(name, dbType, value);
            return sqlParameterBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlParameterBuilder"></param>
        /// <param name="name">参数名称，不要加@</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static SqlParamrterBuilder Append(this SqlParamrterBuilder sqlParameterBuilder, string name, object value)
        {
            sqlParameterBuilder.Add(name, value);
            return sqlParameterBuilder;
        }
    }
}

