using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// 当前工作上下文
    /// </summary>
    public class WorkContext
    {
        /// <summary>
        /// 是否允许负库存出库
        /// </summary>
        /// <returns></returns>
        public static bool IsStockOutInventory()
        {
            string value = ConfigurationManager.AppSettings["IsStockOutInventory"];
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value == "1" ? true : false;
            }
            return false;
        }

        ///<summary>
        ///获取到商品服务中心客户端SDK访问对象
        ///</summary>
        public static Frxs.Erp.ServiceCenter.Product.SDK.DefaultApiClient CreateProductSdkClient()
        {
            return new Frxs.Erp.ServiceCenter.Product.SDK.DefaultApiClient(sdkConfigSectionName: "frxsErpProductSdkConfig", defaultUser: () => new Frxs.Erp.ServiceCenter.Product.SDK.ApiUser()
            {
                UserId = 0,
                UserName = "admin"
            });
        }


        ///<summary>
        ///获取到商品服务中心客户端SDK访问对象
        ///</summary>
        public static Frxs.Erp.ServiceCenter.Promotion.SDK.DefaultApiClient CreatePromotionSdkClient()
        {
            return new Frxs.Erp.ServiceCenter.Promotion.SDK.DefaultApiClient(sdkConfigSectionName: "frxsErpPromotionSdkConfig", defaultUser: () => new Frxs.Erp.ServiceCenter.Promotion.SDK.ApiUser()
            {
                UserId = 0,
                UserName = "admin"
            });
        }

        ///<summary>
        ///获取到ID服务中心客户端SDK访问对象
        ///</summary>
        public static Frxs.Erp.ServiceCenter.ID.SDK.DefaultApiClient CreateIDSdkClient()
        {
            return new Frxs.Erp.ServiceCenter.ID.SDK.DefaultApiClient(sdkConfigSectionName: "frxsErpIDSdkConfig", defaultUser: () => new Frxs.Erp.ServiceCenter.ID.SDK.ApiUser()
            {
                UserId = 0,
                UserName = "admin"
            });
        }
    }
}