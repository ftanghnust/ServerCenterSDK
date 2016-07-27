
/*****************************
* Author:CR
*
* Date:2016-04-25
******************************/
using System;
using System.Collections.Generic;

using System.Linq;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.SDK.Resp;
using Frxs.Erp.ServiceCenter.Product.SDK.Request;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// BuyPreApp业务逻辑类
    /// </summary>
    public partial class BuyPreAppBLO
    {
        #region 成员方法
        #region 根据主键验证BuyPreApp是否存在
        /// <summary>
        /// 根据主键验证BuyPreApp是否存在
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyPreApp model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>().Exists(model);
        }
        #endregion


        #region 添加一个BuyPreApp
        /// <summary>
        /// 添加一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyPreApp model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>().Save(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"> </param>
        /// <param name="model"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public static string Save(int wid, BuyPreApp model, IList<BuyPreAppDetails> details)
        {

            //初使化订单信息
            IDictionary<string, object> dicList = SetLoadData(model, details, wid);

            var connection = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                BuyPreApp buyPreApp = (BuyPreApp)dicList["buyPreApp"];
                IList<BuyPreAppDetails> buyPreAppDetails = (IList<BuyPreAppDetails>)dicList["details"];
                IList<BuyPreAppDetailsExt> buyPreAppDetailsExt = (IList<BuyPreAppDetailsExt>)dicList["detailExtList"];

                if (DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).Save(connection, trans, buyPreApp) <= 0)
                {
                    trans.Rollback();
                    return "保存主单失败！";
                }
                int detailCount = 0;
                int detailExtCount = 0;
                foreach (BuyPreAppDetails detailObj in buyPreAppDetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>(wid.ToString()).Save(connection, trans, detailObj) <= 0)
                    {
                        trans.Rollback();
                        return "保存明细失败！";
                    }
                    detailCount++;
                }
                foreach (BuyPreAppDetailsExt detailExtObj in buyPreAppDetailsExt)
                {
                    if (DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>(wid.ToString()).Save(connection, trans, detailExtObj) <= 0)
                    {
                        trans.Rollback();
                        return "保存明细扩展信息失败！";
                    }

                    detailExtCount++;
                }

                if (detailExtCount == buyPreAppDetailsExt.Count() && detailCount == buyPreAppDetails.Count())
                {
                    trans.Commit();
                    return "0";
                }
                else
                {
                    trans.Rollback();
                    return "保存失败,部分明细保存有错！";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 组装信息
        /// </summary>
        /// <param name="buyPreApp"></param>
        /// <param name="details"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        private static IDictionary<string, object> SetLoadData(BuyPreApp buyPreApp, IList<BuyPreAppDetails> details, int warehouseId)
        {

            IList<BuyPreAppDetailsExt> detailExtList = new List<BuyPreAppDetailsExt>();

            var PIDList = from o in details select o.ProductId;
            //1.调用接口，获取网仓商品信息
            var wProudcts = GetWProductsInfo(warehouseId, PIDList.ToList(), buyPreApp.ModifyUserID.Value, buyPreApp.ModifyUserName);

            //2.调用接口，获取商品信息
            var products = GetProductsInfo(PIDList.ToList(), buyPreApp.ModifyUserID.Value, buyPreApp.ModifyUserName);

            //3.调用接口，获取品牌信息
            var brandIdList = new List<int>();
            foreach (var product in products.ItemList)
            {
                if (product.BrandId1 > 0)
                {
                    brandIdList.Add(product.BrandId1);
                }
                if (product.BrandId2 > 0)
                {
                    brandIdList.Add(product.BrandId2);
                }
            }
            var brandList = GetBrands(brandIdList, buyPreApp.ModifyUserID.Value, buyPreApp.ModifyUserName);

            double TotalOrderAmt = 0.0;    //总金额
            int number = 1;
            var detailsNew = new List<BuyPreAppDetails>();

            foreach (var model in details)
            {
                var wProduct = wProudcts.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                var product = products.ItemList.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                if (product == null)
                {
                    throw new Exception(string.Format("没有找到ID为{0}的商品", model.ProductId));
                }
                if (wProduct == null)
                {
                    throw new Exception(string.Format("仓库中没有找到ID为{0}的商品", model.ProductId));
                }
                model.AppID = model.AppID;
                model.ID = model.AppID + Guid.NewGuid().ToString();

                model.UnitPrice = wProduct.BuyPrice;
                model.AppPrice = model.UnitPrice * model.AppPackingQty;
                model.UnitQty = model.AppQty * model.AppPackingQty;
                model.BarCode = wProduct.BarCode;
                model.ProductImageUrl200 = wProduct.ImageUrl200x200;
                model.ProductImageUrl400 = wProduct.ImageUrl400x400;
                model.ProductName = wProduct.ProductName;
                model.SKU = wProduct.SKU;
                model.SubAmt = model.UnitPrice * model.UnitQty;
                model.Unit = wProduct.Unit;
                model.VendorCode = wProduct.VendorCode;
                model.VendorID = wProduct.VendorID.Value;
                model.VendorName = wProduct.VendorName;
                model.WID = model.WID;
                model.Remark = model.Remark;
                model.SerialNumber = number;
                if (buyPreApp.AppType == 1 && string.IsNullOrEmpty(wProduct.EmpID)) //补货时要求必须加采购员
                {
                    throw new Exception(string.Format("商品编码为{0}的商品缺少相应采购员，无法添加！", wProduct.SKU));
                }  
                model.BuyEmpID = int.Parse( !string.IsNullOrEmpty(wProduct.EmpID) ? wProduct.EmpID : "0");
                model.BuyEmpName = wProduct.EmpName;
                number++;

                TotalOrderAmt = TotalOrderAmt + (double)model.SubAmt;
                BuyPreAppDetailsExt detailsExt = new BuyPreAppDetailsExt();
                var shopCategoryNames = product.ShopCategoryName.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
                detailsExt.ID = model.ID;
                detailsExt.AppID = buyPreApp.AppID;
                detailsExt.ShopCategoryId1 = product.ShopCategoryId1;
                detailsExt.ShopCategoryId1Name = shopCategoryNames[0];
                detailsExt.ShopCategoryId2 = product.ShopCategoryId2;
                detailsExt.ShopCategoryId2Name = shopCategoryNames[1];
                detailsExt.ShopCategoryId3 = product.CategoryId3;
                detailsExt.ShopCategoryId3Name = shopCategoryNames[2];
                detailsExt.BrandId1 = product.BrandId1;

                var brand1 = brandList.Where(x => x.BrandId == detailsExt.BrandId1).FirstOrDefault();
                if (brand1 != null)
                {
                    detailsExt.BrandId1Name = brand1.BrandName;
                }
                else
                {
                    detailsExt.BrandId1Name = "";
                }
                detailsExt.BrandId2 = product.BrandId2;
                var brand2 = brandList.Where(x => x.BrandId == detailsExt.BrandId2).FirstOrDefault();
                if (brand2 != null)
                {
                    detailsExt.BrandId2Name = brand2.BrandName;
                }
                else
                {
                    detailsExt.BrandId1Name = "";
                }
                detailsExt.CategoryId1 = product.CategoryId1;
                detailsExt.CategoryId2 = product.CategoryId2;
                detailsExt.CategoryId3 = product.CategoryId3;
                var categoryNames = product.CategoryName.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
                detailsExt.CategoryId1Name = categoryNames[0];
                detailsExt.CategoryId2Name = categoryNames[1];
                detailsExt.CategoryId3Name = categoryNames[2];
                detailsExt.ModifyTime = DateTime.Now;
                detailsExt.ModifyUserID = buyPreApp.ModifyUserID;
                detailsExt.ModifyUserName = buyPreApp.ModifyUserName;

                detailExtList.Add(detailsExt);
                detailsNew.Add(model);
            }

            buyPreApp.TotalAmt = (decimal)TotalOrderAmt;


            IDictionary<string, object> dicList = new Dictionary<string, object>();
            dicList.Add("buyPreApp", buyPreApp);
            dicList.Add("detailExtList", detailExtList);
            dicList.Add("details", detailsNew);
            return dicList;
        }

        /// <summary>
        /// 获取品牌列表
        /// </summary>
        private static IList<FrxsErpProductBrandCategorieGetResp.BrandCategories> GetBrands(
            IList<int> brandList, int userId, string userName)
        {
            var client = WorkContext.CreateProductSdkClient();
            var req = new FrxsErpProductBrandCategorieGetRequest()
            {
                BrandIds = brandList.ToList(),
                UserId = userId,
                UserName = userName,
                PageIndex = 1,
                PageSize = Int32.MaxValue
            };
            var resp = client.Execute(req);
            if (resp.Flag != 0)
            {
                throw new Exception(resp.Info);
            }
            else
            {
                return resp.Data.ItemList;
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="productIds">商品ID</param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static FrxsErpProductProductListGetResp.FrxsErpProductProductListGetRespData GetProductsInfo(IList<int> productIds, int userId, string userName)
        {
            var client = WorkContext.CreateProductSdkClient();
            var req = new FrxsErpProductProductListGetRequest()
            {
                ProductIds = productIds,
                PageIndex = 1,
                PageSize = int.MaxValue
            };
            var resp = client.Execute(req);
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
        /// 获取仓库商品列表
        /// </summary>
        /// <param name="Wid">仓库ID</param>
        /// <param name="productIds">商品List</param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static IList<FrxsErpProductWProductsGetByIDsExtResp.FrxsErpProductWProductsGetByIDsExtRespData> GetWProductsInfo(int Wid, IList<int> productIds, int userId, string userName)
        {
            var client = WorkContext.CreateProductSdkClient();
            var req = new FrxsErpProductWProductsGetByIDsExtRequest()
            {
                ProductIds = productIds,
                UserId = userId,
                UserName = userName,
                WID = Wid
            };
            var resp = client.Execute(req);
            if (resp.Flag != 0)
            {
                throw new Exception(resp.Info);
            }
            else
            {
                return resp.Data;
            }
        }


        #endregion


        #region 更新一个BuyPreApp
        /// <summary>
        /// 更新一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyPreApp model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>().Edit(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="details"></param>
        /// <param name="detailExt"></param>
        /// <returns></returns>
        public static string Edit(int wid, BuyPreApp model, IList<BuyPreAppDetails> details)
        {
            IDictionary<string, object> dicList = SetLoadData(model, details, wid);

            BuyPreApp buyPreAppModel = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetModel(model.AppID);
            if (buyPreAppModel.Status != 0)
            {
                return "只能对未提交状态单据进行修改！";
            }

            var connection = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                BuyPreApp buyPreApp = (BuyPreApp)dicList["buyPreApp"];
                IList<BuyPreAppDetails> buyPreAppDetails = (IList<BuyPreAppDetails>)dicList["details"];
                IList<BuyPreAppDetailsExt> buyPreAppDetailsExt = (IList<BuyPreAppDetailsExt>)dicList["detailExtList"];

                if (DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).Edit(connection, trans, buyPreApp) <= 0)
                {
                    trans.Rollback();
                    return "保存主单失败！";
                }
                int detailCount = 0;
                int detailExtCount = 0;
                DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>(wid.ToString()).Delete(connection, trans, buyPreApp.AppID);
                foreach (BuyPreAppDetails detailObj in buyPreAppDetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>(wid.ToString()).Save(connection, trans, detailObj) <= 0)
                    {
                        trans.Rollback();
                        return "保存明细失败！";
                    }
                    detailCount++;

                }

                DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>(wid.ToString()).Delete(connection, trans, buyPreApp.AppID);
                foreach (BuyPreAppDetailsExt detailExtObj in buyPreAppDetailsExt)
                {
                    if (DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>(wid.ToString()).Save(connection, trans, detailExtObj) <= 0)
                    {
                        trans.Rollback();
                        return "保存明细扩展信息失败！";
                    }

                    detailExtCount++;
                }

                if (detailExtCount == buyPreAppDetailsExt.Count() && detailCount == buyPreAppDetails.Count())
                {
                    trans.Commit();
                    return "0";
                }
                else
                {
                    trans.Rollback();
                    return "保存失败,部分明细保存有错！";
                }
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion


        #region  状态修改

        /// <summary>
        /// 批量更改状态
        /// </summary>
        /// <param name="buyids"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string ChangeStatus(int wid, IList<string> ids, int status, int userid, string username)
        {
            int row = 0;

            IList<BuyPreApp> modelList = new List<BuyPreApp>();
            IDictionary<string, IList<BuyPreAppDetails>> detailList = new Dictionary<string, IList<BuyPreAppDetails>>();
            IDictionary<string, IList<BuyPreAppDetailsExt>> detailExtList = new Dictionary<string, IList<BuyPreAppDetailsExt>>();
            foreach (var id in ids)
            {
                BuyPreApp model = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetModel(id);

                if (model != null)
                {
                    if (status == 2 && model.Status == 1) //过账
                    {
                        detailList.Add(model.AppID, BuyPreAppDetailsBLO.GetModelList(wid, model.AppID));
                        detailExtList.Add(model.AppID, BuyPreAppDetailsExtBLO.GetModelList(wid, model.AppID));
                    }
                    modelList.Add(model);
                }
                else
                {
                    return "状态更新失败,查找不到指定单号,申请号:" + model.AppID;
                }
            }

            if (modelList == null || modelList.Count <= 0) 
            {

                return "状态更新失败，请刷新单据重新操作!";
            }
            var connection = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    if (status == 1 && model.Status == 0) //状态(0:未提交;1:已提交;2:已过帐;)
                    {
                        model.ConfTime = DateTime.Now;
                        model.ConfUserID = userid;
                        model.ConfUserName = username;

                    }
                    else if (status == 2 && model.Status == 1) //过账
                    {
                        model.PostingTime = DateTime.Now;
                        model.PostingUserID = userid;
                        model.PostingUserName = username;

                    }
                    else if (status == 0 && model.Status == 1) //反确定
                    {
                        model.ConfTime = null;
                        model.ConfUserID = null;
                        model.ConfUserName = null;
                    }
                    else  //其他的为错误
                    {
                        trans.Rollback();
                        return "状态操作失败，请刷新信息正确操作";
                    }

                    model.Status = status;
                    model.ModifyUserID = userid;
                    model.ModifyUserName = username;
                    model.ModifyTime = DateTime.Now;

                    if (DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).EditStatus(model, connection, trans) > 0)
                    {
                        row = row + 1;
                    }
                    else
                    {
                        trans.Rollback();
                        return "状态更新失败,申请号:" + model.AppID;
                    }

                    if (model.Status == 2)
                    {

                        if (model.AppType == 0) //返配
                        {
                            //BuyBackPre 操作

                            string result = CopeToBuyBack(wid, model, detailList[model.AppID], detailExtList[model.AppID], connection, trans);
                            if (result != "0")
                            {
                                trans.Rollback();
                                return result + "  申请号:" + model.AppID;
                            }

                        }
                        else if (model.AppType == 1)  //补货
                        {
                            //BuyOrderPre 操作

                            string result = CopeToBuyOrder(wid, model, detailList[model.AppID], detailExtList[model.AppID], connection, trans);
                            if (result != "0")
                            {
                                trans.Rollback();
                                return result + "  申请号:" + model.AppID;
                            }
                        }
                    }


                }
                if (row == ids.Count)
                {
                    trans.Commit();
                    return "0";
                }
                else
                {
                    trans.Rollback();
                    return "状态更新失败,部分申请号有错";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        #endregion


        /// <summary>
        /// 获取 ID
        /// </summary>
        /// <returns></returns>
        private static string GetID(string idType, int wid, int userId, string userName)
        {
            string id = string.Empty;
            var ServiceCenter = WorkContext.CreateIDSdkClient();
            var resp = ServiceCenter.Execute(new Frxs.Erp.ServiceCenter.ID.SDK.Request.FrxsErpIdIdsGetRequest()
            {
                WID = wid,
                Type = idType == "0" ? Frxs.Erp.ServiceCenter.ID.SDK.Request.FrxsErpIdIdsGetRequest.IDTypes.BuyBack : Frxs.Erp.ServiceCenter.ID.SDK.Request.FrxsErpIdIdsGetRequest.IDTypes.BuyOrder,
                UserId = userId,
                UserName = userName

            });

            if (resp != null && resp.Flag == 0)
            {
                id = resp.Data;
            }
            return id;
        }


        /// <summary>
        ///   复制到采购收购
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="appId"></param>
        /// <returns>返回0表正确</returns>
        private static string CopeToBuyOrder(int wid, BuyPreApp model, IList<BuyPreAppDetails> detailList, IList<BuyPreAppDetailsExt> detailExtList, IDbConnection conn, IDbTransaction tran)
        {
            try
            {
                BuyPreApp orderTemp = model;
              

                if (detailList != null)
                {
                    IList<BuyOrderPre> orderPreList = new List<BuyOrderPre>();
                    IList<BuyOrderPreDetails> orderDetailsList = new List<BuyOrderPreDetails>();
                    IList<BuyOrderPreDetailsExt> orderDetailsExtList = new List<BuyOrderPreDetailsExt>();

                    foreach (BuyPreAppDetails detailobj in detailList)
                    {
                        BuyOrderPre tempPreObj = orderPreList.FirstOrDefault(o => o.VendorID == detailobj.VendorID  && o.BuyEmpID == detailobj.BuyEmpID);
                        if (tempPreObj == null) //没有创建主单
                        {
                            #region 主单

                            tempPreObj = new BuyOrderPre();
                            tempPreObj.BuyEmpID = detailobj.BuyEmpID.HasValue ? detailobj.BuyEmpID.Value : 0;
                            tempPreObj.BuyEmpName = detailobj.BuyEmpName;
                            tempPreObj.BuyID = GetID(orderTemp.AppType.ToString(), wid, orderTemp.ModifyUserID.Value, orderTemp.ModifyUserName); //调用ID库
                            tempPreObj.CreateTime = DateTime.Now;
                            tempPreObj.CreateUserID = orderTemp.ModifyUserID.Value;
                            tempPreObj.CreateUserName = orderTemp.ModifyUserName;
                            tempPreObj.ModifyTime = DateTime.Now;
                            tempPreObj.ModifyUserID = orderTemp.ModifyUserID.Value;
                            tempPreObj.ModifyUserName = orderTemp.ModifyUserName;
                            tempPreObj.OrderDate = orderTemp.AppDate;
                            tempPreObj.PreBuyID = "";
                            tempPreObj.Remark = "补货申请单：" + orderTemp.AppID + " 生成";
                            tempPreObj.SettleID = "";
                            tempPreObj.Status = 0;
                            tempPreObj.SubWCode = orderTemp.SubWCode;
                            tempPreObj.SubWID = orderTemp.SubWID;
                            tempPreObj.SubWName = orderTemp.SubWName;
                            tempPreObj.TotalOrderAmt = double.Parse(detailobj.SubAmt.ToString());
                            tempPreObj.VendorCode = detailobj.VendorCode;
                            tempPreObj.VendorID = detailobj.VendorID;
                            tempPreObj.VendorName = detailobj.VendorName;
                            tempPreObj.WCode = orderTemp.WCode;
                            tempPreObj.WID = orderTemp.WID;
                            tempPreObj.WName = orderTemp.WName;
                            #endregion

                            orderPreList.Add(tempPreObj);
                        }
                        else
                        {
                            tempPreObj.TotalOrderAmt = tempPreObj.TotalOrderAmt + double.Parse(detailobj.SubAmt.ToString());

                        }

                        #region  明细生成

                        BuyOrderPreDetails detail = new BuyOrderPreDetails();
                        detail.BuyID = tempPreObj.BuyID;
                        detail.BarCode = detailobj.BarCode;
                        detail.BuyPackingQty = detailobj.AppPackingQty;
                        detail.BuyPrice = double.Parse(detailobj.AppPrice.ToString());
                        detail.BuyQty = detailobj.AppQty;
                        detail.BuyUnit = detailobj.AppUnit;
                        detail.ID = detailobj.ID;
                        detail.ModifyTime = tempPreObj.ModifyTime;
                        detail.ModifyUserID = tempPreObj.ModifyUserID;
                        detail.ModifyUserName = tempPreObj.ModifyUserName;
                        detail.ProductId = detailobj.ProductId;
                        detail.ProductImageUrl200 = detailobj.ProductImageUrl200;
                        detail.ProductImageUrl400 = detailobj.ProductImageUrl400;
                        detail.ProductName = detailobj.ProductName;
                        detail.Remark = detailobj.Remark;
                        detail.SerialNumber = detailobj.SerialNumber;
                        detail.SKU = detailobj.SKU;
                        detail.SubAmt = double.Parse(detailobj.SubAmt.ToString());
                        detail.Unit = detailobj.Unit;
                        detail.UnitPrice = double.Parse(detailobj.UnitPrice.ToString());
                        detail.UnitQty = detailobj.UnitQty;
                        detail.WID = detailobj.WID;
                        orderDetailsList.Add(detail);
                        #endregion


                        #region  明细扩展生成

                        BuyPreAppDetailsExt buyPreAppDetailsExt = detailExtList.FirstOrDefault(o => o.ID == detailobj.ID);

                        if (buyPreAppDetailsExt != null)
                        {
                            BuyOrderPreDetailsExt buyOrderPreDetailsExt = new BuyOrderPreDetailsExt();
                            buyOrderPreDetailsExt.BuyID = tempPreObj.BuyID;
                            buyOrderPreDetailsExt.BrandId1 = buyPreAppDetailsExt.BrandId1 == null ? 0 : buyPreAppDetailsExt.BrandId1.Value;
                            buyOrderPreDetailsExt.BrandId1Name = buyPreAppDetailsExt.BrandId1Name;
                            buyOrderPreDetailsExt.BrandId2 = buyPreAppDetailsExt.BrandId2 == null ? 0 : buyPreAppDetailsExt.BrandId2.Value; ;
                            buyOrderPreDetailsExt.BrandId2Name = buyPreAppDetailsExt.BrandId2Name;
                            buyOrderPreDetailsExt.CategoryId1 = buyPreAppDetailsExt.CategoryId1;
                            buyOrderPreDetailsExt.CategoryId1Name = buyPreAppDetailsExt.CategoryId1Name;
                            buyOrderPreDetailsExt.CategoryId2 = buyPreAppDetailsExt.CategoryId2;
                            buyOrderPreDetailsExt.CategoryId2Name = buyPreAppDetailsExt.CategoryId2Name;
                            buyOrderPreDetailsExt.CategoryId3 = buyPreAppDetailsExt.CategoryId3;
                            buyOrderPreDetailsExt.CategoryId3Name = buyPreAppDetailsExt.CategoryId3Name;
                            buyOrderPreDetailsExt.ID = buyPreAppDetailsExt.ID;
                            buyOrderPreDetailsExt.ModifyTime = tempPreObj.ModifyTime;
                            buyOrderPreDetailsExt.ModifyUserID = tempPreObj.ModifyUserID;
                            buyOrderPreDetailsExt.ModifyUserName = tempPreObj.ModifyUserName;
                            buyOrderPreDetailsExt.ShopCategoryId1 = buyPreAppDetailsExt.ShopCategoryId1;
                            buyOrderPreDetailsExt.ShopCategoryId1Name = buyPreAppDetailsExt.ShopCategoryId1Name;
                            buyOrderPreDetailsExt.ShopCategoryId2 = buyPreAppDetailsExt.ShopCategoryId2;
                            buyOrderPreDetailsExt.ShopCategoryId2Name = buyPreAppDetailsExt.ShopCategoryId2Name;
                            buyOrderPreDetailsExt.ShopCategoryId3 = buyPreAppDetailsExt.ShopCategoryId3;
                            buyOrderPreDetailsExt.ShopCategoryId3Name = buyPreAppDetailsExt.ShopCategoryId3Name;

                            orderDetailsExtList.Add(buyOrderPreDetailsExt);
                        }
                        #endregion


                    }

                    string result = BuyOrderPreBLO.Save(orderPreList, orderDetailsList, orderDetailsExtList, wid.ToString(), conn, tran);

                    return result;
                }

                return "查找申请单明细为空! 申请单:" + model.AppID;

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        /// <summary>
        /// 复制到采购退货
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        private static string CopeToBuyBack(int wid, BuyPreApp model, IList<BuyPreAppDetails> detailList, IList<BuyPreAppDetailsExt> detailExtList, IDbConnection conn, IDbTransaction tran)
        {
            try
            {
                BuyPreApp orderTemp = model;
             
                if (detailList != null)
                {
                    IList<BuyBackPre> orderPreList = new List<BuyBackPre>();
                    IList<BuyBackPreDetails> orderDetailsList = new List<BuyBackPreDetails>();
                    IList<BuyBackPreDetailsExt> orderDetailsExtList = new List<BuyBackPreDetailsExt>();

                    foreach (BuyPreAppDetails detailobj in detailList)
                    {
                        BuyBackPre tempPreObj = orderPreList.FirstOrDefault(o => o.VendorID == detailobj.VendorID);
                        if (tempPreObj == null) //没有创建主单
                        {
                            #region 主单

                            tempPreObj = new BuyBackPre();
                            tempPreObj.BuyEmpID = detailobj.BuyEmpID.HasValue ? detailobj.BuyEmpID.Value : 0;
                            tempPreObj.BuyEmpName = detailobj.BuyEmpName;
                            tempPreObj.BackID = GetID(orderTemp.AppType.ToString(), wid, orderTemp.ModifyUserID.Value, orderTemp.ModifyUserName); //调用ID库
                            tempPreObj.CreateTime = DateTime.Now;
                            tempPreObj.CreateUserID = orderTemp.ModifyUserID.Value;
                            tempPreObj.CreateUserName = orderTemp.ModifyUserName;
                            tempPreObj.ModifyTime = DateTime.Now;
                            tempPreObj.ModifyUserID = orderTemp.ModifyUserID.Value;
                            tempPreObj.ModifyUserName = orderTemp.ModifyUserName;
                            tempPreObj.OrderDate = orderTemp.AppDate;
                            tempPreObj.PreBuyID = "";
                            tempPreObj.Remark = "返配申请单：" + orderTemp.AppID + " 生成";
                            tempPreObj.SettleID = "";
                            tempPreObj.Status = 0;
                            tempPreObj.SubWCode = orderTemp.SubWCode;
                            tempPreObj.SubWID = orderTemp.SubWID;
                            tempPreObj.SubWName = orderTemp.SubWName;
                            tempPreObj.TotalAmt = double.Parse(detailobj.SubAmt.ToString());
                            tempPreObj.VendorCode = detailobj.VendorCode;
                            tempPreObj.VendorID = detailobj.VendorID;
                            tempPreObj.VendorName = detailobj.VendorName;
                            tempPreObj.WCode = orderTemp.WCode;
                            tempPreObj.WID = orderTemp.WID;
                            tempPreObj.WName = orderTemp.WName;
                            #endregion

                            orderPreList.Add(tempPreObj);
                        }
                        else
                        {
                            tempPreObj.TotalAmt = tempPreObj.TotalAmt + double.Parse(detailobj.SubAmt.ToString());

                        }

                        #region  明细生成

                        BuyBackPreDetails detail = new BuyBackPreDetails();
                        detail.BackID = tempPreObj.BackID;
                        detail.BarCode = detailobj.BarCode;
                        detail.BackPackingQty = detailobj.AppPackingQty;
                        detail.BackPrice = double.Parse(detailobj.AppPrice.ToString());
                        detail.BackQty = detailobj.AppQty;
                        detail.BackUnit = detailobj.AppUnit;
                        detail.ID = detailobj.ID;
                        detail.ModifyTime = tempPreObj.ModifyTime;
                        detail.ModifyUserID = tempPreObj.ModifyUserID;
                        detail.ModifyUserName = tempPreObj.ModifyUserName;
                        detail.ProductId = detailobj.ProductId;
                        detail.ProductImageUrl200 = detailobj.ProductImageUrl200;
                        detail.ProductImageUrl400 = detailobj.ProductImageUrl400;
                        detail.ProductName = detailobj.ProductName;
                        detail.Remark = detailobj.Remark;
                        detail.SerialNumber = detailobj.SerialNumber;
                        detail.SKU = detailobj.SKU;
                        detail.SubAmt = double.Parse(detailobj.SubAmt.ToString());
                        detail.Unit = detailobj.Unit;
                        detail.UnitPrice = double.Parse(detailobj.UnitPrice.ToString());
                        detail.UnitQty = detailobj.UnitQty;
                        detail.WID = detailobj.WID;
                        orderDetailsList.Add(detail);
                        #endregion


                        #region  明细扩展生成

                        BuyPreAppDetailsExt buyPreAppDetailsExt = detailExtList.FirstOrDefault(o => o.ID == detailobj.ID);

                        if (buyPreAppDetailsExt != null)
                        {
                            BuyBackPreDetailsExt buyOrderPreDetailsExt = new BuyBackPreDetailsExt();
                            buyOrderPreDetailsExt.BackID = tempPreObj.BackID;
                            buyOrderPreDetailsExt.BrandId1 = buyPreAppDetailsExt.BrandId1 == null ? 0 : buyPreAppDetailsExt.BrandId1.Value;
                            buyOrderPreDetailsExt.BrandId1Name = buyPreAppDetailsExt.BrandId1Name;
                            buyOrderPreDetailsExt.BrandId2 = buyPreAppDetailsExt.BrandId2 == null ? 0 : buyPreAppDetailsExt.BrandId2.Value; ;
                            buyOrderPreDetailsExt.BrandId2Name = buyPreAppDetailsExt.BrandId2Name;
                            buyOrderPreDetailsExt.CategoryId1 = buyPreAppDetailsExt.CategoryId1;
                            buyOrderPreDetailsExt.CategoryId1Name = buyPreAppDetailsExt.CategoryId1Name;
                            buyOrderPreDetailsExt.CategoryId2 = buyPreAppDetailsExt.CategoryId2;
                            buyOrderPreDetailsExt.CategoryId2Name = buyPreAppDetailsExt.CategoryId2Name;
                            buyOrderPreDetailsExt.CategoryId3 = buyPreAppDetailsExt.CategoryId3;
                            buyOrderPreDetailsExt.CategoryId3Name = buyPreAppDetailsExt.CategoryId3Name;
                            buyOrderPreDetailsExt.ID = buyPreAppDetailsExt.ID;
                            buyOrderPreDetailsExt.ModifyTime = tempPreObj.ModifyTime;
                            buyOrderPreDetailsExt.ModifyUserID = tempPreObj.ModifyUserID;
                            buyOrderPreDetailsExt.ModifyUserName = tempPreObj.ModifyUserName;
                            buyOrderPreDetailsExt.ShopCategoryId1 = buyPreAppDetailsExt.ShopCategoryId1;
                            buyOrderPreDetailsExt.ShopCategoryId1Name = buyPreAppDetailsExt.ShopCategoryId1Name;
                            buyOrderPreDetailsExt.ShopCategoryId2 = buyPreAppDetailsExt.ShopCategoryId2;
                            buyOrderPreDetailsExt.ShopCategoryId2Name = buyPreAppDetailsExt.ShopCategoryId2Name;
                            buyOrderPreDetailsExt.ShopCategoryId3 = buyPreAppDetailsExt.ShopCategoryId3;
                            buyOrderPreDetailsExt.ShopCategoryId3Name = buyPreAppDetailsExt.ShopCategoryId3Name;

                            orderDetailsExtList.Add(buyOrderPreDetailsExt);
                        }
                        #endregion


                    }

                    string result = BuyBackPreBLO.Save(orderPreList, orderDetailsList, orderDetailsExtList, wid.ToString(), conn, tran);

                    return result;
                }

                return "查找申请单明细为空! 申请单:" + model.AppID; ;

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        #region 删除一个BuyPreApp


        /// <summary>
        /// 删除一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public static string Delete(int wid, IList<string> ids)
        {
            IList<BuyPreApp> modelList = new List<BuyPreApp>();
            foreach (var id in ids)
            {
                BuyPreApp orderTemp = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetModel(id);
                if (orderTemp.Status != 0)  //未提交状态
                {
                   
                    if (orderTemp.AppType == 1)
                    {

                        return "非录单状态的补货申请单不能删除";
                    }
                    else
                    {
                        return "非录单状态的反配申请单不能删除";

                    }
                }
                modelList.Add(orderTemp);
            }

            var connection = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    int detailResult = DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>(wid.ToString()).Delete(connection, trans, model.AppID);//删除明细表
                    if (detailResult > 0)
                    {
                        DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>(wid.ToString()).Delete(connection, trans, model.AppID); //删除护展表信息 
                        int result = DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).Delete(model.AppID, connection, trans);
                        if (result < 0)
                        {
                            trans.Rollback();
                            return "删除主表失败！申请号：" + model.AppID;
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return "删除明细失败！申请号: " + model.AppID;
                    }
                }
                trans.Commit();
                return "0";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }


        }
        #endregion


        #region 根据主键逻辑删除一个BuyPreApp
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreApp
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string appID)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>().LogicDelete(appID);
        }
        #endregion



        #region 根据主键获取BuyPreApp对象
        /// <summary>
        /// 根据主键获取BuyPreApp对象
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>BuyPreApp对象</returns>
        public static BuyPreApp GetModel(int wid, string appID)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetModel(appID);
        }
        #endregion




        #region 根据字典获取BuyPreApp数据集
        /// <summary>
        /// 根据字典获取BuyPreApp数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取BuyPreApp集合
        /// <summary>
        /// 分页获取BuyPreApp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyPreApp> GetPageList(int wid, PageListBySql<BuyPreApp> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDAO>(wid.ToString()).GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }
}