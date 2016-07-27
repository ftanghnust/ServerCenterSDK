/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取单个属性详细信息
    /// </summary>
    public class AttributesGetAction : ActionBase<AttributesGetAction.AttributesGetRequestDto, Model.Attributes>
    {

        /// <summary>
        /// 获取属性DTO
        /// </summary>
        public class AttributesGetRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int? AttributeId { get; set; }

            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (!this.AttributeId.HasValue)
                {
                    yield return new RequestDtoValidatorResultError("AttributeId", "必须传入参数值");
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Attributes> Execute()
        {
            var dto = this.RequestDto;
            var model = BLL.AttributesBLO.GetModel(dto.AttributeId.Value);
            return SuccessActionResult(model);
        }
    }
}
