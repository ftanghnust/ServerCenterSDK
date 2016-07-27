/*********************************************************
 * FRXS 小马哥 2016/4/12 18:21:36
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 拣货更新相关表数据
    /// </summary>
    [ActionName("StartPickUpdate")]
    public class PickingStartPickAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.PickingStartPickAction.PickingStartPickActionRequestDto, bool>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class PickingStartPickActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 货区编号
            /// </summary>            
            public string ShelfAreaID { get; set; }

            /// <summary>
            /// 子结构仓库编号
            /// </summary>
            [Required]
            public string ChildWID { get; set; }

            /// <summary>
            /// 父级仓库编号
            /// </summary>
            [Required]
            public string ParentWID { get; set; }
        }

        /// <summary>
        /// 开始拣货
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            string orderId = RequestDto.OrderId;
            string strParentWid = RequestDto.ParentWID;
            string strChildWid = RequestDto.ChildWID;
            PickTimeModel pickTimeModel = null;
            if (!string.IsNullOrWhiteSpace(RequestDto.ShelfAreaID) && Utils.StrToInt(RequestDto.ShelfAreaID, 0) > 0)
            {
                pickTimeModel = SaleOrderPreBLO.GetPickTimeByOrderIdAndAreaID(orderId, strParentWid, RequestDto.ShelfAreaID);
                if (pickTimeModel == null)
                {
                    return ErrorActionResult("没有找到订单信息");
                }
                if (pickTimeModel.PickingBeginDate != null && pickTimeModel.BeginTime != null)
                {
                    return ErrorActionResult("该订单已开始拣货");
                }
            }
            else
            {
                pickTimeModel = new PickTimeModel();
                SaleOrderPre model = SaleOrderPreBLO.GetModel(orderId, Utils.StrToInt(strParentWid, 0));
                if (model == null)
                {
                    return ErrorActionResult("没有找到订单信息");
                }
                if (model.PickingBeginDate != null)
                {
                    return ErrorActionResult("该订单已开始拣货");
                }
                pickTimeModel.ShopID = model.ShopID;
                pickTimeModel.SendDate = model.SendDate;
                pickTimeModel.LineID = Utils.StrToInt(model.LineID, 0);
            }
            //判断订单是否已经拣货，但其他货区没有拣货,判断该订单是否是第一次拣货
            bool isFirstPick = true;
            int stationNumber = 0;
            if (pickTimeModel != null && Utils.StrToInt(pickTimeModel.StationNumber, 0) > 0)
            {
                isFirstPick = false;
                stationNumber = pickTimeModel.StationNumber;
            }
            else
            {
                //获取空闲待装区
                var getStationNumber = WorkContext.CreateProductSdkClient().Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductGetFreeStationNumberRequest()
                {
                    WID = strParentWid
                });
                if (getStationNumber != null && getStationNumber.Data != null && getStationNumber.Flag == (int)ActionResultFlag.SUCCESS)
                {
                    stationNumber = getStationNumber.Data.StationNumber;
                    //更改待装区信息
                    var setStationNumber = WorkContext.CreateProductSdkClient().Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductSetStationNumberActionRequest()
                    {
                        ID = getStationNumber.Data.ID,
                        Status = 1,
                        ShopID = pickTimeModel.ShopID,
                        OrderID = RequestDto.OrderId,
                        OrderConfDate = pickTimeModel.SendDate,
                        LineID = pickTimeModel.LineID.ToString(),
                        OrderStatus = 3
                    });

                    if (setStationNumber == null && setStationNumber.Data == null)
                    {
                        return ErrorActionResult("更新待装区失败");
                    }
                }
                else
                {
                    if (getStationNumber != null)
                    {
                        return ErrorActionResult(getStationNumber.Info);
                    }
                    else
                    {
                        return ErrorActionResult("获取待装区失败");
                    }
                }
            }


            //开始拣货
            if (stationNumber > 0)
            {
                #region 获取商品实际库存数,更改实际拣货数
                SaleOrderPreWaitPickingList model = SaleOrderPreBLO.GetWaitPickDetails(RequestDto.OrderId, strParentWid);
                StockQtyQuery stockModel = new StockQtyQuery();
                stockModel.PDIDList = new List<int>();
                model.ProductData.ToList().ForEach(x =>
                {
                    stockModel.PDIDList.Add(x.ProductID);
                });
                stockModel.WID = Utils.StrToInt(strParentWid, 0);
                stockModel.SubWID = Utils.StrToInt(strChildWid, 0);
                //获取该订单所有商品的可用库存数
                IList<StockSreachQtyModel> listModel = StockQueryBLO.QueryStockQty(stockModel);
                List<ProductUserQty> listProductUserQty = new List<ProductUserQty>();
                listModel.ToList().ForEach(x =>
                {
                    //循环处理，更新订单详细表和待拣货详细表中商品数量和相关金额
                    ProductUserQty pUserQty = new ProductUserQty();
                    pUserQty.ProductId = x.PID;
                    var o = model.ProductData.ToList().Where(y => y.ProductID == x.PID);
                    pUserQty.ProductUserNum = decimal.Parse(o.ToList()[0].SaleQty.ToString()) * o.ToList()[0].SalePackingQty <= x.EnQty ? decimal.Parse(o.ToList()[0].SaleQty.ToString()) : x.EnQty > 0 ? Math.Floor(x.EnQty / o.ToList()[0].SalePackingQty) : 0;
                    listProductUserQty.Add(pUserQty);
                });
                bool updateResult = SaleOrderPreBLO.EditEnQty(listProductUserQty, strParentWid, orderId, RequestDto.ShelfAreaID);
                if (!updateResult)
                {
                    return ErrorActionResult("更新库存数到拣货数失败");
                }
                #endregion
                SaleOrderPre saleOrderPreModel = SaleOrderPreShelfAreaBLO.StartPick(orderId, strParentWid, RequestDto.ShelfAreaID, RequestDto.UserId, RequestDto.UserName, stationNumber.ToString(), isFirstPick);
                if (saleOrderPreModel == null)
                {
                    return ErrorActionResult("拣货失败");
                }
                else
                {
                    return SuccessActionResult(true);
                }

            }
            else
            {
                return ErrorActionResult("获取空闲待装区失败");
            }

        }
    }
}
