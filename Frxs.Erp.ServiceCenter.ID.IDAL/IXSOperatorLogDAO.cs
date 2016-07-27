
/*****************************
* Author:TangFan
*
* Date:2016-04-27
******************************/
using System;
using System.Collections.Generic;

using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.ID.Model;


namespace Frxs.Erp.ServiceCenter.ID.IDAL
{
    /// <summary>
    /// ### XSOperatorLog数据库访问接口
    /// </summary>
    public partial interface IXSOperatorLogDAO
    {
        #region 添加一个XSOperatorLog
        /// <summary>
        /// 添加一个XSOperatorLog
        /// </summary>
        /// <param name="model">XSOperatorLog对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(XSOperatorLog model);
        #endregion


        #region 分页获取XSOperatorLog集合
        /// <summary>
        /// 分页获取XSOperatorLog集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<XSOperatorLog> GetPageList(PageListBySql<XSOperatorLog> page, IDictionary<string, object> conditionDict);
        #endregion

        IList<XSOperatorLogMenu> GetXSOperatorLogMenu();

    }
}