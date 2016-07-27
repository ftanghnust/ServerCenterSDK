/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/31 15:50:29
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 商品限购 确认操作 返回影响的行数
    /// </summary>
    [ActionName("WProduct.NoSale.Confirm")]
    public class WProductNoSaleConfirmAction : ActionBase<WProductNoSaleConfirmAction.WProductNoSaleConfirmActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleConfirmActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要确认的ID序列           
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> IdList { get; set; }

            /// <summary>
            /// 标记 1表示确认 0表示反确认
            /// </summary>
            public int Flag { get; set; }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class WProductNoSaleConfirmActionResponseDto
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
                List<string> noSaleIDList = this.RequestDto.IdList;
                List<string> ids2Operate = new List<string>(noSaleIDList.ToArray());//要操作的符号条件的集合，此集合必须是深复制的副本
                if (RequestDto.Flag == 0)
                {
                    //反确认 之前要检验，确保要操作的记录是 1（已确认），否则在列表中移除该行 使其不参与该操作   状态(0:录单;1:已确认;2:已生效;3:已停用)
                    foreach (var noSaleID in noSaleIDList)
                    {
                        var model = WProductNoSaleBLO.GetModel(noSaleID);
                        if (model == null || model.Status != 1)
                        {
                            ids2Operate.Remove(noSaleID);
                            msg += string.Format(" 单号[{0}]的记录不是“确认”状态,不能反确认！ <br />", noSaleID);
                        }
                    }
                    if (ids2Operate.Count > 0)
                    {
                        result = WProductNoSaleBLO.UpdateStatus(ids2Operate, WProductNoSaleBLO.NoSaleStatus.Uncommitted, RequestDto.UserId, RequestDto.UserName);
                    }
                }
                else
                {
                    //确认 之前要检验，确保要操作的记录是 0（已确认），否则在列表中移除该行，使其不参与该操作    状态(0:录单;1:已确认;2:已生效;3:已停用)
                    foreach (var noSaleID in noSaleIDList)
                    {
                        var model = WProductNoSaleBLO.GetModel(noSaleID);
                        if (model == null || model.Status != 0)
                        {
                            ids2Operate.Remove(noSaleID);
                            msg += string.Format(" 单号[{0}]的记录不是“录单”状态,不能确认！ <br />", noSaleID);
                        }
                    }
                    if (ids2Operate.Count > 0)
                    {
                        result = WProductNoSaleBLO.UpdateStatus(ids2Operate, WProductNoSaleBLO.NoSaleStatus.Submitted, RequestDto.UserId, RequestDto.UserName);
                    }
                }
                if (result < noSaleIDList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", result, noSaleIDList.Count - result, msg), result);
                }
                return SuccessActionResult("操作完成! " + msg, result);
            }
            else
            {
                return ErrorActionResult("上送的参数不正确！", result);
            }
        }
    }
}
