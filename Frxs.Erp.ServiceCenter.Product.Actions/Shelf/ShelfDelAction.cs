using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Shelf
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("Shelf.Del")]
    public class ShelfDelAction : ActionBase<RequestDto.ShelfDelRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            int row=0;
            if(!string.IsNullOrEmpty(requestDto.ShelfID))
            {
                var list = ShelfBLO.ExistsShelIDs(requestDto.ShelfID);
                if (list == null || list.Count < 1)
                {
                    var shelfIds = requestDto.ShelfID.Replace("'", "").Split(',');

                    foreach (string id in shelfIds)
                    {

                        row += ShelfBLO.LogicDelete(int.Parse(id));
                    }
                }
                else
                {
                    var PIDList = from o in list select o.ShelfCode;
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = string.Join(",", PIDList.ToArray()) + "的货位已被使用，不能删除！",

                    };
                }
            }

            


            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data=row
            };
        }
    }
}
