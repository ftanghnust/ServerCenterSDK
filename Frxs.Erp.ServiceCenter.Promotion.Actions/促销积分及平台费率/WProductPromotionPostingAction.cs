/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 16:17:54
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
    /// 促销门店 生效操作
    /// </summary>
    [ActionName("WProduct.Promotion.Posting")]
    public class WProductPromotionPostingAction : ActionBase<WProductPromotionPostingAction.WProductPromotionPostingActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionPostingActionRequestDto : RequestDtoParent //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int? PromotionType { get; set; }
            /// <summary>
            /// 要生效的PromotionID序列
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
        public class WProductPromotionPostingActionResponseDto
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
            if (this.RequestDto != null && this.RequestDto.IdList != null && this.RequestDto.IdList.Count > 0)
            {
                string warehouseId = RequestDto.WarehouseId.ToString();
                //过账/生效 之前要检验，确保要操作的记录是 1（已确认），否则在列表中移除该行    状态(0:录单;1:已确认;2:已生效;3:已停用)
                List<string> promotionIDList = this.RequestDto.IdList;
                List<string> ids2Operate = new List<string>(promotionIDList.ToArray());//要操作的符号条件的集合，此集合必须是深复制的副本
                foreach (var promotionID in promotionIDList)
                {
                    //当用foreach遍历Collection时，如果对Collection有Add或者Remove操作或者给item某个属性赋值都会导致错误。
                    //因为Collection返回的IEnumerator把当前的属性暴露为只读属性，直接对其的修改会导致运行时错误。
                    var model = WProductPromotionBLO.GetModel(promotionID, warehouseId);
                    if (model == null || model.Status != 1)
                    {
                        ids2Operate.Remove(promotionID);//在此不能直接操作promotionIDList，所以操作ids2Operate
                        msg += string.Format(" 单号[{0}]的记录不是“确认”状态,不能生效！<br />", promotionID);
                    }
                }
                if (ids2Operate.Count > 0)
                {
                    result = WProductPromotionBLO.UpdateStatus(ids2Operate, WProductPromotionBLO.PromotionStatus.Posted, RequestDto.UserId, RequestDto.UserName, warehouseId);
                }
                if (result < promotionIDList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", result, promotionIDList.Count - result, msg), result);
                }
                return SuccessActionResult("操作完成! " + msg, result);//认为只有所有的记录都成功才是真的成功了。
            }
            else
            {
                return ErrorActionResult("上送的参数不正确！", result);
            }
        }

    }
}
