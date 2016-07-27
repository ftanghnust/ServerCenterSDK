using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 16:51:17
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取网仓商品信息
    /// </summary>
    [ActionName("WProducts.Get"), ActionResultCache(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY)]
    public class WProductsGetAction : ActionBase<WProductsGetAction.WProductsGetActionRequestDto, WProductsGetAction.WProductsGetActionResponsetDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号，必须填写
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品ID，必须填写
            /// </summary>
            public int ProductId { get; set; }
        }

        /// <summary>
        /// 输出对象信息
        /// </summary>
        public class WProductsGetActionResponsetDto
        {
            /// <summary>
            /// 仓库商品信息
            /// </summary>
            public WProducts WProduct { get; set; }

            /// <summary>
            /// 商品进货价对象
            /// </summary>
            public WProductsBuy WProductsBuy { get; set; }

            /// <summary>
            /// 获取仓库商品货架信息
            /// </summary>
            public Model.Shelf Shelf { get; set; }
        }

        /// <summary>
        /// 仓库包装单位对象
        /// </summary>
        public class WProductsGetActionResponsetDtoUnit
        {
            /// <summary>
            /// 商品包装单位对象
            /// </summary>
            public ProductsUnit ProductsUnit { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductsGetActionResponsetDto> Execute()
        {
            //查询条件
            var searchCondition = new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ProductID", this.RequestDto.ProductId);

            //仓商品
            var wProduct = DALFactory.GetLazyInstance<IWProductsDAO>().GetModel(searchCondition);
            if (wProduct.IsNull())
            {
                return this.ErrorActionResult("仓库商品【{0}】未找到".With(this.RequestDto.ProductId));
            }

            //返回仓库商品信息
            var responseDto = new WProductsGetActionResponsetDto()
            {
                WProduct = wProduct,
                WProductsBuy = DALFactory.GetLazyInstance<IWProductsBuyDAO>().GetModel(searchCondition),
                Shelf =
                    wProduct.ShelfID.HasValue
                        ? DALFactory.GetLazyInstance<IShelfDAO>().GetModel(wProduct.ShelfID.Value)
                        : null
            };

            //加工将包装单位详情获取出来
            return this.SuccessActionResult(responseDto);
        }
    }
}
