using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/22 14:27:38
 * *******************************************************/
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 将所有的促销信息自动确认，先从基础数据库获取到仓库信息，然后依次调用确认
    /// </summary>
    [ActionName("Job.WProductPromotion.Posting")]
    public class JobWProductPromotionPostingAction : ActionBase<JobWProductPromotionPostingAction.JobWProductPromotionPostingActionRequestDto, int>
    {

        /// <summary>
        /// 
        /// </summary>
        public class JobWProductPromotionPostingActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            [In(1, 2)]
            public int PromotionType { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //先获取到基础库的仓库信息
            var warehouseListResp = WorkContext.GetErpProductSDKClient().Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWarehouseTableListRequest()
            {
                ParentWID = 0,
                PageIndex = 1,
                PageSize = int.MaxValue
            });

            //返回数据失败
            if (warehouseListResp.IsNull())
            {
                return this.ErrorActionResult("获取仓库基础数据失败");
            }

            //结果
            int result = 0;

            //循环确认仓库促销
            foreach (var warehouse in warehouseListResp.Data.ItemList)
            {
                try
                {
                    result += DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouse.WID.ToString()).TimerWProductPromotionPosting(this.RequestDto.PromotionType, -1, "system");
                }
                catch { }
            }

            //返回数据
            return this.SuccessActionResult(result);
        }
    }
}
