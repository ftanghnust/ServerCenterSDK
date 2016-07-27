using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product
{
    /// <summary>
    /// 商品返回对象
    /// </summary>
    public partial class ProductResponseDto
    {
        #region 模型
        /// <summary>
        /// 商品ID(主键)SKUNumberService.ID取得
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Erp编码/商品编码(手工输入)
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品副标题
        /// </summary>
        public string ProductName2 { get; set; }

        /// <summary>
        /// 母商品ID(BaseProduct.BaseProductId)
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// l对应产品的图片,对应商品的Product.ProductId
        /// </summary>
        public int ImageProductId { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        public string Mnemonic { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 删除状态(0:未删除;1:已删除)
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售])
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 天下图库的商品ID(从天下图库创建时，带有该ID）
        /// </summary>
        public string TXTKID { get; set; }

        /// <summary>
        /// 多规格属性id:,多个时按分号分开
        /// </summary>
        public string MutAttributes { get; set; }

        /// <summary>
        /// 多规格属性值id,多个时按分号分开
        /// </summary>
        public string MutValues { get; set; }

        /// <summary>
        /// 销售退货标识(数据字典：SaleBackFlag)
        /// </summary>
        public string SaleBackFlag { get; set; }

        /// <summary>
        /// 最小单位体积(cm)
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 最小单位重量(kg)
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }


        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 多少天可退只有saleBackFlag=3时，才有值
        /// </summary>
        public int BackDays { get; set; }


        /// <summary>
        /// 扩展标识1
        /// </summary>
        public string VExt1 { get; set; }


        /// <summary>
        /// 扩展标识2
        /// </summary>
        public string VExt2 { get; set; }


        #endregion
    }


    public partial class ProductResponseDto
    {
        /// <summary>
        /// 国际条码集合
        /// </summary>
        public IEnumerable<ProductsBarCodes> ProductsBarCodeList { get; set; }

        /// <summary>
        /// 商品单位集合
        /// </summary>
        public IEnumerable<ProductsUnit> ProductsUnitList { get; set; }

        /// <summary>
        /// 商品规格集合
        /// </summary>
        public IEnumerable<ProductsAttributes> ProductsAttributeList { get; set; }

        /// <summary>
        /// 商品规格图片对象
        /// </summary>
        public ProductsAttributesPicture ProductsAttributesPicture { get; set; }

        /// <summary>
        /// 商品主图集合
        /// </summary>
        public IEnumerable<ProductsPictureDetail> ProductsPictureDetailList { get; set; }

    }


}
