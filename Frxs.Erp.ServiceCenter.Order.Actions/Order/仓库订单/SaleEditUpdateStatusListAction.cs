using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 改单修改状态
    /// </summary>
    [ActionName("SaleEdit.UpdateStatusList")]
    public class SaleEditUpdateStatusListAction : ActionBase<RequestDto.SaleEditUpdateStatusRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            var user = new BaseUserModel()
            {
                UserName = dto.UserName,
                UserId = dto.UserId
            };

            if(string.IsNullOrEmpty(dto.EditId))
            {
                return this.ErrorActionResult("错误的改单编号");
            }

            var list = dto.EditId.Split(',').ToList();

            if (dto.Status != 2)
            {
                var result = SaleEditBLO.UpdateStatusList(list, dto.Status, dto.WarehouseId, user);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult(true);
                }
                else
                {
                    return this.ErrorActionResult(result.Message, false);
                }
            }
            else
            {
                string editIdmsg1 = "";
                string editIdmsg2 = "";
                string msg1 = "不能进行过帐的状态";
                string msg2 = "改单数据异常";
                string successMsg = "";
                string errorMsg = "";
                foreach (var editId in list)
                {
                    var result = SaleEditBLO.Modify(editId, dto.WarehouseId, user);
                    if (!result.IsSuccess)
                    {
                        if(result.Data==1)
                        {
                            editIdmsg1 += editId + ",";
                        }
                        else
                        {
                            editIdmsg2 += editId + ",";
                        }
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(result.Message))
                        {
                            successMsg += result.Message;
                        }
                    }
                }
           
                //
                if (!string.IsNullOrEmpty(editIdmsg1) || !string.IsNullOrEmpty(editIdmsg2))
                {
                    var str = "";
                    if (!string.IsNullOrEmpty(editIdmsg1))
                    {
                        str += editIdmsg1.Substring(0, editIdmsg1.Length - 1) + "(" + msg1 + ")";
                    }
                    if (!string.IsNullOrEmpty(editIdmsg2))
                    {
                        if(string.IsNullOrEmpty(str))
                        {
                            str += editIdmsg2.Substring(0, editIdmsg2.Length - 1) + "(" + msg2 + ")";
                        }
                        else
                        {
                            str += ","+editIdmsg2.Substring(0, editIdmsg2.Length - 1) + "(" + msg2 + ")";
                        }
                    }
                    errorMsg="改单[" + str +"],过帐失败\n";
                }
                if(string.IsNullOrEmpty(errorMsg)) //全体成功
                {
                    return this.SuccessActionResult(true);
                }
                else
                {
                    var msg = errorMsg + successMsg;
                    return this.ErrorActionResult(msg, false);
                }
            }
        }
    }
}
