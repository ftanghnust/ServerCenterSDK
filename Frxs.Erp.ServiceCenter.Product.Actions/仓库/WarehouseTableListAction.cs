/*********************************************************
 * FRXS(ISC)  2016/3/8 15:41:19
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Warehouse
{
    /// <summary>
    /// 仓库列表查询 表格显示
    /// </summary>
    [ActionName("Warehouse.TableList")]
    public class WarehouseTableListAction : ActionBase<WarehouseTableListRequestDto, ActionResultPagerData<Model.Warehouse>>
    {        
        /// <summary>
        /// 下送的数据
        /// </summary>
        public class WarehouseTableListActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.Warehouse>> Execute()
        {
            //throw new NotImplementedException();

            var requestDto = this.RequestDto;
            PageListBySql<Model.Warehouse> page = new PageListBySql<Model.Warehouse>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false,false);
            PageListBySql<Model.Warehouse> models = WarehouseBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.Warehouse>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
