/*********************************************************
 * FRXS zhangliang4629@163.com 10/29/2015 4:34:48 PM
 * *******************************************************/
using System.Web.Mvc;

namespace Frxs.ServiceCenter.Api.Core.Host
{
    /// <summary>
    /// API接口入口类
    /// </summary>
    public class ApiController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IActionRequestHander _actionRequestHander;

        /// <summary>
        /// API入口处理程序
        /// </summary>
        /// <param name="actionRequestHander">API入口处理程序</param>
        public ApiController(IActionRequestHander actionRequestHander)
        {
            this._actionRequestHander = actionRequestHander;
            this.ValidateRequest = false;
        }

        /// <summary>
        /// API接口处理入口
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public System.Web.Mvc.ActionResult RequestHander()
        {
            return new ActionRequestHanderActionResult(() => { this._actionRequestHander.Execute(); }, this.Logger);
        }

        /// <summary>
        /// 提交首页，直接转到API处理入口 /index
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult Index()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.Index",
                    Format = "VIEW",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 接口帮助文档接口 /help
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult Help()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "Api.Help",
                    Format = "XML",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult HelpXml()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "Api.Help",
                    Format = "XML",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult HelpJson()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "Api.Help",
                    Format = "JSON",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult HelpView()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "Api.Help",
                    Format = "VIEW",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 重启框架系统，在浏览器里输入：/reset 即可
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult Reset()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "Api.Reset",
                    Format = "VIEW",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 清除缓存，注意是系统框架生成的缓存键，即：缓存键带有：_SYS_
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult CacheClear()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.Cache.Clear",
                    Format = "VIEW",
                    Data = new { }.SerializeObjectToJosn()
                });
        }
    }
}