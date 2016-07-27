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
    /// 获取 仓库后台 门店信息详情（不推荐使用本接口！ 为确保为统一缓存的Shop实体，推荐使用Shop.Get接口。）
    /// </summary>
    [ActionName("Shop.Warehouse.Get")]
    public class ShopWhGetAction : ActionBase<ShopWhGetRequestDto, Model.Shop>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Shop> Execute()
        {
            var requestDto = this.RequestDto;
            //2016-5-12 为了确保缓存存入的时候，不同应用程序写的对象都是相同的，BOSS后台和仓库后台都统一从GetModel方法中取数据,取消原来的GetModelInWh方法，调用方不用改代码，返回的数据结果也和原来的一样。
            Model.Shop mode = ShopBLO.GetModel(requestDto.ShopID);
            return this.SuccessActionResult(mode);
        }

    }
}
