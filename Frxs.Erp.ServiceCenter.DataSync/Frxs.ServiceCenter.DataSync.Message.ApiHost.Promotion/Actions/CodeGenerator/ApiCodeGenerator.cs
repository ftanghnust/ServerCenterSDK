/***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 1:14:35 PM (4.0.30319.42000)
 * *************************************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Actions
{
    /// <summary>
    /// 接口层代码生成器(此接口为当前项目接口层代码生成器)
    /// </summary>
    [DisablePackageSdk]
    public class ApiCodeGeneratorAction : ActionBase<ApiCodeGeneratorAction.ActionApiCodeGeneratorActionRequestDto, IDbContext>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ActionApiCodeGeneratorActionRequestDto : SystemRequestDtoBase
        {
            /// <summary>
            /// 模型名称
            /// </summary>
            public string ModelName { get; set; }

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
        /// 
        /// </summary>
        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="dbContext">数据操作上下文</param>
        public ApiCodeGeneratorAction(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IDbContext> Execute()
        {
            return this.SuccessActionResult(this._dbContext);
        }
    }
}
