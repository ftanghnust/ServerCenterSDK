/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/26 10:48:19
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core.Actions
{
    /// <summary>
    /// 框架系统首页
    /// </summary>
    [ActionName("Api.Index"), DisablePackageSdk, AllowAnonymous, DisableDataSignatureTransmission, EnableRecordApiLog(false)]
    public class IndexAction : ActionBase<IndexAction.IndexActionRequestDto, IndexAction.IndexActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class IndexActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class IndexActionResponseDto
        {
            /// <summary>
            /// 接口插件
            /// </summary>
            public IEnumerable<IApiPluginDescriptor> ApiPluginDescriptors { get; set; }
            /// <summary>
            /// 接口描述对象
            /// </summary>
            public IEnumerable<ActionDescriptor> ActionDescriptors { get; set; }
        }

        /// <summary>
        /// 接口查找器
        /// </summary>
        private readonly IActionSelector _actionSelector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionSelector">接口查找器</param>
        public IndexAction(IActionSelector actionSelector)
        {
            this._actionSelector = actionSelector;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IndexActionResponseDto> Execute()
        {
            var resp = new IndexActionResponseDto
            {
                ApiPluginDescriptors = ApiPluginManager.GetApiPlugins().OrderBy(o => o.DisplayName),
                ActionDescriptors = this._actionSelector.GetActionDescriptors().Where(o => o.CanPackageToSdk).OrderBy(o => o.ActionName)
            };
            return this.SuccessActionResult(resp);
        }
    }
}
