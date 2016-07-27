/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/1 15:26:42
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 程序集里的接口统一加前缀
    /// 如果接口所在的程序集里含有此特性标签，框架在加载接口的时候，会统一加上前缀
    /// 此特性只能添加于：AssemblyInfo.cs文件
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class ApiPrefixAttribute : Attribute
    {
        /// <summary>
        /// 统一前缀名称，如：Erp.Product
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix">接口前缀，如：Erp.Product</param>
        public ApiPrefixAttribute(string prefix)
        {
            if (prefix.IsNull())
            {
                throw new ArgumentNullException("prefix");
            }
            this.Prefix = prefix.Trim();
        }

    }
}
