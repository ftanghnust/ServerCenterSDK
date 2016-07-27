
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
    /// SaleFeePreDetails业务逻辑类
    /// </summary>
    public partial class SaleFeePreDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证SaleFeePreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeePreDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleFeePreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(model.WID.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleFeePreDetails
        /// <summary>
        /// 添加一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleFeePreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(model.WID.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleFeePreDetails
        /// <summary>
        /// 更新一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleFeePreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(model.WID.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个SaleFeePreDetails
        /// <summary>
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleFeePreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(model.WID.ToString()).Delete(model);
        }

        /// <summary>
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string wid,string feeId,IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid).Delete(feeId, conn, trans);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleFeePreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid,string iD)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SaleFeePreDetails对象
        /// <summary>
        /// 根据字典获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePreDetails对象</returns>
        public static SaleFeePreDetails GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(conditionDict["WID"].ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleFeePreDetails对象
        /// <summary>
        /// 根据主键获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeePreDetails对象</returns>
        public static SaleFeePreDetails GetModel(string wid,string iD)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(wid).GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleFeePreDetails集合
        /// <summary>
        /// 根据字典获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleFeePreDetails> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(conditionDict["WID"].ToString()).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleFeePreDetails数据集
        /// <summary>
        /// 根据字典获取SaleFeePreDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(conditionDict["WID"].ToString()).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleFeePreDetails集合
        /// <summary>
        /// 分页获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleFeePreDetails> GetPageList(PageListBySql<SaleFeePreDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeePreDetailsDAO>(conditionDict["WID"].ToString()).GetPageList(page, conditionDict);
        }
        #endregion


     

        #endregion
    }
}