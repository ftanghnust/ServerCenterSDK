/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 18:31:03
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 积分促销/平台费率调整 获取单条记录详情
    /// </summary>
    [ActionName("WProduct.Promotion.Get")]
    public class WProductPromotionGetAction : ActionBase<WProductPromotionGetAction.WProductPromotionGetActionRequestDto, WProductPromotionInfo>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionGetActionRequestDto : RequestDtoParent //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int? PromotionType { get; set; }
            /// <summary>
            /// 促销ID 主键ID(WID+ID服务表)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string PromotionID { get; set; }

            
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
        public class WProductPromotionGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductPromotionInfo> Execute()
        {
            if (this.RequestDto != null && !string.IsNullOrWhiteSpace(this.RequestDto.PromotionID))
            {
                string noSaleID = this.RequestDto.PromotionID.Trim();
                if (this.RequestDto.WarehouseId <= 0)
                {
                    return this.ErrorActionResult("仓库ID不正确");
                }
                WProductPromotionInfo model = WProductPromotionBLO.GetModelInfo(this.RequestDto.PromotionID, this.RequestDto.WarehouseId.ToString());
                return this.SuccessActionResult(model);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确!");
            }
        }

    }
}
