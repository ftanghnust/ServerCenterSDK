using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 编辑商品库商品
    /// </summary>
    [ActionName("Product.Edit")]
    public class ProductEditAction : ActionBase<ProductsAddPackageRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;

            if (obj.Product == null)
            {
                return ErrorActionResult("没有指定商品信息");
            }

            var product = obj.Product.MapTo<Products>();
            product.ModifyTime = DateTime.Now;
            product.ModifyUserID = obj.CreateUserID;
            product.ModifyUserName = obj.CreateUserName;
            product.ProductId = obj.ProductId;
            product.BaseProductId = obj.BaseProductId;

            var attrs = new List<ProductsAttributes>();
            var pics = new List<ProductsPictureDetail>();
            var attrPic = obj.ProductsAttributesPicture.MapTo<ProductsAttributesPicture>();
            attrPic.CreateTime = DateTime.Now;
            attrPic.CreateUserID = obj.CreateUserID;
            attrPic.CreateUserName = obj.CreateUserName;
            attrPic.ProductId = product.ProductId;


            var oldProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId), () =>
                                                    ProductsBLO.GetModel(product.ProductId));

            if (oldProduct == null)
            {
                return ErrorActionResult("没有找到原来的商品信息");
            }

            if (string.IsNullOrEmpty(product.Keywords))
            {
                product.Keywords = oldProduct.Keywords;
            }
            if (product.ImageProductId <= 0)
            {
                product.ImageProductId = oldProduct.ImageProductId;
            }
            if (product.ImageProductId <= 0)
            {
                product.ImageProductId = product.ProductId;
            }

            product.CreateUserID = oldProduct.CreateUserID;
            product.CreateUserName = oldProduct.CreateUserName;
            product.CreateTime = oldProduct.CreateTime;


            var oldBaseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(oldProduct.BaseProductId), () =>
                                                   BaseProductsBLO.GetModel(oldProduct.BaseProductId, false));

            if (oldBaseProduct == null)
            {
                return ErrorActionResult("没有找到原来的母商品");
            }

            var baseProduct = obj.BaseProduct.MapTo<BaseProducts>();
            if (baseProduct == null || obj.Flag == 6) //没有传入新的母商品信息，取原来的
            {
                baseProduct = oldBaseProduct;
            }
            else
            {
                if (baseProduct.IsBaseProductId == 1 && string.IsNullOrEmpty(baseProduct.ProductBaseName))
                {
                    return this.ErrorActionResult("母商品名不能为空");
                }

                //传入了新的母商品信息，但母商品的IsVendor仍需使用原来的值
                //页面无法判断即时的IsVendor信息，交由接口查询当前信息回赋
                baseProduct.IsVendor = oldBaseProduct.IsVendor;
                var brandResult = ActionCommon.CheckAndCreateBrand(obj.BaseProduct, obj.UserId, obj.UserName);
                if (brandResult.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(brandResult.Info);
                }
            }
            baseProduct.ModifyTime = DateTime.Now;
            baseProduct.ModifyUserID = obj.CreateUserID;
            baseProduct.ModifyUserName = obj.CreateUserName;
            baseProduct.BaseProductId = obj.BaseProductId;
            baseProduct.CreateTime = oldBaseProduct.CreateTime;
            baseProduct.CreateUserID = oldBaseProduct.CreateUserID;
            baseProduct.CreateUserName = oldBaseProduct.CreateUserName;


            //存在母商品，且现有母商品与原母品规格属性不一致
            if (baseProduct.IsBaseProductId == 1 && baseProduct.IsMutiAttribute != oldBaseProduct.IsMutiAttribute)
            {
                return ErrorActionResult("不能将商品由多规格改为无规格或者由无规格改为多规格");
            }

            baseProduct.BaseProductId = oldBaseProduct.BaseProductId;

            if (baseProduct.IsBaseProductId == 0 && product.ProductId != product.BaseProductId)
            {
                return ErrorActionResult("指定的母商品不能包含子商品");
            }

            #region 商品图片
            if (obj.IsBaseProductPicture == 0 && obj.Flag == 6)
            {
                product.ImageProductId = obj.BaseProductId;
                pics = null;
            }
            else
            {
                int tmpOrder = 0;
                if (obj.IsBaseProductPicture == 0)
                {
                    product.ImageProductId = obj.BaseProductId;
                }
                else
                {
                    product.ImageProductId = product.ProductId;
                }
                if (obj.ProductsPictureDetails != null)
                {
                    foreach (var productsPictureDetail in obj.ProductsPictureDetails)
                    {
                        var pic = productsPictureDetail.MapTo<ProductsPictureDetail>(false, true);
                        pic.CreateUserID = obj.CreateUserID;
                        pic.CreateUserName = obj.CreateUserName;
                        pic.CreateTime = DateTime.Now;
                        tmpOrder++;
                        pic.OrderNumber = tmpOrder;
                        pic.ImageProductId = product.ImageProductId;
                        pics.Add(pic);
                    }
                }
            }

            #endregion


            //存在母商品，且现有母商品与原母品规格属性不一致
            if (baseProduct.IsBaseProductId == 1 && baseProduct.IsMutiAttribute != oldBaseProduct.IsMutiAttribute)
            {
                return ErrorActionResult("不能将商品由多规格改为无规格或者由无规格改为多规格");
            }
            baseProduct.BaseProductId = oldBaseProduct.BaseProductId;


            if (baseProduct.IsMutiAttribute == 1)
            {
                #region 规格属性赋值
                if (obj.ProductsAttributes != null)
                {
                    foreach (var attrDto in obj.ProductsAttributes)
                    {
                        var attr = attrDto.MapTo<ProductsAttributes>(false, true);
                        var tmpCount = obj.ProductsAttributes.Count(x => x.AttributeId == attr.AttributeId);
                        if (tmpCount > 1)
                        {
                            return ErrorActionResult("传入的规格属性中有重复的规格");
                        }

                        attr.ModifyUserID = obj.CreateUserID;
                        attr.ModifyUserName = obj.CreateUserName;
                        attr.ModifyTime = DateTime.Now;
                        attr.ProductId = product.ProductId;
                        if (string.IsNullOrEmpty(attr.AttributeName))
                        {
                            var tmpAttr = AttributesBLO.GetModel(attr.AttributeId);
                            if (tmpAttr != null)
                            {
                                attr.AttributeName = tmpAttr.AttributeName;
                            }
                            else
                            {
                                return ErrorActionResult("没有找到规格属性名");
                            }
                        }
                        if (string.IsNullOrEmpty(attr.ValueStr))
                        {
                            var tmpValue = AttributesValuesBLO.GetModel(attr.ValuesId);
                            if (tmpValue != null)
                            {
                                attr.ValueStr = tmpValue.ValueStr;
                            }
                            else
                            {
                                return ErrorActionResult("没有找到规格属性值名称");
                            }
                        }
                        attrs.Add(attr);
                    }
                }
                #endregion

                var result = ActionCommon.CheckProductAttribute(product, baseProduct, attrs, false);
                if (result.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(result.Info);
                }

                #region 规格属性图校验
                var picCheckResult = ActionCommon.CheckAttributePicture(attrPic);
                if (picCheckResult.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(picCheckResult.Info);
                }

                #endregion
            }
            else
            {
                attrs = null;
                attrPic = null;
            }

            var codes = new List<ProductsBarCodes>();
            if (obj.ProductsBarCodes != null && obj.ProductsBarCodes.Count > 0)
            {
                foreach (var productsBarCode in obj.ProductsBarCodes)
                {
                    var code = productsBarCode.MapTo<ProductsBarCodes>();
                    code.CreateTime = DateTime.Now;
                    code.CreateUserID = obj.CreateUserID;
                    code.CreateUserName = obj.CreateUserName;
                    code.ProductId = product.ProductId;
                    codes.Add(code);
                }
            }

            var productunits = new List<ProductsUnit>();
            if (obj.ProductsUnits != null && obj.ProductsUnits.Count > 0)
            {
                foreach (var productsUnit in obj.ProductsUnits)
                {
                    var unit = productsUnit.MapTo<ProductsUnit>();
                    unit.ModifyTime = DateTime.Now;
                    unit.ModifyUserID = obj.CreateUserID;
                    unit.ModifyUserName = obj.CreateUserName;
                    unit.ProductID = product.ProductId;
                    productunits.Add(unit);
                }
            }


            var data = ProductsBLO.ProductEdit(baseProduct, product, attrs, pics, attrPic, codes, productunits);
            if (!data.IsSuccess)
            {
                return ErrorActionResult(data.Message);
            }
            else
            {
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(product.ImageProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTES_LIST_KEY.With(product.ProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTEPICTURE_KEY.With(product.ProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTVENDORS_LIST_KEY.With(product.BaseProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTUNITS_LIST_KEY.With(product.ProductId));
                return SuccessActionResult("编辑商品成功", null);
            }

        }
    }
}
