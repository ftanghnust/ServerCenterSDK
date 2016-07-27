/*********************************************************
 * FRXS zhangliang4629@163.com 10/27/2015 2:29:27 PM
 * *******************************************************/
using System;
using System.Web;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.Api.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiHostApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 应用程序启动时初始化系统框架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            ApiApplication.Initialize("~/DynamicCompiledDependencyRegistar.cs");
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext httpContext = System.Web.HttpContext.Current;
            string rawUrl = !httpContext.IsNull() ? httpContext.Request.RawUrl : string.Empty;
            var exception = new ApiException(rawUrl, Server.GetLastError().GetBaseException());
            ServicesContainer.Current.Resolver<ILogger>().Error(exception);
        }
    }
}