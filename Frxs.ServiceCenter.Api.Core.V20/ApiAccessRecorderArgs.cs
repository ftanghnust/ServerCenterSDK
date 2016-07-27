/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/25 13:23:00
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// API访问记录器参数类
    /// </summary>
    public class ApiAccessRecorderArgs
    {
        /// <summary>
        /// Action执行开始时间
        /// </summary>
        public DateTime RequestStartTime { get; set; }

        /// <summary>
        /// Action执行结束时间，直接获取当前时间
        /// </summary>
        public DateTime RequestEndTime { get; set; }

        /// <summary>
        /// Action执行总共使用的毫秒数
        /// </summary>
        public double RequestUsedTotalMilliseconds { get; set; }

        /// <summary>
        /// 客户端请求方式
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 客户端请求参数包
        /// </summary>
        public string RequestData { get; set; }

        /// <summary>
        /// 服务器输出去数据包
        /// </summary>
        public string ResponseData { get; set; }

        /// <summary>
        /// 输出格式xml/json/view
        /// </summary>
        public string ResponseFormat { get; set; }

        /// <summary>
        /// 当前操作用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 当前操作用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 当前操作接口描述
        /// </summary>
        public IActionDescriptor ActionDescriptor { get; set; }

        /// <summary>
        /// 上送的参数
        /// </summary>
        public RequestParams RequestParams { get; set; }
    }
}
