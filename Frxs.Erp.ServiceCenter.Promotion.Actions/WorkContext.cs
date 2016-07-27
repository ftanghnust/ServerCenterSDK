using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.Erp.ServiceCenter.Product.SDK;
using ProductApiClient = Frxs.Erp.ServiceCenter.Product.SDK.DefaultApiClient;
using ProductApiUser = Frxs.Erp.ServiceCenter.Product.SDK.ApiUser;

namespace Frxs.Erp.ServiceCenter.Promotion
{
    /// <summary>
    /// 当前工作上下文
    /// </summary>
    public class WorkContext
    {
        ///<summary>
        ///基础信息库接口
        ///</summary>
        public static ProductApiClient GetErpProductSDKClient()
        {
            return new ProductApiClient(sdkConfigSectionName: "frxsErpProductSdkConfig", defaultUser: () => new ProductApiUser { UserId = -1, UserName = "Admin" });
        }
    }
}