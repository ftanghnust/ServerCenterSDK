/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/8 16:16:42
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
using Frxs.Erp.ServiceCenter.Promotion.Model;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 促销 确认/反确认 操作
    /// </summary>
    [ActionName("WProduct.Promotion.Confirm")]
    public class WProductPromotionConfirmAction : ActionBase<WProductPromotionConfirmAction.WProductPromotionConfirmActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductPromotionConfirmActionRequestDto : RequestDtoParent //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 促销类型(1:门店积分促销;2:平台费率促销)
            /// </summary>
            public int PromotionType { get; set; }

            /// <summary>
            /// 0表示录单状态 1表示确认
            /// </summary>
            public int Flag { get; set; }
            /// <summary>
            /// 要操作的ID序列
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
        public class WProductPromotionConfirmActionResponseDto
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
                List<string> promotionIDList = this.RequestDto.IdList;
                List<string> ids2Operate = new List<string>(promotionIDList.ToArray());//要操作的符号条件的集合，此集合必须是深复制的副本
                if (RequestDto.Flag == 0)
                {//反确认 确定要是 确认状态 的才能 反确认操作 确保要操作的记录是 1（已确认），否则在列表中移除该行    状态(0:录单;1:已确认;2:已生效;3:已停用)
                    foreach (var promotionID in promotionIDList)
                    {
                        var model = WProductPromotionBLO.GetModel(promotionID, warehouseId);
                        if (model == null || model.Status != 1)
                        {
                            ids2Operate.Remove(promotionID);
                            msg += string.Format(" 单号[{0}]的记录不是“确认”状态,不能反确认！ <br />", promotionID);
                        }
                    }
                    if (ids2Operate.Count > 0)
                    {
                        result = WProductPromotionBLO.UpdateStatus(promotionIDList, WProductPromotionBLO.PromotionStatus.Uncommitted, RequestDto.UserId, RequestDto.UserName, warehouseId);
                    }

                }
                else
                {
                    foreach (var promotionID in RequestDto.IdList)
                    {
                        #region 互斥判断 有任何一条记录已经存在则不执行操作
                        RepeatPromotionInfo existInfo = WProductPromotionBLO.GetRepeatInfo(warehouseId, RequestDto.PromotionType, promotionID, RequestDto.WarehouseId);
                        if (existInfo != null && existInfo.Exist == true)
                        {
                            string errInfo = string.Format("重复操作：存在已经“确认/生效”的记录:单号[{0}];商品编码[{1}];门店编号[{2}];", existInfo.PromotionID, existInfo.Sku, existInfo.ShopCode);
                            return this.ErrorActionResult(errInfo, result);
                        }
                        #endregion

                        #region 确保要操作的记录是 0（录单），否则在列表中移除该行    //状态(0:录单;1:已确认;2:已生效;3:已停用)
                        var model = WProductPromotionBLO.GetModel(promotionID, warehouseId);
                        if (model == null || model.Status != 0)
                        {
                            ids2Operate.Remove(promotionID);
                            msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能确认！ <br />", promotionID);
                        }
                        #endregion
                    }
                    if (ids2Operate.Count > 0)
                    {
                        result = WProductPromotionBLO.UpdateStatus(promotionIDList, WProductPromotionBLO.PromotionStatus.Submitted, RequestDto.UserId, RequestDto.UserName, warehouseId);
                    }
                }
                if (result < promotionIDList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", result, promotionIDList.Count - result, msg), result);
                }
                return this.SuccessActionResult("操作完成! " + msg, result);//认为只有所有的记录都成功才是真的成功了。
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确！", result);
            }
        }
    }
}
