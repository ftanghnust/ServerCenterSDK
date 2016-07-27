/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 13:28:53
 * *******************************************************/
using System.Web.Mvc;
using System.Web.Routing;

namespace Frxs.ServiceCenter.Api.Core.Host
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

            //API接口框架欢迎页入口 /
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Index",
                url: "",
                defaults: new { controller = "Api", action = "Index" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //API接口框架统一接口访问入口 /api? 扩展框架需要注意下，/api 开头为系统框架使用的，请勿占用
            //routes.MapRoute(
            //    name: "ServiceCenter.Api.Core.V20_API_01",
            //    url: "Api/{ActionName}/{Format}/{Version}",
            //    defaults: new { controller = "Api", action = "RequestHander", version = "", format = "View" },
            //    namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_API",
                url: "Api",
                defaults: new { controller = "Api", action = "RequestHander" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //框架内部帮助创插件入口 /help
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Help",
                url: "Help",
                defaults: new { controller = "Api", action = "Help" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Help_XML",
                url: "Help/XML",
                defaults: new { controller = "Api", action = "HelpXml" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Help_JSON",
                url: "Help/JSON",
                defaults: new { controller = "Api", action = "HelpJson" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Help_VIEW",
                url: "Help/VIEW",
                defaults: new { controller = "Api", action = "HelpView" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //所有资源获取类  /Resource?resourceName=jquery-1.9.1.min.js
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_GetResource",
                url: "GetResource",
                defaults: new { controller = "Resource", action = "GetResource" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //获取资源的另外一种方式：/Resource/jquery-1.9.1.min.js
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_GetResource_01",
                url: "Resource/{*resourceName}",
                defaults: new { controller = "Resource", action = "GetResource" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //重启接口框架
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_Reset",
                url: "Reset",
                defaults: new { controller = "Api", action = "Reset" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });

            //清除系统所有缓存(_SYS_)
            routes.MapRoute(
                name: "ServiceCenter.Api.Core.V20_CacheClear",
                url: "CacheClear",
                defaults: new { controller = "Api", action = "CacheClear" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
        }

        /// <summary>
        /// 优先级，将优先级改成最小，方便后续创建可以重写框架注册的路由
        /// </summary>
        public int Priority
        {
            get { return int.MinValue; }
        }
    }
}
