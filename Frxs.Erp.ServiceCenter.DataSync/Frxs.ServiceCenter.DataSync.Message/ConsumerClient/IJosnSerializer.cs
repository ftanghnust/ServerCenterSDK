/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 5:16:38 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// JSON序列化接口，交给外部调用系统去实现（防止程序集冲突）
    /// </summary>
    public interface IJosnSerializer
    {
        /// <summary>
        /// 消息摘要反序列化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Deserialize(string value, Type type);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// 消息摘要序列化，用于保存到其他存储介质
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Serialize(object value);
    }
}
