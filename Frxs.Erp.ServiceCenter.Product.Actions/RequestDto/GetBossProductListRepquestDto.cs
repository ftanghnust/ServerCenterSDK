using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 列表传入参数
    /// </summary>
    public class GetBossProductListRepquestDto : RequestDtoBase
    {
        /// <summary>
        /// <![CDATA[
        /// 商品ID；如果不传入可以直接设置为null或者new List<int>(){}
        /// ]]>
        /// </summary> 
        public IList<int> ProductIds { get; set; }

        /// <summary>
        /// 母商品编码
        /// </summary>
        public int? BaseProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 品牌ID1
        /// </summary>
        public int? BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID2
        /// </summary>
        public int? BrandId2 { get; set; }

        /// <summary>  
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }

        ///// <summary>
        ///// ERP编码
        ///// </summary>
        //public string ErpCode { get; set; }

        /// <summary>
        /// 一级基本分类
        /// </summary>
        public int? CategoriesID1 { get; set; }

        /// <summary>
        ///二级基本分类
        /// </summary>
        public int? CategoriesID2 { get; set; }

        /// <summary>
        ///二级基本分类
        /// </summary>
        public int? CategoriesID3 { get; set; }

        /// <summary>
        /// 一级运营分类
        /// </summary>
        public int? ShopCategoriesID1 { get; set; }

        /// <summary>
        /// 二级运营分类
        /// </summary>
        public int? ShopCategoriesID2 { get; set; }

        /// <summary>
        /// 二级运营分类
        /// </summary>
        public int? ShopCategoriesID3 { get; set; }

        /// <summary>
        /// 商品ERP编码
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int? Status { get; set; }

        ///// <summary>
        ///// 是否是第三方商品：0为否 1为是
        ///// </summary>
        //public int? IsVendor { get; set; }

        /// <summary>
        /// 母商品名称关键词
        /// </summary>
        public string ProductBaseName { get; set; }

        /// <summary>
        /// 是否是母商品：0为否，1为是
        /// </summary>
        public int? IsBaseProductId { get; set; }

        /// <summary>
        /// 当前页(默认1)
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 分页大小（默认10）
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 是否仅查询母商品
        /// </summary>
        public bool IsOnlyBaseProduct { get; set; }

        /// <summary>
        /// 规格属性ID串
        /// </summary>
        public string MutAttributes { get; set; }

        /// <summary>
        /// 是否多格式属性
        /// </summary>
        public int? IsMutiAttribute { get; set; }

        ///// <summary>
        ///// 零售价1
        ///// </summary>
        //public double? SalePrice1 { get; set; }

        ///// <summary>
        ///// 零售价2(零售价2必须大于登录零售价1)
        ///// </summary>
        //public double? SalePrice2 { get; set; }

        /// <summary>
        /// 图片库里的商品ID(即此商品主图保存在商品主图库里的商品ID)
        /// </summary>
        public int? ImageProductId { get; set; }

        /// <summary>
        /// 验证之前赋值
        /// </summary>
        public override void BeforeValid()
        {
          

        }
    }
}
