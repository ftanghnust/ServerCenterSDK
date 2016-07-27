using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// 用于Action实现一些公用的方法或功能
    /// </summary>
    public class ActionCommon
    {
        /// <summary>
        /// 检查并创建品牌
        /// </summary>
        /// <param name="baseProduct"></param>
        /// <param name="createUserId"></param>
        /// <param name="createUserName"></param>
        /// <returns></returns>
        public static ActionResult CheckAndCreateBrand(BaseProductAddRequestDto baseProduct, int createUserId, string createUserName)
        {
            var result = new ActionResult();
            //if (baseProduct.BrandId1 == 0 && !string.IsNullOrWhiteSpace(baseProduct.BrandName1))
            //{
            //    var condition = new Dictionary<string, object>();
            //    condition.Add("BrandName", baseProduct.BrandName1.Trim());

            //    var brand = BrandCategoriesBLO.GetModel(condition);
            //    if (brand != null)
            //    {
            //        baseProduct.BrandId1 = brand.BrandId;
            //    }
            //    else
            //    {
            //        var newBrand = new BrandCategories();
            //        newBrand.BrandName = baseProduct.BrandName1.Trim();
            //        newBrand.CreateTime = DateTime.Now;
            //        newBrand.CreateUserID = createUserId;
            //        newBrand.CreateUserName = createUserName;
            //        newBrand.ModifyTime = DateTime.Now;
            //        newBrand.ModifyUserID = createUserId;
            //        newBrand.ModifyUserName = createUserName;
            //        var brandId = BrandCategoriesBLO.Save(newBrand);
            //        if (brandId > 0)
            //        {
            //            baseProduct.BrandId1 = brandId;
            //        }
            //        else
            //        {
            //            result.Flag = ActionResultFlag.FAIL;
            //            result.Info = "创建品牌" + baseProduct.BrandName1 + "失败";
            //            result.Data = null;
            //            return result;
            //        }
            //    }
            //}
            //if (baseProduct.BrandId2 == 0 && !string.IsNullOrWhiteSpace(baseProduct.BrandName2))
            //{
            //    var condition = new Dictionary<string, object>();
            //    condition.Add("BrandName", baseProduct.BrandName2.Trim());
            //    var brand = BrandCategoriesBLO.GetModel(condition);
            //    if (brand != null)
            //    {
            //        baseProduct.BrandId2 = brand.BrandId;
            //    }
            //    else
            //    {
            //        var newBrand = new BrandCategories();
            //        newBrand.BrandName = baseProduct.BrandName2.Trim();
            //        newBrand.CreateTime = DateTime.Now;
            //        newBrand.CreateUserID = createUserId;
            //        newBrand.CreateUserName = createUserName;
            //        newBrand.ModifyTime = DateTime.Now;
            //        newBrand.ModifyUserID = createUserId;
            //        newBrand.ModifyUserName = createUserName;
            //        var brandId = BrandCategoriesBLO.Save(newBrand);
            //        if (brandId > 0)
            //        {
            //            baseProduct.BrandId2 = brandId;
            //        }
            //        else
            //        {
            //            result.Flag = ActionResultFlag.FAIL;
            //            result.Info = "创建品牌" + baseProduct.BrandName2 + "失败";
            //            result.Data = null;
            //            return result;
            //        }
            //    }
            //}
            //result.Flag = ActionResultFlag.SUCCESS;
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrPic"></param>
        /// <returns></returns>
        public static ActionResult CheckAttributePicture(ProductsAttributesPicture attrPic)
        {
            var result = new ActionResult();
            if (attrPic != null)
            {
                if (string.IsNullOrEmpty(attrPic.ImageUrlOrg))
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性图原图不能为空";
                    return result;
                }
                if (string.IsNullOrEmpty(attrPic.ImageUrl120x120))
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性图120*120图不能为空";
                    return result;
                }
                if (string.IsNullOrEmpty(attrPic.ImageUrl200x200))
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性图200*200图不能为空";
                    return result;
                }
                if (string.IsNullOrEmpty(attrPic.ImageUrl400x400))
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性图400*400图不能为空";
                    return result;
                }
                if (string.IsNullOrEmpty(attrPic.ImageUrl60x60))
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性图60*60图不能为空";
                    return result;
                }
            }
            result.Flag = ActionResultFlag.SUCCESS;
            result.Info = "OK";
            return result;
        }


        /// <summary>
        /// 商品规格属性校验
        /// </summary>
        /// <param name="product">商品</param>
        /// <param name="baseProduct">母商品</param>
        /// <param name="attrs">商品属性</param>
        /// <param name="bAddFlag">是否添加商品</param>
        /// <returns></returns>
        public static ActionResult CheckProductAttribute(Products product, BaseProducts baseProduct, IList<ProductsAttributes> attrs, bool bAddFlag)
        {
            var result = new ActionResult();
            if (baseProduct.IsMutiAttribute == 0)
            {
                result.Flag = ActionResultFlag.SUCCESS;
                result.Info = "无规模商品不需要验证规格属性";
                result.Data = null;
            }

            //取母商品下所有子商品，判断是否有规格属性完全一致的情况
            var condition = new Dictionary<string, object>();
            condition.Add("BaseProductId", baseProduct.BaseProductId);
            var allProducts = ProductsBLO.GetList(condition);
            if (allProducts == null || allProducts.Count <= 0)
            {
                result.Flag = ActionResultFlag.FAIL;
                result.Info = "没有找到母商品信息";
                result.Data = null;
                return result;
            }

            foreach (var attr in attrs)
            {
                var count = attrs.Count(x => x.AttributeId == attr.AttributeId);
                if (count > 1)
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "规格属性错误，有" + count.ToString(CultureInfo.InvariantCulture) + "条" + attr.AttributeName + "规格属性";
                    result.Data = null;
                    return result;
                }
            }


            if (!bAddFlag)
            {
                //编辑商品时，母商品下仅有当前商品时，直接通过（该商品为唯一子商品且为母商品）
                if (allProducts.Count == 1 && allProducts[0].ProductId == product.ProductId && allProducts[0].ProductId == allProducts[0].BaseProductId)
                {
                    result.Flag = ActionResultFlag.SUCCESS;
                    result.Info = "OK";
                    result.Data = null;
                    return result;
                }
            }

            var attrsOrder = attrs.OrderBy(x => x.AttributeId);
            StringBuilder sbAttributeValues = new StringBuilder();
            StringBuilder sbAttribute = new StringBuilder();
            string attrsValues = "";
            string attrsStr = "";
            foreach (var productAttribute in attrsOrder)
            {
                sbAttributeValues.Append(productAttribute.ValuesId + ",");
                sbAttribute.Append(productAttribute.AttributeId + ",");
            }
            if (sbAttributeValues.Length > 0)
            {
                attrsValues = sbAttributeValues.ToString().Substring(0, sbAttributeValues.Length - 1);
                attrsStr = sbAttribute.ToString().Substring(0, sbAttribute.Length - 1);
            }

            var tmpOldProduct = allProducts[0];
            foreach (var productse in allProducts)
            {
                if (productse.ProductId == product.BaseProductId)
                {
                    tmpOldProduct = productse;
                    break;
                }
            }

            //bAddFlag: 新增商品时绑定到母商品时, product.ProductId != product.BaseProductId :非母商品的商品编辑时才需要验证
            if (product.ProductId != product.BaseProductId || bAddFlag)
            {
                if (attrsStr != tmpOldProduct.MutAttributes)
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "指定的母商品与商品的规格属性条数或属性不一致，无法绑定";
                    result.Data = null;
                    return result;
                }
            }
            else
            {
                if (product.ProductId == product.BaseProductId && !bAddFlag)
                {
                    if (allProducts.Count > 1 && attrsStr != tmpOldProduct.MutAttributes)
                    {
                        result.Flag = ActionResultFlag.FAIL;
                        result.Info = "指定的母商品下包含其他的子商品，不能修改规格属性";
                        result.Data = null;
                        return result;
                    }
                }
            }

            foreach (var allProduct in allProducts)
            {
                if (allProduct.MutValues == attrsValues && allProduct.MutAttributes == attrsStr && allProduct.ProductId != product.ProductId)
                {
                    result.Flag = ActionResultFlag.FAIL;
                    result.Info = "母商品下存在与当前商品规格属性完全相同的商品！";
                    result.Data = null;
                    return result;
                }
            }

            result.Flag = ActionResultFlag.SUCCESS;
            result.Info = "OK";
            result.Data = null;
            return result;

        }


    }
}
