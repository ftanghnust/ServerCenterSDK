/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 商品图片明细表ProductsPictureDetail实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsPictureDetail : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 即为：Product.ProductID
        /// </summary>
        [DataMember]
        [DisplayName("即为：Product.ProductID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ImageProductId { get; set; }

        /// <summary>
        /// 原图800*800路径(商品主图放大,商品详情图点击)
        /// </summary>
        [DataMember]
        [DisplayName("原图800*800路径(商品主图放大,商品详情图点击)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrlOrg { get; set; }

        /// <summary>
        /// zip为400*400的图路径(商品详情图)
        /// </summary>
        [DataMember]
        [DisplayName("zip为400*400的图路径(商品详情图)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl400x400 { get; set; }

        /// <summary>
        /// zip为200*200的图路径(商品列表图)
        /// </summary>
        [DataMember]
        [DisplayName("zip为200*200的图路径(商品列表图)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl200x200 { get; set; }

        /// <summary>
        /// zip为120*120的图路径
        /// </summary>
        [DataMember]
        [DisplayName("zip为120*120的图路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl120x120 { get; set; }

        /// <summary>
        /// zip为60*60的图路径(订单提交页列表小图)
        /// </summary>
        [DataMember]
        [DisplayName("zip为60*60的图路径(订单提交页列表小图)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl60x60 { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        [DisplayName("排序")]

        public int OrderNumber { get; set; }

        /// <summary>
        /// 是否为主图(只有一张;0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为主图(只有一张;0:不是;1:是)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsMaster { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion
    }
}