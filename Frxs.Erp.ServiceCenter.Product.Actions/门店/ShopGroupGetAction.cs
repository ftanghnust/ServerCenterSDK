/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 9:45:39
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取门店群组信息
    /// </summary>
    [ActionName("ShopGroup.Get"), ActionResultCache(ShopCacheKey.FRXS_SHOP_GROUP_PATTERN_KEY)]
    public class ShopGroupGetAction : ActionBase<ShopGroupGetAction.ShopGroupGetActionRequestDto, ShopGroup>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 群组ID
            /// </summary>
            public int GroupID { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }

        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ShopGroup> Execute()
        {
            if (this.RequestDto != null)
            {
                Model.ShopGroup shopGroup = ShopGroupBLO.GetModel(RequestDto.GroupID);
                return this.SuccessActionResult(shopGroup);
            }
            else
            {
                return this.ErrorActionResult("上传参数不对");
            }
        }

    }
}
