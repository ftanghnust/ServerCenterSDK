using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.WarehouseEmp
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseEmp.IsFrozen")]
    public class WarehouseEmpIsFrozenAction : ActionBase<RequestDto.WarehouseEmpIsFrozenRequest, int>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            int row = 0;
            if (!string.IsNullOrEmpty(requestDto.EmpID))
            {
                var shelfIds = requestDto.EmpID.Replace("'", "").Split(',');

                foreach (string id in shelfIds)
                {
                    Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp model = new Model.WarehouseEmp();
                    model.EmpID = int.Parse(id);
                    model.IsFrozen = requestDto.IsFrozen;
                    model.ModifyTime = DateTime.Now;
                    model.ModifyUserID = requestDto.UserId;
                    model.ModifyUserName = requestDto.UserName;
                    row += WarehouseEmpBLO.LogicIsFrozenDelete(model);

                    WarehouseEmpBLO.DeleteCache(model.EmpID);
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
