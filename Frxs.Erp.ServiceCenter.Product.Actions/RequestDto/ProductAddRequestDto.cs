using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ProductAddRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 添加完成后会带回
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品名称2
        /// </summary>
        public string ProductName2 { get; set; }

        /// <summary>
        /// 天下图库ID
        /// </summary>
        public string TXTKID { get; set; }

        ///// <summary>
        ///// ERPCODE
        ///// </summary>
        //public string ErpCode { get; set; }

        /// <summary>
        /// 商品关键词
        /// </summary>
        public string Keywords { get; set; }

        ///// <summary>
        ///// 最高限价
        ///// </summary>
        //public decimal? MarketPrice { get; set; }

        ///// <summary>
        ///// 零售价
        ///// </summary>
        //public decimal? SalePrice { get; set; }

        ///// <summary>
        ///// 删除状态(0:未删除;1:已删除)
        ///// </summary>
        //public int IsDeleted { get; set; }

        /// <summary>
        /// 总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售])
        /// </summary>
        public int Status { get; set; }


        ///// <summary>
        ///// 多规格属性id:,多个时按分号分开
        ///// </summary>
        //public string MutAttributes { get; set; }

        ///// <summary>
        ///// 多规格属性值id,多个时按分号分开
        ///// </summary>
        //public string MutValues { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        public string Mnemonic { get; set; }

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

        ///// <summary>
        ///// 第三方供应商ID
        ///// </summary>
        //public int VendorID { get; set; }

        /// <summary>
        /// ERP编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品图片对应的ID
        /// </summary>
        public int ImageProductId { get; set; }

        ///// <summary>
        ///// 商品图片集合
        ///// </summary>
        //public ICollection<string> Imgs { get; set; }

        /// <summary>
        /// 扩展标识1
        /// </summary>
        public string VExt1 { get; set; }


        /// <summary>
        /// 扩展标识2
        /// </summary>
        public string VExt2 { get; set; }

    }
}
