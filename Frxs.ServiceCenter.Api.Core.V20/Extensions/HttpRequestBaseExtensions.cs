/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/12/17 11:12:20
 * *******************************************************/
using System.Web;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// HttpRequest扩展类
    /// </summary>
    public static class HttpRequestBaseExtensions
    {
        /// <summary>
        /// 判断一个HttpRequest是否是AJAX请求
        /// </summary>
        /// <param name="request">当前httpRequest</param>
        /// <returns>返回是否是AJAX请求</returns>
        public static bool IsAjaxRequest(this HttpRequestBase request)
        {
            //request参数不能为null
            request.CheckNullThrowArgumentNullException("request");
            //直接判断下请求头是否包含Ajax请求头
            return request["X-Requested-With"] == "XMLHttpRequest" || (request.Headers != null && request.Headers["X-Requested-With"] == "XMLHttpRequest");
        }

        /// <summary>
        /// 将URL地址转换成本地地址
        /// </summary>
        /// <param name="request">当前httpRequest</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrlLocalToHost(this HttpRequestBase request, string url)
        {
            return !url.IsNullOrEmpty() && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        /// <summary>
        /// 获取客户端IP地址；如果都未找到就会返回string.empty
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp(this HttpRequestBase request)
        {
            //request参数不能为null
            request.CheckNullThrowArgumentNullException("request");
            try
            {
                //环境变量里有客户端IP信息，直接返回
                string clientIp = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!clientIp.IsNullOrEmpty())
                {
                    return clientIp;
                }

                //客户端提交了远程客户端地址
                clientIp = request.ServerVariables["REMOTE_ADDR"];
                if (!clientIp.IsNullOrEmpty())
                {
                    return clientIp;
                }

                clientIp = request.UserHostAddress;
                if (!clientIp.IsNullOrEmpty())
                {
                    return clientIp;
                }

                //IPV6
                if (clientIp == "::1")
                {
                    clientIp = "127.0.0.1";
                }
            }
            catch
            {
                // ignored
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取服务器地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string LocalAddr(this HttpRequestBase request)
        {
            var localAddr = request.ServerVariables["LOCAL_ADDR"];
            return localAddr.IsNullOrEmptyForDefault(() => string.Empty, str => str.Equals("::1") ? "127.0.0.1" : str);
        }
    }
}
