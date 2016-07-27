/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 11:53:09 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.StartUp
{
    /// <summary>
    /// 系统初始化需要做的一些事件
    /// </summary>
    public class StartUp : IStartUp
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMessageStoreManager _messageStoreManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageStoreManager"></param>
        public StartUp(IMessageStoreManager messageStoreManager)
        {
            this._messageStoreManager = messageStoreManager;
        }

        /// <summary>
        /// 站点启动的时候会自动运行此方法
        /// </summary>
        public void Init()
        {
        }
    }
}