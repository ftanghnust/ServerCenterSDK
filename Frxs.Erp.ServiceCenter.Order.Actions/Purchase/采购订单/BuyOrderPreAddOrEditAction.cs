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
    /// 采购收货单(待处理)录入或编辑
    /// </summary>
    [ActionName("BuyOrderPre.AddOrEdit")]
    public class BuyOrderPreAddOrEditAction : ActionBase<RequestDto.BuyOrderPreAddOrEditActionRequestDto, int>
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
            if (string.IsNullOrEmpty(requestDto.order.BuyID)) 
            {
                return this.ErrorActionResult("采购单编号为空");
            }
            if (requestDto.orderdetails.Count != requestDto.orderdetailsext.Count)
            {
                return this.ErrorActionResult("商品明细列表与明细扩展列表不匹配");
            }
            BuyOrderPre order = requestDto.order.MapTo<BuyOrderPre>();
            order.ModifyUserID = requestDto.UserId;
            order.ModifyUserName = requestDto.UserName;
            var orderdetails = new List<BuyOrderPreDetails>();
            if (requestDto.orderdetails != null && requestDto.orderdetails.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.orderdetails)
                {
                    i = i + 1;
                    BuyOrderPreDetails orderdetail = model.MapTo<BuyOrderPreDetails>();
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
                return this.ErrorActionResult("采购单详情数据为空");
            }
            var orderdetailsexts = new List<BuyOrderPreDetailsExt>();
            if (requestDto.orderdetailsext != null && requestDto.orderdetailsext.Count > 0)
            {
                var orderdetailsext = requestDto.orderdetailsext;
                for (int i = 0; i < orderdetailsext.Count; i++)
                {
                    BuyOrderPreDetailsExt orderdetailext = orderdetailsext[i].MapTo<BuyOrderPreDetailsExt>();
                    orderdetailext.ID = orderdetails[i].ID;
                    orderdetailext.BuyID = order.BuyID;
                    orderdetailext.ModifyUserID = RequestDto.UserId;
                    orderdetailext.ModifyUserName = requestDto.UserName;
                    orderdetailsexts.Add(orderdetailext);
                }
            }
            else
            {
                return this.ErrorActionResult("采购单详情扩展数据为空");
            }

            if (requestDto.Flag == "Add")
            {
                order.CreateUserID = requestDto.UserId;
                order.CreateUserName = requestDto.UserName;
                order.CreateTime = DateTime.Now;
                order.ModifyTime = DateTime.Now;
                order.Status = 0;
                var result =  BuyOrderPreBLO.Save(order, orderdetails, orderdetailsexts,requestDto.WarehouseId.ToString());
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
                var result = BuyOrderPreBLO.Edit(order, orderdetails, orderdetailsexts, requestDto.WarehouseId.ToString());
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
