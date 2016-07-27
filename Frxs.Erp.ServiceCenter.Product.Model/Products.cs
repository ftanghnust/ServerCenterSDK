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
    /// Products实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Products : BaseModel
    {

        #region 模型
        /// <summary>
        /// 商品ID(主键)SKUNumberService.ID取得
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(主键)SKUNumberService.ID取得")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// Erp编码/商品编码(手工输入)
        /// </summary>
        [DataMember]
        [DisplayName("Erp编码/商品编码(手工输入)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [DisplayName("商品名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品副标题
        /// </summary>
        [DataMember]
        [DisplayName("商品副标题")]

        public string ProductName2 { get; set; }

        /// <summary>
        /// 母商品ID(BaseProduct.BaseProductId)
        /// </summary>
        [DataMember]
        [DisplayName("母商品ID(BaseProduct.BaseProductId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BaseProductId { get; set; }

        /// <summary>
        /// l对应产品的图片,对应商品的Product.ProductId
        /// </summary>
        [DataMember]
        [DisplayName("l对应产品的图片,对应商品的Product.ProductId")]

        public int ImageProductId { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        [DataMember]
        [DisplayName("助记码")]

        public string Mnemonic { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        [DataMember]
        [DisplayName("搜索关键字")]

        public string Keywords { get; set; }

        /// <summary>
        /// 删除状态(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("删除状态(0:未删除;1:已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售])
        /// </summary>
        [DataMember]
        [DisplayName("总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售])")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 天下图库的商品ID(从天下图库创建时，带有该ID）
        /// </summary>
        [DataMember]
        [DisplayName("天下图库的商品ID(从天下图库创建时，带有该ID）")]

        public string TXTKID { get; set; }

        /// <summary>
        /// 多规格属性id:,多个时按分号分开
        /// </summary>
        [DataMember]
        [DisplayName("多规格属性id:,多个时按分号分开")]

        public string MutAttributes { get; set; }

        /// <summary>
        /// 多规格属性值id,多个时按分号分开
        /// </summary>
        [DataMember]
        [DisplayName("多规格属性值id,多个时按分号分开")]

        public string MutValues { get; set; }

        /// <summary>
        /// 销售退货标识(数据字典：SaleBackFlag)
        /// </summary>
        [DataMember]
        [DisplayName("销售退货标识(数据字典：SaleBackFlag)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SaleBackFlag { get; set; }

        /// <summary>
        /// 最小单位体积(cm)
        /// </summary>
        [DataMember]
        [DisplayName("最小单位体积(cm)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal Volume { get; set; }

        /// <summary>
        /// 最小单位重量(kg)
        /// </summary>
        [DataMember]
        [DisplayName("最小单位重量(kg)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal Weight { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]
        public string ModifyUserName { get; set; }



        /// <summary>
        /// 多少天可退只有saleBackFlag=3时，才有值
        /// </summary>
        [DataMember]
        [DisplayName("多少天可退")]
        public int BackDays { get; set; }


        /// <summary>
        /// 扩展标识1
        /// </summary>
        [DataMember]
        [DisplayName("扩展标识1")]
        public string  VExt1 { get; set; }


        /// <summary>
        /// 扩展标识2
        /// </summary>
        [DataMember]
        [DisplayName("扩展标识2")]
        public string VExt2 { get; set; }


        #endregion
    }


}