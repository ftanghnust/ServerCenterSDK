/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/18 8:55:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 确认/反确认 操作
    /// </summary>
    [ActionName("StockAdj.Confirm")]
    public class StockAdjConfirmAction : ActionBase<StockAdjConfirmAction.StockAdjConfirmActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjConfirmActionRequestDto : RequestDtoParent  //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要操作的ID序列
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> IdList { get; set; }

            /// <summary>
            /// 操作标志 0 :未提交/反确认 1:已提交/确认
            /// </summary>
            public int Flag { get; set; }
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
        public class StockAdjConfirmActionResponseDto
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
            string message = string.Empty;
            if (this.RequestDto != null && this.RequestDto.IdList != null && this.RequestDto.IdList.Count > 0)
            {
                string warehouseId = RequestDto.WarehouseId.ToString();

                foreach (var adjId in this.RequestDto.IdList)
                {
                    var model = StockAdjBLO.GetModel(adjId, warehouseId);
                    if (RequestDto.Flag == 0)
                    {
                        //反确认 必须先判断 当前记录状态是 “已提交” 才能操作
                        if (model == null || model.Status != 1)
                        {
                            msg += string.Format(" 单号[{0}]的记录不是“确认”状态,不能反确认！ <br />", adjId);
                        }
                        else
                        {
                            result += StockAdjBLO.UpdateStatus(adjId, StockAdjBLO.StockAdjStatus.Uncommitted, RequestDto.UserId, RequestDto.UserName, warehouseId, ref message);
                        }
                    }
                    else
                    {
                        int detailCount = StockAdjBLO.GetDetailCount(adjId, warehouseId);
                        //必须先判断 当前记录状态是 “未提交” 才能操作
                        if (model == null || model.Status != 0)
                        {
                            msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能确认！ <br />", adjId);
                        }
                        else if (detailCount == 0)
                        {
                            msg += string.Format(" 单号[{0}]的记录没有明细,不能确认！ <br />", adjId);
                        }
                        else
                        {
                            #region 尝试获取盘亏单的明细异常信息(库存不足)
                            string lackInfo = string.Empty;
                            if (model.AdjType == 1)
                            { //盘亏单确认时预先判断明细中是否有异常：当前实时库少于库存调整数量存造成不能正常过账的数据
                                IList<StockAdjDif> adjDifList = StockAdjBLO.GetAdjQtysCheck(adjId, warehouseId, model.SubWID);
                                if (adjDifList != null && adjDifList.Count > 0)
                                {
                                    foreach (var item in adjDifList)
                                    {
                                        lackInfo += string.Format("商品[{0}]实时库存比调整数量少[{1}]个<br />", item.SKU, item.Dif);
                                    }
                                }
                            }
                            #endregion
                            if (!string.IsNullOrEmpty(lackInfo))
                            {
                                msg += string.Format(" 单号[{0}]的明细可能有异常,请检查！ <br />{1}", adjId, lackInfo);
                            }
                            else //2016-6-23 需求确认后，对比实时库存后拦截有异常的记录，防止录单人员进行反复繁琐的确认和反确认操作
                            {
                                result += StockAdjBLO.UpdateStatus(adjId, StockAdjBLO.StockAdjStatus.Submitted, RequestDto.UserId, RequestDto.UserName, warehouseId, ref message);
                            }
                        }
                    }
                }
                if (result < RequestDto.IdList.Count)
                {
                    if (result == 0)
                    {//一条都未成功则返回简单提示
                        return ErrorActionResult(string.Format("操作失败!<br />{0}", msg), result);
                    }
                    return ErrorActionResult(string.Format("操作完成！{0}条操作成功,{1}条操作失败!<br />{2}", result, RequestDto.IdList.Count - result, msg), result);
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    msg = string.Format("<br />有如下信息请注意:<br />{0}", msg);
                }
                return this.SuccessActionResult(string.Format("操作完成，修改了{0}条记录。{1}", result, msg), result);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确！", result);
            }
        }
    }
}
