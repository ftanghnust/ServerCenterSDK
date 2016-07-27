/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 14:55:13
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

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 获取总部后台门店查询列表结果
    /// </summary>
    [ActionName("Shop.TableList")]
    public class ShopTableListAction : ActionBase<ShopTableListRequestDto, ActionResultPagerData<Model.Shop>>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns>分页结果</returns>
        public override ActionResult<ActionResultPagerData<Model.Shop>> Execute()
        {

            var requestDto = this.RequestDto;
            PageListBySql<Model.Shop> page = new PageListBySql<Model.Shop>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.Shop> models = ShopBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.Shop>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
