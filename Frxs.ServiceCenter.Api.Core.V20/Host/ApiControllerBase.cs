/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/27 19:17:31
 * *******************************************************/
using System.Web.Mvc;

namespace Frxs.ServiceCenter.Api.Core.Host
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public abstract class ApiControllerBase : Controller
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 初始化一下空日志接口，防止null错误
        /// </summary>
        protected ApiControllerBase()
        {
            this.Logger = NullLogger.Instance;
        }
    }
}
