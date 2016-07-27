/*********************************************************
 * FRXS zhangliang4629@163.com 10/29/2015 4:34:48 PM
 * *******************************************************/
using System.Web.Mvc;
using Frxs.ServiceCenter.Api.Core.Host;

namespace Frxs.ServiceCenter.Api.Core.SdkBuilder.Host
{
    /// <summary>
    /// API接口入口类
    /// </summary>
    public class ApiController : ApiControllerBase
    {
        /// <summary>
        /// API入口处理程序
        /// </summary>
        public ApiController()
        {
            this.ValidateRequest = false;
        }

        /// <summary>
        /// 接口文档生成器
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult DocBuilder()
        {
            return this.RedirectToAction("RequestHander", new { ActionName = "Api.Doc.Builder", Format = "VIEW", Data = "" });
        }

        /// <summary>
        /// 下载SDK(C#)
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult CSharpDownSdk()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.BuildSDK",
                    Format = "VIEW",
                    Data = new { SaveType = "dll" }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 下载源码
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult CSharpDownSource()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.BuildSDK",
                    Format = "VIEW",
                    Data = new { SaveType = "source" }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult CSharpSdkBuilder()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.BuildSdk",
                    Format = "VIEW",
                    Data = new {Actionname = "API.BuildSdk", Version = ""}.SerializeObjectToJosn()
                });
        }
    }
}