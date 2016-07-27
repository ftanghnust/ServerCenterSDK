using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    public class ProductsAttributesPictureAddRequestDto : RequestDtoBase
    {

        #region 模型
        /// <summary>
        /// 商品ID(Product.ProductId)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 原图800*800路径
        /// </summary>
        public string ImageUrlOrg { get; set; }

        /// <summary>
        /// zip为400*400的图路径
        /// </summary>
        public string ImageUrl400x400 { get; set; }

        /// <summary>
        /// zip为200*200的图路径
        /// </summary>
        public string ImageUrl200x200 { get; set; }

        /// <summary>
        /// zip为120*120的图路径
        /// </summary>
        public string ImageUrl120x120 { get; set; }

        /// <summary>
        /// zip为60*60的图路径
        /// </summary>
        public string ImageUrl60x60 { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        #endregion
    }
}
