/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/2 8:27:58
 * *******************************************************/

using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.SDK;

namespace Frxs.ServiceCenter.Api.Host.Actions
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientAction : ActionBase<NullRequestDto, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {

            var defaultClient = new DefaultApiClient(sdkConfigSectionName: "frxsErpProductSdkConfig");
            var resp = defaultClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWProductsGetRequest()
            {
                ProductId = 1,
                WID = 105
            });

            HttpClient h = new HttpClient();
            Task<string> s = h.GetStringAsync("http://localhost:8080/Api?ActionName=API.Index&Format=VIEW&Data=%7B%7D");

            return this.SuccessActionResult(s.Result+resp.SerializeObjectToJosn());
        }
    }
}