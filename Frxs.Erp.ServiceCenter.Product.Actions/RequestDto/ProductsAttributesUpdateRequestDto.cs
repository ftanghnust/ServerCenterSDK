using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 修改商品属性规格上传参数
    /// </summary>
    public class ProductsAttributesUpdateRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 规格属性集合
        /// </summary>
        public ICollection<ProductsAttribute> ProductsAttributes { get; set; }

        /// <summary>
        /// 商品规格图片
        /// </summary>
        public AttributesPicture ProductsAttributesPicture { get; set; }

        /// <summary>
        /// 是否多规格
        /// </summary>
        public int IsMutiAttribute { get; set; }

        /// <summary>
        /// 上传的规格属性键值对
        /// </summary>
        public class ProductsAttribute
        {
            /// <summary>
            /// 属性ID
            /// </summary>
            public int AttributeId { get; set; }
            /// <summary>
            /// 属性名称
            /// </summary>
            public string AttributeName { get; set; }
            /// <summary>
            /// 属性值ID
            /// </summary>
            public int ValuesId { get; set; }
            /// <summary>
            /// 属性的值
            /// </summary>
            public string ValueStr { get; set; }
        }

        /// <summary>
        /// 规格属性图
        /// </summary>
        public class AttributesPicture
        {
            /// <summary>
            /// 原始图
            /// </summary>
            public string ImageUrlOrg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ImageUrl400X400 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ImageUrl200X200 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ImageUrl120X120 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ImageUrl60X60 { get; set; }

        }
    }
}
