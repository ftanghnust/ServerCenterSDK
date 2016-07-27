/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/16/2016 10:35:13 AM
 * *******************************************************/
using System.Collections.Generic;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 用户缓存所有仓库存储库(此类注册为全局单列)
    /// </summary>
    internal class MessageStoreCache : IMessageStoreCache
    {
        /// <summary>
        /// 缓存已经注册的仓库消息存储信息
        /// Key     :   仓库编号
        /// Value   :   仓库消息存储介质映射对象
        /// </summary>
        private Dictionary<int, MessageStore> _instance = new Dictionary<int, MessageStore>();

        /// <summary>
        /// 
        /// </summary>
        private readonly IMessageStoreManager _messageStoreManager;
        private static readonly object _locker = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageStoreManager"></param>
        public MessageStoreCache(IMessageStoreManager messageStoreManager)
        {
            messageStoreManager.CheckNullThrowArgumentNullException("messageStoreManager");

            //初始化的时候就将仓库所有的消息存储映射保存到本地缓存
            this._messageStoreManager = messageStoreManager;
            foreach (var item in this._messageStoreManager.GetMessageStores())
            {
                this._instance.Add(item.WID, item);
            }
        }

        /// <summary>
        /// 是否已经注册
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns></returns>
        public bool MessageStoreExists(int wid)
        {
            //0.先从缓存里检测下是否注册，如果不存在
            if (!this._instance.ContainsKey(wid))
            {
                //1.在从数据库里去检测下是否注册了，未注册直接返回错误
                if (!this._messageStoreManager.MessageStoreExists(wid))
                {
                    return false;
                }

                //2.注册了就将注册的信息保存到缓存
                lock (_locker)
                {
                    if (!this._instance.ContainsKey(wid))
                    {
                        this._instance.Add(wid, new MessageStore()
                        {
                            WID = wid,
                            StorageName = this._messageStoreManager.GetMessageStoreName(wid)
                        });
                    }
                }
            }

            return true;
        }
    }
}
