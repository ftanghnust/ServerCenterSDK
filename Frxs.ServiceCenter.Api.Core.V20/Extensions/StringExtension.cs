/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 字符类型扩展类
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 根据切分字符成int数组类型；不会返回失败信息，转型错误的直接忽略掉
        /// </summary>
        /// <param name="value">待拆分的字符串</param>
        /// <param name="splitStr">拆分字符</param>
        /// <returns></returns>
        public static int[] ToIntArray(this string value, char splitStr)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new int[0];
            }
            string[] arr = value.Split(new char[] { splitStr });
            return (from item in arr where item.IsInt() select item.As<int>()).ToArray();
        }

        /// <summary>
        /// 默认,切分
        /// </summary>
        /// <param name="value">待切分的字符串，使用,分开</param>
        /// <returns></returns>
        public static int[] ToIntArray(this string value)
        {
            return ToIntArray(value, ',');
        }

        /// <summary>
        /// 判断一个字符串数组是否可以转型成数字数组（如果可以转型成double类型即代表可以转型成功）
        /// </summary>
        /// <param name="strArr">字符串数组</param>
        /// <returns></returns>
        public static bool IsNumericArray(this string[] strArr)
        {
            if (strArr.IsNull() || strArr.Length == 0)
            {
                return false;
            }
            return strArr.All(item => item.Is<double>());
        }

        /// <summary>
        /// 将字符串按照指定的字符进行切分
        /// </summary>
        /// <param name="value"></param>
        /// <param name="splitStr">指定切分字符</param>
        /// <returns></returns>
        public static string[] ToStringArray(this string value, char[] splitStr)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new string[0];
            }
            return value.Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 将字符串按照指定的字符进行切分，默认,切分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] ToStringArray(this string value)
        {
            return ToStringArray(value, new char[] { ',' });
        }

        /// <summary>
        /// 将当前字符串重复count次
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Replicate(this string value, int count)
        {
            if (count < 0)
            {
                throw new ApiException("count参数错误");
            }
            string text = value;
            for (int i = 0; i < count; i++)
            {
                text = text + value;
            }
            return text;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator">连接符号</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Join(this string value, string separator, string b)
        {
            if (value.IsNullOrEmpty() && b.IsNullOrEmpty())
                return "";

            if (value.IsNullOrEmpty())
                return b ?? "";

            if (b.IsNullOrEmpty())
                return value ?? "";

            return value + separator + b;
        }

        /// <summary>
        /// 对字符串进行UrlEncode编码
        /// </summary>
        /// <param name="value">待编码字符串</param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            return System.Web.HttpUtility.UrlEncode(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string value)
        {
            return System.Web.HttpUtility.HtmlEncode(value);
        }

        /// <summary>
        /// 转型成DateTime，失败返回null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string value)
        {
            try
            {
                return DateTime.Parse(DateTime.Parse(value).ToString("yyyy/MM/dd HH:mm:ss"));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转型成int，失败返回null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt(this string value)
        {
            int i = 0;
            if (!int.TryParse(value, out i))
            {
                return null;
            }
            return i;
        }

        /// <summary>
        /// 转型成long，失败返回null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? ToLong(this string value)
        {
            long i = 0;
            if (!long.TryParse(value, out i))
            {
                return null;
            }
            return i;
        }

        /// <summary>
        /// 转型成ToDecimal，失败返回null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string value)
        {
            decimal i = 0;
            if (!decimal.TryParse(value, out i))
            {
                return null;
            }
            return i;
        }

        /// <summary>
        /// 对个需要格式化的字符串格式化
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string With(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="appendString"></param>
        /// <returns></returns>
        public static string Append(this string str, string appendString)
        {
            return str + appendString;
        }

        /// <summary>
        /// 裁剪字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">裁剪长度</param>
        /// <param name="ellipsis">裁剪后的字符代替字符</param>
        /// <returns></returns>
        public static string CutString(this string value, int length, string ellipsis)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (value.Length <= length)
            {
                return value;
            }
            return value.Substring(0, length) + (ellipsis ?? string.Empty);
        }

        /// <summary>
        /// 裁剪字符
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(this string value, int length)
        {
            return CutString(value, length, string.Empty);
        }

        /// <summary>
        /// 当前字符串是否为空或者为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 当前字符串是否为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull(this string value)
        {
            return null == value;
        }

        /// <summary>
        /// 判断当前字符串是否为空，来返回实际对象
        /// </summary>
        /// <typeparam name="T">返回对象</typeparam>
        /// <param name="value">当前字符串</param>
        /// <param name="valueEmptyFun">当前字符串为空的时候，返回默认对象</param>
        /// <param name="valueNotEmptyFun">当前字符串不为空的时候，返回对象，输入字符串为当前字符串</param>
        /// <returns></returns>
        public static T IsNullOrEmptyForDefault<T>(this string value, Func<T> valueEmptyFun, Func<string, T> valueNotEmptyFun)
        {
            if (value.IsNullOrEmpty())
            {
                return valueEmptyFun();
            }
            return valueNotEmptyFun(value);
        }

        /// <summary>
        /// 转型成int
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static int AsInt(this string value)
        {
            return value.AsInt(0);
        }

        /// <summary>
        /// 转型成int，失败则使用默认值
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">转型失败，返回此默认值</param>
        /// <returns></returns>
        public static int AsInt(this string value, int defaultValue)
        {
            int result;
            if (!int.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 转型成Decimal;转型失败则返回：0m
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static decimal AsDecimal(this string value)
        {
            return value.As<decimal>(0m);
        }

        /// <summary>
        /// 转型成Decimal;转型失败则返回指定的默认值
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">转型失败，返回此默认值</param>
        /// <returns></returns>
        public static decimal AsDecimal(this string value, decimal defaultValue)
        {
            return value.As(defaultValue);
        }

        /// <summary>
        /// 转换成Float;失败默认返回0
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static float AsFloat(this string value)
        {
            return value.AsFloat(0f);
        }

        /// <summary>
        /// 转换成Float;失败默认返回指定的默认值
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">转型失败，返回此默认值</param>
        /// <returns></returns>
        public static float AsFloat(this string value, float defaultValue)
        {
            float result;
            if (!float.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 转型成DateTime，转型失败默认返回：default(DateTime)=0001/1/1 0:00:00
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static DateTime AsDateTime(this string value)
        {
            return value.AsDateTime(default(DateTime));
        }

        /// <summary>
        /// 转型成DateTime
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">转型失败，返回此默认值</param>
        /// <returns></returns>
        public static DateTime AsDateTime(this string value, DateTime defaultValue)
        {
            DateTime result;
            if (!DateTime.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 将字符串转型成指定的基元类型
        /// </summary>
        /// <typeparam name="TValue">指定数据类型</typeparam>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static TValue As<TValue>(this string value)
        {
            return value.As(default(TValue));
        }

        /// <summary>
        /// 字符串与指定的类型是否可以相互转换
        /// </summary>
        /// <typeparam name="TValue">指定的基元类型</typeparam>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">无法转型，就默认使用默认指定值</param>
        /// <returns></returns>
        public static TValue As<TValue>(this string value, TValue defaultValue)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    TValue result = (TValue)((object)converter.ConvertFrom(value));
                    return result;
                }
                converter = TypeDescriptor.GetConverter(typeof(string));
                if (converter.CanConvertTo(typeof(TValue)))
                {
                    TValue result = (TValue)((object)converter.ConvertTo(value, typeof(TValue)));
                    return result;
                }
            }
            catch
            {
            }
            return defaultValue;
        }

        /// <summary>
        /// 转型成bool，转型失败默认返回：false
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool AsBool(this string value)
        {
            return value.AsBool(false);
        }

        /// <summary>
        /// 转型成bool,转型失败则返回默认值
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <param name="defaultValue">转型失败，返回此默认值</param>
        /// <returns></returns>
        public static bool AsBool(this string value, bool defaultValue)
        {
            bool result;
            if (!bool.TryParse(value, out result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 字符串是否能转型成bool类型
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool IsBool(this string value)
        {
            bool flag;
            return bool.TryParse(value, out flag);
        }

        /// <summary>
        /// 字符串是否能转出int类型
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool IsInt(this string value)
        {
            int num;
            return int.TryParse(value, out num);
        }

        /// <summary>
        /// 字符串是否能转型成Decimal类型
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(this string value)
        {
            return value.Is<decimal>();
        }

        /// <summary>
        /// 字符串是否能转型成Float类型
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool IsFloat(this string value)
        {
            float num;
            return float.TryParse(value, out num);
        }

        /// <summary>
        /// 字符串是否能转型成DateTime类型
        /// </summary>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string value)
        {
            DateTime dateTime;
            return DateTime.TryParse(value, out dateTime);
        }

        /// <summary>
        /// 字符串是否可以转型成指定的类型
        /// </summary>
        /// <typeparam name="TValue">指定的基元类型</typeparam>
        /// <param name="value">待转型的字符串</param>
        /// <returns></returns>
        public static bool Is<TValue>(this string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
            if (converter != null)
            {
                try
                {
                    if (value == null || converter.CanConvertFrom(null, value.GetType()))
                    {
                        converter.ConvertFrom(null, CultureInfo.CurrentCulture, value);
                        return true;
                    }
                }
                catch
                {
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 将JSON字符串转换成实体对象
        /// 注意：如果字符串不是合法的JSON字符串；无法反序列化出指定对象，则返回null，因此外部程序需要判断返回值
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="jsonValue">JSON字符串</param>
        /// <returns>返回指定的T对象</returns>
        public static T DeserializeJsonStringToObject<T>(this string jsonValue)
        {
            try
            {
                return ((IJosnSerializer)new DefaultJosnSerializer()).Deserialize<T>(jsonValue);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 将JSON字符串转换成实体对象
        /// </summary>
        /// <param name="jsonValue">JSON字符串</param>
        /// <param name="type">待转换的实体类型</param>
        /// <returns></returns>
        public static object DeserializeJsonStringToObject(this string jsonValue, Type type)
        {
            try
            {
                return ((IJosnSerializer)new DefaultJosnSerializer()).Deserialize(jsonValue, type);
            }
            catch
            {
                return null;
            }
        }
    }
}
