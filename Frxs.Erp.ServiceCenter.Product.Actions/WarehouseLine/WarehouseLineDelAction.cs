using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.WarehouseLine
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseLine.Del")]
    public class WarehouseLineDelAction : ActionBase<RequestDto.WarehouseLineDelRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            int row=0;
            if(!string.IsNullOrEmpty(requestDto.LineID))
            {
                var WarehouseLineIds = requestDto.LineID.Replace("'", "").Split(',');

                foreach (string id in WarehouseLineIds)
                {
                    Dictionary<string, object> conditionDict = new Dictionary<string, object>();
                    conditionDict.Add("LineID", id);
                    var list = WarehouseLineShopBLO.GetList(conditionDict);
                    if(list!=null)
                    {
                        if (list.Count > 0)
                        {
                            Frxs.Erp.ServiceCenter.Product.Model.WarehouseLine model = WarehouseLineBLO.GetModel(int.Parse(id));
                            return new ActionResult<int>()
                            {
                                Flag = ActionResultFlag.FAIL,
                                Info = model.LineName+"已经匹配门店，不能删除！"
                               
                            };
                        }
                    }
                }

                foreach(string id in WarehouseLineIds)
                {
                    Frxs.Erp.ServiceCenter.Product.Model.WarehouseLine model = new Model.WarehouseLine();
                    model.LineID = int.Parse(id);
                    model.ModifyTime = DateTime.Now;
                    model.ModifyUserID = requestDto.UserId;
                    model.ModifyUserName = requestDto.UserName;
                    row += WarehouseLineBLO.LogicDelete(model);

                    WarehouseLineBLO.DeleteCache(model.LineID);
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
