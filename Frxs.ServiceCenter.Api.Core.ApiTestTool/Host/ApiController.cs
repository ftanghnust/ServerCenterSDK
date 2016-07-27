/*********************************************************
 * FRXS zhangliang4629@163.com 10/29/2015 4:34:48 PM
 * *******************************************************/
using System.Web.Mvc;
using System.Linq;
using Frxs.ServiceCenter.Api.Core.Host;

namespace Frxs.ServiceCenter.Api.Core.ApiTestTool.Host
{
    /// <summary>
    /// API接口入口类
    /// </summary>
    public class ApiController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IActionSelector _actionSelector;

        /// <summary>
        /// API入口处理程序
        /// </summary>
        /// <param name="actionSelector">接口查找器</param>
        public ApiController(IActionSelector actionSelector)
        {
            this.ValidateRequest = false;
            this._actionSelector = actionSelector;
        }

        /// <summary>
        /// 测试工具首页
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult ApiTool()
        {
            return this.RedirectToAction("RequestHander",
                new
                {
                    ActionName = "API.TestTool",
                    Format = "VIEW",
                    Data = new { }.SerializeObjectToJosn()
                });
        }

        /// <summary>
        /// 搜索接口集合 /logs/ActionsGet?query=x
        /// </summary>
        /// <param name="query">接口关键词</param>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult ActionsGet(string query)
        {
            //所有接口
            var actions = this._actionSelector.GetActionDescriptors();

            if (!query.IsNullOrEmpty())
            {
                actions = actions.Where(o => o.ActionName.ToLower().Contains(query.ToLower()));
            }

            //返回JSON字符串
            return this.Content(new
            {
                suggestions = from item in actions
                              select new
                              {
                                  value = item.ActionName,
                                  data = item.ActionName
                              }
            }.SerializeObjectToJosn());

        }
    }
}