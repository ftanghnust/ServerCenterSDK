/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/14 15:25:37
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core.ViewEngine
{
    /// <summary>
    /// 视图暴露出来的属性集合（外部注入值）
    /// </summary>
    public class ViewParameterCollection : List<ViewParameter>
    {
        /// <summary>
        /// 根据属性名称获取视图属性对象
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        public ViewParameter this[string name]
        {
            get
            {
                return this.FirstOrDefault(viewParameter => viewParameter.Name == name);
            }
        }

        /// <summary>
        /// 添加一个视图属性对象
        /// </summary>
        /// <param name="paramName">属性类型</param>
        /// <returns></returns>
        public void Add(string paramName)
        {
            this.Add(paramName, null);
        }

        /// <summary>
        /// 添加一个视图属性对象
        /// </summary>
        /// <param name="paramName">属性名称</param>
        /// <param name="paramValue">属性值</param>
        /// <returns></returns>
        public void Add(string paramName, object paramValue)
        {
            this.Add(new ViewParameter(paramName, paramValue));
        }

    }
}
