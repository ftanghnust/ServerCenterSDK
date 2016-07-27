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
    /// 
    /// </summary>
    [ActionName("WStationNumber.Del")]
    public class WStationNumberDelAction : ActionBase<RequestDto.WStationNumberDelRequest, int>
    {     

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int row = 0;

            foreach (int id in requestDto.ID)
            {
                Frxs.Erp.ServiceCenter.Product.Model.WStationNumber model = new Model.WStationNumber();
                model.ID = id;
                model.ModifyTime = DateTime.Now;
                model.ModifyUserID = requestDto.UserId;
                model.ModifyUserName = requestDto.UserName;
                row += WStationNumberBLO.Delete(model);
            }

            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = row
            };
        }
    }
}
