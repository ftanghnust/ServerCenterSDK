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
    /// 属性值更新
    /// </summary>
    [ActionName("AttributesValues.Update")]
    public class AttributesValuesUpdateAction : ActionBase<AttributesValuesUpdateAction.AttributesValuesUpdateRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 修改属性值DTO
        /// </summary>
        public class AttributesValuesUpdateRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int ValuesId { get; set; }

            /// <summary>
            /// 属性表ID(Attribute.AttributeID)
            /// </summary>
            public int AttributeId { get; set; }

            /// <summary>
            /// 值
            /// </summary>
            public string ValueStr { get; set; }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取接口参数
            var dto = this.RequestDto;

            AttributesValues attr = new AttributesValues()
            {
                AttributeId = dto.AttributeId,
                ValuesId = dto.ValuesId,
                ValueStr = dto.ValueStr,
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                IsDeleted = 0
            };
            int i = Frxs.Erp.ServiceCenter.Product.BLL.AttributesValuesBLO.Edit(attr);
            if (i > 0)
            {
                //返回成功
                return SuccessActionResult("编辑成功", null);
            }
            switch (i)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistReference:
                    //返回失败
                    return ErrorActionResult("存在被引用的数据，请重新输入");
                case (int)ProductCenterEnum.ReturnResultInfo.ExistSameName:
                    //返回失败
                    return ErrorActionResult("已存在相同的规格值，请重新输入");
                case (int)ProductCenterEnum.ReturnResultInfo.NoExist:
                    //返回失败
                    return ErrorActionResult("数据不存在");
                default:
                    //返回失败
                    return ErrorActionResult("编辑失败");
            }
        }

    }
}
