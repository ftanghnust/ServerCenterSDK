/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;


namespace Frxs.ServiceCenter.Product.Api.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("AttributesValues.Delete")]
    public class AttributesValuesDeleteAction : ActionBase<AttributesValuesDeleteAction.AttributesValuesDeleteRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 删除属性值DTO
        /// </summary>
        public class AttributesValuesDeleteRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int ValuesId { get; set; }

            /// <summary>
            /// 属性表ID(Attribute.AttributeID)
            /// </summary>
            public int AttributeId { get; set; }

        }

        /// <summary>
        /// 属性值删除
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取接口参数
            var dto = this.RequestDto;

            AttributesValues attr = new AttributesValues()
            {
                ValuesId = dto.ValuesId,
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                IsDeleted = 1
            };
            int i = Frxs.Erp.ServiceCenter.Product.BLL.AttributesValuesBLO.LogicDelete(attr);
            if (i > 0)
            {
                return SuccessActionResult("删除成功", null);
            }

            switch (i)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistReference:
                    return ErrorActionResult("此属性值存在被引用的商品数据");
                case (int)ProductCenterEnum.ReturnResultInfo.NoExist:
                    return ErrorActionResult("此属性值数据不存在");
                default:
                    //删除失败
                    return ErrorActionResult("删除失败");
            }
        }

    }
}
