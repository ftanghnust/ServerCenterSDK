/*********************************************************
 * FRXS zhangliang4629@163.com 10/27/2015 2:29:27 PM
 * *******************************************************/
using Autofac;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Frxs.ServiceCenter.Api.Core;
using Autofac.Integration.Mvc;

namespace Frxs.Erp.ServiceCenter.ID.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiHostApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 应用程序启动时，需要进行下面注册; 初始化顺序请不要更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            ApiApplication.Initialize(Server.MapPath("~/DynamicCompiledDependencyRegistar.cs"));
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            string rawUrl = !System.Web.HttpContext.Current.IsNull() ? System.Web.HttpContext.Current.Request.RawUrl : string.Empty;
            var exception = new ApiException(rawUrl, Server.GetLastError().GetBaseException());
            ServicesContainer.Current.Resolver<ILogger>().Error(exception);
        }
    }
}