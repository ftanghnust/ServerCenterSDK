/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 字符串输出器默认实现
    /// </summary>
    internal class DefaultResponse : IResponse
    {
        /// <summary>
        /// 自定义一些输出头信息，实现类无需了解
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        private static void AddCustomerResponseHeaders(RequestContext requestContext)
        {
            try
            {
                ////输出一些头信息到客户端
                //requestContext.HttpContext.Response.Headers.Add("Api-Action-Name",
                //    requestContext.RawRequestParams.ActionName ?? string.Empty);

                ////版本
                //requestContext.HttpContext.Response.Headers.Add("Api-Version",
                //    requestContext.ActionDescriptor.IsNull() ? "" : requestContext.ActionDescriptor.Version);

                ////集群，分布式服务器编号
                //requestContext.HttpContext.Response.Headers.Add("Api-Server-Name", requestContext.SysOptions.ServerName);

                //把上下文保存的一些自定义打点数据输出到客户端头部，方便调试
                //foreach (var item in requestContext.AdditionDatas)
                //{
                //    requestContext.HttpContext.Response.Headers.Add(item.Key, (item.Value is DateTime) ? ((DateTime)item.Value).ToString("yyyy/MM/dd HH:mm:ss.ffffff") : item.Value.ToString());
                //}
            }
            finally { }
        }

        /// <summary>
        /// 输出格式化数据到客户端
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="responseFormat">输出格式化类型</param>
        /// <param name="serializedActionResultString">格式化了的ActionResult对象字符串</param>
        public void ResponseSerializedStringToClient(RequestContext requestContext, ResponseFormat responseFormat, string serializedActionResultString)
        {
            //参数值为null
            requestContext.CheckNullThrowArgumentNullException("requestContext");
            requestContext.HttpContext.CheckNullThrowArgumentNullException("requestContext.HttpContext");

            //添加一些自定义的header头信息
            AddCustomerResponseHeaders(requestContext);

            //字符串格式为XML
            if (responseFormat == ResponseFormat.XML)
            {
                requestContext.HttpContext.Response.ContentType = "application/xml; charset=utf-8";
            }

            //字符串格式为JSON
            if (responseFormat == ResponseFormat.JSON)
            {
                requestContext.HttpContext.Response.ContentType = "application/json; charset=utf-8";
            }

            //HTML
            if (responseFormat == ResponseFormat.VIEW)
            {
                requestContext.HttpContext.Response.ContentType = "text/html; charset=utf-8";
            }

            //输出格式化数据给客户端
            requestContext.HttpContext.Response.Write(serializedActionResultString ?? string.Empty);
        }
    }
}