/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/28 12:28:35
 * *******************************************************/
using System.Web.Mvc;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// 插件路由是、配置
    /// </summary>
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// 路由配置
        /// </summary>
        /// <param name="routes"></param>
        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapRoute(
                name: "Api_Core_DBAccessRecorder_Logs",
                url: "logs",
                defaults: new { controller = "Home", action = "Logs" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.AccessRecorder.Controllers" });

            routes.MapRoute(
                name: "Api_Core_DBAccessRecorder_Search",
                url: "logs/S",
                defaults: new { controller = "Home", action = "Search" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.AccessRecorder.Controllers" });

            routes.MapRoute(
                name: "Api_Core_DBAccessRecorder_ActionsGet",
                url: "logs/ActionsGet",
                defaults: new { controller = "Home", action = "ActionsGet" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.AccessRecorder.Controllers" });

            routes.MapRoute(
                name: "Api_Core_DBAccessRecorder_Get",
                url: "logs/{id}",
                defaults: new { controller = "Home", action = "Get" },
                namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.AccessRecorder.Controllers" },
                constraints: new { id = "[0-9]{1,15}" });
        }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority
        {
            get { return 10; }
        }
    }
}
