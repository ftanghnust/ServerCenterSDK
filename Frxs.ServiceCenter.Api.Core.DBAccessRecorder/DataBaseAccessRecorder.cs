/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/21 17:22:38
 * *******************************************************/
using System;
using System.Linq;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// 将访问记录记录到数据库;方便管理统计接口访问量
    /// </summary>
    public class DataBaseAccessRecorder : IApiAccessRecorder
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Domain.AccessRecorder> _accessRecorderRepository;
        private readonly IRepository<Domain.ActionDescriptor> _actionDescriptorRepository;
        private readonly IRepository<Domain.Response> _responseRepository;
        private readonly IDataBaseAccessRecorderConfig _config;

        /// <summary>
        /// 将访问记录记录到数据库;方便管理统计接口访问量
        /// </summary>
        /// <param name="accessRecorderRepository"></param>
        /// <param name="actionDescriptorRepository"></param>
        /// <param name="responseRepository"></param>
        /// <param name="config"></param>
        public DataBaseAccessRecorder(
            IRepository<Domain.AccessRecorder> accessRecorderRepository,
            IRepository<Domain.ActionDescriptor> actionDescriptorRepository,
            IRepository<Domain.Response> responseRepository,
            IDataBaseAccessRecorderConfig config)
        {
            this.Logger = NullLogger.Instance;
            this._accessRecorderRepository = accessRecorderRepository;
            this._actionDescriptorRepository = actionDescriptorRepository;
            this._responseRepository = responseRepository;
            this._config = config;
        }

        /// <summary>
        /// 实现API记录器
        /// 方法里尽量做到快速的记录，不要进行大的操作，从而影响到API整体框架的性能
        /// </summary>
        /// <param name="args"></param>
        public void Record(ApiAccessRecorderArgs args)
        {
            //设置为不记录日志
            if (!this._config.IsNull() && !this._config.EnableAccessRecorder)
            {
                return;
            }

            try
            {
                //构造日志记录对象
                var entity = new Domain.AccessRecorder()
                {
                    ApiName = args.ActionDescriptor.ActionName,
                    Created = DateTime.Now,
                    ResponseFormat = args.ResponseFormat,
                    Ip = args.Ip,
                    Sign = args.RequestParams.Sign,
                    TimeStamp = args.RequestParams.TimeStamp,
                    StartTime = args.RequestStartTime,
                    EndTime = args.RequestEndTime,
                    RequestData = string.Empty,
                    UsedTime = double.Parse(args.RequestUsedTotalMilliseconds.ToString("0.00")),
                    HttpMethod = args.HttpMethod,
                    Author = args.ActionDescriptor.AuthorName,
                    Version = args.ActionDescriptor.Version,
                    UserId = args.UserId,
                    UserName = args.UserName ?? string.Empty
                };

                //记录日志
                this._accessRecorderRepository.Insert(entity);

                //详情
                this._responseRepository.Insert(new Domain.Response()
                {
                    Id = entity.Id,
                    RequestData = args.RequestData,
                    ResponseData = args.ResponseData
                });

                //查询是否存在API记录信息
                var apiDescriptor = this._actionDescriptorRepository.Table.FirstOrDefault(o => o.ActionName == args.ActionDescriptor.ActionName);

                //新增接口访问
                if (apiDescriptor.IsNull())
                {
                    this._actionDescriptorRepository.Insert(new Domain.ActionDescriptor()
                    {
                        ActionName = args.ActionDescriptor.ActionName,
                        AuthorName = args.ActionDescriptor.AuthorName,
                        Description = args.ActionDescriptor.Description,
                        HttpMethod = args.ActionDescriptor.HttpMethod.ToString(),
                        IsObsolete = args.ActionDescriptor.IsObsolete,
                        IsRequireHttps = args.ActionDescriptor.RequireHttps,
                        RequiredUserIdAndUserName = args.ActionDescriptor.RequiredUserIdAndUserName,
                        Version = args.ActionDescriptor.Version,
                        AccessCount = 1,
                        LastAccessTime = DateTime.Now //null
                    });
                }
                //已经存在了就修改访问记录数（新增记录数）
                else
                {
                    apiDescriptor.AccessCount++;
                    apiDescriptor.LastAccessTime = DateTime.Now;
                    this._actionDescriptorRepository.Update(apiDescriptor);
                }
            }
            catch (Exception ex)
            {
                //将错误记录到日志
                this.Logger.Error(ex);
            }
        }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority
        {
            get { return 0; }
        }
    }
}
