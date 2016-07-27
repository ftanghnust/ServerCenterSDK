using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 编辑订单备注
    /// </summary>
    [ActionName("OrderShop.EditRemark")]
    public class OrderShopEditRemarkAction : ActionBase<RequestDto.OrderEditRemarkRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("没有订单编号");
            }
            if (dto.EditType != 0 && dto.EditType != 1)
            {
                return this.ErrorActionResult("错误的编辑状态");
            }
            if(dto.EditType==1 && string.IsNullOrEmpty(dto.DetailId))
            {
                return this.ErrorActionResult("请传入编辑商品明细的ID");
            }
            var user = new BaseUserModel(dto.UserId, dto.UserName);

            var result =new BackMessage<bool>();
            if(dto.EditType==0)
            {
                result = SaleOrderShopBLO.UpdateRemark(dto.OrderId, dto.Remark,dto.WarehouseId,user);
            }
            else
            {
                result = SaleOrderShopBLO.UpdateRemark(dto.OrderId, dto.DetailId,dto.Remark,dto.WarehouseId,user);
            }
            if (result.IsSuccess)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
