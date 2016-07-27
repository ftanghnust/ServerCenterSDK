using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 属性更新
    /// </summary>
    [ActionName("Attributes.Update")]
    public class AttributesUpdateAction : ActionBase<AttributesUpdateAction.AttributesUpdateRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 修改属性DTO
        /// </summary>
        public class AttributesUpdateRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int AttributeId { get; set; }

            /// <summary>
            /// 属性名称
            /// </summary>
            [Required]
            public string AttributeName { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取接口参数
            var dto = this.RequestDto;

            Attributes attr = new Attributes()
            {
                AttributeId = dto.AttributeId,
                AttributeName = dto.AttributeName,
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                ModifyTime = DateTime.Now,
                IsDeleted = 0
            };
            int i = BLL.AttributesBLO.Edit(attr);
            if (i > 0)
            {
                return SuccessActionResult("编辑成功", null);
            }
            switch (i)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistSameName:
                    return ErrorActionResult("存在相同名称");
                case (int)ProductCenterEnum.ReturnResultInfo.ExistReference:
                    return ErrorActionResult("存在被引用的数据");
                case (int)ProductCenterEnum.ReturnResultInfo.NoExist:
                    return ErrorActionResult("数据不存在");
                default:
                    return ErrorActionResult("编辑失败");
            }
        }
    }
}
