/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/14/2016 4:40:13 PM
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息存储介质管理器
    /// </summary>
    public interface IMessageStoreManager
    {
        /// <summary>
        /// 根据仓库编号获取存储介质
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns></returns>
        string GetMessageStoreName(int? wid);

        /// <summary>
        /// 获取全局消息存储介质名称
        /// </summary>
        /// <returns></returns>
        string GetGlobalMessageStoreName();

        /// <summary>
        /// 创建存储介质
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns></returns>
        string CreateMessageStore(int wid);

        /// <summary>
        /// 判断仓库的存储介质是否存在
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns>true/false</returns>
        bool MessageStoreExists(int wid);

        /// <summary>
        /// 获取所有存储配置
        /// </summary>
        /// <returns></returns>
        IEnumerable<MessageStore> GetMessageStores();

        /// <summary>
        /// 保存消息到存储介质，带分发功能
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        bool SaveMessageToStore(Message<IMessageBody> message);

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <typeparam name="T">时间参数类型</typeparam>
        /// <param name="wid">仓库编号</param>
        /// <param name="startMessageId">起始消息编号</param>
        /// <param name="number">每次获取消息数</param>
        /// <returns></returns>
        IEnumerable<Message<T>> GetMessages<T>(int? wid, string startMessageId, int number) where T : IMessageBody;
    }
}
