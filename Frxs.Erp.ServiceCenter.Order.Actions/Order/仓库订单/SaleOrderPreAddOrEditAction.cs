using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 新增,代客订单
    /// </summary>
    [ActionName("SaleOrderPre.AddOrEdit")]
    public class SaleOrderPreAddOrEditAction : ActionBase<RequestDto.SaleOrderPreAddOrEditRequestDto,int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;
            if (dto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }

            var order = dto.SaleOrderPre.MapTo<SaleOrderPre>();
            var details = new List<SaleOrderPreDetails>();
            var detailExts = new List<SaleOrderPreDetailsExt>();
            SaleOrderSendNumber sendNumber=null;
      
         
            foreach (var detail in dto.SaleOrderPreDetailList)
            {
                var d = detail.MapTo<SaleOrderPreDetails>();
                details.Add(d);
            }
            foreach (var detailExt in dto.SaleOrderPreDetailExtsList)
            {
                var d = detailExt.MapTo<SaleOrderPreDetailsExt>();
                detailExts.Add(d);
            }
            if(dto.SendNumber!=null)
            {
                sendNumber = dto.SendNumber.MapTo<SaleOrderSendNumber>();
            }
            
            
          
            var picks = dto.Picks.MapToList<SaleOrderPreDetailsPick>();
            var shelfAreas = dto.ShelfAreas.MapToList<SaleOrderPreShelfArea>();

            //新增订单
            if (dto.Flag == 0)
            {
                var oldOrder = SaleOrderPreBLO.GetModel(order.OrderId,dto.WarehouseId);
                if(oldOrder!=null)
                {
                    return this.SuccessActionResult();
                }
                //(details|detailExts).OrderBy(o => o.ID).ToList() --防止它每次修改顺序都会被打乱问题
                var result = SaleOrderPreBLO.SaveNewOrder(order, details.OrderBy(o => o.ID).ToList(), detailExts.OrderBy(o => o.ID).ToList(), sendNumber, picks.ToList(), shelfAreas.ToList(), dto.WarehouseId);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult();
                }
                else
                {
                    return this.ErrorActionResult(result.Message);
                }
            }
            else // if(dto.Flag==1) 编辑订单
            {
                //(details|detailExts).OrderBy(o => o.ID).ToList() --防止它每次修改顺序都会被打乱问题
                var result = SaleOrderPreBLO.EditOrder(order, details.OrderBy(o => o.ID).ToList(), detailExts.OrderBy(o => o.ID).ToList(), picks.ToList(), shelfAreas.ToList(), dto.WarehouseId);
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
}
