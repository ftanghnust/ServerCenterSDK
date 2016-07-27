/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/8 17:19:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 销售退货单(待处理)录入或编辑
    /// </summary>
    [ActionName("SaleBackPre.AddOrEdit")]
    public class SaleBackPreAddOrEditAction : ActionBase<RequestDto.SaleBackPreAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            if (string.IsNullOrEmpty(requestDto.order.BackID))
            {
                return this.ErrorActionResult("销售退货单编号为空");
            }
            if (requestDto.orderdetails.Count != requestDto.orderdetailsext.Count)
            {
                return this.ErrorActionResult("商品明细列表与明细扩展列表不匹配");
            }
            SaleBackPre order = requestDto.order.MapTo<SaleBackPre>();
            order.ModifyUserID = requestDto.UserId;
            order.ModifyUserName = requestDto.UserName;
            var orderdetails = new List<SaleBackPreDetails>();
            if (requestDto.orderdetails != null && requestDto.orderdetails.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.orderdetails)
                {
                    i = i + 1;
                    SaleBackPreDetails orderdetail = model.MapTo<SaleBackPreDetails>();
                    if (string.IsNullOrEmpty(orderdetail.ID))
                    {
                        orderdetail.ID = orderdetail.WID.ToString() + Guid.NewGuid().ToString();
                    }
                    orderdetail.ModifyUserID = RequestDto.UserId;
                    orderdetail.ModifyUserName = requestDto.UserName;
                    orderdetail.SerialNumber = i;
                    orderdetails.Add(orderdetail);
                }
            }
            else
            {
                return this.ErrorActionResult("销售退货单详情数据不能为空");
            }
            var orderdetailsexts = new List<SaleBackPreDetailsExt>();
            if (requestDto.orderdetailsext != null && requestDto.orderdetailsext.Count > 0)
            {
                var orderdetailsext = requestDto.orderdetailsext;
                for (int i = 0; i < orderdetailsext.Count; i++)
                {
                    SaleBackPreDetailsExt orderdetailext = orderdetailsext[i].MapTo<SaleBackPreDetailsExt>();
                    orderdetailext.ID = orderdetails[i].ID;
                    orderdetailext.BackID = order.BackID;
                    orderdetailext.ModifyUserID = RequestDto.UserId;
                    orderdetailext.ModifyUserName = requestDto.UserName;
                    orderdetailsexts.Add(orderdetailext);
                }
            }
            else
            {
                return this.ErrorActionResult("销售退货单详情扩展数据不能为空");
            }

            if (requestDto.Flag == "Add")
            {
                order.CreateUserID = requestDto.UserId;
                order.CreateUserName = requestDto.UserName;
                order.Status = 0;
                order.CreateTime = DateTime.Now;
                order.ModifyTime = DateTime.Now;
                var result = SaleBackPreBLO.Save(order, orderdetails, orderdetailsexts,requestDto.WarehouseId.ToString());
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult();
                }
                else
                {
                    return this.ErrorActionResult(result.Message);
                }
            }
            else
            {
                order.ModifyTime = DateTime.Now;
                var result = SaleBackPreBLO.Edit(order, orderdetails, orderdetailsexts, requestDto.WarehouseId.ToString());
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
