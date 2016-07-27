/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 11:01:36
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("ShopGroupDetails.Save")]
    public class ShopGroupDetailsSaveAction : ActionBase<ShopGroupDetailsSaveAction.ShopGroupDetailsSaveActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupDetailsSaveActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            #region 模型
            /// <summary>
            /// 分组ID
            /// </summary>
            public int GroupID { get; set; }
            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>           
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>        
            public int ShopID { get; set; }


            #endregion

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
        public class ShopGroupDetailsSaveActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(ShopCacheKey.FRXS_SHOP_GROUP_PATTERN_KEY);
        }
    }
}
