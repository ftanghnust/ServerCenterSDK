/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 20:14:28
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

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整主表(盘亏盘盈表) 删除
    /// </summary>
    [ActionName("StockAdj.Del")]
    public class StockAdjDelAction : ActionBase<StockAdjDelAction.StockAdjDelActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDelActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要删除的AdjID序列
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> AdjIDs { get; set; }
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
        public class StockAdjDelActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (this.RequestDto == null)
            {
                return this.ErrorActionResult("上传的参数错误!");
            }
            string warehouseId = RequestDto.WarehouseId.ToString();
            int row = 0;
            string msg = string.Empty;
            if (this.RequestDto.AdjIDs.Count > 0)
            {
                foreach (var adjIDItem in this.RequestDto.AdjIDs)
                {
                    var currentModel = StockAdjBLO.GetModel(adjIDItem, warehouseId);
                    //只有主表记录处于录单状态才能删除
                    if (currentModel != null && currentModel.Status == 0)
                    {
                        row += StockAdjBLO.DeleteInfo(adjIDItem, warehouseId);
                    }
                    else
                    {
                        msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能删除！ <br />", adjIDItem);
                    }
                }
            }
            return this.SuccessActionResult(string.Format("操作完成！ 删除了{0}条记录。", row) + msg, row);
        }
    }
}
