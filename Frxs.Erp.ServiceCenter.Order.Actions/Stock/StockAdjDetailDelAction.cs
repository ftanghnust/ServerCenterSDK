/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 19:34:11
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
    /// 盘点调整明细表 删除操作
    /// </summary>
    [ActionName("StockAdjDetail.Del")]
    public class StockAdjDetailDelAction : ActionBase<StockAdjDetailDelAction.StockAdjDetailDelActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDetailDelActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要删除的ID序列
            /// </summary>            
            public List<string> Ids { get; set; }

            /// <summary>
            /// 盘点调整，如果传入该参数，则会删除该单号下所有的明细表和扩展表
            /// </summary>
            public string AdjID { get; set; }
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
        public class StockAdjDetailDelActionResponseDto
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
            //若单据号不为空，则清空数据
            if (!string.IsNullOrEmpty(this.RequestDto.AdjID))
            {
                var currentMainModel = StockAdjBLO.GetModel(RequestDto.AdjID, warehouseId);
                //删除详情表和扩展表之前，盘点主表记录要是“录单”状态，否则不能删除，若主表记录不存在，则也允许删除详情表和扩展表
                if (currentMainModel.Status != 0)
                {
                    msg += string.Format(" 单号[{0}]的盘点调整主表记录不是“录单”状态,不能删除详情信息！ <br />", RequestDto.AdjID);
                }
                row = StockAdjDetailBLO.DeleteInfoByAdjID(RequestDto.AdjID, warehouseId);
            }
            else if (this.RequestDto.Ids.Count > 0)
            {
                foreach (var id in this.RequestDto.Ids)
                {
                    var currentDetailModel = StockAdjDetailBLO.GetModel(id, warehouseId);
                    if (currentDetailModel != null)
                    {
                        string adjId = currentDetailModel.AdjID;
                        var currentMainModel = StockAdjBLO.GetModel(adjId, warehouseId);
                        //删除详情表和扩展表之前，盘点主表记录要是“录单”状态，否则不能删除，若主表记录不存在，则也允许删除详情表和扩展表
                        if (currentMainModel.Status != 0)
                        {
                            msg += string.Format(" 单号[{0}]的盘点调整主表记录不是“录单”状态,不能删除详情信息！ <br />", adjId);
                        }
                    }
                    row += StockAdjDetailBLO.DeleteInfo(id, warehouseId);
                }
                if (row < RequestDto.Ids.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", row, RequestDto.Ids.Count - row, msg), row);
                }
            }
            return this.SuccessActionResult(string.Format("操作完成！ 删除了{0}条记录。", row) + msg, row);
        }
    }
}
