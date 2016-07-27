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
    [ActionName("API.Logs.Get")]
    [EnableRecordApiLog(false), DisablePackageSdk, AllowAnonymous, DisableDataSignatureTransmission]
    public class ApiLogGetAction : ActionBase<ApiLogGetAction.ApiLogGetActionRequestDto, ApiLogGetAction.ApiLogGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ApiLogGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 访问日志编号
            /// </summary>
            public int Id { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ApiLogGetActionResponseDto
        {
            /// <summary>
            /// 
            /// </summary>
            public Domain.AccessRecorder AccessRecorder { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Domain.Response ResponseData { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Domain.AccessRecorder> _accessRecorderRepository;
        private readonly IRepository<Domain.Response> _responseRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessRecorderRepository"></param>
        /// <param name="responseRepository"></param>
        public ApiLogGetAction(
            IRepository<Domain.AccessRecorder> accessRecorderRepository,
            IRepository<Domain.Response> responseRepository)
        {
            this._accessRecorderRepository = accessRecorderRepository;
            this._responseRepository = responseRepository;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ApiLogGetAction.ApiLogGetActionResponseDto> Execute()
        {

            //var q = from item in this._accessRecorderRepository.Table
            //        join item1 in this._actionDescriptorRepository.Table
            //        on item.ApiName equals item1.ActionName
            //        join item2 in this._responseRepository.Table
            //        on item.Id equals item2.Id where  (item2.Id == 12 && item.ApiName.StartsWith("s"))
            //        select item.ApiName;

            return this.SuccessActionResult(new ApiLogGetActionResponseDto()
            {
                //访问记录
                AccessRecorder = this._accessRecorderRepository.TableNoTracking.FirstOrDefault(o => o.Id == this.RequestDto.Id),
                //输出详情
                ResponseData = this._responseRepository.TableNoTracking.FirstOrDefault(o => o.Id == this.RequestDto.Id)
            });
        }
    }
}
