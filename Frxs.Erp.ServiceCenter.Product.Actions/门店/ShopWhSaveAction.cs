/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:03:47
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库后台 门店信息修改 3月23日 和胡总确认，对比现有C8系统，只修改门店的配送信息 
    /// </summary>
    [ActionName("Shop.Warehouse.Save")]
    public class ShopWhSaveAction : ActionBase<ShopWhSaveRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑 门店线路信息修改 -- 更新门店和仓库线路的映射关系   
        /// </summary>
        /// <returns>ActionResult</returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            Frxs.Erp.ServiceCenter.Product.Model.Shop mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.Shop>();

            #region 删除门店对象缓存,防止下次读取时门店线路信息不更新
            ShopBLO.DelShopCache(mode.ShopID);
            #endregion
            // 仓库配送线路门店关系表 记录
            WarehouseLineShopBLO.DeleteByShopID(requestDto.ShopID);
            // 新增一个映射关系
            WarehouseLineShop modelToSave = new WarehouseLineShop();
            modelToSave.ShopID = requestDto.ShopID;
            modelToSave.LineID = requestDto.LineID;
            modelToSave.SerialNumber = requestDto.SerialNumber;
            modelToSave.ModifyTime = DateTime.Now;
            modelToSave.ModifyUserID = requestDto.UserId;
            modelToSave.ModifyUserName = requestDto.UserName;
            WarehouseLineShopBLO.Save(modelToSave);

            return this.SuccessActionResult();
        }
    }
}
