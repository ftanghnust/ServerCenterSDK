﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/29 13:06:27
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core.Resource;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// 大于指定值
    /// </summary>
    public class GreaterThanAttribute : AbstractCompareAttribute
    {
        /// <summary>
        /// 比较类型
        /// </summary>
        protected override CompareType CompareType
        {
            get
            {
                return CompareType.GreaterThan;
            }
        }

        /// <summary>
        /// 设置的值，只要是实现了 IComparable 接口即可
        /// </summary>
        /// <param name="value">属性值必须大于此值</param>
        public GreaterThanAttribute(object value) : base(value)
        {
            this.ErrorMessage = CoreResource.GreaterThanAttribute_Error;
        }
    }
}
