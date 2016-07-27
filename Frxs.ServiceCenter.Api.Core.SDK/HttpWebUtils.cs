﻿/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/3/2015 8:29:56 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// SDK客户端HTTP访问类
    /// </summary>
    internal class HttpWebUtils
    {
        /// <summary>
        /// 
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpWebUtils()
        {
            this.Timeout = 100000;
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public HttpRespBody DoPost(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest httpWebRequest = GetHttpWebRequest(url, "POST");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters));
            Stream reqStream = httpWebRequest.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
            return HttpWebResponseToString(httpWebResponse, encoding);
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="textParams">请求参数</param>
        /// <param name="fileParams">上传文件</param>
        /// <returns>HTTP响应</returns>
        public HttpRespBody DoPost(string url, IDictionary<string, string> textParams, IDictionary<string, FileItem> fileParams)
        {
            if (fileParams == null || fileParams.Count == 0)
            {
                return this.DoPost(url, textParams);
            }
            string boundary = DateTime.Now.Ticks.ToString("X");
            HttpWebRequest webRequest = this.GetHttpWebRequest(url, "POST");
            webRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            Stream requestStream = webRequest.GetRequestStream();
            byte[] bytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            string contentDisposition = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
            IEnumerator<KeyValuePair<string, string>> enumerator = textParams.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string content = string.Format(contentDisposition, enumerator.Current.Key, enumerator.Current.Value);
                byte[] bytes3 = Encoding.UTF8.GetBytes(content);
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Write(bytes3, 0, bytes3.Length);
            }
            string format = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
            IEnumerator<KeyValuePair<string, FileItem>> enumerator2 = fileParams.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                string s2 = string.Format(format, enumerator2.Current.Key, enumerator2.Current.Value.GetFileName(), enumerator2.Current.Value.GetMimeType());
                byte[] bytes4 = Encoding.UTF8.GetBytes(s2);
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Write(bytes4, 0, bytes4.Length);
                byte[] content = enumerator2.Current.Value.GetContent();
                requestStream.Write(content, 0, content.Length);
            }
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
            return this.HttpWebResponseToString(httpWebResponse, encoding);
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public HttpRespBody DoGet(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            HttpWebRequest httpWebRequest = GetHttpWebRequest(url, "GET");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
            return HttpWebResponseToString(httpWebResponse, encoding);
        }

        /// <summary>
        /// 创建HttpWebRequest
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="method">POST/GET</param>
        /// <returns></returns>
        private HttpWebRequest GetHttpWebRequest(string url, string method)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ServicePoint.Expect100Continue = false;
            httpWebRequest.Method = method;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.UserAgent = "User-Agent: FRXS";
            httpWebRequest.Referer = "";
            httpWebRequest.Timeout = this.Timeout;
            httpWebRequest.Proxy = null;
            return httpWebRequest;
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="httpResponse">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        private HttpRespBody HttpWebResponseToString(HttpWebResponse httpResponse, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                //以字符流的方式读取HTTP响应
                stream = httpResponse.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                string body = reader.ReadToEnd();
                //构造新的输出对象
                HttpRespBody respBody = new HttpRespBody(body);
                //添加一个http状态码
                respBody.Headers.Add("StatusCode", httpResponse.StatusCode.ToString());
                //将httpHeader集合保存到输出对象
                httpResponse.Headers.AllKeys.ToList().ForEach(key =>
                {
                    if (!respBody.Headers.ContainsKey(key))
                    {
                        respBody.Headers.Add(key, httpResponse.Headers[key]);
                    }
                });
                return respBody;
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (httpResponse != null) httpResponse.Close();
            }
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        private string BuildGetUrl(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            return url;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        private string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(HttpUtility.UrlEncode(value)); //Uri.EscapeDataString(value)
                    hasParam = true;
                }
            }

            return postData.ToString();
        }
    }
}
