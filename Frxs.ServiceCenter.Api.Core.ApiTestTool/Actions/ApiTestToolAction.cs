/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/6 8:37:50
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.ApiTestTool.Actions
{
    /// <summary>
    /// 调试接口工具接口插件
    /// </summary>
    [ActionName("API.TestTool")]
    [DisablePackageSdk, EnableRecordApiLog(false), DisableDataSignatureTransmission]
    public class ApiTestToolAction : ActionBase<ApiTestToolAction.ApiTestToolActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ApiTestToolActionRequestDto : RequestDtoBase
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
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            return this.SuccessActionResult();
        }
    }
}
