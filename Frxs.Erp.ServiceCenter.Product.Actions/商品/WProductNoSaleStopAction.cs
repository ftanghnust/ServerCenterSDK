/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/1 16:02:47
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
    /// 商品限购 停用 返回影响的行数
    /// </summary>
    [ActionName("WProduct.NoSale.Stop")]
    public class WProductNoSaleStopAction : ActionBase<WProductNoSaleStopAction.WProductNoSaleStopActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductNoSaleStopActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 要停用的ID序列
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public List<string> IdList { get; set; }
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
                //停用 之前要检验，确保要操作的记录是 2（已生效），否则在列表中移除该行 使其不参与该操作    状态(0:录单;1:已确认;2:已生效;3:已停用)
                List<string> noSaleIDList = this.RequestDto.IdList;
                List<string> ids2Operate = new List<string>(noSaleIDList.ToArray());//要操作的符号条件的集合，此集合必须是深复制的副本
                foreach (var noSaleID in noSaleIDList)
                {
                    var model = WProductNoSaleBLO.GetModel(noSaleID);
                    if (model == null || model.Status != 2)
                    {
                        ids2Operate.Remove(noSaleID);
                        msg += string.Format(" 单号[{0}]的记录不是“已生效”状态,不能停用！ <br />", noSaleID);
                    }
                }
                if (ids2Operate.Count > 0)
                {
                    result = WProductNoSaleBLO.UpdateStatus(ids2Operate, WProductNoSaleBLO.NoSaleStatus.Stopped, RequestDto.UserId, RequestDto.UserName);
                }
                if (result < noSaleIDList.Count)
                {
                    return ErrorActionResult(string.Format("操作完成！{0}条记录操作成功,{1}条记录操作失败! <br />原因：<br />{2}", result, noSaleIDList.Count - result, msg), result);
                }
                return this.SuccessActionResult("操作完成! " + msg, result);
            }
            else
            {
                return this.ErrorActionResult("上送的参数不正确！", result);
            }
        }

    }
}
