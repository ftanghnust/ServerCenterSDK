/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 13:28:53
 * *******************************************************/
using System.Web.Mvc;
using System.Web.Routing;

namespace Frxs.ServiceCenter.Api.Core.SdkBuilder.Host
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

            //文档生成器
            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.SdkBuilder_DocBuilder",
                url: "DocBuilder",
                defaults: new { controller = "Api", action = "DocBuilder" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.SdkBuilder.Host" });

            //下载SDK（c#系统框架默认的SDK输出）
            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.SdkBuilder_CSharpDownSdk",
                url: "CSharpDownSdk",
                defaults: new { controller = "Api", action = "CSharpDownSdk" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.SdkBuilder.Host" });

            //下载SDK源码
            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.SdkBuilder_CSharpDownSource",
                url: "CSharpDownSource",
                defaults: new { controller = "Api", action = "CSharpDownSource" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.SdkBuilder.Host" });

            //调试工具
            routes.MapRoute(
                name: "Frxs.ServiceCenter.Api.Core.SdkBuilder_ApiTool",
                url: "CSharpSdkBuilder",
                defaults: new { controller = "Api", action = "CSharpSdkBuilder" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.SdkBuilder.Host" });
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
