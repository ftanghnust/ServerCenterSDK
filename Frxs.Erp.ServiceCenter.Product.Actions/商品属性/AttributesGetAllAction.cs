/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取所有属性集合
    /// </summary>
    [ActionName("Attributes.GetAll")]
    public class AttributesGetAllAction : ActionBase<AttributesGetAllAction.AttributesGetAllRequestDto, List<Attributes>>
    {
        /// <summary>
        /// 请求查询参数
        /// </summary>
        public class AttributesGetAllRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 规格名称
            /// </summary>
            public string AttributeName { get; set; }

            /// <summary>
            /// 规格Id
            /// </summary>
            public int? AttributeId { get; set; }
        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Attributes>> Execute()
        {
            var dto = this.RequestDto;

            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("IsDeleted", 0);
            if (dto.AttributeId != null && dto.AttributeId != 0)
            {
                conditionDict.Add("AttributeId", dto.AttributeId);
            }
            if (dto.AttributeName != null)
            {
                conditionDict.Add("AttributeName", dto.AttributeName);
            }
            var list = AttributesBLO.GetList(conditionDict);

            return SuccessActionResult(list.ToList());
        }
    }
}
