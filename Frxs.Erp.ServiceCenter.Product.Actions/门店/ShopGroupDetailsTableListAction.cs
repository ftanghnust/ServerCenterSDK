/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 10:48:23
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 门店群组明细表
    /// </summary>
    [ActionName("ShopGroupDetails.TableList"), ActionResultCache(ShopCacheKey.FRXS_SHOP_GROUP_PATTERN_KEY)]
    public class ShopGroupDetailsTableListAction : ActionBase<ShopGroupDetailsTableListAction.ShopGroupDetailsTableListActionRequestDto, IList<ShopGroupDetails>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupDetailsTableListActionRequestDto : RequestDtoBase 
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            public int ShopID { get; set; }

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
        /// 下送的数据
        /// </summary>
        public class ShopGroupDetailsTableListActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<ShopGroupDetails>> Execute()
        {
            var requestDto = this.RequestDto;           
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            requestDtoDict.Remove("UserId");

            return this.SuccessActionResult(ShopGroupDetailsBLO.GetList(requestDtoDict));
        }

    }
}
