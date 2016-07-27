using Frxs.Erp.ServiceCenter.Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    public interface IAppVersionDAO
    {
        /// <summary>
        /// 获取指定的更新版本
        /// </summary>
        AppVersionModel GetUpdateModel(int SysType, int AppType);
    }
}
