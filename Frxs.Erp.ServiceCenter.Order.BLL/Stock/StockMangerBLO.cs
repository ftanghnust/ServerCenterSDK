using Frxs.Erp.ServiceCenter.Order.IDAL.Order.Stock;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.IOCFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.BLL.Stock
{
    public class StockMangerBLO
    {

        public class StockCRModel
        {
            public int ProductID { get; set; }

            /// <summary>
            /// 库存单位库存数量
            /// </summary>
            public decimal StockQty { get; set; }

            public decimal PyQty { get; set; }
 
        }
        
        /// <summary>
        /// 批次是否可负库存出库
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static bool BatStockOutToIsAllowNStockout(BatStockOutModel model, IDbConnection conn, IDbTransaction tran, ref string msg)
        {
            bool result = false;
            msg = "";//提示消息初始化
            bool isAllowNStockout = WorkContext.IsStockOutInventory();
            if (!isAllowNStockout)
            {
                //直接调出库方法
                return BatStockOut(model, isAllowNStockout, conn, tran, ref msg);
            }

            //获取需要盘盈的商品列表
            List<StockCRModel> pkList = GetLessProductQtyList(model, conn, tran, ref msg);
            
            if (pkList.Count > 0)
            {
                BackMessage<bool> pyResult = GoToPY(model, pkList, conn, tran, ref msg);
                msg = pyResult.Message;//盘点消息
                result = pyResult.Data;//盘点结果
                if (result)
                {
                    //执行出库操作
                   result = BatStockOut(model, isAllowNStockout, conn, tran, ref msg);
                }
            }
            else
            {
                //执行出库操作
                result = BatStockOut(model, isAllowNStockout, conn, tran, ref msg);
            }
            return result;
        }

        /// <summary>
        /// 获取需要盘盈的商品列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static List<StockCRModel> GetLessProductQtyList(BatStockOutModel model, IDbConnection conn, IDbTransaction tran, ref string msg)
        {
            List<StockCRModel> pkList = new List<StockCRModel>();
            List<int> lisPd = new List<int>();
            foreach (StockOutInPutInModel md in model.OutPList)
            {
                if (md.OutQty <= 0)
                {
                    //如果出库数量小于等于0 ，不处理
                    continue;
                }
                lisPd.Add(md.ProductID);
            }
            if (lisPd.Count == 0)
            {
                return pkList;
            }
            IStockMangerDAO manDAO = DALFactory.GetLazyInstance<IStockMangerDAO>(model.WID.ToString());
            IList<StockQtyModel> stList = manDAO.QueryStockQtyList(new StockQtyQueryModel() { WID = model.WID, SubWID = model.SubWID, ProductList = lisPd }, conn, tran);           
            foreach (StockOutInPutInModel md in model.OutPList)
            {
                if (md.OutQty <= 0)
                {
                    //如果出库数量小于等于0 ，不处理
                    continue;
                }
                if (stList == null || stList.Count == 0)
                {
                    pkList.Add(new StockCRModel() { ProductID = md.ProductID, StockQty = 0, PyQty = md.OutQty });//全部需要盘盈
                    continue;
                }
                IList<StockQtyModel> resultList = stList.Where(item => item.ProductId == md.ProductID).ToList();
                if (resultList == null || resultList.Count() == 0)
                {
                    pkList.Add(new StockCRModel() { ProductID = md.ProductID, StockQty = 0, PyQty = md.OutQty });//全部需要盘盈
                    continue;
                }
                if (resultList[0].StockQty < md.OutQty)
                {
                    pkList.Add(new StockCRModel() { ProductID = md.ProductID, StockQty = resultList[0].StockQty, PyQty = md.OutQty - resultList[0].StockQty });//需要盘盈
                    continue;
                }
            }
            return pkList;
        }


        /// <summary>
        /// 执行自动盘盈
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pkList"></param>
        /// <returns></returns>
        public static BackMessage<bool> GoToPY(BatStockOutModel model,List<StockCRModel> pkList,IDbConnection conn, IDbTransaction tran, ref string msg)
        {
            StockAdj stockAdj = new StockAdj();
            IList<StockAdjDetail> details = new List<StockAdjDetail>();
            IList<StockAdjDetailsExt> detailsExts = new List<StockAdjDetailsExt>();
            
            stockAdj.RefBID = model.OrderId;
            stockAdj.WID=model.WID; //传
            stockAdj.WCode=model.WCode; //传
            stockAdj.WName=model.WName;//传
            stockAdj.SubWID=model.SubWID;//传
            stockAdj.SubWCode=model.SubWCode;//传
            stockAdj.SubWName = model.SubWName;//传
            stockAdj.Remark = string.Format("订单：{0}盘盈",model.OrderId);
            StockOutInPutInModel temp;
            StockAdjDetailsExt extMod;
            IList<string> skus=new List<string>();
            foreach (var item in pkList)
            {
                //原对象
                temp = model.OutPList.Where(i => i.ProductID == item.ProductID).FirstOrDefault();
                skus.Add(temp.SKU);
                details.Add(new StockAdjDetail()
                {
                    ProductId = item.ProductID,//传
                    SKU = temp.SKU,//传
                    ProductName = temp.BaseData.ProductName,//传
                    BarCode = temp.BaseData.BarCode,//有值则传，没值不传
                    ProductImageUrl200 = temp.BaseData.ProductImageUrl200,//有值则传，没值不传
                    ProductImageUrl400 = temp.BaseData.ProductImageUrl400,//有值则传，没值不传
                    AdjUnit = temp.BaseData.Unit,//传
                    AdjPackingQty = 1,//传
                    AdjQty = (decimal)item.PyQty,//传 //调整数量
                    Unit = temp.BaseData.Unit,//传
                    UnitQty = (decimal)item.PyQty,//传                  
                    SalePrice = temp.BaseData.UnitPrice,//传
                    AdjAmt = System.Math.Round((decimal)item.PyQty * temp.BaseData.UnitPrice,4),//传  保留四位小数               
                    StockQty = item.StockQty,//传
                });
            }
            #region 由于商品部分信息查询是使用sku列表，单独处理填充数据
            if (skus.Count<=0)
            {
                return BackMessage<bool>.FailBack(false, "没有找到商品SKU信息");
            }
            var productWorkContext = WorkContext.CreateProductSdkClient();
            var prdResp = productWorkContext.Execute(new Product.SDK.Request.FrxsErpProductWProductsAddedListForStockImportGetRequest()
            {
                WID = stockAdj.WID,
                SKUs = skus,
                UserId = model.CreateUserID.HasValue?model.CreateUserID.Value:0,
                UserName = model.CreateUserName,
                PageIndex = 1,
                PageSize = int.MaxValue
            });
            if(prdResp==null)
            {
                 return BackMessage<bool>.FailBack(false, "查询商品信息失败");
            }
            foreach (var detail in details)
            {
                var product = prdResp.Data.ItemList.FirstOrDefault(x => x.ProductId == detail.ProductId);
                if(product==null)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("查询商品{0}的信息失败",detail.ProductName));
                }
                detail.VendorID = product.VendorID.HasValue?product.VendorID.Value:0;
                detail.VendorName = product.VendorName;
                detail.VendorCode = product.VendorCode;
                detail.BuyPrice = product.BuyPrice.HasValue?product.BuyPrice.Value:0;

                //获取商品扩展信息
                extMod = new StockAdjDetailsExt();
                extMod.BrandId1 = product.BrandId1;
                extMod.BrandId1Name = product.BrandId1Name;
                extMod.BrandId2 = product.BrandId2;
                extMod.BrandId2Name = product.BrandId2Name;
                extMod.CategoryId1 = (int)product.CategoryId1;
                extMod.CategoryId1Name = product.CategoryId1Name;
                extMod.CategoryId2 = (int)product.CategoryId2;
                extMod.CategoryId2Name = product.CategoryId2Name;
                extMod.CategoryId3 = (int)product.CategoryId3;
                extMod.CategoryId3Name = product.CategoryId3Name;
                extMod.ShopCategoryId1 = (int)product.ShopCategoryId1;
                extMod.ShopCategoryId1Name = product.ShopCategoryId1Name;
                extMod.ShopCategoryId2 = (int)product.ShopCategoryId2;
                extMod.ShopCategoryId2Name = product.ShopCategoryId2Name;
                extMod.ShopCategoryId3 = (int)product.ShopCategoryId3;
                extMod.ShopCategoryId3Name = product.ShopCategoryId3Name;
                extMod.AdjID = "";
                detailsExts.Add(extMod);
            }
            #endregion
            //调用盘盈
            BackMessage<bool> result = StockAdjBLO.CreateAutoStockAdjSurplus(stockAdj, details, detailsExts, model.WID,
                                                     new BaseUserModel() { UserId = (int)model.CreateUserID, UserName = model.CreateUserName }, conn, tran);
            return result;
        }


        /// <summary>
        /// 批次出库
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static bool BatStockOut(BatStockOutModel model, bool isAllowNStockout, IDbConnection conn, IDbTransaction tran, ref string msg)
        {
            msg = "";//提示消息初始化
            IStockMangerDAO manDAO = DALFactory.GetLazyInstance<IStockMangerDAO>(model.WID.ToString());
            IList<StockQtyModel> stList = null;
            foreach (StockOutInPutInModel md in model.OutPList)
            {
                if (md.OutQty <= 0)
                {
                    //如果出库数量小于等于0 ，不处理
                    continue;
                }
                stList = manDAO.QueryStockQtyList(new StockQtyQueryModel() { WID = model.WID, SubWID = model.SubWID, ProductId = md.ProductID },conn,tran);
                if (stList == null || stList.Count == 0)
                {
                    msg = string.Format("找不到商品[{0}]库存信息",string.IsNullOrEmpty(md.SKU)?md.ProductID.ToString():md.SKU);
                    return false;
                }
                if (stList.Count > 1)
                {
                    msg = string.Format("商品[{0}]库存异常，存在多条库存记录！", stList[0].SKU);
                    return false;
                }
                if (isAllowNStockout == false && stList[0].StockQty < md.OutQty)
                {                    
                    msg = string.Format("商品[{0}]库存不足,总数量差：{1}", stList[0].SKU, stList[0].StockQty - md.OutQty);  //提示由productid 改为SKU 唐凡
                    return false;
                }

                //change库存信息
                manDAO.UpdateStockQty(stList[0].ID, StockType.StockQty, -md.OutQty, (int)model.CreateUserID, model.CreateUserName, conn, tran);

                //处理批次出库信息
                IList<StockFIFOInModel> batSList = manDAO.QueryStockFIFOInList(new QueryStockFIFOInModel() { WID = model.WID, SubWID = model.SubWID, ProductID = md.ProductID, Flag = 0 }, conn, tran);
                if (batSList != null && batSList.Count > 0)
                {
                    decimal nStockCount = batSList.Sum(it => it.Qty - it.TotalOutQty);
                    if (isAllowNStockout == false && nStockCount < md.OutQty)
                    {
                        msg = string.Format("商品[{0}]批次库存不足,差额{1}", stList[0].SKU, nStockCount - md.OutQty); //提示由productid 改为SKU 唐凡
                        return false;
                    }
                    decimal sqty = 0;
                    decimal nqty = md.OutQty;

                    #region 批次出库
                    StockFIFOInModel oit = null;
                    for (int i = 0; i < batSList.Count; i++)
                    {
                        oit = batSList[i];                    
                        if (nqty == 0)
                        {
                            //退出
                            break;
                        }
                        if (((oit.Qty - oit.TotalOutQty) - nqty) >= 0)
                        {
                            sqty = nqty;//本次减库存数
                        }
                        else
                        {
                            sqty = (oit.Qty - oit.TotalOutQty);//本次减库存数
                        }
                        nqty -= sqty;//剩余需减库存

                        oit.TotalOutQty = oit.TotalOutQty + sqty;
                        if (oit.TotalOutQty == oit.Qty)
                        {
                            oit.Flag = 1;
                        }
                        oit.StockQty = stList[0].StockQty - sqty;//当前商品当前库存数
                        manDAO.UpdateStockFIFOIn(oit, conn, tran);//更新批次库存

                        //增加出库批次
                        manDAO.AddStockFIFOOut(new StockFIFOOutModel()
                        {
                            InID = oit.InID,
                            BillID = model.BillID,
                            BillDetailID = md.BillDetailID,
                            OutQty = sqty,//出库数
                            ProductID = md.ProductID,
                            StockQty = stList[0].StockQty - sqty,//当前出库后库存
                            StockTime = DateTime.Now,
                            BillType = model.BillType,
                            SubWID = model.SubWID,
                            WID = model.WID,
                            VendorID = oit.VendorID
                        }, conn, tran);
                        if (nqty == 0)
                        {
                            //退出
                            break;
                        }
                    }
                    #endregion
                }
            } 
            return true;
        }


        /// <summary>
        /// 批次入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>        
        public static bool BatStockIn(BatStockInModel model, IDbConnection conn, IDbTransaction tran)
        {
            bool result = false;

            var res = WorkContext.CreateProductSdkClient().Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWarehouseSubWarehouseValidateRequest()
            {
                SubWID = model.SubWID,
                WID = model.WID,
            });
            if (res == null)
            {
                throw new Exception("验证仓库信息，服务器没有响应！");
            }
            else if (res.Flag != 0)
            {
                throw new Exception(res.Info);
            }
            

            IList<StockQtyModel> stListSource = null;

            List<int> lisPd = new List<int>();
            foreach (StockFIFOInModel md in model.InPList)
            {
                if (md.Qty <= 0)
                {
                    //如果出库数量小于等于0 ，不处理
                    continue;
                }
                lisPd.Add(md.ProductID);
            }
            
            IStockMangerDAO manDAO = DALFactory.GetLazyInstance<IStockMangerDAO>(model.WID.ToString());
            //查询商品全部库存信息
            stListSource = manDAO.QueryStockQtyList(new StockQtyQueryModel() { WID = model.WID, SubWID = model.SubWID, ProductList = lisPd }, conn, tran);

            IList<StockQtyModel> stListTemp = null;
            foreach (StockFIFOInModel md in model.InPList)
            {
                stListTemp = stListSource.Where(item => item.ProductId == md.ProductID).ToList();//得到当前库存信息
                if (stListTemp == null || stListTemp.Count == 0)
                {
                    //insert库存信息
                    manDAO.AddStockQty(new StockQtyModel()
                    {
                        BuyTranQty = 0,
                        SubWID=md.SubWID,//子机构ID
                        WID=md.WID,//仓库ID,
                        SKU= md.SKU,//SKU
                        ProductName=md.ProductName,
                        CreateTime = DateTime.Now,
                        CreateUserID = model.CreateUserID,
                        CreateUserName = model.CreateUserName,
                        ProductId = md.ProductID,
                        SaleTranQty = 0,
                        StockQty = md.Qty,//库存单位数量
                        UpdateStockTime = DateTime.Now,
                        ModifyTime = DateTime.Now
                    }, conn, tran);
                    md.StockQty = md.Qty;//库存单位数量
                }
                else
                {
                    //change库存信息
                    manDAO.UpdateStockQty(stListTemp[0].ID, StockType.StockQty, md.Qty, (int)model.CreateUserID, model.CreateUserName, conn, tran);
                    md.StockQty = stListTemp[0].StockQty+md.Qty;//库存单位数量
                }

                //if (md.VendorID <= 0 && (md.BillType==1 || md.BillType==2))
                //{
                //    //获取默认主供应商
                //    md.VendorID = 43;
                //    md.VendorCode="0000167";
                //    md.VendorName = "0000167市绿香源米业有限公司";
                //}
                //批次入库
                if (md.VendorID <= 0 || string.IsNullOrEmpty(md.VendorCode))
                {
                    throw new Exception(string.Format("[{0}]主供应商为空！",md.SKU));
                }
                manDAO.AddStockFIFOIn(md, conn, tran);
            }
            result = true;

            return result;
        }

       /// <summary>
        /// 批次入库
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>        
        public static bool BatStockIn(BatStockInModel model)
        {
            bool result = false;
            IDbConnection conn = null;
            IDbTransaction tran = null;     
            IStockMangerDAO manDAO =DALFactory.GetLazyInstance<IStockMangerDAO>(model.WID.ToString());
            try
            {
                conn = manDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                BatStockIn(model, conn, tran);//批次入库
                tran.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }


    }
}
