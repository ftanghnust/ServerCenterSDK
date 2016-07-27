
/*****************************
* Author:TangFan
*
* Date:2016-06-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 系统字符串配置表SysAppSettings业务逻辑类
    /// </summary>
    public partial class SysAppSettingsBLO
    {
        /// <summary>
        /// 根据主键获取SysAppSettings对象
        /// </summary>
        /// <param name="iD">ID主键</param>
        /// <returns>SysAppSettings对象</returns>
        public static SysAppSettings GetModel(int WID, string SKey)
        {
            return DALFactory.GetLazyInstance<ISysAppSettingsDAO>().GetModel(WID, SKey);
        }
    }
}