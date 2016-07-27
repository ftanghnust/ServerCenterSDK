/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/24 12:43:56
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 指示接口开发人员特性，方便框架自动生成文档显示说明
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorAttribute : Attribute
    {
        /// <summary>
        /// 开发人员名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 接口开发人员特性，增加此特性可以在文档生成的时候显示开发人员名称，便于查阅
        /// </summary>
        /// <param name="name">开发人员名称</param>
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
    }
}
