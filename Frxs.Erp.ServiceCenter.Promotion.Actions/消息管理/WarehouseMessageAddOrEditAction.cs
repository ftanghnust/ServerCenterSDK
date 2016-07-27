/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 仓库消息录入或编辑
    /// </summary>
    [ActionName("WarehouseMessage.AddOrEdit")]
    public class WarehouseMessageAddOrEditAction : ActionBase<RequestDto.WarehouseMessageAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;

            WarehouseMessage order = requestDto.order.MapTo<WarehouseMessage>();
            order.CreateTime = DateTime.Now;
            order.CreateUserID = requestDto.UserId;
            order.CreateUserName = requestDto.UserName;
            order.ModityTime = DateTime.Now;
            order.ModityUserID = requestDto.UserId;
            order.ModityUserName = requestDto.UserName;

            var orderdetails = new List<WarehouseMessageShops>();
            if (requestDto.orderdetailsList != null && requestDto.orderdetailsList.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.orderdetailsList)
                {
                    i = i + 1;
                    WarehouseMessageShops orderdetail = model.MapTo<WarehouseMessageShops>();

                    orderdetails.Add(orderdetail);
                }
                order.detailList = orderdetails;
            }


            if (requestDto.Flag == "Add")
            {
                order.Status = 0;  //未发布
                //新增操作
                int result = WarehouseMessageBLO.Save(order, requestDto.WareHouseId.ToString());
                if (result == 0)
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "新增仓库消息失败！"
                    };
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = result
                    };
                }
            }
            else 
            {
                //修改操作
                string result = WarehouseMessageBLO.Edit(order, requestDto.WareHouseId.ToString());
                if (result == "1")
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK",
                        Data = 1
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
