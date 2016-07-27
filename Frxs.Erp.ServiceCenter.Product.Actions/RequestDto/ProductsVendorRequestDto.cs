/*********************************************************
 * FRXS(ISC) chujl 2015-03-23
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using System.Collections;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// ProductsVendor.Option
    /// </summary>
    public class ProductsVendorOptionActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 商品主供应商
        /// </summary>
        [Required]
        public int VendorID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int WID { get; set; }


        /// <summary>
        /// 产品IDS集合（用于设制主供应供）
        /// </summary>  
        [Required, NotEmpty]
        public List<int> ProductIds { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public override void BeforeValid()
        {
        }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }


    /// <summary>
    /// ProductsVendor.AddOrEditAction
    /// </summary>
    public class ProductsVendorAddOrEditActionRequestDto : RequestDtoBase
    {


        /// <summary>
        /// 操作类型（1为添加产品供应商关系  2为设制主供应供）
        /// </summary>
        public int? OptionType { get; set; }

        /// <summary>
        /// 商品主供应商
        /// </summary>
        [Required]
        public int VendorID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int WID { get; set; }



        /// <summary>
        /// 供应商商品关系表RequestDto
        /// </summary>
        public class ProductsVendorRequestDto
        {

            #region 模型



            /// <summary>
            /// 商品ID(product.ProductID)
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 库存单位采购价格
            /// </summary>
            public double BuyPrice { get; set; }

            /// <summary>
            /// 是否为主供应商(0:不是;1:是)
            /// </summary>
            public int IsMaster { get; set; }





            #endregion



        }


        /// <summary>
        /// 集合
        /// </summary>
        public IList<ProductsVendorRequestDto> productsVendorList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void BeforeValid()
        {
        }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    /// <summary>
    /// 商品供应商关系：更新最新采购价格
    /// </summary>
    public class ProductsVendorUpdateLastBuyPriceRequestDto : RequestDtoBase
    {


        /// <summary>
        /// 商品主供应商
        /// </summary>
        [Required]
        public int VendorID { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        public int Wid { get; set; }



        /// <summary>
        /// 供应商商品关系中更新采购价对象的集合
        /// </summary>
        public IList<ProductsVendorUnitPriceRequestDto> ProductsVendorBuyPriceList { get; set; }


        /// <summary>
        /// 供应商商品关系中更新采购价对象
        /// </summary>
        public class ProductsVendorUnitPriceRequestDto
        {

            #region 模型

            /// <summary>
            /// 商品ID(product.ProductID)
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 库存单位采购价格
            /// </summary>
            public double BuyPrice { get; set; }

            #endregion

        }


        /// <summary>
        /// 
        /// </summary>
        public override void BeforeValid()
        {
        }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }


    }

    /// <summary>
    /// ProductsVendor.GetList 查询
    /// </summary>
    public class ProductsVendorGetListActionRequestDto : PageListRequestDto
    {

        #region 模型

        /// <summary>
        /// 是否分页查询(为1表示分页，为0，NULL 不分页)
        /// </summary>
        public int? IsPage { get; set; }

        /// <summary>
        /// 主键ID
        /// </summary>
        public long? ID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int? WID { get; set; }

        /// <summary>
        /// 商品ID(product.ProductID)
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// 商品主供应商
        /// </summary>
        [Required]
        public int? VendorID { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位采购价格
        /// </summary>
        public decimal? BuyPrice { get; set; }

        /// <summary>
        /// 是否为主供应商(0:不是;1:是)
        /// </summary>
        public int? IsMaster { get; set; }

        /// <summary>
        /// 库存单位最新进价
        /// </summary>
        public double? LastBuyPrice { get; set; }

        /// <summary>
        /// 最新采购入库时间
        /// </summary>
        public DateTime? LastBuyTime { get; set; }

        /// <summary>
        /// 查询关键字，编码、条码、名称
        /// </summary>
        public string KeyWord { get; set; }

        #endregion



        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }


}
