/*****************************
* Author:luojing
*
* Date:2016-03-09
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
    /// 属性添加;返回值为：添加成功后属性的ID值
    /// </summary>
    [ActionName("Attributes.Add")]
    public class AttributesAddAction : Frxs.ServiceCenter.Api.Core.ActionBase<AttributesAddAction.AttributesAddRequestDto, int>
    {
        /// <summary>
        /// 新增属性DTO
        /// </summary>
        public class AttributesAddRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 属性名称
            /// </summary>
            public string AttributeName { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //根据客户端提交的JSON数据反序列化出对象
            var dto = this.RequestDto;

            //DTO转到数据库实体
            //var model = dto.MapTo<Frxs.ServiceCenter.Product.Model.Attributes>();
            Attributes model = new Attributes()
            {
                AttributeName = dto.AttributeName,
                IsDeleted = 0,
                CreateUserID = dto.UserId,
                CreateUserName = dto.UserName
            };

            //执行Services保存
            int result = BLL.AttributesBLO.Save(model);
            if (result > 0)
            {
                //返回成功
                return SuccessActionResult("增加成功", result);
            }

            switch (result)
            {
                case (int)ProductCenterEnum.ReturnResultInfo.ExistSameName:
                    return ErrorActionResult("规格属性已存在相同名称", result);
                default:
                    return ErrorActionResult("增加失败", result);
            }
        }
    }
}
