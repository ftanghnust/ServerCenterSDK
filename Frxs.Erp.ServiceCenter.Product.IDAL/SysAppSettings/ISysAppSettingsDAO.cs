
/*****************************
* Author:TangFan
*
* Date:2016-06-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 系统字符串配置表SysAppSettings数据库访问接口
    /// </summary>
    public partial interface ISysAppSettingsDAO
    {
        /// <summary>
        /// 根据主键获取SysAppSettings对象
        /// </summary>
        /// <param name="iD">ID主键</param>
        /// <returns>SysAppSettings对象</returns>
        SysAppSettings GetModel(int WID, string SKey);
    }
}