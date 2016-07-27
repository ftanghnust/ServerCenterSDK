/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 1:00:52 PM
 * *******************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 基于Newtonsoft.Json实现，消息体使用JSON格式保存
    /// </summary>
    internal class JsonMessageBodyFormatter : IMessageBodyFormatter
    {
        /// <summary>
        /// 将字符串反序列化成IMessageBody对象
        /// </summary>
        /// <param name="value">JSON字符串</param>
        /// <param name="type">待反序列化的对象类型</param>
        /// <returns></returns>
        public IMessageBody Deserialize(string value, Type type)
        {
            return (IMessageBody)JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// 将实现了IMessageBody接口的对象序列化成json，保存
        /// </summary>
        /// <param name="value">待序列化的对象</param>
        /// <returns></returns>
        public string Serialize(IMessageBody value)
        {
            return JsonConvert.SerializeObject(value,
                new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" });
        }
    }
}