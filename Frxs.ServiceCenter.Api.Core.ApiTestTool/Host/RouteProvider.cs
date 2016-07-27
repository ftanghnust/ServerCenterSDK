/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 13:28:53
 * *******************************************************/
using System.Web.Mvc;
using System.Web.Routing;

namespace Frxs.ServiceCenter.Api.Core.ApiTestTool.Host
{
    /// <summary>
    /// 路由注册，系统框架会自动注册此路由
    /// </summary>
    internal class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// 注册接口路由设置
        /// </summary>
        /// <param name="routes"></param>
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = true;

            //调试工具
            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.ApiTestTool_ApiTool",
                url: "ApiTool",
                defaults: new { controller = "Api", action = "ApiTool" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.ApiTestTool.Host" });

            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.ApiTestTool_ActionsGet",
                url: "ApiTool/ActionsGet",
                defaults: new { controller = "Api", action = "ActionsGet" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.ApiTestTool.Host" });
        }

        /// <summary>
        /// 优先级，设置为0，覆盖掉系统框架注册的路由
        /// </summary>
        public int Priority
        {
            get { return 0; }
        }
    }
}
