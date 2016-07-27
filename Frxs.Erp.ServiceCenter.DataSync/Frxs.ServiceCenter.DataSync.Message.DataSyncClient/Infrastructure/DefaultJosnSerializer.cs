/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/12 9:43:08
 * *******************************************************/
using System;
using Newtonsoft.Json;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 默认的序列化反序列化实现(Newtonsoft.Json)
    /// </summary>
    internal class DefaultJosnSerializer : IJosnSerializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="value">输入的JSON字符串</param>
        /// <param name="type">需要反序列化的类型</param>
        /// <returns></returns>
        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">需要反序列化的类型</typeparam>
        /// <param name="value">输入的JSON字符串</param>
        /// <returns></returns>
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value">待序列化的对象</param>
        /// <returns>返回序列化后的JSON字符串</returns>
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
