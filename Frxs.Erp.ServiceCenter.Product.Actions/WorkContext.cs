using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Frxs.Erp.ServiceCenter.Product
{
    /// <summary>
    /// 当前工作上下文
    /// </summary>
    public class WorkContext
    {
        ///<summary>
        ///获取到会员服务中心客户端SDK访问对象
        ///</summary>
        public static Member.SDK.DefaultApiClient GetErpMemberSDKClient()
        {
            var sdkClient = new Member.SDK.DefaultApiClient(sdkConfigSectionName: "sdkConfigErpMember", defaultUser: () => new Member.SDK.ApiUser { UserId = 0, UserName = "AdminTest" });
            //设置超时时间1分钟
            sdkClient.SetTimeout(60000);
            return sdkClient;
        }

    }
}