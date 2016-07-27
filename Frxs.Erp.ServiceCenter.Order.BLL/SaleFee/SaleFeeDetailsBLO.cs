
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
    /// SaleFeeDetails业务逻辑类
    /// </summary>
    public partial class SaleFeeDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证SaleFeeDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeeDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleFeeDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(model.WID.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleFeeDetails
        /// <summary>
        /// 添加一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleFeeDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(model.WID.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleFeeDetails
        /// <summary>
        /// 更新一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleFeeDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(model.WID.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个SaleFeeDetails
        /// <summary>
        /// 删除一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleFeeDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(model.WID.ToString()).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleFeeDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeeDetails
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string wid,string iD)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(wid).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SaleFeeDetails对象
        /// <summary>
        /// 根据字典获取SaleFeeDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeeDetails对象</returns>
        public static SaleFeeDetails GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(conditionDict["WID"].ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleFeeDetails对象
        /// <summary>
        /// 根据主键获取SaleFeeDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeeDetails对象</returns>
        public static SaleFeeDetails GetModel(string wid,string iD)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(wid).GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleFeeDetails集合
        /// <summary>
        /// 根据字典获取SaleFeeDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleFeeDetails> GetList(int wid,IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleFeeDetailsDAO>(wid.ToString()).GetList(conditionDict);
        }
        #endregion





        #endregion
    }
}