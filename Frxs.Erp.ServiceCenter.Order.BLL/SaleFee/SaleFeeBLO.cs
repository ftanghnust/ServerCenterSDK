
/*****************************
* Author:chujl
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
    /// SaleFee业务逻辑类
    /// </summary>
    public partial class SaleFeeBLO
    {
        #region 成员方法
        #region 根据主键验证SaleFee是否存在
        /// <summary>
        /// 根据主键验证SaleFee是否存在
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleFee model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(model.WID.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleFee
        /// <summary>
        /// 添加一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleFee model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(model.WID.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleFee
        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleFee model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(model.WID.ToString()).Edit(model);
        }

        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleFee model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(model.WID.ToString()).Edit(model, conn,trans);
        }


        #endregion


        #region 删除一个SaleFee
        /// <summary>
        /// 删除一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleFee model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(model.WID.ToString()).Delete(model);
        }

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string wid,string ids)
        {
            //return LazyDAOObjectCreator..LogicDelete(ids);

            var idsArr = ids.Split(',');
            int row = 0;
            var connection = DALFactory.GetLazyInstance<ISaleFeeDAO>(wid).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var id in idsArr)
                {
                    if (SaleFeeBLO.LogicDelete(wid,id, connection, trans) > 0)
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


        #region 根据主键逻辑删除一个SaleFee
        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid,string feeID)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(wid).LogicDelete(feeID);
        }

        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid,string feeID, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(wid).LogicDelete(feeID, conn, trans);
        }
        #endregion


        #region 根据字典获取SaleFee对象
        /// <summary>
        /// 根据字典获取SaleFee对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFee对象</returns>
        public static SaleFee GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(conditionDict["WID"].ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleFee对象
        /// <summary>
        /// 根据主键获取SaleFee对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFee对象</returns>
        public static SaleFee GetModel(string wid,string feeID)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(wid).GetModel(feeID);
        }
        #endregion


        #region 根据字典获取SaleFee集合
        /// <summary>
        /// 根据字典获取SaleFee集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleFee> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(conditionDict["WID"].ToString()).GetList(conditionDict);
        }
        #endregion


        #region 分页获取SaleFee集合

        /// <summary>
        /// 分页获取SaleFee集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="totalAmt">总合计</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleFee> GetPageList(int wid,PageListBySql<SaleFee> page, IDictionary<string, object> conditionDict, out decimal totalAmt)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDAO>(wid.ToString()).GetPageList(page, conditionDict, out totalAmt);
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
        public static int ChangeStatus(string wid,string ids, int status, int userid, string username)
        {
            var idsArr = ids.Split(',');
            int row = 0;
            var connection = DALFactory.GetLazyInstance<ISaleFeeDAO>(wid).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var id in idsArr)
                {

                    SaleFee model = SaleFeeBLO.GetModel(wid,id);
                    if (model != null)
                    {
                        if (model.Status == 1) //状态(0:未提交;1:已提交;2:已过帐;3:已结算)
                        {
                          
                            model.ConfTime = DateTime.Now;
                            model.ConfUserID = userid;
                            model.ConfUserName = username;

                        }else if (model.Status == 2 ){

                            model.PostingTime = DateTime.Now;
                            model.PostingUserID = userid;
                            model.PostingUserName = username;
                        }
                        else if (model.Status == 3)
                        {
                            model.SettleTime = DateTime.Now;
                            model.SettleUserID = userid;
                            model.SettleUserName = username;
                        }
                        model.Status = status;
                        model.ModifyUserID = userid;
                        model.ModifyUserName = username;
                        model.ModifyTime = DateTime.Now;

                        if (SaleFeeBLO.Edit(model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return 0;
                        }
                    }

                }
                trans.Commit();
                return row;
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

        #endregion
    }
}