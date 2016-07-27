
/*****************************
* Author:TangFan
*
* Date:2016-04-27
******************************/
using System;
using System.Collections.Generic;

using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.ID.Model;
using Frxs.Erp.ServiceCenter.ID.IDAL;
using Frxs.Erp.ServiceCenter.ID.BLL;
using System.Reflection;
using System.ComponentModel;
using Frxs.Platform.Utility;



namespace Frxs.Erp.ServiceCenter.ID.BLL
{
    /// <summary>
    /// XSOperatorLog业务逻辑类
    /// </summary>
    public partial class XSOperatorLogBLO
    {

        #region 添加一个XSOperatorLog
        /// <summary>
        /// 添加一个XSOperatorLog
        /// </summary>
        /// <param name="model">XSOperatorLog对象</param>
        /// <returns>最新标识列</returns>
        public static BackMessage<bool> Save(XSOperatorLog model)
        {
            XSOperatorLog.MenuIDEnum menuid = (XSOperatorLog.MenuIDEnum)model.MenuID;
            string MenuName = GetEnumDescription.Description(menuid);
            if (string.IsNullOrEmpty(MenuName)) {
                return BackMessage<bool>.FailBack(false, "操作菜单名称信息错误");
            }
            model.MenuName = MenuName;
            int result = DALFactory.GetLazyInstance<IXSOperatorLogDAO>().Save(model);
            if (result <= 0) {
                return BackMessage<bool>.FailBack(false, "写操作日志失败");
            }
            return BackMessage<bool>.SuccessBack(true);
        }
        #endregion


        #region 分页获取XSOperatorLog集合
        /// <summary>
        /// 分页获取XSOperatorLog集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<XSOperatorLog> GetPageList(PageListBySql<XSOperatorLog> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSOperatorLogDAO>().GetPageList(page, conditionDict);
        }
        #endregion

        public static IList<XSOperatorLogMenu> GetXSOperatorLogMenu()
        {
            return DALFactory.GetLazyInstance<IXSOperatorLogDAO>().GetXSOperatorLogMenu();
        }

    }
}