/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/27 10:17:04
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统框架消息队列接口
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 发送消息到消息队列
        /// </summary>
        /// <param name="messageLable">消息队列消息标签</param>
        /// <param name="messageBody">消息主体</param>
        void Send<T>(string messageLable, T messageBody);

    }
}
