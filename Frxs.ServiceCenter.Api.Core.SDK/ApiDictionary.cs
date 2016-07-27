/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/2/2015 8:32:16 PM
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 排序字典类，便于签名
    /// </summary>
    internal class ApiDictionary : SortedDictionary<string, string>
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 
        /// </summary>
        public ApiDictionary() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        public ApiDictionary(IDictionary<string, string> dictionary)
            : base(dictionary)
        { }

        /// <summary>
        /// 添加一个新的键值对。空键或者空值的键值对将会被忽略。
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="value">键对应的值，目前支持：string, int, long, double, bool, DateTime类型</param>
        public void Add(string key, object value)
        {
            string strValue;

            if (value == null)
            {
                strValue = null;
            }
            else if (value is string)
            {
                strValue = (string)value;
            }
            else if (value is Nullable<DateTime>)
            {
                Nullable<DateTime> dateTime = value as Nullable<DateTime>;
                strValue = dateTime.Value.ToString(DateTimeFormat);
            }
            else if (value is Nullable<int>)
            {
                strValue = (value as Nullable<int>).Value.ToString();
            }
            else if (value is Nullable<long>)
            {
                strValue = (value as Nullable<long>).Value.ToString();
            }
            else if (value is Nullable<double>)
            {
                strValue = (value as Nullable<double>).Value.ToString();
            }
            else if (value is Nullable<bool>)
            {
                strValue = (value as Nullable<bool>).Value.ToString().ToLower();
            }
            else
            {
                strValue = value.ToString();
            }

            this.Add(key, strValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                base.Add(key, value);
            }
        }
    }
}
