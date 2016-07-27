/*****************************
* Author:luojing
*
* Date:2016-03-14
******************************/
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 添加商品库商品接口
    /// </summary>
    [ActionName("Product.Add")]
    public class ProductAddAction : ActionBase<ProductsAddPackageRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑。返回商品编号
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var result = new ActionResult();

            var obj = this.RequestDto;

            //品牌反查
            if (obj.BaseProduct != null)
            {
                if (obj.Flag == 1 || obj.Flag == 2)
                {
                    IBrandCategoriesDAO iBrandCategories = DALFactory.GetLazyInstance<IBrandCategoriesDAO>();
                    if (obj.BaseProduct.BrandId1 == 0 && !string.IsNullOrWhiteSpace(obj.BaseProduct.BrandName1))
                    {
                        var condition = new Dictionary<string, object>();
                        condition.Add("BrandName", obj.BaseProduct.BrandName1.Trim());
                        var brand = iBrandCategories.GetModel(condition);
                        if (brand != null)
                        {
                            obj.BaseProduct.BrandId1 = brand.BrandId;
                        }
                        else
                        {
                            var newBrand = new BrandCategories();
                            newBrand.BrandName = obj.BaseProduct.BrandName1.Trim();
                            newBrand.CreateTime = DateTime.Now;
                            newBrand.CreateUserID = obj.CreateUserID;
                            newBrand.CreateUserName = obj.CreateUserName;
                            newBrand.ModifyTime = DateTime.Now;
                            newBrand.ModifyUserID = obj.CreateUserID;
                            newBrand.ModifyUserName = obj.CreateUserName;
                            var brandId = iBrandCategories.Save(newBrand);
                            if (brandId > 0)
                            {
                                obj.BaseProduct.BrandId1 = brandId;
                                this.CacheManager.Remove(Frxs.Platform.Utility.ConstDefinition.CACHE_BRAND_LIST_KEY);
                            }
                            else
                            {
                                return ErrorActionResult("创建品牌" + obj.BaseProduct.BrandName1 + "失败");
                            }
                        }
                    }
                    if (obj.BaseProduct.BrandId2 == 0 && !string.IsNullOrWhiteSpace(obj.BaseProduct.BrandName2))
                    {
                        var condition = new Dictionary<string, object>();
                        condition.Add("BrandName", obj.BaseProduct.BrandName2.Trim());
                        var brand = iBrandCategories.GetModel(condition);
                        if (brand != null)
                        {
                            obj.BaseProduct.BrandId2 = brand.BrandId;
                        }
                        else
                        {
                            var newBrand = new BrandCategories();
                            newBrand.BrandName = obj.BaseProduct.BrandName2.Trim();
                            newBrand.CreateTime = DateTime.Now;
                            newBrand.CreateUserID = obj.CreateUserID;
                            newBrand.CreateUserName = obj.CreateUserName;
                            newBrand.ModifyTime = DateTime.Now;
                            newBrand.ModifyUserID = obj.CreateUserID;
                            newBrand.ModifyUserName = obj.CreateUserName;
                            var brandId = iBrandCategories.Save(newBrand);
                            if (brandId > 0)
                            {
                                obj.BaseProduct.BrandId2 = brandId;
                                this.CacheManager.Remove(Frxs.Platform.Utility.ConstDefinition.CACHE_BRAND_LIST_KEY);
                            }
                            else
                            {
                                return ErrorActionResult("创建品牌" + obj.BaseProduct.BrandName2 + "失败");
                            }
                        }
                    }
                }
            }

            var baseProduct = new BaseProducts();
            switch (obj.Flag)
            {
                case 1: //不关联母商品，新建一个
                    baseProduct = obj.BaseProduct.MapTo<BaseProducts>(false, true);
                    baseProduct.CreateTime = DateTime.Now;
                    baseProduct.CreateUserID = obj.CreateUserID;
                    baseProduct.CreateUserName = obj.CreateUserName;
                    baseProduct.ModifyTime = DateTime.Now;
                    baseProduct.ModifyUserID = obj.CreateUserID;
                    baseProduct.ModifyUserName = obj.CreateUserName;
                    baseProduct.ProductBaseName = "";
                    baseProduct.IsBaseProductId = (int)ProductCenterEnum.BaseProductIsBaseProductId.不是;
                    break;
                case 2://新建母商品
                    baseProduct = obj.BaseProduct.MapTo<BaseProducts>(false, true);
                    baseProduct.CreateTime = DateTime.Now;
                    baseProduct.CreateUserID = obj.CreateUserID;
                    baseProduct.CreateUserName = obj.CreateUserName;
                    baseProduct.ModifyTime = DateTime.Now;
                    baseProduct.ModifyUserID = obj.CreateUserID;
                    baseProduct.ModifyUserName = obj.CreateUserName;
                    if (string.IsNullOrEmpty(baseProduct.ProductBaseName))
                    {
                        baseProduct.ProductBaseName = obj.Product.ProductName;
                    }
                    baseProduct.IsBaseProductId = (int)ProductCenterEnum.BaseProductIsBaseProductId.是;
                    //母商品必然是多规格的~
                    baseProduct.IsMutiAttribute = (int)ProductCenterEnum.BaseProductIsMutiAttribute.是;
                    break;
                case 3://关联母商品
                    baseProduct.BaseProductId = obj.BaseProductId;
                    baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(obj.BaseProductId), () =>
                                                        BaseProductsBLO.GetModel(obj.BaseProductId, false));
                    if (baseProduct == null)
                    {
                        return ErrorActionResult("没有找到母商品");
                    }
                    if (baseProduct.IsBaseProductId == 0)
                    {
                        return ErrorActionResult("没有这个母商品");
                    }
                    if (baseProduct.IsMutiAttribute == 0)
                    {
                        return ErrorActionResult("不能将商品关联到一个无规格的母商品上");
                    }
                    break;
                default:
                    return this.ErrorActionResult("没有指定母商品类型");
            }

            var product = obj.Product.MapTo<Products>(false, true);

            var attrs = new List<ProductsAttributes>();
            var pics = new List<ProductsPictureDetail>();
            var attrPic = obj.ProductsAttributesPicture.MapTo<ProductsAttributesPicture>(false, true);

            if (baseProduct.IsMutiAttribute == 1 && obj.ProductsAttributes != null)
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


            if (obj.IsBaseProductPicture == 0 && obj.Flag == 3)
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
                    product.ImageProductId = 0;
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
                        pics.Add(pic);
                    }
                }
            }

            #region //关联母商品需要进行一些校验
            if (obj.Flag == 3)
            {
                var newBaseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(obj.BaseProductId), () =>
                                                        BaseProductsBLO.GetModel(obj.BaseProductId, false));
                if (newBaseProduct == null)
                {
                    return ErrorActionResult("没有找到这个母商品");

                }
                if (newBaseProduct.IsBaseProductId != 1)
                {
                    return ErrorActionResult("指定的母商品不能包含子商品");
                }

                result = ActionCommon.CheckProductAttribute(product, newBaseProduct, attrs, true);
                if (result.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(result.Info);
                }

            }
            #endregion

            product.CreateTime = DateTime.Now;
            product.CreateUserID = obj.CreateUserID;
            product.CreateUserName = obj.CreateUserName;
            product.ModifyTime = DateTime.Now;
            product.ModifyUserID = obj.CreateUserID;
            product.ModifyUserName = obj.CreateUserName;
            attrPic.CreateTime = DateTime.Now;
            attrPic.CreateUserID = obj.CreateUserID;
            attrPic.CreateUserName = obj.CreateUserName;

            if (baseProduct.IsMutiAttribute == 0)
            {
                attrPic = null;
            }

            var picCheckResult = ActionCommon.CheckAttributePicture(attrPic);
            if (picCheckResult.Flag != ActionResultFlag.SUCCESS)
            {
                return ErrorActionResult(picCheckResult.Info);
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
                    codes.Add(code);
                }
            }

            //添加商品单位处理逻辑
            var productUnits = new List<ProductsUnit>();
            if (obj.ProductsUnits != null && obj.ProductsUnits.Count > 0)
            {
                foreach (var productUnit in obj.ProductsUnits)
                {
                    var productunit = productUnit.MapTo<ProductsUnit>();
                    productunit.ModifyTime = DateTime.Now;
                    productunit.ModifyUserID = obj.CreateUserID;
                    productunit.ModifyUserName = obj.CreateUserName;
                    productUnits.Add(productunit);
                }
            }

            //执行新增操作功能
            var data = ProductsBLO.ProductAdd(baseProduct, product, attrs, pics, attrPic, codes, productUnits);
            if (!data.IsSuccess)
            {
                result.Flag = ActionResultFlag.FAIL;
                result.Info = data.Message;
                var tmp = new { ProductId = data.Data };
                result.Data = tmp;
                return ErrorActionResult(data.Message);
            }

            //设置缓存信息
            product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(data.Data), ()
                => ProductsBLO.ProductsGet(data.Data));
            baseProduct = BaseProductsBLO.GetModel(product.BaseProductId, false);
            if (baseProduct != null)
            {
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(baseProduct.BaseProductId));
                this.CacheManager.Set(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(baseProduct.BaseProductId), baseProduct, 60 * 24 * 30);
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTVENDORS_LIST_KEY.With(baseProduct.BaseProductId));
            }
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(product.ImageProductId));
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTUNITS_LIST_KEY.With(data.Data));


            return SuccessActionResult("添加商品成功", data.Data);


        }

    }
}
