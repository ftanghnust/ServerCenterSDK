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
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 门店费用录入或编辑
    /// </summary>
    [ActionName("SaleFee.AddOrEdit")]
    public class SaleFeeAddOrEditAction : ActionBase<RequestDto.SaleFeeAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            try
            {

            var requestDto = this.RequestDto;

            SaleFeePre order = requestDto.saleFee.MapTo<SaleFeePre>();

            var orderdetails = new List<SaleFeePreDetails>();
            if (requestDto.orderdetailsList != null && requestDto.orderdetailsList.Count > 0)
            {
                int i = 0;
                foreach (var model in requestDto.orderdetailsList)
                {
                    i = i + 1;
                    SaleFeePreDetails orderdetail = model.MapTo<SaleFeePreDetails>();
                    if (string.IsNullOrEmpty(orderdetail.ID))
                    {
                        orderdetail.ID = orderdetail.WID.ToString() + Guid.NewGuid().ToString();
                    }
                    orderdetail.SerialNumber = i;
                    orderdetails.Add(orderdetail);
                }
                order.detailList = orderdetails;
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "门店费用详情数据不能为空！"
                };
            }

            if (requestDto.Flag == "Add")
            {
                order.Status = 0;  //未发布
                int result = SaleFeePreBLO.Save(requestDto.WareHouseId,order); 
                if (result == 0)
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "新增门店费用失败！"
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
                string result = SaleFeePreBLO.Edit(requestDto.WareHouseId, order);
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
            catch (Exception ex)
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "操作门店费用失败,请刷新重试！"
                };
            }

        }
    }
}
