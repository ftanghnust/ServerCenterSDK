using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.MSSQLDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Product.SDK.Resp;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Settlement
{
    /// <summary>
    /// 日结功能生成
    /// </summary>
    [ActionName("Settlement.Add")]
    public class SettlementAddAction : ActionBase<RequestDto.SettlementAddRequsetDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //分库连接 先确定仓库ID
            string warehouseId = RequestDto.Wid.ToString();



            //日结开始时间和日结结束时间 怎么读取：
            //            ---- SettleDate画面的日期('2016-07-02')  SettleStartTime,上一笔时间('2016-07-02 03:00:01'), SettleEndTime --getDate();执行的系统时间
            //--SET @n1=len(@settleStartTime);
            //--IF (@n1==0) 
            //--BEGIN
            //--   SELECT @settleStartTime=MAX(SettleEndTime) FROM dbo.Settlement WHERE WID=@WID AND SubWID=@SubWID 
            //--   IF (LEN(@settleStartTime)==0)
            //--   BEGIN
            //--   SELECT @settleStartTime=MIN(CreateTime) FROM dbo.StockQty 
            //--         WHERE WID=@WID AND SubWID=@SubWID
            //--   END
            //--END 
            //--set @settleEndTime=GETDATE()

            //DateTime settleDate = DateTime.Now.Date; //结算日期
            //DateTime settleStartTime = DateTime.Now.Date;  //今天的00:00:00
            //DateTime settleEndTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);  //今天的23点59分59秒

            DateTime settleDate = DateTime.Now.Date; //结算日期
            if (!string.IsNullOrEmpty(this.RequestDto.SettleDate))
            {
                DateTime.TryParse(this.RequestDto.SettleDate, out settleDate);
            }

            DateTime? settleStartTime = DALFactory.GetLazyInstance<SettlementDAO>(warehouseId).GetSettleStartTime(this.RequestDto.Wid, this.RequestDto.SubWid);
            if (!settleStartTime.HasValue)
            {
                settleStartTime = DALFactory.GetLazyInstance<IStockQueryDAO>(warehouseId).GetStockQtyCreateMinDate(this.RequestDto.Wid, this.RequestDto.SubWid);
            }
            DateTime settleEndTime = DateTime.Now;


            //日结算单编号生成
            string settleId = Guid.NewGuid().ToString();
            string settleNo = this.RequestDto.Wid + settleDate.ToString("yyyyMMdd");

            Model.Settlement settlement = new Model.Settlement
                            {
                                CreateTime = DateTime.Now,
                                CreateUserID = RequestDto.UserId,
                                CreateUserName = this.RequestDto.UserName,
                                WID = this.RequestDto.Wid,
                                Remark = "日结功能批量生产",
                                ModifyTime = DateTime.Now,
                                ModifyUserID = RequestDto.UserId,
                                ModifyUserName = this.RequestDto.UserName,
                                ID = settleId,
                                SettleDate = settleDate,
                                SettleStartTime = settleStartTime.Value,
                                SettleEndTime = settleEndTime,
                                SettleNo = settleNo,
                                Status = RequestDto.Status, //状态值默认为 0表示手动，1表示自动
                                SubWCode = RequestDto.SubWCode,
                                SubWID = RequestDto.SubWid,
                                SubWName = RequestDto.SubWName,
                                WCode = RequestDto.WCode,
                                WName = RequestDto.WName
                            };

            //判断是否重复生成结算单
            //bool flag = DALFactory.GetLazyInstance<SettlementDAO>(warehouseId).ExistsSettleDate(settlement);
            //if (flag)
            //{
            //    string wName = settlement.WName + "(" + settlement.WID + ")";
            //    string subWname = settlement.SubWName + "(" + settlement.SubWID + ")";
            //    string settleDates = settlement.SettleDate.ToString("yyyy-MM-dd");
            //    return ErrorActionResult(string.Format("在当前仓库【{0}】下的子仓库【{1}】有当前结算日期{2}的结算单存在," +
            //                                           "不能进行结算操作,请手动删除后再进行当前时间的结算操作", wName, subWname
            //                                           , settleDates));
            //}

            GetProductStockQuery requestDtoQuery = new GetProductStockQuery
                                                      {
                                                          Wid = this.RequestDto.Wid,
                                                          SubWid = this.RequestDto.SubWid,
                                                          SettleStartTime = settleStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                                          SettleEndTime = settleEndTime.ToString("yyyy-MM-dd HH:mm:ss")
                                                      };

            IList<SettlementDetail> settlementDetailList = DALFactory.GetLazyInstance<SettlementDetailDAO>(warehouseId).
                GetProductStockList(requestDtoQuery, "P_GETProductStockData");

            if (settlementDetailList == null || settlementDetailList.Count == 0)
            {
                return ErrorActionResult("日结明细数据获取错误，请确认后再操作");
            }

            //IList<int> productIds = settlementDetailList.Select(item => item.ProductId).ToList();

            IList<int> productIds = new List<int>();

            //准备调用 产品SDK,获取到 基本资料中心客户端SDK访问对象 （根据2016-3-22 胡勇提供的 “5个服务中心的依赖关系”，订单SDK可以调用基本资料SDK，但不可反向调用）
            var productWorkContext = WorkContext.CreateProductSdkClient();

            //设置基础库接口调用的超时时间 
            productWorkContext.SetTimeout(100000);

            //读取商品的信息可能要直接从商品表Product中读取，不能从商品的WProduct读取(要问老胡)
            var prdResp = productWorkContext.Execute(new Product.SDK.Request.FrxsErpProductWProductsBaseListGetRequest()
            {
                Wid = RequestDto.Wid,
                ProductIds = productIds,
                UserId = RequestDto.UserId,
                UserName = RequestDto.UserName
            });

            //错误信息优先处理
            if (prdResp == null)
            {
                return ErrorActionResult("商品列表数据读取错误");
            }
            if (prdResp.Flag != 0)
            {
                return ErrorActionResult(prdResp.Info);
            }

            foreach (var settlementDetail in settlementDetailList)
            {
                var wProductsBase = prdResp.Data.FirstOrDefault(i => i.ProductId == settlementDetail.ProductId);
                if (wProductsBase != null)
                {
                    settlementDetail.BuyPrice = wProductsBase.BuyPrice;
                    settlementDetail.SalePrice = wProductsBase.SalePrice;
                    //赋商品相关的属性值
                    settlementDetail.BarCode = wProductsBase.BarCode;
                    settlementDetail.BrandId1 = wProductsBase.BrandId1;
                    settlementDetail.BrandId1Name = wProductsBase.BrandId1Name;
                    settlementDetail.BrandId2 = wProductsBase.BrandId2;
                    settlementDetail.BrandId2Name = wProductsBase.BrandId2Name;
                    settlementDetail.CategoryId1 = wProductsBase.CategoryId1;
                    settlementDetail.CategoryId1Name = wProductsBase.CategoryId1Name;
                    settlementDetail.CategoryId2 = wProductsBase.CategoryId2;
                    settlementDetail.CategoryId2Name = wProductsBase.CategoryId2Name;
                    settlementDetail.CategoryId3 = wProductsBase.CategoryId3;
                    settlementDetail.CategoryId3Name = wProductsBase.CategoryId3Name;
                    settlementDetail.ProductId = wProductsBase.ProductId;
                    settlementDetail.ProductName = wProductsBase.ProductName;
                    settlementDetail.ShopCategoryId1 = wProductsBase.ShopCategoryId1;
                    settlementDetail.ShopCategoryId1Name = wProductsBase.ShopCategoryId1Name;
                    settlementDetail.ShopCategoryId2 = wProductsBase.ShopCategoryId2;
                    settlementDetail.ShopCategoryId2Name = wProductsBase.ShopCategoryId2Name;
                    settlementDetail.ShopCategoryId3 = wProductsBase.ShopCategoryId3;
                    settlementDetail.ShopCategoryId3Name = wProductsBase.ShopCategoryId3Name;
                    settlementDetail.SKU = wProductsBase.SKU;
                    settlementDetail.Unit = wProductsBase.Unit;
                }
                else
                {
                    settlementDetail.BuyPrice = 0;
                    settlementDetail.SalePrice = 0;
                    settlementDetail.ProductName = "";
                    settlementDetail.SKU = "";
                    settlementDetail.Unit = "";
                }

                //单据修改的时间
                settlementDetail.RefSet_ID = settleId;
                settlementDetail.ModifyTime = DateTime.Now;
                settlementDetail.ModifyUserID = RequestDto.UserId;
                settlementDetail.ModifyUserName = RequestDto.UserName;

                if (settlementDetail.BeginAmt == -1)
                {
                    settlementDetail.BeginAmt = settlementDetail.BeginQty * settlementDetail.SalePrice;
                }

                //单独计算的功能：
                // 库存金额=库存数*配送价 StockAmt=StockQty *SalePrice
                settlementDetail.StockAmt = settlementDetail.StockQty * settlementDetail.SalePrice;

                //期末库存数量=期初库存数量+采购数量 -采购退货数量 -销售数量 +销售退货数量 +盘盈数量 -盘亏数量
                //(EndQty= BeginQty +BuyQty -BuyBackQty -SaleQty+SaleBackQty+AdjGainQty-AdjLossQty)
                settlementDetail.EndQty =
                    settlementDetail.BeginQty + settlementDetail.BuyQty - settlementDetail.BuyBackQty -
                    settlementDetail.SaleQty + settlementDetail.SaleBackQty
                    + settlementDetail.AdjGainQty - settlementDetail.AdjLossQty;
                //--期末库存金额 = EndQty* SalePrice
                settlementDetail.EndStockAmt = settlementDetail.EndQty * settlementDetail.SalePrice;

                //--差异数量=库存数量-期末库存数量
                settlementDetail.EndDiffQty = settlementDetail.StockQty - settlementDetail.EndQty;
                //--差异金额=差异数量*销售价
                settlementDetail.EndDiffStockAmt = settlementDetail.EndDiffQty * settlementDetail.SalePrice;


                //汇总功能：
                settlement.AdjGainQty += settlementDetail.AdjGainQty;
                settlement.AdjLossQty += settlementDetail.AdjLossQty;
                settlement.AjgGginAmt += settlementDetail.AjgGginAmt;
                settlement.AjgLosssAmt += settlementDetail.AjgLosssAmt;

                settlement.BackSubAddAmt += settlementDetail.BackSubAddAmt;
                settlement.BackSubVendor1Amt += settlementDetail.BackSubVendor1Amt;
                settlement.BackSubVendor2Amt += settlementDetail.BackSubVendor2Amt;
                settlement.BeginAmt += settlementDetail.BeginAmt;
                settlement.BeginQty += settlementDetail.BeginQty;
                settlement.BuyAmt += settlementDetail.BuyAmt;
                settlement.BuyBackAmt += settlementDetail.BuyBackAmt;
                settlement.BuyBackQty += settlementDetail.BuyBackQty;
                settlement.BuyQty += settlementDetail.BuyQty;

                settlement.EndDiffQty += settlementDetail.EndDiffQty;
                settlement.EndDiffStockAmt += settlementDetail.EndDiffStockAmt;
                settlement.EndQty += settlementDetail.EndQty;
                settlement.EndStockAmt += settlementDetail.EndStockAmt;

                settlement.SaleAmt += settlementDetail.SaleAmt;
                settlement.SaleQty += settlementDetail.SaleQty;
                settlement.SaleBackAmt += settlementDetail.SaleBackAmt;
                settlement.SaleBackQty += settlementDetail.SaleBackQty;
                settlement.SaleSubAddAmt += settlementDetail.SaleSubAddAmt;
                settlement.SaleSubBasePoint += settlementDetail.SaleSubBasePoint;
                settlement.SaleSubPoint += settlementDetail.SaleSubPoint;
                settlement.SaleSubVendor1Amt += settlementDetail.SaleSubVendor1Amt;
                settlement.SaleSubVendor2Amt += settlementDetail.SaleSubVendor2Amt;
                settlement.StockAmt += settlementDetail.StockAmt;
                settlement.StockQty += settlementDetail.StockQty;

            }


            //保存操作: 事务处理，先保存日结明细数据，再保存日结主表数据

            //返回的成功记录的计数
            int rows = 0;
            //当前批次内遍历的行号
            int index = 0;
            //事务执行返回的错误信息
            string msg = string.Empty;


            rows = SaveListToDb(warehouseId, settlementDetailList, settlement, ref msg);

            if (!string.IsNullOrEmpty(msg))
            {
                return this.ExceptionActionResult(string.Format("操作失败，出现错误：。<br />{0}", msg));
            }
            else
            {
                return SuccessActionResult(string.Format("操作完成，批量录入了{0}条日结明细数据。", rows), rows);
            }


            //1、读取库存数量SELECT S.ProductId,S.StockQty,S.WID,S.SubWID FROM dbo.StockQty WHERE WID=105 AND SubWID=211

            //IList<ProductId>

            //2.通过这个IList<ProductId>读取 SKU，ProductName，BarCode，Unit，BuyPrice，SalePrice
            //，CategoryId1，CategoryId1Name,CategoryId2,CategoryId2Name,CategoryId3,CategoryId3Name,
            //ShopCategoryId1,ShopCategoryId1Name,ShopCategoryId2,ShopCategoryId2Name,ShopCategoryId3,
            //ShopCategoryId3Name,BrandId1,BrandId1Name,BrandId2,BrandId2Name （这里最好一个接口读取过来）


            //3. 读取商品的期初数量BeginQty和期初金额BeginAmt，读取上一次结算的数据,如果为空,那么该商品的期初库存为0，期末库存也为0
            //（这个地方有一个问题,如果上次历史数据中没有这个商品怎么办，要重新读取一次这个商品吗）
            //select * from Settlement s1 inner join SettlementDetail s2 ON s1.ID=s2.RefSet_ID


        }


        /// <summary>
        /// 根据传入的集合，采用事务保存到数据库
        /// </summary>
        /// <param name="warehouseId">仓库ID，决定了连接哪个数据库</param>
        /// <param name="detailWithExtList">日结明细列表</param>
        /// <param name="settlement">日结主表 </param>
        /// <param name="message">执行中的异常信息</param>
        /// <returns>影响的行数</returns>
        private int SaveListToDb(string warehouseId, IList<SettlementDetail> detailWithExtList, Model.Settlement settlement, ref string message)
        {
            if (detailWithExtList == null) throw new ArgumentNullException("detailWithExtList");
            int rows = 0;//计数

            #region 日结明细批量录入 事务开始写入 日志记录
            WriteDebugLog(string.Format(" 7. ===== 日结明细批量录入 事务开始写入{0}条记录 =====", detailWithExtList.Count));
            #endregion

            //事务操作
            var connection = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var detailWithExt in detailWithExtList)
                {
                    rows += DALFactory.GetLazyInstance<ISettlementDetailDAO>(warehouseId).Save(connection, trans, detailWithExt);
                }
                DALFactory.GetLazyInstance<ISettlementDAO>(warehouseId).Save(connection, trans, settlement);
                GetUpdateBillQuery dto = new GetUpdateBillQuery
                                             {
                                                 SettID = settlement.ID,
                                                 SubWid = settlement.SubWID,
                                                 Wid = settlement.WID
                                             };
                DALFactory.GetLazyInstance<ISettlementDAO>(warehouseId).UpdateBillSettleIdAndSettleTime(connection, trans, dto, "P_UpdateBillSettDate");

                trans.Commit();
            }
            catch (Exception ex)
            {
                message += ex.Message;
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

            #region 盘点明细导入 事务写入完成 日志记录
            WriteDebugLog(string.Format(" 8. =====日结明细批量录入 事务写入完成{0}条记录 {1} ==========本次导入结束 ==========", rows, Environment.NewLine));
            #endregion

            return rows;
        }

        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="logContent"></param>
        private void WriteDebugLog(string logContent)
        {
            //使用服务中心框架自带的记录方法
            Logger.Information(logContent);
        }

    }


}
