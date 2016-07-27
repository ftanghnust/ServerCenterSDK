/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:20:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility.Pager;
using System.Collections;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 获取总部后台门店信息详情(用于排单)
    /// </summary>
    [ActionName("Shop.GetListAndOrder")]
    public class ShopGetListAndOrderAction : ActionBase<ShopGetListAndOrderRequestDto, IList<Model.ShopExt>>
    {
        
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.ShopExt>> Execute()
        {
            var requestDto = this.RequestDto;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            IList<Model.ShopExt> shopList = ShopBLO.GetShopAndOrderList(requestDtoDict);
            return this.SuccessActionResult(shopList);
        }

    }
}
