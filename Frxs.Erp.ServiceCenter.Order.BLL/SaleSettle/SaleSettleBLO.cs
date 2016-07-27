
/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;

using System.Linq;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Erp.ServiceCenter.Order.BLL.Stock;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleSettle业务逻辑类
    /// </summary>
    public partial class SaleSettleBLO
    {
        #region 成员方法
        #region 根据主键验证SaleSettle是否存在
        /// <summary>
        /// 根据主键验证SaleSettle是否存在
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleSettle model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个SaleSettle
        /// <summary>
        /// 添加一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static string Save(SaleSettle model, string warehouseId, SaleOrderPrePacking packingModel,BaseUserModel user=null)
        {
            int result = 0;
            string message = string.Empty;

            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                var SaleOrderPreModel = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(warehouseId).GetModel(connection, trans, model.OrderID);

                if (SaleOrderPreModel == null)
                {
                    trans.Rollback();
                    return "未查到ID为：" + model.OrderID + "的订单，请查询后重新提交！";
                }

                if (SaleOrderPreModel.Status != 4)
                {
                    trans.Rollback();
                    return "销售订单状态已改变，请查询后重新提交！";
                }
                Dictionary<string, object> conditionDict = new Dictionary<string, object>();
                conditionDict.Add("OrderId", SaleOrderPreModel.OrderId);
                var SaleOrderPreDetailsList = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(warehouseId).GetList(connection, trans, conditionDict);

                var list = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetList(connection, trans, model.ShopID, model.WID);

                IList<SaleSettleTemp> saleSettleTempList = new List<SaleSettleTemp>();

                decimal Amt = decimal.Zero;
                foreach (SaleSettleTemp item in list)
                {
                    Amt += item.BillPayAmt;
                    if (SaleOrderPreModel.PayAmount + Amt >= 0)
                    {
                        saleSettleTempList.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }

                #region 1、保存销售订单装箱数表

                DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).Save(connection, trans, packingModel);

                #endregion

                #region 2、保存结算单主表
                model.BackAmt = (from s in saleSettleTempList
                                 where s.BillType == 1
                                 select s.BillPayAmt)
                   .Sum();
                model.FeeAmt = (from s in saleSettleTempList
                                where s.BillType == 2
                                select s.BillPayAmt)
                   .Sum();
                model.SaleAmt = SaleOrderPreModel.PayAmount;
                model.SettleAmt = model.SaleAmt + model.FeeAmt + model.BackAmt;
                model.ModifyTime = DateTime.Now;
                model.CreateTime = DateTime.Now;
                model.SettleTime = DateTime.Now;
                model.WName = SaleOrderPreModel.WName;
                model.WCode = SaleOrderPreModel.WCode;
                DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Save(connection, trans, model);

                IList<Field> fieldList = new List<Field>();
                fieldList.Add(new Field
                {
                    FieldName = "PostingUserID",
                    FieldValue = model.CreateUserID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "PostingTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "PostingUserName",
                    FieldValue = model.CreateUserName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "ConfUserID",
                    FieldValue = model.CreateUserID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "ConfTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "ConfUserName",
                    FieldValue = model.CreateUserName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                IList<WhereCondition> whereConditionList = new List<WhereCondition>();
                whereConditionList.Add(
                  new WhereCondition
                  {
                      AttachSymbol = Attach.And,
                      CompareSymbol = Compare.Equals,
                      FieldObj = new Field
                      {
                          FieldName = "SettleID",
                          FieldValue = model.SettleID,
                          FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                          FieldLength = 50
                      }
                  }
                );

                result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleSettle");//更新销售订单__待处理单据

                #endregion

                #region 3、保存结算单明细
                SaleSettleDetail detail = new SaleSettleDetail();
                detail.ID = model.WID + Guid.NewGuid().ToString();
                detail.SettleID = model.SettleID;
                detail.WID = model.WID;
                detail.BillType = 0;
                detail.BillID = model.OrderID;
                detail.BillDate = DateTime.Parse(SaleOrderPreModel.OrderDate.ToString());
                detail.BillAmt = SaleOrderPreModel.TotalProductAmt;
                detail.BillAddAmt = SaleOrderPreModel.TotalAddAmt.HasValue ? SaleOrderPreModel.TotalAddAmt.Value : 0;
                detail.BillPayAmt = SaleOrderPreModel.PayAmount;
                detail.ModifyUserID = model.ModifyUserID;
                detail.ModifyUserName = model.ModifyUserName;
                detail.ModifyTime = DateTime.Now;

                DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Save(connection, trans, detail);

                foreach (SaleSettleTemp item in saleSettleTempList)
                {
                    detail = new SaleSettleDetail();
                    detail = Frxs.Platform.Utility.Map.AutoMapperHelper.MapTo<SaleSettleDetail>(item);
                    detail.ID = model.WID + Guid.NewGuid().ToString();
                    detail.SettleID = model.SettleID;
                    detail.WID = model.WID;
                    detail.ModifyUserID = model.ModifyUserID;
                    detail.ModifyUserName = model.ModifyUserName;
                    detail.ModifyTime = DateTime.Now;
                    DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Save(connection, trans, detail);
                }
                #endregion

                #region 4、更新销售订单__待处理单据

                fieldList = new List<Field>();
                fieldList.Add(new Field
                {
                    FieldName = "Status",
                    FieldValue = 5,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                });

                fieldList.Add(new Field
                {
                    FieldName = "SettleID",
                    FieldValue = model.SettleID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "PackingEmpID",
                    
                    FieldValue =user==null?model.CreateUserID:user.UserId,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "PackingTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "PackingEmpName",
                    FieldValue =user==null? model.CreateUserName:user.UserName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                whereConditionList = new List<WhereCondition>();
                whereConditionList.Add(
                  new WhereCondition
                  {
                      AttachSymbol = Attach.And,
                      CompareSymbol = Compare.Equals,
                      FieldObj = new Field
                      {
                          FieldName = "OrderId",
                          FieldValue = model.OrderID,
                          FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                          FieldLength = 50
                      }
                  }
                );

                whereConditionList.Add(
                 new WhereCondition
                 {
                     AttachSymbol = Attach.And,
                     CompareSymbol = Compare.Equals,
                     FieldObj = new Field
                     {
                         FieldName = "Status",
                         ParamterName = "OrderStatusWhere",
                         FieldValue = 4,
                         FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                     }
                 }
               );

                result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleOrderPre");//更新销售订单__待处理单据
                if (result == 0)
                {
                    message = "销售订单状态已改变，请查询后重新提交！";
                    trans.Rollback();
                    return message;
                }
                #endregion

                #region 5、新增订单跟踪表
                //新增订单跟踪表
                SaleOrderTrack trackModel = new SaleOrderTrack();
                trackModel.ID = model.WID + Guid.NewGuid().ToString();
                trackModel.OrderID = model.OrderID;
                trackModel.WID = model.WID;
                trackModel.Remark = "您的订单已经装箱完成，等待装车";
                trackModel.IsDisplayUser = 1;
                trackModel.OrderStatus = 5;
                trackModel.OrderStatusName = "装箱完成";
                trackModel.CreateTime = DateTime.Now;
                trackModel.CreateUserID = model.CreateUserID;
                trackModel.CreateUserName = model.CreateUserName;
                DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Save(connection, trans, trackModel);
                #endregion

                #region 6、更新退货单状态
                var BillID = (from s in saleSettleTempList
                              where s.BillType == 1
                              select s.BillID);
                foreach (string item in BillID)
                {
                    fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "Status",
                        FieldValue = 3,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleID",
                        FieldValue = model.SettleID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleUserName",
                        FieldValue = model.CreateUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleUserID",
                        FieldValue = model.CreateUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "BackID",
                              FieldValue = item,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    whereConditionList.Add(
                     new WhereCondition
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.Equals,
                         FieldObj = new Field
                         {
                             FieldName = "Status",
                             ParamterName = "OrderStatusWhere",
                             FieldValue = 2,
                             FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                         }
                     }
                   );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleBack");//更新退货单订单
                    if (result == 0)
                    {
                        message = "退货单状态已改变，请查询后重新提交！";
                        trans.Rollback();
                        return message;
                    }
                }
                #endregion

                #region 7、更新费用明细表
                var BillDetailsID = (from s in saleSettleTempList
                                     where s.BillType == 2
                                     select s.BillDetailsID);
                foreach (string item in BillDetailsID)
                {
                    fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleID",
                        FieldValue = model.SettleID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserName",
                        FieldValue = model.CreateUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserID",
                        FieldValue = model.CreateUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "ID",
                              FieldValue = item,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleFeeDetails");//更新费用明细表      
                    if (result == 0)
                    {
                        message = "费用明细状态已改变，请查询后重新提交！";
                        trans.Rollback();
                        return message;
                    }
                }
                #endregion

                #region 8、更新费用表

                result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).SaveSaleFeeStatus(connection, trans, model.SettleID, model.WID, model.CreateUserID, model.CreateUserName);//更新费用表

                #endregion

                #region 9、修改库存

                BatStockOutModel outMod = new BatStockOutModel();
                outMod.WID = SaleOrderPreModel.WID;
                outMod.SubWID = SaleOrderPreModel.SubWID.HasValue ? SaleOrderPreModel.SubWID.Value : 0;
                outMod.BillType = 4;
                outMod.BillID = SaleOrderPreModel.OrderId;
                outMod.CreateUserID = model.CreateUserID;
                outMod.CreateUserName = model.CreateUserName;

                //以下字段自动盘盈时需使用
                outMod.SubWCode = SaleOrderPreModel.SubWCode;
                outMod.SubWName = SaleOrderPreModel.SubWName;
                outMod.WCode = SaleOrderPreModel.WCode;
                outMod.WName = SaleOrderPreModel.WName;
                outMod.OrderId = SaleOrderPreModel.OrderId;//订单号

                IList<StockOutInPutInModel> OutPList = new List<StockOutInPutInModel>();
                foreach (var item in SaleOrderPreDetailsList)
                {
                    if (item.UnitQty > 0)
                    {
                        StockOutInPutInModel temp = new StockOutInPutInModel();
                        temp.BillDetailID = item.ID;
                        temp.ProductID = item.ProductId;
                        temp.OutQty = item.UnitQty;
                        temp.SKU = item.SKU;

                        //以下数据自动盘盈时需使用
                        temp.BaseData = new StockOutInPutInModelOther();
                        temp.BaseData.BarCode = item.BarCode;
                        temp.BaseData.ProductImageUrl200 = item.ProductImageUrl200;
                        temp.BaseData.ProductImageUrl400 = item.ProductImageUrl400;
                        temp.BaseData.ProductName = item.ProductName;
                        temp.BaseData.SalePackingQty = item.SalePackingQty;
                        temp.BaseData.SalePrice = item.SalePrice;
                        temp.BaseData.SaleUnit = item.SaleUnit;
                        temp.BaseData.Unit = item.Unit;
                        temp.BaseData.UnitPrice = item.UnitPrice;
                        temp.BaseData.WCProductID = item.WCProductID;
                        
                        OutPList.Add(temp);
                    }
                }
                outMod.OutPList = OutPList;
                string msg = "";
                if (!StockMangerBLO.BatStockOutToIsAllowNStockout(outMod,connection, trans, ref msg))
                {
                    //异常
                    trans.Rollback();
                    message = msg;
                    return message;
                }
                #endregion


                trans.Commit();
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

            return message;
        }
        #endregion

        #region 添加一个SaleSettle
        /// <summary>
        /// 添加一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static string Save(SaleSettle model, string warehouseId, IList<SaleSettleDetail> Details)
        {
            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (!DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Exists(connection, trans, model))
                {
                    model.ModifyTime = DateTime.Now;
                    model.CreateTime = DateTime.Now;
                    model.SettleTime = DateTime.Now;
                    DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Save(connection, trans, model);

                    #region 3、保存结算单明细

                    foreach (SaleSettleDetail item in Details)
                    {
                        item.ID = model.WID + Guid.NewGuid().ToString();
                        item.SettleID = model.SettleID;
                        item.WID = model.WID;
                        item.ModifyUserID = model.ModifyUserID;
                        item.ModifyUserName = model.ModifyUserName;
                        item.ModifyTime = DateTime.Now;
                        DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Save(connection, trans, item);
                    }
                    #endregion
                }
                else
                {
                    trans.Rollback();
                    return "订单ID已经存在，请查询后重新提交！";
                }



                trans.Commit();
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

            return message;
        }
        #endregion

        #region 更新一个SaleSettle
        /// <summary>
        /// 更新一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static string Edit(SaleSettle model, string warehouseId, IList<SaleSettleDetail> Details)
        {
            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (!DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Exists(connection, trans, model))
                {
                    trans.Rollback();
                    return "订单ID不存在，请查询后重新提交！";
                }

                SaleSettle modelOld = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetModel(connection, trans, model.SettleID);

                if (modelOld.Status != 0)
                {
                    trans.Rollback();
                    return "订单不是录单状态，请查询后重新提交！";
                }

                model.ModifyTime = DateTime.Now;
                DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Edit(connection, trans, model);

                #region 3、保存结算单明细
                DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Delete(connection, trans, model.SettleID);
                foreach (SaleSettleDetail item in Details)
                {
                    item.ID = model.WID + Guid.NewGuid().ToString();
                    item.SettleID = model.SettleID;
                    item.WID = model.WID;
                    item.ModifyUserID = model.ModifyUserID;
                    item.ModifyUserName = model.ModifyUserName;
                    item.ModifyTime = DateTime.Now;
                    DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Save(connection, trans, item);
                }
                #endregion

                trans.Commit();
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

            return message;
        }
        #endregion


        #region 更新一个SaleSettle
        /// <summary>
        /// 更新一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleSettle model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleSettle model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Delete(model);
        }
        #endregion

        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static string Delete(string SettleID, string warehouseId)
        {
            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                SaleSettle modelOld = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetModel(connection, trans, SettleID);

                if (modelOld.Status != 0)
                {
                    trans.Rollback();
                    return "订单不是录单状态，请查询后重新提交！";
                }

                DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Delete(connection, trans, SettleID);


                DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Delete(connection, trans, SettleID);


                trans.Commit();
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

            return message;
        }
        #endregion

        #region 过账
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static string Post(SaleSettle model, string warehouseId, IList<SaleSettleDetail> Details)
        {
            int result = 0;
            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                SaleSettle modelOld = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetModel(connection, trans, model.SettleID);

                if (modelOld.Status != 1)
                {
                    trans.Rollback();
                    return "订单不是确认状态，请查询后重新提交！";
                }

                //DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).Edit(connection, trans, model);
                //IList<Field> fieldList = new List<Field>();
                //IList<WhereCondition> whereConditionList = new List<WhereCondition>();

                IList<Field> fieldList = new List<Field>();
                fieldList.Add(new Field
                {
                    FieldName = "Status",
                    FieldValue = 2,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                });

                fieldList.Add(new Field
                {
                    FieldName = "PostingUserID",
                    FieldValue = model.PostingUserID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "PostingTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "PostingUserName",
                    FieldValue = model.PostingUserName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "ModifyUserID",
                    FieldValue = model.ModifyUserID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                fieldList.Add(new Field
                {
                    FieldName = "ModifyTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "ModifyUserName",
                    FieldValue = model.ModifyUserName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                    FieldLength = 50
                });

                IList<WhereCondition> whereConditionList = new List<WhereCondition>();
                whereConditionList.Add(
                  new WhereCondition
                  {
                      AttachSymbol = Attach.And,
                      CompareSymbol = Compare.Equals,
                      FieldObj = new Field
                      {
                          FieldName = "SettleID",
                          FieldValue = model.SettleID,
                          FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                          FieldLength = 50
                      }
                  }
                );

                whereConditionList.Add(
                 new WhereCondition
                 {
                     AttachSymbol = Attach.And,
                     CompareSymbol = Compare.Equals,
                     FieldObj = new Field
                     {
                         FieldName = "Status",
                         ParamterName = "OrderStatusWhere",
                         FieldValue = 1,
                         FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                     }
                 }
               );

                result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleSettle");//更新销售订单__待处理单据
                if (result == 0)
                {
                    message = "订单不是确认状态，请查询后重新提交！";
                    trans.Rollback();
                    return message;
                }

                #region 6、更新退货单状态
                var BillID = (from s in Details
                              where s.BillType == 1
                              select s.BillID);
                foreach (string item in BillID)
                {
                    fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "Status",
                        FieldValue = 3,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleID",
                        FieldValue = model.SettleID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleUserName",
                        FieldValue = model.ModifyUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleUserID",
                        FieldValue = model.ModifyUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "BackID",
                              FieldValue = item,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    whereConditionList.Add(
                     new WhereCondition
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.Equals,
                         FieldObj = new Field
                         {
                             FieldName = "Status",
                             ParamterName = "OrderStatusWhere",
                             FieldValue = 2,
                             FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                         }
                     }
                   );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleBack");//更新退货单订单
                    if (result == 0)
                    {
                        message = string.Format("结算单【{0}】明细中的退货单【{1}】不是过账状态，不能结算！", model.SettleID, item);
                        trans.Rollback();
                        return message;
                    }
                }
                #endregion

                #region 7、更新费用明细表
                var BillDetailsID = (from s in Details
                                     where s.BillType == 2
                                     select s.BillDetailsID);
                foreach (string item in BillDetailsID)
                {
                    fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "SettleID",
                        FieldValue = model.SettleID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserName",
                        FieldValue = model.CreateUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserID",
                        FieldValue = model.CreateUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "ID",
                              FieldValue = item,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    whereConditionList.Add(
                     new WhereCondition
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.IsNull,
                         FieldObj = new Field
                         {
                             FieldName = "SettleID",
                             FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                             FieldLength = 50
                         }
                     }
                   );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleFeeDetails");//更新费用明细表      
                    if (result == 0)
                    {
                        var saleSettleDetail = Details.FirstOrDefault(i => i.BillDetailsID.ToLower().Trim() == item.ToLower().Trim());
                        if (saleSettleDetail == null)
                        {
                            message = string.Format("结算单明细数据读取错误");
                        }
                        if (saleSettleDetail != null)
                        {
                            string sBillID = saleSettleDetail.BillID;
                            message = string.Format("结算单【{0}】明细中的费用明细【{1}】已结算,不能再结算,请查询后重新提交", model.SettleID, sBillID);
                        }
                        trans.Rollback();
                        return message;
                    }
                }
                #endregion

                #region 8、更新费用表

                result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).SaveSaleFeeStatus(connection, trans, model.SettleID, model.WID, (int)model.ModifyUserID, model.ModifyUserName);//更新费用表


                #endregion

                trans.Commit();
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

            return message;
        }
        #endregion

        #region 确认或者反确认
        /// <summary>
        /// 确认或者反确认
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static string SureOrNo(SaleSettle model, string warehouseId, bool Sure)
        {
            int result = 0;
            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (Sure)
                {
                    IList<Field> fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "Status",
                        FieldValue = 1,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ConfUserID",
                        FieldValue = model.ConfUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ConfTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ConfUserName",
                        FieldValue = model.ConfUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserID",
                        FieldValue = model.ModifyUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserName",
                        FieldValue = model.ModifyUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    IList<WhereCondition> whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "SettleID",
                              FieldValue = model.SettleID,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    whereConditionList.Add(
                     new WhereCondition
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.Equals,
                         FieldObj = new Field
                         {
                             FieldName = "Status",
                             ParamterName = "OrderStatusWhere",
                             FieldValue = 0,
                             FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                         }
                     }
                   );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleSettle");//更新销售订单__待处理单据
                    if (result == 0)
                    {
                        message = "单据状态已改变，请查询后重新提交！";
                        trans.Rollback();
                        return message;
                    }
                }
                else
                {
                    IList<Field> fieldList = new List<Field>();
                    fieldList.Add(new Field
                    {
                        FieldName = "Status",
                        FieldValue = 0,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ConfUserID",
                        FieldValue = DBNull.Value,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ConfTime",
                        FieldValue = DBNull.Value,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ConfUserName",
                        FieldValue = DBNull.Value,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserID",
                        FieldValue = model.ModifyUserID,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    });
                    fieldList.Add(new Field
                    {
                        FieldName = "ModifyUserName",
                        FieldValue = model.ModifyUserName,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    });

                    IList<WhereCondition> whereConditionList = new List<WhereCondition>();
                    whereConditionList.Add(
                      new WhereCondition
                      {
                          AttachSymbol = Attach.And,
                          CompareSymbol = Compare.Equals,
                          FieldObj = new Field
                          {
                              FieldName = "SettleID",
                              FieldValue = model.SettleID,
                              FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                              FieldLength = 50
                          }
                      }
                    );

                    whereConditionList.Add(
                     new WhereCondition
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.Equals,
                         FieldObj = new Field
                         {
                             FieldName = "Status",
                             ParamterName = "OrderStatusWhere",
                             FieldValue = 1,
                             FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                         }
                     }
                   );

                    result = DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(connection, trans, fieldList, whereConditionList, "SaleSettle");//更新销售订单__待处理单据
                    if (result == 0)
                    {
                        message = "单据状态已改变，请查询后重新提交！";
                        trans.Rollback();
                        return message;
                    }
                }

                trans.Commit();
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

            return message;
        }
        #endregion


        #region 根据主键逻辑删除一个SaleSettle
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettle
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string settleID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).LogicDelete(settleID);
        }
        #endregion


        #region 根据字典获取SaleSettle对象
        /// <summary>
        /// 根据字典获取SaleSettle对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleSettle对象</returns>
        public static SaleSettle GetModel(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取SaleSettle对象
        /// <summary>
        /// 根据主键获取SaleSettle对象
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleSettle对象</returns>
        public static SaleSettle GetModel(string settleID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetModel(settleID);
        }
        #endregion


        #region 根据字典获取SaleSettle集合
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<SaleSettle> GetList(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取SaleSettle数据集
        /// <summary>
        /// 根据字典获取SaleSettle数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleSettle集合

        /// <summary>
        /// 分页获取SaleSettle集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="totalAmt">添加 总页面合计字段</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleSettle> GetPageList(PageListBySql<SaleSettle> page, IDictionary<string, object> conditionDict, string warehouseId,out decimal totalAmt)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).GetPageList(page, conditionDict,out totalAmt);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 获取零时表
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public static IList<SaleSettleTemp> GetList(int ShopID, int WID)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDAO>(WID.ToString()).GetList(ShopID, WID);
        }
        #endregion


        #endregion
    }
}