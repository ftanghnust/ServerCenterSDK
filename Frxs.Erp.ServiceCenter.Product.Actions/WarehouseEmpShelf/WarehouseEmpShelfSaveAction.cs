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
    [ActionName("WarehouseEmpShelf.Save")]
    public class WarehouseEmpShelfSaveAction : ActionBase<RequestDto.WarehouseEmpShelfSaveRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            
            var requestDto = this.RequestDto;  
            int row = 0;
            if (!string.IsNullOrEmpty(requestDto.ShelfIDs))
            {
                var shelfIds = requestDto.ShelfIDs.Replace("'", "").Split(',');

                Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmpShelf model = new Model.WarehouseEmpShelf();
                model.EmpID = int.Parse(requestDto.EmpID);
                model.ShelfAreaID = int.Parse(requestDto.ShelfAreaID);
                model.CreateTime = DateTime.Now;
                model.CreateUserID = requestDto.UserId;
                model.CreateUserName = requestDto.UserName;
                row += WarehouseEmpShelfBLO.Save(model, shelfIds);

            }
            else
            {
                Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmpShelf model = new Model.WarehouseEmpShelf();
                model.EmpID = int.Parse(requestDto.EmpID);
                row += WarehouseEmpShelfBLO.Save(model, null);
            }


            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
