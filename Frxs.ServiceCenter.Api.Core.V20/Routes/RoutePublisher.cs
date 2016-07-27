/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/28 11:16:49
 * *******************************************************/
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 路由规则发布器
    /// </summary>
    internal sealed class RoutePublisher
    {
        /// <summary>
        /// 批量注册所有实现IRouteProvider接口的路由规则
        /// </summary>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="actionSelector">接口查找器</param>
        /// <param name="routes">MVC全局静态路由表</param>
        public static void RegisterRoutes(ITypeFinder typeFinder, IActionSelector actionSelector, RouteCollection routes)
        {
            //1.所有路由配置注册
            typeFinder.FindClassesOfType<IRouteProvider>()
                .Where(type => !type.IsAbstract)
                .Select(type => (IRouteProvider)Activator.CreateInstance(type))
                .OrderByDescending(o => o.Priority)
                .ToList()
                .ForEach(o => o.RegisterRoutes(routes));

            //用于保存所有的路由配置
            //Dictionary<string, ActionDescriptor> addedRouteUrl = new Dictionary<string, ActionDescriptor>();

            //2.注册有接口的特性路由器注册
            foreach (var actionDescriptor in actionSelector.GetActionDescriptors()
                .Where(o => !o.Route.IsNull() && !o.Route.Url.IsNullOrEmpty()))
            {
                //如果不包含自动添加默认接口名称作为接口参数
                if (actionDescriptor.Route.Url.Contains("{") || actionDescriptor.Route.Url.Contains("}"))
                {
                    throw new ApiException(Resource.CoreResource.RoutePublisher_ForbiddenCharacter.With(actionDescriptor.ActionName, "{", "}"));
                }

                //先保存下所有的Url,出现错误直接抛出异常（让开发人员在开发的时候就发现定义了相同的路由策略）
                //if (addedRouteUrl.Keys.Contains(actionDescriptor.Route.Url))
                //{
                //    throw new ApiException(Resource.CoreResource.RoutePublisher_RouteAdded
                //        .With(actionDescriptor.Route.Url,
                //        actionDescriptor.ActionName,
                //        actionDescriptor.ActionType.FullName,
                //        addedRouteUrl[actionDescriptor.Route.Url].ActionName,
                //        addedRouteUrl[actionDescriptor.Route.Url].ActionType.FullName));
                //}

                //否则就添加
                //addedRouteUrl.Add(actionDescriptor.Route.Url, actionDescriptor);

                //设置路由
                routes.MapRoute(
                    name: "Route.{0}.{1}".With(actionDescriptor.ActionName, actionDescriptor.Version),
                    url: actionDescriptor.Route.Url,
                    defaults: new { Controller = "Api", Action = "RequestHander", ActionName = actionDescriptor.ActionName },
                    namespaces: new string[] { "Frxs.ServiceCenter.Api.Core.Host" });
            }
        }
    }
}
