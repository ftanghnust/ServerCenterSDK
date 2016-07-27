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


namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 属性值添加
    /// </summary>
    [ActionName("AttributesValues.Add")]
    public class AttributesValuesAddAction : ActionBase<AttributesValuesAddAction.AttributesValuesAddRequestDto, Int32>
    {
        /// <summary>
        /// 新增属性值DTO
        /// </summary>
        public class AttributesValuesAddRequestDto : RequestDtoBase
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
        public override ActionResult<Int32> Execute()
        {
            //根据客户端提交的JSON数据反序列化出对象
            var dto = this.RequestDto;

            //DTO转到数据库实体
            //var model = dto.MapTo<Frxs.ServiceCenter.Product.Model.Attributes>();
            AttributesValues model = new AttributesValues()
            {
                AttributeId = dto.AttributeId,
                ValuesId = dto.ValuesId,
                ValueStr = dto.ValueStr,
                //   DisplaySequence = dto.DisplaySequence,                
                IsDeleted = 0,
                CreateUserID = dto.UserId,
                CreateUserName = dto.UserName
            };


            //执行Services保存
            int result = BLL.AttributesValuesBLO.Save(model);
            if (result > 0)
            {
                return SuccessActionResult("增加成功", result);
            }

            switch (result)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistSameName:
                    return ErrorActionResult("已存在相同的规格值，请重新输入", result);
                default:
                    return ErrorActionResult("增加失败");
            }
        }
    }
}
