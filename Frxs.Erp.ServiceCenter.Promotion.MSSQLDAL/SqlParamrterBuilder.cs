using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// SQL参数构造封装类
    /// </summary>
    public class SqlParamrterBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, SqlParameter> _dit = new Dictionary<string, SqlParameter>();

        /// <summary>
        /// 
        /// </summary>
        public SqlParamrterBuilder() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        public void Add(string name, SqlDbType dbType, int size, object value)
        {
            SqlParameter sqlParameter = new SqlParameter(string.Format("@{0}", name), dbType, size);
            sqlParameter.Value = value;
            this._dit.Add(name, sqlParameter);
        }

        /// <summary>
        /// 添加一个sqlparameter参数
        /// </summary>
        /// <param name="name">参数名称，无需@</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="value">参数值</param>
        public void Add(string name, SqlDbType dbType, object value)
        {
            SqlParameter sqlParameter = new SqlParameter(string.Format("@{0}", name), dbType);
            sqlParameter.Value = value;
            this._dit.Add(name, sqlParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">参数名称，无需@</param>
        /// <param name="value">参数值</param>
        public void Add(string name, object value)
        {
            SqlParameter sqlParameter = new SqlParameter(string.Format("@{0}", name), value);
            this._dit.Add(name, sqlParameter);
        }

        /// <summary>
        /// 返回参数数组
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] ToSqlParameters()
        {
            IList<SqlParameter> list = new List<SqlParameter>();
            foreach (var item in this._dit)
            {
                list.Add(item.Value);
            }
            return list.ToArray();
        }
    }
}
