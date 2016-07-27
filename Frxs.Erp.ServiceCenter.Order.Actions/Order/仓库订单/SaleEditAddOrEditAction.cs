using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 改单添加
    /// </summary>
    [ActionName("SaleEdit.AddOrEdit")]
    public class SaleEditAddOrEditAction : ActionBase<RequestDto.SaleEditAddRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            var edit = dto.SaleEdit.MapTo<SaleEdit>();
            var order = new List<SaleEditOrders>();
            order = dto.Order.MapToList<SaleEditOrders>().ToList();
            foreach (var o in order)
            {
                o.ProcFlag = 0;
            }
            var detail = dto.Details.MapToList<SaleEditDetails>();
            var detailExts = dto.DetailExts.MapToList<SaleEditDetailsExt>();
            var user = new BaseUserModel()
                           {
                               UserId = dto.UserId,
                               UserName = dto.UserName
                           };
            if (dto.Type == 0) //添加
            {
                var result = SaleEditBLO.Save(edit, detail.ToList(), detailExts.ToList(), order.ToList(), user, dto.WarehouseId);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult(true);
                }
                else
                {
                    return this.ErrorActionResult(result.Message);
                }
            }
            else //修改
            {
                var result = SaleEditBLO.Edit(edit, detail.ToList(), detailExts.ToList(), order.ToList(), user, dto.WarehouseId);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult(true);
                }
                else
                {
                    return this.ErrorActionResult(result.Message);
                }
            }

        }
    }
}
