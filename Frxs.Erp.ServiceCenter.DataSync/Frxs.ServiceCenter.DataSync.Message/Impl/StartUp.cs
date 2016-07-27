/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 2:15:07 PM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data.Entitys;
using System;
using System.Linq;
using System.Messaging;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 系统启动的时候做的事情
    /// </summary>
    internal class StartUp : IStartUp
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataSyncConfig _config;
        private readonly IRepository<StorageRelationship> _storageRelationshipRepository;
        private readonly IRepository<SequentialNumber> _sequentialNumberRepository;
        private readonly ILogger _logger;
        private readonly IDbContext _dbContext;
        private readonly IMessageStoreManager _messageStoreManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config">默认实现配置文件</param>
        /// <param name="storageRelationshipRepository">存储映射仓储</param>
        /// <param name="sequentialNumberRepository">序列号生成器仓储</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="dbContext">数据库上下文</param>
        /// <param name="messageStoreManager">消息存储上下文</param>
        public StartUp(
            DataSyncConfig config,
            IRepository<StorageRelationship> storageRelationshipRepository,
            IRepository<SequentialNumber> sequentialNumberRepository,
            ILogger logger,
            IDbContext dbContext,
            IMessageStoreManager messageStoreManager)
        {
            config.CheckNullThrowArgumentNullException("config");
            storageRelationshipRepository.CheckNullThrowArgumentNullException("storageRelationshipRepository");
            sequentialNumberRepository.CheckNullThrowArgumentNullException("sequentialNumberRepository");
            dbContext.CheckNullThrowArgumentNullException("dbContext");
            messageStoreManager.CheckNullThrowArgumentNullException("messageStoreManager");

            this._config = config;
            this._storageRelationshipRepository = storageRelationshipRepository;
            this._sequentialNumberRepository = sequentialNumberRepository;
            this._logger = logger ?? NullLogger.Instance;
            this._dbContext = dbContext;
            this._messageStoreManager = messageStoreManager;
        }

        /// <summary>
        /// 初始化消息队列
        /// </summary>
        private void InitMSMQ()
        {
            //安装正常消息队列
            if (!MessageQueue.Exists(this._config.MSMQPath))
            {
                MessageQueue.Create(this._config.MSMQPath);
                this._logger.Information(Resource.Resource.StartUp_CreatedMSMQ.With(this._config.MSMQPath));
            }

            //安装发送错误日志队列
            if (!MessageQueue.Exists(this._config.SendErrorMSMQPath))
            {
                MessageQueue.Create(this._config.SendErrorMSMQPath);
                this._logger.Information(Resource.Resource.StartUp_CreatedMSMQ.With(this._config.SendErrorMSMQPath));
            }
        }

        /// <summary>
        /// 初始化数据库(初始化数据库，初始化系统需要的值，需要大概几秒左右)
        /// </summary>
        private void InitDataBase()
        {
            //检测是否存在种子表数据
            var identiys = this._sequentialNumberRepository.TableNoTracking.FirstOrDefault();

            //不存在就创建，并且设置种子
            if (identiys.IsNull())
            {
                this._dbContext.AutoDetectChangesEnabled = false;
                var currentTime = DateTime.Now;
                var currentYear = currentTime.Year;
                var currentMonth = currentTime.Month;
                //If 20 years later, we still use this system, congratulations! we are very successful. good luck.
                for (int year = currentYear; year <= currentYear + 20; year++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                        {
                            if (year == currentYear && month < currentMonth)
                            {
                                continue;
                            }
                            this._sequentialNumberRepository.Insert(new SequentialNumber()
                            {
                                Year = year,
                                Month = month,
                                Day = day,
                                MaxIdentity = 0
                            });
                        }
                    }
                };
                this._dbContext.SaveChanges();
                this._dbContext.AutoDetectChangesEnabled = true;
                this._logger.Information(Resource.Resource.StartUp_CreatedDB);
            }
        }

        /// <summary>
        /// 初始化数据库表等
        /// </summary>
        public void Init()
        {
            //初始化数据库
            this.InitDataBase();

            //初始化消息队列
            this.InitMSMQ();

            //防止消息长期没有被清理，每次启动站点的时候，自动执行下清理作业任务
            new ClearExpiredMessageTask(this._messageStoreManager,
                                        this._dbContext,
                                        this._logger,
                                        this._config).Execute(null);
        }
    }
}