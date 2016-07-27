/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 16:13:13
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 促销门店删除接口
    /// </summary>
    [ActionName("WProduct.Promotion.Del")]
    public class WProductPromotionDelAction : ActionBase<WProductPromotionDelAction.WProductPromotionDelActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionDelActionRequestDto : RequestDtoParent// RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int? PromotionType { get; set; }
            /// <summary>
            /// 要删除的ID序列
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> IdList { get; set; }
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
        public class WProductPromotionDelActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            int result = 0;
            string msg = string.Empty;
            string warehouseId = RequestDto.WarehouseId.ToString();
            if (this.RequestDto != null && this.RequestDto.IdList.Count > 0)
            {
                //删除 之前要检验，确保要操作的记录是 0 录单，否则不删除    状态(0:录单;1:已确认;2:已生效;3:已停用)
                foreach (var promotionID in this.RequestDto.IdList)
                {
                    var model = WProductPromotionBLO.GetModel(promotionID, warehouseId);
                    if (model == null || model.Status != 0)
                    {
                        msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能删除！<br /> ", promotionID);
                    }
                    else
                    {
                        result += WProductPromotionBLO.DeleteInfo(promotionID, warehouseId);
                    }
                }
                if (result < RequestDto.IdList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成! 删除了{0}条记录,{1}条记录删除失败,<br />原因：<br />{2}", result, RequestDto.IdList.Count - result, msg), result);
                }
                return SuccessActionResult(string.Format("操作完成! 删除了{0}条记录", result) + msg, result);
            }
            else
            {
                return ErrorActionResult("上送的参数不正确！", result);
            }
        }

    }
}
