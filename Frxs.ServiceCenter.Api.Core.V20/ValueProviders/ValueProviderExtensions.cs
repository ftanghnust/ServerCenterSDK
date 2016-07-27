/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/16 15:56:08
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 值提供器扩展类
    /// </summary>
    public static class ValueProviderExtensions
    {
        /// <summary>
        /// 获取值提供器提供的值，转换成字符串
        /// </summary>
        /// <param name="valueProvider">值提供器</param>
        /// <param name="key">key</param>
        /// <param name="defaultFun">当key返回null的时候，返回默认的指定值，委托入参为：key值</param>
        /// <returns></returns>
        public static string GetString(this IValueProvider valueProvider, string key, Func<string, string> defaultFun)
        {
            valueProvider.CheckNullThrowArgumentNullException("valueProvider");

            //当前的值提供器
            var value = valueProvider.GetValue(key);

            //值为null，直接使用默认的委托返回数据
            if (value.IsNull())
            {
                return defaultFun.IsNull() ? null : defaultFun(key);
            }

            //返回数据
            return value.ToString();
        }
    }
}
