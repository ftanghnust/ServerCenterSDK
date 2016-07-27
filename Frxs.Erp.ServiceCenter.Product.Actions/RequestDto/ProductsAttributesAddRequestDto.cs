
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品属性映射关系DTO
    /// </summary>
    public class ProductsAttributesAddRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商品ID(Product.ProductId)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 属性表ID(Attribute.AttributeId）
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// 属性值表ID(AttributeValues.ValueId）
        /// </summary>
        public int ValuesId { get; set; }


        public string AttributeName { get; set; }


        public string ValueStr { get; set; }
        /// <summary>
        /// 最新修改时间
        /// </summary>
        public string ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }
    }
}
