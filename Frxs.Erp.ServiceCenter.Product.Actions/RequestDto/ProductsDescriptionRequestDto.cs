using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductsDescriptionRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 商品母表ID（初始值和BaseProduct.BaseProductID一样)
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        public string ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 子商品ID
        /// </summary>
        public int ProductId { get; set; }

        #endregion
    }
}
