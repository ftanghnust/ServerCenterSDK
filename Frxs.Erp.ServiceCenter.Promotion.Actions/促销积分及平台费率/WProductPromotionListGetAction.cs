/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/6 16:39:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 积分促销及平台费率调整单 列表查询
    /// </summary>
    [ActionName("WProduct.Promotion.List.Get")]
    public class WProductPromotionListGetAction : ActionBase<WProductPromotionListGetAction.WProductPromotionListGetActionRequestDto, ActionResultPagerData<WProductPromotion>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionListGetActionRequestDto : PageListRequestDto  //(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int PromotionType { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// ERP编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 状态(0:录单;1:已确认;2:已生效;3:已停用)
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 商品条码
            /// </summary>
            public string BarCode { get; set; }

            /// <summary>
            /// 促销单号 主键ID(WID+ID服务表)
            /// </summary>

            public string PromotionID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            [Required(ErrorMessage = "仓库ID{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 活动主题
            /// </summary>
            public string PromotionName { get; set; }

            /// <summary>
            /// 生效时间 开始时间点(yyyy-MM-dd HH:mm:ss)
            /// </summary>          
            public DateTime? BeginTimeFrom { get; set; }


            /// <summary>
            /// 生效时间 截至时间点(yyyy-MM-dd HH:mm:ss)
            /// </summary>          
            public DateTime? BeginTimeEnd { get; set; }

            
            /// <summary>
            /// 校验上送参数是否正确
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
        public class WProductPromotionListGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductPromotion>> Execute()
        {
            
            var requestDto = this.RequestDto;
            if (this.RequestDto == null)
            {
                return ErrorActionResult("上传的参数不对!");
            }

            string wid = requestDto.WID.ToString();
            PageListBySql<Model.WProductPromotion> page = new PageListBySql<Model.WProductPromotion>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WProductPromotion> models = WProductPromotionBLO.GetPageList(page, requestDtoDict, wid);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WProductPromotion>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
