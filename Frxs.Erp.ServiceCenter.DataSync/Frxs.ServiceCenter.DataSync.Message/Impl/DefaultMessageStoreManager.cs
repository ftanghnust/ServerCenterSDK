/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/14/2016 4:43:15 PM
 * *******************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 默认的消息存储管理
    /// </summary>
    internal class DefaultMessageStoreManager : IMessageStoreManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMessageBodyFormatter _messageBodyFormatter;
        private readonly IEvenSelector _evenSelector;
        private const string SaveMessageSql = @"INSERT INTO [{0}] ([Id],[Topic],[WID],[Body],[Created]) VALUES (@p0,@p1,@p2,@p3,@p4);";
        private readonly string NewLine = Environment.NewLine;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="messageBodyFormatter">消息摘要格式化器</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="evenSelector">事件查找器</param>
        public DefaultMessageStoreManager(
            IDbContext dbContext,
            ILogger logger,
            IMessageBodyFormatter messageBodyFormatter,
            IEvenSelector evenSelector)
        {
            dbContext.CheckNullThrowArgumentNullException("dbContext");
            messageBodyFormatter.CheckNullThrowArgumentNullException("messageBodyFormatter");
            evenSelector.CheckNullThrowArgumentNullException("evenSelector");

            this._dbContext = dbContext;
            this._logger = logger ?? NullLogger.Instance;
            this._messageBodyFormatter = messageBodyFormatter;
            this._evenSelector = evenSelector;
        }

        /// <summary>
        /// 根据仓库编号获取存储介质
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns></returns>
        public string GetMessageStoreName(int? wid)
        {
            return wid.HasValue && wid.Value > 0 ? "Message_{0}".With(wid.Value) : "Message";
        }

        /// <summary>
        /// 获取全局消息存储介质名称
        /// </summary>
        /// <returns></returns>
        public string GetGlobalMessageStoreName()
        {
            return this.GetMessageStoreName(null);
        }

        /// <summary>
        /// 创建仓库所对应的存储介质
        /// </summary>
        /// <param name="wid">仓库编号</param>
        /// <returns>成功后返回存储介质名称，如果返回空或者null则代表创建失败</returns>
        public string CreateMessageStore(int wid)
        {
            try
            {
                if (wid <= 0)
                {
                    throw new ApiException("wid不能小于等于0");
                }

                //获取存储介质
                var storageName = this.GetMessageStoreName(wid);

                //存在了直接返回存储介质名称
                if (this.MessageStoreExists(wid))
                {
                    return storageName;
                }

                //不存在就创建存储介质
                using (TransactionScope scope = new TransactionScope())
                {
                    //创建仓库对应的存储介质
                    var sqlScripts = @"
                                    IF object_id('{0}') IS NULL
                                    BEGIN
                                        CREATE TABLE [{0}](
	                                    [Id] [nvarchar](50) NOT NULL,
	                                    [Topic] [nvarchar](50) NOT NULL,
	                                    [WID] [int] NOT NULL,
	                                    [Body] [nvarchar](500) NULL,
	                                    [Created] [datetime] NOT NULL,
                                        CONSTRAINT [PK_dbo.{0}] PRIMARY KEY CLUSTERED 
                                        (
	                                        [Id] ASC
                                        )
                                        WITH (PAD_INDEX  = OFF, 
                                                    STATISTICS_NORECOMPUTE  = OFF, 
                                                    IGNORE_DUP_KEY   = OFF, 
                                                    ALLOW_ROW_LOCKS  = ON, 
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] 

                                        INSERT INTO [StorageRelationship] ([WID],
                                                                           [StorageName],
                                                                           [LastConsumeMessageId],
                                                                           [LastConsumeTime]) 
                                                                           VALUES (@p0, @p1, @p2,null)

                                    END".With(storageName);

                    //批量执行
                    this._dbContext.ExecuteSqlCommand(sqlScripts, false, null,
                                                                    new object[] { wid, storageName, string.Empty });
                    //提交
                    scope.Complete();
                }

                return storageName;
            }
            catch (Exception exc)
            {
                this._logger.Error(exc);
                return null;
            }
        }

        /// <summary>
        /// 获取所有仓库配置的存储介质信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MessageStore> GetMessageStores()
        {
            var query = this._dbContext.SqlQuery<MessageStore>(@"SELECT [WID], [StorageName] FROM [StorageRelationship]");
            return query.ToList();
        }

        /// <summary>
        /// 判断仓库的存储介质是否存在
        /// </summary>
        /// <param name="wid">仓库编号，仓库编号如果是小于等于0，始终会返回true</param>
        /// <returns></returns>
        public bool MessageStoreExists(int wid)
        {
            //小于0的情况下直接返回存在，属于全局消息，一定存在
            if (wid <= 0)
            {
                return true;
            }
            return this._dbContext.SqlQuery<int>(@"SELECT COUNT(1) 
                                                   FROM [StorageRelationship] 
                                                   WHERE [WID] = @p0", new object[] { wid }).First() > 0;
        }

        /// <summary>
        /// 保存消息到存储介质，带分发功能
        /// </summary>
        /// <param name="message">对外消息消息</param>
        /// <returns></returns>
        public bool SaveMessageToStore(Message<IMessageBody> message)
        {
            //存储消息实体
            var storeMessage = new Data.Entitys.Message()
            {
                Created = message.Created,
                Id = message.Id,
                Topic = message.Topic,
                WID = message.WID,
                Body = this._messageBodyFormatter.Serialize(message.Body)
            };

            //集中sql语句
            List<string> sqlScripts = new List<string>();

            //添加到全局消息存储介质
            sqlScripts.Add(SaveMessageSql.With(this.GetGlobalMessageStoreName()));

            //如果仓库编号==0则进行分发
            if (message.WID <= 0)
            {
                foreach (var item in this.GetMessageStores())
                {
                    sqlScripts.Add(SaveMessageSql.With(item.StorageName));
                }
            }
            //单独的
            else
            {
                sqlScripts.Add(SaveMessageSql.With(this.GetMessageStoreName(message.WID)));
            }

            try
            {
                //批量执行
                this._dbContext.ExecuteSqlCommand(string.Join(this.NewLine, sqlScripts.ToArray()), false, null,
                                                                   new object[] {
                                                                               storeMessage.Id,
                                                                               storeMessage.Topic,
                                                                               storeMessage.WID,
                                                                               storeMessage.Body,
                                                                               storeMessage.Created
                                                                   });

                return true;
            }
            catch (Exception exc)
            {
                this._logger.Error(exc);
                return false;
            }
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <typeparam name="T">时间参数类型</typeparam>
        /// <param name="wid">仓库编号</param>
        /// <param name="startMessageId">起始消息编号</param>
        /// <param name="number">每次获取消息数</param>
        /// <returns></returns>
        public IEnumerable<Message<T>> GetMessages<T>(int? wid, string startMessageId, int number) where T : IMessageBody
        {
            //每次获取指定的消息数量
            string sql = "SELECT TOP({0}) * FROM [{1}] ".With(number, this.GetMessageStoreName(wid));

            //设置开始消息
            if (!startMessageId.IsNullOrEmpty())
            {
                sql = sql + " WHERE [Id] > @p0";
            }

            //按照消息编号顺序进行排序
            sql = sql + " ORDER BY [Id] ASC ";

            //返回列表
            var messages = this._dbContext.SqlQuery<Data.Entitys.Message>(sql,
                                                new object[] { startMessageId }).ToList();

            //并行进行组装
            var items = messages.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                    .Select(message => new Message<T>()
                    {
                        Created = message.Created,
                        Id = message.Id,
                        Topic = message.Topic,
                        WID = message.WID,
                        Body = (T)this._messageBodyFormatter.Deserialize(message.Body,
                                    this._evenSelector.GetEventDescriptor(message.Topic).MessageBodyType)
                    });

            //返回列表
            return items.ToList();
        }
    }
}
