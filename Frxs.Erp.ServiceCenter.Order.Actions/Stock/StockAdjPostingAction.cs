/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/18 9:58:50
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 过账 操作
    /// </summary>
    [ActionName("StockAdj.Posting")]
    public class StockAdjPostingAction : ActionBase<StockAdjPostingAction.StockAdjPostingActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjPostingActionRequestDto : RequestDtoParent //RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
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
        public class StockAdjPostingActionResponseDto
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
            if (this.RequestDto != null && RequestDto.IdList != null && RequestDto.IdList.Count > 0)
            {
                string warehouseId = RequestDto.WarehouseId.ToString();
                foreach (var adjId in RequestDto.IdList)
                {
                    var model = StockAdjBLO.GetModel(adjId, warehouseId);
                    //过账之前要先确认该记录是处于“已提交”状态，否则不能操作
                    if (model == null || model.Status != 1)
                    {
                        msg += string.Format(" 单号[{0}]的记录不是“已提交”状态,不能过账！ <br />", adjId);
                    }
                    else
                    {
                        result += StockAdjBLO.UpdateStatus(adjId, StockAdjBLO.StockAdjStatus.Posted, RequestDto.UserId, RequestDto.UserName, warehouseId, ref message);
                        if (!string.IsNullOrEmpty(message))
                        {
                            //return ErrorActionResult("出现错误,操作终止: " + message + string.Format(" 修改了{0}条记录 ", result));//2016-5-9 咨询胡总，需求可能要批量操作
                            msg += string.Format(" {0} <br />", message);
                        }
                    }
                }
                if (result < RequestDto.IdList.Count)
                {//批量操作时认为只有所有的记录都成功才是完全成功了。
                    if (result == 0)
                    {//一条都未成功则返回简单提示
                        return ErrorActionResult(string.Format("操作失败! <br />{0}", msg), result);
                    }
                    return ErrorActionResult(string.Format("操作完成！{0}条操作成功,{1}条操作失败!<br />{2}", result, RequestDto.IdList.Count - result, msg), result);
                }
                return SuccessActionResult(string.Format("操作完成，修改了{0}条记录 ", result) + msg, result);
            }
            else
            {
                return ErrorActionResult("上送的参数不正确！", result);
            }
        }
    }
}
