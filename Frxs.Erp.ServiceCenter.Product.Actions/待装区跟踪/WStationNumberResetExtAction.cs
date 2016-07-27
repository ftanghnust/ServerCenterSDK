using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 按订单清除
    /// </summary>
    [ActionName("WStationNumber.ResetExt")]
    public class WStationNumberResetExtAction : ActionBase<RequestDto.WStationNumberResetExtRequest, int>
    {     

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            int row = 0;

                Frxs.Erp.ServiceCenter.Product.Model.WStationNumber model = new Model.WStationNumber();
                model.OrderID = requestDto.OrderId;
                model.ModifyTime = DateTime.Now;
                model.ModifyUserID = requestDto.UserId;
                model.ModifyUserName = requestDto.UserName;
                model.Status = 0;
                row += WStationNumberBLO.ResetWStationNumberExt(model);
            

            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = row
            };
        }
    }
}
