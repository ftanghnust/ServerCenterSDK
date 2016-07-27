/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/23/2016 5:41:39 PM
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 获取文件对应的httpcontent类型
    /// </summary>
    public class HttpContentType
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly IDictionary<string, string> _httpContentTypeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        static HttpContentType()
        {
            _httpContentTypeMap.Add(".js", "application/javascript");
            _httpContentTypeMap.Add(".css", "text/css");
            _httpContentTypeMap.Add(".html", "text/html");
            _httpContentTypeMap.Add(".gif", "image/gif");
            _httpContentTypeMap.Add(".jpg", "image/jpeg");
            _httpContentTypeMap.Add(".png", "image/png");
            _httpContentTypeMap.Add(".ico", "image/x-icon");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileExtension">根据扩展名称获取文件的httpContentType类型</param>
        /// <returns></returns>
        public static string GetContentType(string fileExtension)
        {
            if (fileExtension.IsNullOrEmpty())
            {
                return null;
            }

            if (!fileExtension.StartsWith("."))
            {
                fileExtension = ".{0}".With(fileExtension);
            }

            if (_httpContentTypeMap.Keys.Contains(fileExtension))
            {
                return _httpContentTypeMap[fileExtension];
            }

            return null;
        }
    }
}
