using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Promotion.SDK.Request;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 订单确认
    /// </summary>
    [ActionName("OrderShop.AutoConfirm")]
    public class OrderAutoConfirmAction : ActionBase<RequestDto.OrderBaseRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            try
            {
                var dto = this.RequestDto;

                //数据检查
                if (string.IsNullOrEmpty(dto.OrderId))
                {
                    return this.ErrorActionResult("错误的订单编号");
                }

                //从门店订单表取数据
                var result = new SaleOrderPreAddOrEditRequestDto();
                var picks = new List<SaleOrderPreDetailsPick>();
                var shelfAreas = new List<SaleOrderPreShelfArea>();
                var orderClient = WorkContext.CreatePromotionSdkClient();
                var orderReq = dto.MapTo<FrxsErpPromotionOrderShopGetRequest>();
                var orderResp = orderClient.Execute(orderReq);
                var productIdList = new List<int>();
                if (orderResp == null)
                {
                    throw new Exception("查询订单信息失败");
                }
                if (orderResp.Flag != 0)
                {
                    return this.ErrorActionResult(orderResp.Info);
                }
                else
                {
                    result.SaleOrderPre = orderResp.Data.Order.MapTo<SaleOrderPreRequestDto>();
                    result.SaleOrderPreDetailList = new List<SaleOrderPreDetailRequestDto>();
                    result.SaleOrderPreDetailExtsList = new List<SaleOrderPreDetailExtsRequestDto>();

                    foreach (var detail in orderResp.Data.Details)
                    {
                        var d = detail.MapTo<SaleOrderPreDetailRequestDto>();
                        result.SaleOrderPreDetailList.Add(d);
                        productIdList.Add(d.ProductId);
                    }
                    foreach (var detailExt in orderResp.Data.DetailExts)
                    {
                        var d = detailExt.MapTo<SaleOrderPreDetailExtsRequestDto>();
                        result.SaleOrderPreDetailExtsList.Add(d);
                    }
                    result.SaleOrderPre.Status = 2;
                }
                var part = new OrderPartsServer();

                //限购检查
                #region 限购检查
                var list = new List<FrxsErpPromotionSaleCartAddOrEditRequest.SaleCartAddOrEditRequestDto>();
                foreach (var detail in result.SaleOrderPreDetailList)
                {
                    list.Add(new FrxsErpPromotionSaleCartAddOrEditRequest.SaleCartAddOrEditRequestDto()
                    {
                        ProductID = detail.ProductId,
                        PreQty = detail.PreQty,
                        WarehouseId = dto.WarehouseId
                    });
                }
                string msg = "";
                List<SimpleProdcutQuoteModel> maxList = new List<SimpleProdcutQuoteModel>();
                var flag = part.QuotaCheck(orderResp.Data.Order.ShopID, dto.WarehouseId, productIdList, list, dto.UserId, dto.UserName, ref msg, maxList);
                if (!flag)//有限购商品超过限制
                {
                    foreach (var detail in result.SaleOrderPreDetailList)
                    {
                        var m = maxList.Where(x => x.ProductId == detail.ProductId).FirstOrDefault();
                        if (m != null && detail.PreQty>m.MaxPreQty && m.MaxPreQty!=0)
                        {
                            detail.PreQty = m.MaxPreQty;
                        }
                    }
                }
                #endregion

                //重处理商品价格和积分运算
                #region 重处理商品价格和积分运算
                var wProudcts = part.GetWProductsInfo(dto.WarehouseId, productIdList, orderResp.Data.Order.ShopID, dto.UserId, dto.UserName);
                var promotionProducts = part.GetPromotionRebate(dto.WarehouseId, orderResp.Data.Order.ShopID, productIdList,
                                                                       dto.UserId, dto.UserName);
                var productStock = part.GetProductStock(dto.WarehouseId, orderResp.Data.Order.SubWID.Value, productIdList, dto.UserId,
                                                               dto.UserName);

                //移除已下架或限购商品
                if (wProudcts.ItemList.Count != result.SaleOrderPreDetailList.GroupBy(x => x.ProductId).Count())
                {
                    for (int i = result.SaleOrderPreDetailList.Count - 1; i >= 0; i--)
                    {
                        var detail = result.SaleOrderPreDetailList[i];
                        var tmp = wProudcts.ItemList.FirstOrDefault(x => x.ProductId == detail.ProductId);
                        if (tmp == null)
                        {
                            result.SaleOrderPreDetailList.Remove(detail);
                            result.SaleOrderPreDetailExtsList.RemoveAt(i);
                        }
                    }
                }

                if (result.SaleOrderPreDetailList.Count <= 0)
                {
                    return this.ErrorActionResult("订单所有商品均已被限制购买");
                }

                foreach (var detail in result.SaleOrderPreDetailList)
                {
                    var wProduct = wProudcts.ItemList.Where(x => x.ProductId == detail.ProductId).FirstOrDefault();
                    var pProduct =
                        promotionProducts.Where(x => x.ProductID == detail.ProductId).FirstOrDefault();
                    var stock =
                        productStock.StockQtyList.Where(x => x.PID == detail.ProductId).FirstOrDefault();

                    if (wProduct == null)
                    {
                        return this.ErrorActionResult(string.Format("仓库中没有找到商品{0}", detail.ProductName));
                    }
                    if (wProduct.WStatus != 1)
                    {
                        return this.ErrorActionResult(string.Format("商品{0}已下架，不能提交订单，请手工删除该商品后再确认订单", wProduct.ProductName));
                    }
                    detail.ProductName = wProduct.ProductName;
                    detail.ProductImageUrl200 = wProduct.ImageUrl200x200;
                    detail.ProductImageUrl400 = wProduct.ImageUrl400x400;
                    detail.Unit = wProduct.Unit;
                    detail.BasePoint = wProduct.BasePoint.HasValue ? wProduct.BasePoint.Value : 0;
                    detail.SalePackingQty = wProduct.BigPackingQty.HasValue ? wProduct.BigPackingQty.Value : 1;
                    detail.SalePrice = (wProduct.SalePrice.HasValue ? wProduct.SalePrice.Value : 0) * detail.SalePackingQty;
                    detail.SaleQty = detail.PreQty;
                    detail.SaleUnit = wProduct.BigUnit;
                    detail.ShopAddPerc = wProduct.ShopAddPerc.HasValue ? wProduct.ShopAddPerc.Value : 0;
                    detail.ShopPoint = wProduct.ShopPoint.HasValue ? wProduct.ShopPoint.Value : 0;
                    detail.UnitPrice = (wProduct.SalePrice.HasValue ? wProduct.SalePrice.Value : 0);
                    detail.UnitQty = (wProduct.BigPackingQty.HasValue
                                                         ? wProduct.BigPackingQty.Value
                                                         : 1) * detail.PreQty;
                    detail.VendorPerc1 = wProduct.VendorPerc1.HasValue ? wProduct.VendorPerc1.Value : 0;
                    detail.VendorPerc2 = wProduct.VendorPerc2.HasValue ? wProduct.VendorPerc2.Value : 0;

                    detail.IsStockOut = stock == null ? 1 : ((detail.PreQty * wProduct.BigPackingQty) >
                                                              stock.StockQty
                                                                  ? 1
                                                                  : 0);

                    if (pProduct != null)
                    {
                        detail.PromotionID = pProduct.PromotionID;
                        detail.PromotionName = pProduct.ProductName;
                        detail.PromotionShopPoint = pProduct.Point;
                        //detail.SubPoint = detail.PromotionShopPoint * detail.UnitQty;
                    }
                    else
                    {
                        detail.PromotionShopPoint = 0;
                    }

                    detail.SubPoint = ((detail.PromotionShopPoint.HasValue && detail.PromotionShopPoint.Value > 0) ? detail.PromotionShopPoint.Value : detail.ShopPoint) * detail.UnitQty;
                    detail.PromotionUnitPrice = detail.UnitPrice;
                    detail.SubAmt = detail.SalePrice * detail.PreQty; //没有促销价格，按原价计算

                    detail.SubAddAmt = detail.SubAmt * detail.ShopAddPerc;
                    detail.SubBasePoint = detail.BasePoint * detail.SubAmt;
                    detail.SubVendor1Amt = detail.VendorPerc1 * detail.SubAmt ;
                    detail.SubVendor2Amt = detail.VendorPerc2 * detail.SubAmt ;

                    var pick = new SaleOrderPreDetailsPick()
                    {
                        BarCode = detail.BarCode,
                        CheckTime = null,
                        CheckUserID = null,
                        CheckUserName = null,
                        ID = detail.ID,
                        IsAppend = 0,
                        IsCheckRight = null,
                        ModifyTime = DateTime.Now,
                        ModifyUserID = dto.UserId,
                        ModifyUserName = dto.UserName,
                        OrderID = detail.OrderID,
                        ProductID = detail.ProductId,
                        PickQty = null,
                        PickTime = null,
                        PickUserID = null,
                        PickUserName = null,
                        ProductImageUrl200 = detail.ProductImageUrl200,
                        ProductImageUrl400 = detail.ProductImageUrl400,
                        ProductName = detail.ProductName,
                        Remark = detail.Remark,
                        SKU = detail.SKU,
                        SalePackingQty = detail.SalePackingQty,
                        SaleQty = detail.SaleQty.Value,
                        SaleUnit = detail.SaleUnit,
                        ShelfAreaID = wProduct.ShelfAreaID,
                        ShelfCode = wProduct.ShelfCode,
                        ShelfID = wProduct.ShelfID,
                        WCProductID = (int)wProduct.WProductID
                    };
                    picks.Add(pick);
                    var tmpArea = shelfAreas.FirstOrDefault(x => x.ShelfAreaID == pick.ShelfAreaID);
                    if (tmpArea == null)
                    {
                        var area = new SaleOrderPreShelfArea()
                        {
                            BeginTime = null,
                            EndTime = null,
                            ID = dto.WarehouseId.ToString() + Guid.NewGuid(),
                            ModifyTime = DateTime.Now,
                            ModifyUserID = dto.UserId,
                            ModifyUserName = dto.UserName,
                            OrderID = detail.OrderID,
                            Package1Qty = null,
                            Package2Qty = null,
                            Package3Qty = null,
                            PickUserID = null,
                            PickUserName = null,
                            Remark = 0,
                            ShelfAreaID = pick.ShelfAreaID,
                            ShelfAreaCode = wProduct.ShelfAreaCode,
                            ShelfAreaName = wProduct.ShelfAreaName,
                            WID = dto.WarehouseId
                        };
                        shelfAreas.Add(area);
                    }
                }
                #endregion

                //重新计算订单数据
                #region 重新计算订单数据
                result.SaleOrderPre.CouponAmt = 0;
                result.SaleOrderPre.TotalAddAmt = result.SaleOrderPreDetailList.Sum(x => x.SubAddAmt);
                result.SaleOrderPre.TotalProductAmt = result.SaleOrderPreDetailList.Where(x => x.SubAmt.HasValue).Sum(x => x.SubAmt.Value);
                result.SaleOrderPre.PayAmount = result.SaleOrderPre.TotalAddAmt.Value + result.SaleOrderPre.TotalProductAmt;
                result.SaleOrderPre.TotalPoint = result.SaleOrderPreDetailList.Where(x => x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
                result.SaleOrderPre.TotalBasePoint = result.SaleOrderPreDetailList.Sum(x => x.SubBasePoint);
                result.SaleOrderPre.Status = 2;
                result.SaleOrderPre.ConfDate = DateTime.Now;
                #endregion

                //此处将门店订单数据写入仓库订单数据begin
                var tmpOrder = result.SaleOrderPre.MapTo<SaleOrderPre>();
                var tmpDetails = result.SaleOrderPreDetailList.MapToList<SaleOrderPreDetails>().ToList();
                var tmpDetailExts = result.SaleOrderPreDetailExtsList.MapToList<SaleOrderPreDetailsExt>();
                var sendNumber = new SaleOrderSendNumber();

                sendNumber.OrderID = tmpOrder.OrderId;
                sendNumber.ModifyTime = DateTime.Now;
                sendNumber.ModifyUserID = dto.UserId;
                sendNumber.ModifyUserName = dto.UserName;
                sendNumber.WID = tmpOrder.WID;
                sendNumber.SendNumber = 999;
                var shop = part.GetShopInfo(tmpOrder.ShopID, dto.UserId, dto.UserName);
                if(shop==null)
                {
                    return this.ErrorActionResult("取门店信息失败");
                }
                var line = part.GetWLineInfo(tmpOrder.LineID.Value, dto.UserId, dto.UserName);
                if(line==null)
                {
                    return this.ErrorActionResult("取线路信息失败");
                }
                sendNumber.ShopSerialNumber = shop.SerialNumber;
                sendNumber.LineSerialNumber = line.SerialNumber;
                
                var res = SaleOrderPreBLO.SaveNewOrder(tmpOrder, tmpDetails, tmpDetailExts.ToList(), sendNumber, picks.ToList(), shelfAreas.ToList(), dto.WarehouseId);
                if (!res.IsSuccess)
                {
                    return this.ErrorActionResult(res.Message);
                }
                //此处写仓库订单数据end
                

                //此处回写门店订单状态
                var client = WorkContext.CreatePromotionSdkClient();
                var req = dto.MapTo<FrxsErpPromotionOrderShopConfirmRequest>();
                var resp = client.Execute(req);
                if (resp == null)
                {
                    throw new Exception("回写订单信息失败");
                }
                if (resp.Flag != 0)
                {
                    return this.ErrorActionResult(resp.Info);
                }
                else
                {
                    var track = new SaleOrderTrack()
                    {
                        CreateTime = DateTime.Now,
                        CreateUserID = dto.UserId,
                        CreateUserName = dto.UserName,
                        IsDisplayUser = 1,
                        OrderID = req.OrderId,
                        OrderStatus = 2,
                        Remark = "您的订单已确认"
                    };
                    track.CreateTime = DateTime.Now;
                    track.CreateUserID = dto.UserId;
                    track.CreateUserName = dto.UserName;
                    track.OrderStatusName = SaleOrderPreBLO.ConvertStatusToString(2);
                    track.WID = dto.WarehouseId;
                    track.ID = dto.WarehouseId.ToString() + Guid.NewGuid();

                    var iflag = SaleOrderTrackBLO.Save(track, dto.WarehouseId.ToString());
                    if (iflag > 0)
                    {
                        return this.SuccessActionResult();
                    }
                    else
                    {
                        return this.ErrorActionResult("添加跟踪信息失败");
                    }
                }
            }
            catch (Exception ex)
            {
                return this.ErrorActionResult(ex.Message);
            }
        }
    }
}
