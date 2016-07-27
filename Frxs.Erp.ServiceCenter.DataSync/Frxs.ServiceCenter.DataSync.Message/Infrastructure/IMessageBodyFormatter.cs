/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 12:57:28 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 时间消息摘要格式化器
    /// </summary>
    public interface IMessageBodyFormatter
    {
        /// <summary>
        /// 消息摘要反序列化
        /// </summary>
        /// <param name="value">消息参数被序列化后的字符串，可能是XML或者JOSN</param>
        /// <param name="type">待反序列化后的对象类型</param>
        /// <returns></returns>
        IMessageBody Deserialize(string value, Type type);

        /// <summary>
        /// 消息摘要序列化，用于保存到其他存储介质
        /// </summary>
        /// <param name="value">实现消息体对象</param>
        /// <returns>返回XML或者JSON</returns>
        string Serialize(IMessageBody value);

    }
}