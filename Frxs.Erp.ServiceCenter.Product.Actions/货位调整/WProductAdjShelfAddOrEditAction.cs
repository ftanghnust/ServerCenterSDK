/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 货位调整录入或编辑
    /// </summary>
    [ActionName("WProductAdjShelf.AddOrEdit")]
    public class WProductAdjShelfAddOrEditAction : ActionBase<RequestDto.WProductAdjShelfAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            WProductAdjShelf order = requestDto.WProductAdjShelf.MapTo<WProductAdjShelf>();

            order.ModifyTime = DateTime.Now;
            order.ModifyUserID = requestDto.UserId;
            order.ModifyUserName = requestDto.UserName;
         
            var orderdetails = new List<WProductAdjShelfDetails>();
            if (requestDto.orderdetailsList != null && requestDto.orderdetailsList.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.orderdetailsList)
                {
                    i = i + 1;
                    WProductAdjShelfDetails orderdetail = model.MapTo<WProductAdjShelfDetails>();
                    orderdetail.CreateTime = DateTime.Now;
                    orderdetail.CreateUserID = requestDto.UserId;
                    orderdetail.CreateUserName = requestDto.UserName; 

                    orderdetails.Add(orderdetail);
                }
                order.wProductAdjShelfDetailsList = orderdetails;
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "货位调整详情数据不能为空！"
                };
            }

            if (requestDto.Flag == "Add")
            {

                order.CreateTime = DateTime.Now;
                order.CreateUserID = requestDto.UserId;
                order.CreateUserName = requestDto.UserName;
                order.Status = 0;  //未发布
                string result = WProductAdjShelfBLO.Save(order,requestDto.WareHouseId.Value); 
                
                if (result == "1")
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = int.Parse(result)
                    };
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = result
                    };
                }
            }
            else 
            {
                string result = WProductAdjShelfBLO.Edit(order, requestDto.WareHouseId.Value);
                if (result == "1")
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = int.Parse(result)
                    };
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = result
                    };
                }
            }

        }
    }
}
