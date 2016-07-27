using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ShelfArea
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("ShelfArea.Del")]
    public class ShelfAreaDelAction : ActionBase<RequestDto.ShelAreafDelRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            int row = 0;
            if (!string.IsNullOrEmpty(requestDto.ShelfAreaID))
            {
                var list = ShelfAreaBLO.ExistsShelfAreaCode(requestDto.ShelfAreaID);
                if (list == null || list.Count < 1)
                {
                    var shelfIds = requestDto.ShelfAreaID.Replace("'", "").Split(',');

                    foreach (string id in shelfIds)
                    {
                        row += ShelfAreaBLO.LogicDelete(int.Parse(id));
                    }
                }
                else
                {
                    var PIDList = from o in list select o.ShelfAreaName;
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = string.Join(",", PIDList.ToArray())+"的货区已被使用，不能删除！",
                       
                    };
                }
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
