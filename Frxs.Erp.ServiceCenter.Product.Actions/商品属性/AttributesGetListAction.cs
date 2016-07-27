/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 属性获取
    /// </summary>
    [ActionName("Attributes.GetList")]
    public class AttributesGetListAction : ActionBase<AttributesGetListAction.AttributesGetListRequestDto, ActionResultPagerData<Attributes>>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        public class AttributesGetListRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 规格名称
            /// </summary>
            public string AttributeName { get; set; }

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
            /// 输入数据验证
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

                if (this.PageIndex == 0)
                {
                    this.PageIndex = 1;
                }
                if (this.PageSize == 0)
                {
                    this.PageSize = 10;
                }
            }

        }


        /// <summary>
        /// 执行方法
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Attributes>> Execute()
        {
            var dto = this.RequestDto;
            PageListBySql<Attributes> page = new PageListBySql<Attributes>(dto.PageIndex, dto.PageSize);
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            if (!dto.AttributeName.IsNullOrEmpty())
            {
                conditionDict.Add("AttributeName", dto.AttributeName);
            }
            if (!dto.ValueStr.IsNullOrEmpty())
            {
                conditionDict.Add("ValueStr", dto.ValueStr);
            }
            PageListBySql<Attributes> models = AttributesBLO.GetPageList(page, conditionDict);

            return this.SuccessActionResult(new ActionResultPagerData<Attributes>()
                                                {
                                                    ItemList = models.ItemList.ToList(),
                                                    TotalRecords = models.TotalRecords
                                                });


        }
    }
}

