using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WStationNumber.Save")]
    public class WStationNumberSaveAction : ActionBase<RequestDto.WStationNumberAddRequestDto, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            for (int i = requestDto.StartID; i <= requestDto.EndID; i++)
            {
                Frxs.Erp.ServiceCenter.Product.Model.WStationNumber mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.WStationNumber>();

                mode.StationNumber = i;
                mode.WID = requestDto.WID;

                if (WStationNumberBLO.ExistsWStationNumber(mode))
                {                    
                }
                else
                {
                    mode.Status = 0;
                    
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    mode.CreateUserID = requestDto.UserId;
                    mode.CreateUserName = requestDto.UserName;
                    WStationNumberBLO.Save(mode);
                }
            }
            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
