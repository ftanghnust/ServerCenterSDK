﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/14 9:54:24
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    ///  HTTP请求返回对象
    /// </summary>
    internal class HttpRespBody
    {
        /// <summary>
        /// 用于保存http-Headers信息
        /// </summary>
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        /// <summary>
        /// 构造输入内容
        /// </summary>
        /// <param name="body">返回的body数据</param>
        public HttpRespBody(string body)
        {
            this.Body = body;
        }

        /// <summary>
        /// 返回的body数据
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 返回的头信息
        /// </summary>
        public Dictionary<string, string> Headers
        {
            get
            {
                return this._headers;
            }
        }
    }
}
