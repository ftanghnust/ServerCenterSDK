﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/22 20:37:56
 * *******************************************************/
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统初始化入口
    /// </summary>
    public class ApiApplication
    {
        /// <summary>
        /// 系统框架默认的配置文件地址
        /// </summary>
        private static readonly string DefaultApiConfig = "~/WebApiConfig.cs";

        /// <summary>
        /// 初始化，初始化的时候做了如下事情(请注意必须顺序，全局配置必须在其他前面，业务注册服务需要依赖配置)
        /// 1.先初始化外部配置文件(如果指定了apiConfigPhysicalFilePath参数，否则会自动搜索根目录下面的~/ApiConfig.cs文件)
        /// 2.注册系统所有服务
        /// 3.MVC创建Controller容器更改
        /// </summary>
        /// <param name="apiConfigPhysicalFilePath">配置文件物理路径(或者以~/开头的虚拟路径)，如果不配置此路径将不会进行外部配置注册</param>
        public static void Initialize(string apiConfigPhysicalFilePath = "")
        {
            //0.注册全局配置信息(必须在最前注册)
            if (apiConfigPhysicalFilePath.IsNullOrEmpty())
            {
                //映射成物理路径
                var defaultApiConfigPhysicalFilePath = HostHelper.MapPath(DefaultApiConfig);
                //未指定接口框架配置文件，系统自动查找根节点，查找ApiConfig.cs文件
                if (System.IO.File.Exists(defaultApiConfigPhysicalFilePath))
                {
                    apiConfigPhysicalFilePath = defaultApiConfigPhysicalFilePath;
                }
            }
            //检测是否以~/开头，就进行映射成物理路径
            else
            {
                if (apiConfigPhysicalFilePath.StartsWith("~/") || !apiConfigPhysicalFilePath.Contains(":\\"))
                {
                    apiConfigPhysicalFilePath = HostHelper.MapPath(apiConfigPhysicalFilePath);
                }
            }

            //进行配置注册
            if (!apiConfigPhysicalFilePath.IsNullOrEmpty())
            {
                DynamicCompiledDependencyRegistarManager.Registar(apiConfigPhysicalFilePath);
            }

            //HOST域名未配置
            if (SystemOptionsManager.Current.HttpHost.IsNullOrEmpty())
            {
                SystemOptionsManager.Current.HttpHost = string.Empty;
            }
            else
            {
                //外部配置的httpHost信息
                string httpHost = SystemOptionsManager.Current.HttpHost;
                string httpStart = "http://";
                string httpsStart = "https://";

                //去除 http:// 或者 https:// 前缀
                if (httpHost.StartsWith(httpStart, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    SystemOptionsManager.Current.HttpHost = httpHost.Substring(7, httpHost.Length - 7);
                }
                if (httpHost.StartsWith(httpsStart, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    SystemOptionsManager.Current.HttpHost = httpHost.Substring(8, httpHost.Length - 8);
                }

                //去除URL虚拟路径
                httpHost = SystemOptionsManager.Current.HttpHost;
                int indexOf = httpHost.IndexOf("/");
                SystemOptionsManager.Current.HttpHost = indexOf != -1 ? httpHost.Substring(0, indexOf) : httpHost;
            }

            //1.注册系统所有服务
            var container = ServicesContainer.Current.Initialize(SystemOptionsManager.Current);

            //2.类型查找器
            var typeFinder = ServicesContainer.Current.Resolver<ITypeFinder>();
            var actionSelector = ServicesContainer.Current.Resolver<IActionSelector>();

            //3.将实现IStartUp实现类，初始化一下
            StartUpManager.Start(typeFinder);

            //4.发布注册路由
            RoutePublisher.RegisterRoutes(typeFinder, actionSelector, RouteTable.Routes);

            //5.覆盖MVC框架自带controller创建器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //6.启动所有作业任务
            TaskThreadManager.Instance.Initialize(typeFinder);
            TaskThreadManager.Instance.Start();
        }
    }
}