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

namespace Frxs.ServiceCenter.Product.Api.Actions
{
    /// <summary>
    /// 属性值获取
    /// 说明：获取规格属性值列表接口实现了2种不同的逻辑,如果用户传入ValuesIds为null或者不传,返回所有规格值列表数据，如果ValuesIds中包含商品规格值编号,返回包含规则值编号的列表数据
    /// </summary>
    [ActionName("AttributesValues.GetList")]
    public class AttributesValuesGetListAction : ActionBase<AttributesValuesGetListAction.AttributesValuesGetListRequestDto, IList<AttributesValues>>
    {

        /// <summary>
        /// 获取属性值DTO
        /// </summary>
        public class AttributesValuesGetListRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 规格值编号组（用来过滤数据操作功能）
            /// </summary>
            public List<int> ValuesIds { get; set; }

            /// <summary>
            /// 属性表ID(Attribute.AttributeID)
            /// </summary>
            public int AttributeId { get; set; }

            /// <summary>
            /// 当前页(默认1)
            /// </summary>
            public int PageIndex { get; set; }

            /// <summary>
            /// 分页大小（默认10）
            /// </summary>
            public int PageSize { get; set; }


            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (AttributeId < 0)
                {
                    yield return new RequestDtoValidatorResultError("AttributeId");
                }

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
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<AttributesValues>> Execute()
        {
            IList<AttributesValues> list = new List<AttributesValues>();

            var dto = this.RequestDto;
            var nlist = AttributesValuesBLO.AttributesValuesGetList(dto.AttributeId);
            if (nlist != null && nlist.Count > 0)
            {
                //判断是否要做过滤操作。如果没有赋值这不做过滤数据，如果有值要过滤数据
                if (this.RequestDto.ValuesIds != null && this.RequestDto.ValuesIds.Count > 0)
                {
                    foreach (var valuesId in this.RequestDto.ValuesIds)
                    {
                        var item = nlist.FirstOrDefault(i => i.ValuesId == valuesId);
                        if (item != null)
                        {
                            list.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in nlist)
                    {
                        list.Add(item);
                    }
                }
            }
            return SuccessActionResult(list.ToList());
        }
    }
}
