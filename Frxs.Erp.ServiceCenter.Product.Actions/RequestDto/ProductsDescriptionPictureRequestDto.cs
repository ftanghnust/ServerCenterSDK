
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductsDescriptionPictureRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商品母表ID
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 原图路径
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
        /// 排序(1,2,3..)
        /// </summary>
        public int OrderNumber { get; set; }

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
