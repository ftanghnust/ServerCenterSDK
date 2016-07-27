using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 商品仓库价格获取列表
    /// </summary>
    [ActionName("Products.WarehousePrice.Get")]
    public class ProductWarehousePriceGetAction : ActionBase<ProductWarehousePriceGetAction.ProductWarehousePriceGetActionRequestDto, List<ProductWarehousePriceGetAction.ProductWarehousePriceGetActionResponseDto>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ProductWarehousePriceGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 商品ID
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 网仓ID，可以为空，如果为空，则会返回当前商品所有仓库的价格信息
            /// </summary>
            public int? WID { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class ProductWarehousePriceGetActionResponseDto
        {
            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProdcutId { get; set; }

            /// <summary>
            /// 仓库商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 仓库名称
            /// </summary>
            public string WName { get; set; }

            /// <summary>
            /// 供应商ID
            /// </summary>
            public int VendorID { get; set; }

            /// <summary>
            /// 主供应商
            /// </summary>
            public string VendorName { get; set; }

            /// <summary>
            /// 仓库库存
            /// </summary>
            public decimal WStock { get; set; }

            /// <summary>
            /// 进货价
            /// </summary>
            public decimal BuyPrice { get; set; }

            /// <summary>
            /// 建议门店零售价
            /// </summary>
            public decimal MarketPrice { get; set; }

            /// <summary>
            /// 批发价
            /// </summary>
            public decimal SalePrice { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ProductWarehousePriceGetActionResponseDto>> Execute()
        {
            //查询网仓商品信息
            var queryConditions = new Dictionary<string, object>();
            queryConditions.Add("ProductId", this.RequestDto.ProductId);
            if (this.RequestDto.WID.HasValue)
            {
                queryConditions.Add("WID", this.RequestDto.WID.Value);
            }

            //获取所有的仓库商品信息
            var wproducts = DALFactory.GetLazyInstance<IWProductsDAO>().GetList(queryConditions);

            //输出对象
            List<ProductWarehousePriceGetActionResponseDto> data = new List<ProductWarehousePriceGetActionResponseDto>();
            IWProductsBuyDAO iWProductsBuy = DALFactory.GetLazyInstance<IWProductsBuyDAO>();
            IVendorDAO iVendor = DALFactory.GetLazyInstance<IVendorDAO>();
            IWarehouseDAO iWarehouse = DALFactory.GetLazyInstance<IWarehouseDAO>();

            //商品各仓库价格查询
            foreach (var item in wproducts)
            {
                //商品仓库采购价
                var wproductsBuy = iWProductsBuy.GetModel(new Dictionary<string, object>()
                    .Append("ProductId", item.ProductId)
                    .Append("WID", item.WID));

                //供应商
                var vendor = iVendor.GetModel(wproductsBuy.VendorID);

                //仓库信息
                var warehouse = iWarehouse.GetModel(item.WID);

                //输出对象
                var respDto = new ProductWarehousePriceGetActionResponseDto()
                {
                    ProdcutId = item.ProductId,
                    ProductName = item.ProductName2,
                    WID = item.WID,
                    WName = warehouse.IsNull() ? null : warehouse.WName,
                    VendorID = wproductsBuy.VendorID,
                    VendorName = vendor.IsNull() ? null : vendor.VendorName,
                    BuyPrice = wproductsBuy.IsNull() ? -1 : (decimal)wproductsBuy.BuyPrice,
                    MarketPrice = (decimal)item.MarketPrice,
                    SalePrice = (decimal)item.SalePrice,
                    WStock = 0
                };

                data.Add(respDto);
            }

            //返回数据
            return SuccessActionResult(data);
        }

    }
}
