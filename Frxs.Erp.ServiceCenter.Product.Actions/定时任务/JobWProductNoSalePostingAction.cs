using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/10 16:13:47
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("Job.WProductNoSale.Posting")]
    public class JobWProductNoSalePostingAction : ActionBase<JobWProductNoSalePostingAction.JobWProductNoSalePostingActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class JobWProductNoSalePostingActionRequestDto : RequestDtoBase
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
        public override ActionResult<int> Execute()
        {
            int result = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().JobPosting(-1, "system");
            return this.SuccessActionResult(result);
        }

    }
}
