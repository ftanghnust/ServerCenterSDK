/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/25 9:54:27
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
    /// 门店群组 查询表格
    /// </summary>
    [ActionName("ShopGroup.TableList"), ActionResultCache(ShopCacheKey.FRXS_SHOP_GROUP_PATTERN_KEY)]
    public class ShopGroupTableListAction : ActionBase<ShopGroupTableListAction.ShopGroupTableListActionRequestDto, ActionResultPagerData<ShopGroup>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopGroupTableListActionRequestDto : PageListRequestDto //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }
            /// <summary>
            /// 分组编号
            /// </summary>
            public string GroupCode { get; set; }

            /// <summary>
            /// 分组名称
            /// </summary>
            public string GroupName { get; set; }
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
        public override ActionResult<ActionResultPagerData<ShopGroup>> Execute()
        {

            var requestDto = this.RequestDto;
            PageListBySql<Model.ShopGroup> page = new PageListBySql<Model.ShopGroup>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.ShopGroup> models = ShopGroupBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.ShopGroup>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });


        }

    }
}
