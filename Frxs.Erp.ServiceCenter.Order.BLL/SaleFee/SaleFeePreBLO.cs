
/*****************************
* Author:CR
*
* Date:2016-03-28
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleFeePre业务逻辑类
    /// </summary>
    public partial class SaleFeePreBLO
    {
        #region 成员方法
        #region 根据主键验证SaleFeePre是否存在
        /// <summary>
        /// 根据主键验证SaleFeePre是否存在
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleFeePre model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(model.WID.ToString()).Exists(model);
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
        public static int ChangeStatus(int wid,string ids, int status, int userid, string username)
        {
            var idsArr = ids.Split(',');
            int row = 0;
            IList<SaleFeePre> modelList = new List<SaleFeePre>();
            foreach (var id in idsArr)
            {
                SaleFeePre model = SaleFeePreBLO.GetModel(wid.ToString(), id);
                modelList.Add(model);
            }

            var connection = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    if (model != null)
                    {
                        if (status == 1 && model.Status == 0) //状态(0:未提交;1:已提交;2:已过帐;3:已结算)
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
                        else if (status == 3 && model.Status == 2) //结算
                        {
                          
                            model.SettleTime = DateTime.Now;
                            model.SettleUserID = userid;
                            model.SettleUserName = username;

                        }
                        else if (status == 1 && model.Status == 2) //反账
                        {
                            model.PostingTime = null;
                            model.PostingUserID = null ;
                            model.PostingUserName = null;

                            if (SaleFeePreBLO.EditStatusReset(wid,model, connection, trans) > 0)
                            {
                                row = row + 1;
                            }
                            else
                            {
                                trans.Rollback();
                                return 0;
                            }
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
                            return 0;
                        }

                        model.Status = status;
                        model.ModifyUserID = userid;
                        model.ModifyUserName = username;
                        model.ModifyTime = DateTime.Now;
                        if (SaleFeePreBLO.EditStatus(wid,model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return 0;
                        }

                        if (model.Status == 2)
                        {

                            //复制主表
                            DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).EditAndCopy(model.FeeID, connection, trans);
                            //复制明细表
                            DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).EditAndCopy2(model.FeeID, connection, trans);
                            //删除明细表
                            DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid.ToString()).Delete(model.FeeID, connection, trans);
                            //删除待处理主表
                            DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).LogicDelete(model.FeeID, connection, trans);
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
                    }

                }
                trans.Commit();
                return row;
            }
            catch (Exception)
            {
                trans.Rollback();
                return 0;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        #endregion



        #region 添加一个SaleFeePre
        /// <summary>
        /// 添加一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(int wid,SaleFeePre model)
        {

            var connection = DALFactory.GetLazyInstance<ISaleFeeDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                int id = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).Save(model, connection, trans);
                if (id <= 0)
                {
                    trans.Rollback();
                    return 0;
                }
                int detailscount = 0;
                foreach (var obj in model.detailList)
                {

                    if (DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid.ToString()).Save(obj, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return 0;
                    }
                    detailscount = detailscount + 1;
                }
                if (detailscount == model.detailList.Count)
                {
                    trans.Commit();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    return 0;
                }
            }
            catch (Exception)
            {
                trans.Rollback();
                return 0;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion


        #region 更新一个SaleFeePre
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public static string Edit(int wid,SaleFeePre model)
        {

            SaleFeePre orderTemp = SaleFeePreBLO.GetModel(wid.ToString(), model.FeeID);

            if (orderTemp == null || orderTemp.Status != 0)  //不是未提交状态
            {
                return "修改单据失败，单据已删除或状态不为录单";
            }
            var connection = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                if (DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).Edit(model, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return "修改单据失败!";
                }
                if (SaleFeePreDetailsBLO.Delete(wid.ToString(), model.FeeID, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return "修改单据明细失败，仓库为："+wid.ToString();
                }

                int detailscount = 0;
                foreach (var obj in model.detailList)
                {

                    if (DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid.ToString()).Save(obj, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return "保存单据明细失败，仓库为：" + wid.ToString();
                    }
                    detailscount = detailscount + 1;
                }

                if (detailscount == model.detailList.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "修改单据失败!";
                }
            }
            catch (Exception)
            {
                trans.Rollback();
                return "修改单据报错";
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(model.WID.ToString()).Edit(model, conn, trans);
        }
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int EditStatus(int wid,SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).EditStatus(model, conn, trans);
        }

        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int EditStatusReset(int wid ,SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).EditStatusReset(model, conn, trans);
        }
        #endregion


        #region 删除一个SaleFeePre
        /// <summary>
        /// 删除一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleFeePre model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(model.WID.ToString()).Delete(model);
        }
        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string wid,string ids)
        {

            var idsArr = ids.Split(',');
            int row = 0;
            IList<SaleFeePre> modelList = new List<SaleFeePre>();
            foreach (var id in idsArr)
            {
                SaleFeePre model = SaleFeePreBLO.GetModel(wid, id);
                if (model.Status != 0)
                {
                    return 0;
                }
                modelList.Add(model);
            }
            var connection = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    SaleFeePreDetailsBLO.Delete(wid, model.FeeID, connection, trans);//删除明细
                    if (SaleFeePreBLO.LogicDelete(wid, model.FeeID, connection, trans) > 0)
                    {
                        row = row + 1;
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
                    }

                }
                trans.Commit();
                return row;
            }
            catch (Exception)
            {
                trans.Rollback();
                return 0;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion


        #region 根据主键逻辑删除一个SaleFeePre
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePre
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid,string feeID)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid).LogicDelete(feeID);
        }

        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid, string feeID, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid).LogicDelete(feeID, conn, trans);
        }

        #endregion




        #region 根据字典获取SaleFeePre对象
        /// <summary>
        /// 根据字典获取SaleFeePre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePre对象</returns>
        public static SaleFeePre GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(conditionDict["WID"].ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleFeePre对象
        /// <summary>
        /// 根据主键获取SaleFeePre对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFeePre对象</returns>
        public static SaleFeePre GetModel(string wid,string feeID)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid).GetModel(feeID);
        }
        #endregion


        #region 根据字典获取SaleFeePre集合
        /// <summary>
        /// 根据字典获取SaleFeePre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleFeePre> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(conditionDict["WID"].ToString()).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleFeePre数据集
        /// <summary>
        /// 根据字典获取SaleFeePre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(conditionDict["WID"].ToString()).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleFeePre集合
        /// <summary>
        /// 分页获取SaleFeePre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleFeePre> GetPageList(PageListBySql<SaleFeePre> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDAO>(conditionDict["WID"].ToString()).GetPageList(page, conditionDict);
        }
        #endregion



        #endregion
    }
}