using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Erp.ServiceCenter.Product.SDK.Request;
using Frxs.Erp.ServiceCenter.Product.SDK.Resp;
using Frxs.Erp.ServiceCenter.Promotion.SDK.Request;
using Frxs.Erp.ServiceCenter.Promotion.SDK.Resp;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
  public class OrderPartsServer
  {
      /// <summary>
      /// 获取门店信息  admin erp123456 xsck erp2016
      /// </summary>
      /// <param name="shopId">门店ID</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public FrxsErpProductShopGetResp.FrxsErpProductShopGetRespData GetShopInfo(int shopId, int userId, string userName)
      {
          var client = WorkContext.CreateProductSdkClient();
          var req = new FrxsErpProductShopGetRequest()
          {
              ShopID = shopId,
              UserName = userName,
              UserId = userId
          };
          var resp = client.Execute(req);
          if (resp == null)
          {
              throw new Exception("查询门店信息失败");
          }
          if (resp.Flag != 0)
          {
              return null;
          }
          else
          {
              return resp.Data;
          }
      }

      /// <summary>
      /// 取线路信息
      /// </summary>
      /// <param name="lineId">线路ID</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public FrxsErpProductWarehouseLineGetResp.FrxsErpProductWarehouseLineGetRespData GetWLineInfo(int lineId, int userId, string userName)
      {
          var client = WorkContext.CreateProductSdkClient();
          var req = new FrxsErpProductWarehouseLineGetRequest()
          {
              LineID = lineId,
              UserName = userName,
              UserId = userId
          };
          var resp = client.Execute(req);
          if (resp == null)
          {
              throw new Exception("查询线路信息失败");
          }
          if (resp.Flag != 0)
          {
              return null;
          }
          else
          {
              return resp.Data;
          }
      }


      /// <summary>
      /// 获取门店返点列表情况
      /// </summary>
      /// <param name="wid">仓库ID</param>
      /// <param name="shopId">门店ID</param>
      /// <param name="productIds">商品ID串</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public IList<FrxsErpPromotionWProductPromotionDetailsListModelGetResp.FrxsErpPromotionWProductPromotionDetailsListModelGetRespData> GetPromotionRebate(int wid, int shopId, IList<int> productIds, int userId, string userName)
      {
          var productStr = "";
          foreach (var productId in productIds)
          {
              productStr += productId + ",";
          }
          productStr = productStr.Substring(0, productStr.Length - 1);
          var client = WorkContext.CreatePromotionSdkClient();
          var promotionDetails = client.Execute(new Frxs.Erp.ServiceCenter.Promotion.SDK.Request.FrxsErpPromotionWProductPromotionDetailsListModelGetRequest()
          {
              WID = wid,
              ShopID = shopId,
              ProductIDList = productStr,
              PromotionType = 2,
              UserId = userId,
              UserName = userName
          });
          if (promotionDetails == null)
          {
              throw new Exception("查询返点信息失败");
          }
          if (promotionDetails.Flag != 0)
          {
              return null;
          }
          else
          {
              return promotionDetails.Data;
          }
      }

      /// <summary>
      /// 获取仓库商品列表
      /// </summary>
      /// <param name="Wid">仓库ID</param>
      /// <param name="productIds">商品List</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public FrxsErpProductWProductsGetToB2BResp.FrxsErpProductWProductsGetToB2BRespData GetWProductsInfo(int Wid, IList<int> productIds, int shopId, int userId, string userName)
      {
          var client = WorkContext.CreateProductSdkClient();
          var req = new FrxsErpProductWProductsGetToB2BRequest()
          {
              ProductIds = productIds,
              UserId = userId,
              UserName = userName,
              WID = Wid,
              ShopID = shopId
          };
          var resp = client.Execute(req);
          if (resp == null)
          {
              throw new Exception("查询仓库商品信息失败");
          }
          if (resp.Flag != 0)
          {
              throw new Exception(resp.Info);
          }
          else
          {
              return resp.Data;
          }
      }


      /// <summary>
      /// 获取仓库商品库存
      /// </summary>
      /// <param name="Wid">仓库ID</param>
      /// <param name="subWid">子仓库ID </param>
      /// <param name="productIds">商品List</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public QueryStockQtyResponseDTO GetProductStock(int Wid, int subWid, IList<int> productIds, int userId, string userName)
      {

          StockQtyQuery query = new StockQtyQuery();
          query.WID = Wid;
          query.SubWID = subWid;
          query.PDIDList = productIds.ToList();

          QueryStockQtyResponseDTO rsp = new QueryStockQtyResponseDTO();
          rsp.StockQtyList = StockQueryBLO.QueryStockQty(query);
          return rsp;
      }



      /// <summary>
      /// 获取门店限购列表情况
      /// </summary>
      /// <param name="wid">仓库ID</param>
      /// <param name="shopId">门店ID</param>
      /// <param name="productIds">商品ID串</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public IList<FrxsErpPromotionWProductPromotionDetailsListModelGetResp.FrxsErpPromotionWProductPromotionDetailsListModelGetRespData> GetPromotionQuota(int wid, int shopId, IList<int> productIds, int userId, string userName)
      {
          var productStr = "";
          foreach (var productId in productIds)
          {
              productStr += productId + ",";
          }
          productStr = productStr.Substring(0, productStr.Length - 1);
          var client = WorkContext.CreatePromotionSdkClient();
          var promotionDetails = client.Execute(new Frxs.Erp.ServiceCenter.Promotion.SDK.Request.FrxsErpPromotionWProductPromotionDetailsListModelGetRequest()
          {
              WID = wid,
              BeginTime = DateTime.Now,
              EndTime = DateTime.Now,
              ShopID = shopId,
              ProductIDList = productStr,
              PromotionType = 1,
              UserId = userId,
              UserName = userName
          });
          if (promotionDetails == null)
          {
              throw new Exception("查询限购信息失败");
          }
          if (promotionDetails.Flag != 0)
          {
              return null;
          }
          else
          {
              return promotionDetails.Data;
          }
      }


      /// <summary>
      /// 获取商品信息
      /// </summary>
      /// <param name="productIds">商品ID</param>
      /// <param name="userId"></param>
      /// <param name="userName"></param>
      /// <returns></returns>
      public Frxs.Erp.ServiceCenter.Product.SDK.Resp.FrxsErpProductProductListGetResp.FrxsErpProductProductListGetRespData GetProductsInfo(IList<int> productIds, int userId, string userName)
      {
          var client = WorkContext.CreateProductSdkClient();
          var req = new FrxsErpProductProductListGetRequest()
          {
              ProductIds = productIds,
              PageIndex = 1,
              PageSize = int.MaxValue
          };
          var resp = client.Execute(req);
          if (resp == null)
          {
              throw new Exception("查询商品信息失败");
          }
          if (resp.Flag != 0)
          {
              return null;
          }
          else
          {
              return resp.Data;
          }
      }

      /// <summary>
      /// 限购检查方法
      /// </summary>
      /// <param name="shopId">门店ID</param>
      /// <param name="Wid">仓库ID</param>
      /// <param name="productIds">商品ID列表</param>
      /// <param name="list">被检查的购物车或订单列表</param>
      /// <param name="userId">用户ID</param>
      /// <param name="userName">用户姓名</param>
      /// <param name="msg">返回的出错消息</param>
      /// <param name="maxList">返回的限购数量列表，如不需要返回该列表，传入null</param>
      /// <returns>true or false</returns>
      public bool QuotaCheck(int shopId, int Wid, IList<int> productIds, List<FrxsErpPromotionSaleCartAddOrEditRequest.SaleCartAddOrEditRequestDto> list, int userId, string userName, ref string msg, List<SimpleProdcutQuoteModel> maxList = null)
      {
          #region 限购判断
          //获取限购信息
          var quota = GetPromotionQuota(Wid, shopId, productIds, userId, userName);
          //有购物车商品处于限购状态
          if (quota != null && quota.Count > 0)
          {
              if (maxList != null)
              {
                  maxList = new List<SimpleProdcutQuoteModel>();
                  foreach (var product in quota)
                  {
                      maxList.Add(new SimpleProdcutQuoteModel()
                      {
                          ProductId = product.ProductID,
                          MaxPreQty = product.MaxOrderQty
                      });
                  }
              }
              foreach (var product in quota)
              {
                  decimal count = 0;
                  var cartProdcut = list.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
                  if (cartProdcut != null)
                  {
                      count += cartProdcut.PreQty;
                  }
                  //判断购物车中是否超过限制数量
                  if (count > product.MaxOrderQty && product.MaxOrderQty != 0)
                  {
                      var tmpList = new List<int>();
                      tmpList.Add(product.ProductID);
                      var productInfo = GetProductsInfo(tmpList, userId, userName);
                      if (productInfo == null || productInfo.TotalRecords <= 0)
                      {
                          msg = string.Format("没有找到ID为{0}的商品", product.ProductID);
                          return false;
                      }
                      msg = string.Format("购物车中商品{0}数量为{1}件，限购{2}件", productInfo.ItemList[0].ProductName, count,
                                          product.MaxOrderQty);
                      return false;
                  }
              }
          }
          #endregion

          return true;
      }
  }

  /// <summary>
  /// 简单的限购数据类，用于返回一个限购最大数量的列表
  /// </summary>
  public class SimpleProdcutQuoteModel
  {
      /// <summary>
      /// 商品ID
      /// </summary>
      public int ProductId { get; set; }

      /// <summary>
      /// 最大限购数量
      /// </summary>
      public decimal MaxPreQty { get; set; }
  }
}
