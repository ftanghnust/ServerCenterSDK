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
    [ActionName("WarehouseLineShop.Save")]
    public class WarehouseLineShopSaveAction : ActionBase<RequestDto.WarehouseLineShopSaveRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;

            var ids = this.RequestDto.idList.Split(',');
            int num = 1;
            foreach (string id in ids)
            {
                WarehouseLineShop mode = WarehouseLineShopBLO.GetModel(int.Parse(id));
                mode.SerialNumber = num;
                mode.ModifyUserID = requestDto.UserId;
                mode.ModifyUserName = requestDto.UserName;
                WarehouseLineShopBLO.Edit(mode);
                #region 删除门店对象缓存,防止下次读取时门店线路信息不更新
                ShopBLO.DelShopCache(mode.ShopID);
                #endregion
                num++;
            }

            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
