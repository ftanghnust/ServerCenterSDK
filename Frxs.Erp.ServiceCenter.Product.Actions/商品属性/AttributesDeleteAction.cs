/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/

using System;
using Frxs.Erp.ServiceCenter.Product.Actions;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 属性删除
    /// </summary>
    [ActionName("Attributes.Delete")]
    public class AttributesDeleteAction : ActionBase<AttributesDeleteAction.AttributesDeleteRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 删除属性DTO
        /// </summary>
        public class AttributesDeleteRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int AttributeId { get; set; }

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
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                IsDeleted = 1 //0表示正常，1表示删除
            };

            int i = BLL.AttributesBLO.LogicDelete(attr);
            if (i > 0)
            {
                return SuccessActionResult("删除成功", null);
            }

            switch (i)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistReference:
                    return ErrorActionResult("存在被引用的数据");
                case (int)ProductCenterEnum.ReturnResultInfo.ExistSameName:
                    return ErrorActionResult("此属性存在属性值");
                case (int)ProductCenterEnum.ReturnResultInfo.NoExist:
                    return ErrorActionResult("数据不存在");
                default:
                    //删除失败
                    return ErrorActionResult("删除失败");
            }
        }
    }
}
