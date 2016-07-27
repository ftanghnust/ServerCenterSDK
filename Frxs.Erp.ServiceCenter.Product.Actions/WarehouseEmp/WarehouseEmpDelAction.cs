using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Cache.Provide;
using Frxs.Platform.Cache;

namespace Frxs.Erp.ServiceCenter.Product.Actions.WarehouseEmp
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseEmp.Del")]
    public class WarehouseEmpDelAction : ActionBase<RequestDto.WarehouseEmpDelRequest, int>
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
                    Model.WarehouseEmp mode = WarehouseEmpBLO.GetModel(int.Parse(id));
                    if (mode.UserType != 3)
                    {
                        var result = WarehouseEmpBLO.ExistsWarehouseEmp(int.Parse(id), mode.UserType);

                        if (!result.IsNullOrEmpty())
                        {

                            return new ActionResult<int>()
                            {
                                Flag = ActionResultFlag.FAIL,
                                Info = mode.EmpName + "已经在" + result + "绑定数据，请清除绑定后再删除！"

                            };
                        }
                    }
                }

                foreach (string id in shelfIds)
                {
                    Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp model = new Model.WarehouseEmp();
                    model.EmpID = int.Parse(id);
                    model.ModifyTime = DateTime.Now;
                    model.ModifyUserID = requestDto.UserId;
                    model.ModifyUserName = requestDto.UserName;
                    row += WarehouseEmpBLO.LogicDelete(model);

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
