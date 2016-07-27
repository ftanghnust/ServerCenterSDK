/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取包含商品
    /// </summary>
    [ActionName("AttributesProducts.GetList")]
    public class AttributesProductsGetListAction : ActionBase<AttributesProductsGetListAction.AttributesProductsGetListRequestDto, AttributesProductsGetListAction.AttributesProductsGetListResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public class AttributesProductsGetListRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int AttributeId { get; set; }

            /// <summary>
            /// SKU编码
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 规格值
            /// </summary>
            public string ValueStr { get; set; }

            /// <summary>
            /// 当前页(默认1)
            /// </summary>
            public int PageIndex { get; set; }

            /// <summary>
            /// 分页大小（默认10）
            /// </summary>
            public int PageSize { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                if (this.PageIndex == 0)
                {
                    this.PageIndex = 1;
                }
                if (this.PageSize == 0)
                {
                    this.PageSize = 10;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.PageIndex < 0)
                {
                    yield return new RequestDtoValidatorResultError("PageIndex");
                }
                if (this.PageSize < 0)
                {
                    yield return new RequestDtoValidatorResultError("PageSize");
                }
            }
        }


        /// <summary>
        ///
        /// </summary>
        public class AttributesProductsGetListResponseDto
        {
            /// <summary>
            /// 总记录数
            /// </summary>
            public int TotalRecords { get; set; }

            /// <summary>
            /// 输出的集合数据，此处对象必须为一个集合类型的对象，比如：数组,列表
            /// </summary>
            public List<Model.AttributesProducts> ItemList { get; set; }

            /// <summary>
            /// 表名
            /// </summary>
            public string AttributeName { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<AttributesProductsGetListResponseDto> Execute()
        {
            var dto = this.RequestDto;

            PageListBySql<AttributesProducts> page = new PageListBySql<AttributesProducts>(dto.PageIndex, dto.PageSize);
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            if (dto.AttributeId != 0)
            {
                conditionDict.Add("AttributeId", dto.AttributeId);
            }
            if (dto.ValueStr != null)
            {
                conditionDict.Add("ValueStr", dto.ValueStr);
            }
            if (dto.SKU != null)
            {
                conditionDict.Add("SKU", dto.SKU);
            }
            PageListBySql<AttributesProducts> models = AttributesBLO.ProductsGetPageList(page, conditionDict);
            return SuccessActionResult(new AttributesProductsGetListResponseDto()
            {
                ItemList = models.ItemList.ToList(),
                TotalRecords = models.TotalRecords,
                AttributeName = models.TableName
            });
        }
    }
}
