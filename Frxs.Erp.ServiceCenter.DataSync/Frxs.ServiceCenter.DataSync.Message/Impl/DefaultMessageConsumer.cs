/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 9:37:48 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Entitys;
using System;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 默认消息获取
    /// </summary>
    internal class DefaultMessageConsumer : IMessageConsumer<IMessageBody>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<StorageRelationship> _storageRelationshipRepository;
        private readonly IMessageStoreManager _messageStoreManager;
        private readonly IDbContext _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageRelationshipRepository">存储关系访问</param>
        /// <param name="messageStoreManager">消息存储管理器</param>
        /// <param name="unitOfWork">工作单元</param>
        public DefaultMessageConsumer(
            IRepository<StorageRelationship> storageRelationshipRepository,
            IMessageStoreManager messageStoreManager,
            IDbContext unitOfWork)
        {
            storageRelationshipRepository.CheckNullThrowArgumentNullException("storageRelationshipRepository");
            messageStoreManager.CheckNullThrowArgumentNullException("messageStoreManager");
            unitOfWork.CheckNullThrowArgumentNullException("unitOfWork");

            this._storageRelationshipRepository = storageRelationshipRepository;
            this._messageStoreManager = messageStoreManager;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取待消费的消息
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <param name="startMessageId">起始消息</param>
        /// <param name="number">每次获取多少条</param>
        /// <returns></returns>
        public MessageConsumeResult<IMessageBody> Consume(int? wid, string startMessageId, int number)
        {
            //从存储介质里获取消息集合
            var messages = this._messageStoreManager.GetMessages<IMessageBody>(wid, startMessageId, number);

            //获取当前批次的最后ID
            string lastConsumeMessageId = messages.Any() ? messages.Max(o => o.Id) : "";

            //更新存储映射(不为空或者大于0的情况下才积累消费情况)
            if (wid.HasValue && wid.Value > 0 && !lastConsumeMessageId.IsNullOrEmpty())
            {
                var storageRelationship = this._storageRelationshipRepository.Table.FirstOrDefault(o => o.WID == wid.Value);
                if (!storageRelationship.IsNull())
                {
                    storageRelationship.LastConsumeMessageId = lastConsumeMessageId;
                    storageRelationship.LastConsumeTime = DateTime.Now;
                    this._storageRelationshipRepository.Update(storageRelationship);
                    this._unitOfWork.SaveChanges();
                }
            }

            //返回领域消息对象
            return new MessageConsumeResult<IMessageBody>(messages.OrderBy(o => o.Id));
        }
    }
}