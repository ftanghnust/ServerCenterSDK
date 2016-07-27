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
    [ActionName("AttributesValues.DisplaySequence")]
    public class AttributesValuesDisplaySequenceAction : ActionBase<AttributesValuesDisplaySequenceAction.AttributesValuesDisplaySequenceRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public class AttributesValuesDisplaySequenceRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int ValuesIdA { get; set; }

            /// <summary>
            /// 主键ID
            /// </summary>
            public int ValuesIdB { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public int DisplaySequenceA { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public int DisplaySequenceB { get; set; }

         
        }



        /// <summary>
        /// 规格值上移下移
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取接口参数
            var dto = this.RequestDto;

            AttributesValues modelA = new AttributesValues()
            {
                ValuesId = dto.ValuesIdA,
                DisplaySequence = dto.DisplaySequenceA,
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                ModifyTime = DateTime.Now
            };
            AttributesValues modelB = new AttributesValues()
            {
                ValuesId = dto.ValuesIdB,
                DisplaySequence = dto.DisplaySequenceB,
                ModifyUserID = dto.UserId,
                ModifyUserName = dto.UserName,
                ModifyTime = DateTime.Now
            };

            int i = Frxs.Erp.ServiceCenter.Product.BLL.AttributesValuesBLO.DisplaySequence(modelA, modelB);
            if (i > 0)
            {
                return SuccessActionResult("移位成功", null);
            }
            switch (i)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistReference:
                    //返回失败
                    return ErrorActionResult("存在被引用的数据");
                case (int)ProductCenterEnum.ReturnResultInfo.NoExist:
                    return ErrorActionResult("数据不存在");
                default:
                    return ErrorActionResult("移位失败");
            }
        }
    }
}
