using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK.Request;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK.Resp;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient;
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 消息处理类(需要重写所有的事件处理)
    /// </summary>
    public partial class DefaultMessageHandler : MessageHandler
    {
        /// <summary>
        /// 商品更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnProductChanged(object sender, ProductChangedEventAgrs e)
        {
            var request = new DataSyncBaseProductGetDetailRequest { ProductId = e.ProductId };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            var productEntity = dataContext.Products.Find(e.ProductId);
            if (null != productEntity)
            {

                #region 先删除

                //商品规格 删除
                var productsAttributes = dataContext.ProductsAttributes.Where(o => o.ProductId == productEntity.ProductId).ToList();
                foreach (var item in productsAttributes)
                {
                    dataContext.ProductsAttributes.Remove(item);
                }

                //商品规格图片 删除
                if (null == resp.Data.ProductsAttributesPicture)
                {
                    var productsAttributesPictureDel = dataContext.ProductsAttributesPictures.FirstOrDefault(o => o.ProductId == productEntity.ProductId);
                    if (null != productsAttributesPictureDel)
                    {
                        dataContext.ProductsAttributesPictures.Remove(productsAttributesPictureDel);
                    }
                }

                //商品国际条码 删除
                var productsBarCodes = dataContext.ProductsBarCodes.Where(o => o.ProductId == productEntity.ProductId).ToList();
                foreach (var item in productsBarCodes)
                {
                    dataContext.ProductsBarCodes.Remove(item);
                }


                //商品图片详情 删除
                var productsDescriptionPictures = dataContext.ProductsDescriptionPictures.Where(o => o.BaseProductId == productEntity.BaseProductId).ToList();
                foreach (var item in productsDescriptionPictures)
                {
                    dataContext.ProductsDescriptionPictures.Remove(item);
                };

                //商品文字详情删除
                if (null == resp.Data.ProductsDescription)
                {
                    var productsDescriptions = dataContext.ProductsDescriptions.FirstOrDefault(o => o.BaseProductId == productEntity.BaseProductId);
                    dataContext.ProductsDescriptions.Remove(productsDescriptions);
                }

                //商品主图 删除
                var productsPictureDetails = dataContext.ProductsPictureDetails.Where(o => o.ImageProductId == productEntity.ProductId).ToList();
                foreach (var item in productsPictureDetails)
                {
                    dataContext.ProductsPictureDetails.Remove(item);
                }

                //商品单位 删除
                var productsUnits = dataContext.ProductsUnits.Where(o => o.ProductID == productEntity.ProductId).ToList();
                foreach (var item in productsUnits)
                {
                    dataContext.ProductsUnits.Remove(item);
                }

                ////商品供应商关系 删除
                //var productsVendors = dataContext.ProductsVendors.Where(o => o.ProductId == productEntity.ProductId).ToList();
                //foreach (var item in productsVendors)
                //{
                //    dataContext.ProductsVendors.Remove(item);
                //}

                #endregion

                #region 后添加

                //商品
                resp.Data.Product.MapTo(productEntity);

                //母商品
                var baseProductsEntity = dataContext.BaseProducts.Find(productEntity.BaseProductId);
                if (null != baseProductsEntity)
                {
                    resp.Data.BaseProduct.MapTo(baseProductsEntity);
                }

                //商品规格 添加
                foreach (var productsAttribute in resp.Data.ProductsAttributes)
                {
                    dataContext.ProductsAttributes.Add(productsAttribute.MapTo<Models.ProductsAttribute>());
                }

                //商品规格图片 更改
                if (null != resp.Data.ProductsAttributesPicture)
                {
                    var productsAttributesPictures = dataContext.ProductsAttributesPictures.FirstOrDefault(o => o.ProductId == productEntity.ProductId);
                    if (null == productsAttributesPictures)
                    {
                        //商品规格图片 新增
                        resp.Data.ProductsAttributesPicture.MapTo<Models.ProductsAttributesPicture>();
                    }
                    else
                    {
                        //商品规格图片 修改
                        resp.Data.ProductsAttributesPicture.MapTo(productsAttributesPictures);
                    }
                }

                //商品国际条码新增
                foreach (var productsBarCode in productsBarCodes)
                {
                    dataContext.ProductsBarCodes.Add(productsBarCode.MapTo<Models.ProductsBarCode>());
                }

                //商品图片详情 新增
                foreach (var productsDescriptionPicture in resp.Data.ProductsDescriptionPictures)
                {
                    var entity = productsDescriptionPicture.MapTo<Models.ProductsDescriptionPicture>();
                    dataContext.ProductsDescriptionPictures.Add(entity);
                }


                //商品文字详情 新增
                if (null != resp.Data.ProductsDescription)
                {
                    resp.Data.ProductsDescription.MapTo<Models.ProductsDescription>();
                }

                //商品主图 新增
                foreach (var productsPictureDetail in resp.Data.ProductsPictureDetails)
                {
                    var entity = productsPictureDetail.MapTo<Models.ProductsPictureDetail>();
                    dataContext.ProductsPictureDetails.Add(entity);
                }

                //商品单位 新增
                foreach (var productsUnit in resp.Data.ProductsUnits)
                {
                    var entity = productsUnit.MapTo<Models.ProductsUnit>();
                    dataContext.ProductsUnits.Add(entity);
                }

                ////商品供应商关系 新增
                //foreach (var productsVendor in resp.Data.ProductsVendors)
                //{
                //    productsVendor.MapTo<Models.ProductsVendor>();
                //}

                #endregion

                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 商品创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnProductCreated(object sender, ProductCreatedEventAgrs e)
        {
            var request = new DataSyncBaseProductGetDetailRequest { ProductId = e.ProductId };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            if (null == dataContext.Products.FirstOrDefault(o => o.ProductId == e.ProductId))
            {
                DataSyncBaseProductGetDetailResp.DataSyncBaseProductGetDetailRespData data = resp.Data;

                //商品规格
                foreach (var item in data.ProductsAttributes)
                {
                    dataContext.ProductsAttributes.Add(item.MapTo<Models.ProductsAttribute>());
                }
                if (null != data.ProductsAttributesPicture)
                {
                    dataContext.ProductsAttributesPictures.Add(data.ProductsAttributesPicture.MapTo<Models.ProductsAttributesPicture>());
                }
                foreach (var item in data.ProductsBarCodes)
                {
                    dataContext.ProductsBarCodes.Add(item.MapTo<Models.ProductsBarCode>());
                }

                if (null != data.ProductsDescription)
                {
                    dataContext.ProductsDescriptions.Add(data.ProductsDescription.MapTo<Models.ProductsDescription>());
                }

                foreach (var item in data.ProductsDescriptionPictures)
                {
                    dataContext.ProductsDescriptionPictures.Add(item.MapTo<Models.ProductsDescriptionPicture>());
                }
                foreach (var item in data.ProductsPictureDetails)
                {
                    dataContext.ProductsPictureDetails.Add(item.MapTo<Models.ProductsPictureDetail>());
                }
                //dataContext.ProductsSKUNumberServices.Add(data.ProductsPictureDetails.MapTo<Models.ProductsPictureDetail>());
                foreach (var item in data.ProductsUnits)
                {
                    dataContext.ProductsUnits.Add(item.MapTo<Models.ProductsUnit>());
                }
                //foreach (var item in data.ProductsVendors)
                //{
                //    dataContext.ProductsVendors.Add(item.MapTo<Models.ProductsVendor>());
                //}
                if (null != data.Product)
                {
                    dataContext.Products.Add(data.Product.MapTo<Models.Product>());
                }
                if (null != data.BaseProduct)
                {
                    dataContext.BaseProducts.Add(data.BaseProduct.MapTo<Models.BaseProduct>());
                }
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 商品移除(只有读取商品。修改商品的状态就可以)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnProductRemoved(object sender, ProductRemovedEventAgrs e)
        {
            var request = new DataSyncBaseProductGetRequest { ProductId = e.ProductId };
            var resp = this.ApiClient.Execute(request);
            var dataContext = this.CreateBaseDataContext();
            var entity = dataContext.Products.Find(e.ProductId);
            if (null != entity)
            {
                resp.Data.MapTo(entity);
                dataContext.SaveChanges();
            }
        }
    }
}
