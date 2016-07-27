/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 1:12:49 PM
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息ID获取接口
    /// 注意：此接口必须实现为后获取的MessageId比前一次获取的大
    /// </summary>
    public interface IMessageIdGenerator
    {
        /// <summary>
        /// 获取消息ID
        /// </summary>
        /// <returns></returns>
        string GetNextId();
    }
}