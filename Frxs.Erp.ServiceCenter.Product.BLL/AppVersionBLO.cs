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
	/// APP版本号
	/// </summary>
    public partial class AppVersionBLO
	{

        /// <summary>
        /// 获取指定的更新版本
        /// </summary>
        public static AppVersionModel GetUpdateModel(int SysType, int AppType)
        {
            return DALFactory.GetLazyInstance<IAppVersionDAO>().GetUpdateModel(SysType, AppType);
        }		
	}
}

