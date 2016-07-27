/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/12/2016 11:33:42 AM
 * *******************************************************/
using System.Linq;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.SDK;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 客户端访问路由
    /// </summary>
    public class ApiClientRoute
    {
        /// <summary>
        /// 获取API客户端访问接口
        /// </summary>
        /// <returns></returns>
        public static IApiClient CreateApiClient()
        {
            //调用同步接口数据
            var client = new DefaultApiClient("m.api.com", signService: null);

            //获取系统配置
            var config = ConfigurationFactory.GetConfiguration();

            //同步接口路由
            client.GetServerUrlFun = (actioName) =>
            {
                var apiRoute = config.ApiRoutes.FirstOrDefault(o => actioName.StartsWith(o.Prefix));
                if (apiRoute != null)
                {
                    return apiRoute.ServerUrl;
                }
                //因为系统框架有几个获取服务器时间接口，挂载到任意接口即可，这里直接挂载到基础库接口服务器上
                return config.MessageServerUrl;
            };

            //返回接口调用对象
            return client;
        }
    }
}
