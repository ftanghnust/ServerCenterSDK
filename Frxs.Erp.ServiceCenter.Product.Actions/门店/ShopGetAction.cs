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

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 获取总部后台门店信息详情
    /// </summary>
    [ActionName("Shop.Get")]
    public class ShopGetAction : ActionBase<ShopGetRequestDto, Model.Shop>
    {
        
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Shop> Execute()
        {            
            var requestDto = this.RequestDto;
            Model.Shop mode = ShopBLO.GetModel(requestDto.ShopID);
            return this.SuccessActionResult(mode);
        }

    }
}
