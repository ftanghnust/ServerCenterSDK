/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/3/2015 1:31:29 PM
 * *******************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ObjectExtensions
    {
        /// <summary>
        /// 序列化成JSON
        /// </summary>
        /// <param name="obj">任意对象类型</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.ffffff" };
            return JsonConvert.SerializeObject(obj, dateTimeConverter);
        }
    }
}
