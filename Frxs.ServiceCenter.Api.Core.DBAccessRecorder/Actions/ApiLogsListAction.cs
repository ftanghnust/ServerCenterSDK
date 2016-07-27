/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/28 13:18:30
 * *******************************************************/

using System.Linq;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// 日志访问插件
    /// </summary>
    [ActionName("API.Logs.List")]
    [EnableRecordApiLog(false), DisablePackageSdk, AllowAnonymous, DisableDataSignatureTransmission , ActionResultCache(1)]
    public class ApiLogsAction : ActionBase<ApiLogsAction.ApiLogsActionRequestDto, PagedList<Domain.AccessRecorder>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ApiLogsActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 接口名称
            /// </summary>
            public string ApiName { get; set; }

            /// <summary>
            /// IP地址，方便筛选客户端访问
            /// </summary>
            public string Ip { get; set; }

            /// <summary>
            /// 使用时间（毫秒）
            /// </summary>
            public int? UsedTime { get; set; }

            /// <summary>
            /// 总记录数
            /// </summary>
            public int? TotalCount { get; set; }

            /// <summary>
            /// 修改下上送参数
            /// </summary>
            public override void BeforeValid()
            {
                if (this.PageIndex <= 0) this.PageIndex = 1;
                if (this.PageSize <= 0) this.PageSize = 50;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Domain.AccessRecorder> _accessRecorderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessRecorderRepository"></param>
        public ApiLogsAction(IRepository<Domain.AccessRecorder> accessRecorderRepository)
        {
            this._accessRecorderRepository = accessRecorderRepository;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PagedList<Domain.AccessRecorder>> Execute()
        {
            //查询表
            var query = this._accessRecorderRepository.TableNoTracking;

            //指定了接口名称
            if (!this.RequestDto.ApiName.IsNullOrEmpty())
            {
                query = query.Where(o => o.ApiName == this.RequestDto.ApiName);
            }

            //查询IP
            if (!this.RequestDto.Ip.IsNullOrEmpty())
            {
                query = query.Where(o => o.Ip == this.RequestDto.Ip);
            }

            //毫秒数
            if (this.RequestDto.UsedTime.HasValue && this.RequestDto.UsedTime > 0)
            {
                query = query.Where(o => o.UsedTime >= this.RequestDto.UsedTime);
            }

            //排序
            query = query.OrderByDescending(o => o.Id);

            //返回分页集合对象
            var pagedList = new PagedList<Domain.AccessRecorder>(query, this.RequestDto.PageIndex - 1, this.RequestDto.PageSize, this.RequestDto.TotalCount);

            //返回查询集合
            return this.SuccessActionResult(pagedList);
        }
    }
}
