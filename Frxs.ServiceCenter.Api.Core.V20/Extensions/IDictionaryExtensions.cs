/*********************************************************
 * zhangliang@frxs.com 11/01 10:04:21 PM
 * *******************************************************/
using System;
using System.Linq;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// IDictionary Extensions
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// 添加一个键值并且返回字段对象
        /// </summary>
        /// <typeparam name="TKey">键数据类型</typeparam>
        /// <typeparam name="TValue">值数据类型</typeparam>
        /// <param name="dict">字典对象</param>
        /// <param name="key">当前加入key键</param>
        /// <param name="value">当前加入的值</param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Append<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 添加一个键值并且返回字段对象
        /// </summary>
        /// <typeparam name="TKey">键数据类型</typeparam>
        /// <typeparam name="TValue">值数据类型</typeparam>
        /// <param name="dict">字典对象</param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Append<TKey, TValue>(this IDictionary<TKey, TValue> dict, params KeyValuePair<TKey, TValue>[] items)
        {
            if (items.IsNull())
            {
                return dict;
            }
            foreach (var kp in items)
            {
                dict.Add(kp.Key, kp.Value);
            }
            return dict;
        }

        /// <summary>
        /// 添加一个键值并且返回字段对象
        /// </summary>
        /// <typeparam name="TKey">键数据类型</typeparam>
        /// <typeparam name="TValue">值数据类型</typeparam>
        /// <param name="dict">字典对象</param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Append<TKey, TValue>(this IDictionary<TKey, TValue> dict, params Tuple<TKey, TValue>[] items)
        {
            foreach (var kp in items)
            {
                dict.Add(kp.Item1, kp.Item2);
            }
            return dict;
        }

        /// <summary>
        /// 添加一个键值并且返回字段对象
        /// </summary>
        /// <typeparam name="TKey">键数据类型</typeparam>
        /// <typeparam name="TValue">值数据类型</typeparam>
        /// <param name="dict">字典对象</param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Append<TKey, TValue>(this IDictionary<TKey, TValue> dict, Func<KeyValuePair<TKey, TValue>> @default)
        {
            var kv = @default();
            dict.Add(kv.Key, kv.Value);
            return dict;
        }

        /// <summary>
        /// 判断一个字段对象是否为空，注意此扩展方法仅仅判断字段里是否为0个集合
        /// </summary>
        /// <param name="dict">字段对象</param>
        /// <returns>包含0个元素，返回true</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public static bool IsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            dict.CheckNullThrowArgumentNullException("dict");
            return !dict.Any();
        }

        /// <summary>
        /// 根据键获取字典值，如果指定的键不存在，就从后续的默认委托获取值
        /// </summary>
        /// <param name="dict">字典对象</param>
        /// <typeparam name="TKey">键数据类型</typeparam>
        /// <typeparam name="TValue">值数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="default">返回默认值委托</param>
        /// <returns></returns>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> @default)
        {
            dict.CheckNullThrowArgumentNullException("dict");
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return @default(key);
        }
    }
}

