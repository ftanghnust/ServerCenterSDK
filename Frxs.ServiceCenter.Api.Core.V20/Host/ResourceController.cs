/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/2 13:28:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core.Host
{
    /// <summary>
    /// 获取资源类（方便插件资源文件获取），插件view视图里获取资源文件可以直接使用此控制器
    /// 比如，想获取插件本身自己内嵌的资源JS文件，直接使用下面方式既可以
    /// <![CDATA[
    /// <script type="text/javascript" src="/GetResource?resourceName=jquery-1.9.1.min.js"></script>
    /// <script type="text/javascript" src="/GetResource/jquery-1.9.1.min.js"></script>
    /// ]]>
    /// </summary>
    public class ResourceController : ApiControllerBase
    {
        /// <summary>
        /// 程序集内嵌资源查找器
        /// </summary>
        private readonly IResourceFinderManager _resourceFinderManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceFinderManager">资源查找管理器</param>
        public ResourceController(IResourceFinderManager resourceFinderManager)
        {
            resourceFinderManager.CheckNullThrowArgumentNullException("resourceFinders");
            this._resourceFinderManager = resourceFinderManager;
        }

        /// <summary>
        /// 获取资源  /GetResource?resourceName=jquery-1.9.1.min.js 或者 /GetResource/jquery-1.9.1.min.js
        /// </summary>
        /// <param name="resourceName">资源名称，请注意此地方仅仅是判断资源名称和资源查找器里集合尾部相同的资源；</param>
        /// <returns>返回指定内嵌资源文件文本</returns>
        public System.Web.Mvc.ActionResult GetResource(string resourceName)
        {
            //获取资源
            var resource = this._resourceFinderManager.GetResource(resourceName);

            //存在资源就显示资源文本到客户端
            if (resource.IsNull()) return this.Content(string.Empty);

            //js
            if (resourceName.EndsWith(".js", StringComparison.OrdinalIgnoreCase))
            {
                return this.Content(resource, "application/javascript");
            }

            //css
            if (resourceName.EndsWith(".css", StringComparison.OrdinalIgnoreCase))
            {
                return this.Content(resource, "text/css");
            }

            //html
            if (resourceName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                return this.Content(resource, "text/html");
            }

            //gif
            if (resourceName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                return this.File(Convert.FromBase64String(resource), "image/gif");
            }

            //jpg
            if (resourceName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
            {
                return this.File(Convert.FromBase64String(resource), "image/jpeg");
            }

            //png
            if (resourceName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                return this.File(Convert.FromBase64String(resource), "image/png");
            }

            //ico
            if (resourceName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
            {
                return this.File(Convert.FromBase64String(resource), "image/x-icon");
            }

            //否则返回文本类型
            return this.Content(resource, "text/plain");
        }
    }
}
