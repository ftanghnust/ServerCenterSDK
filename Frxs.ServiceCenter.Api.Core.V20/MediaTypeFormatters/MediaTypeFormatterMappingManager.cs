/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/29/2016 1:43:14 PM
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 根据请求获取最格式的输出
    /// </summary>
    public class MediaTypeFormatterMappingManager
    {
        /// <summary>
        /// 接收的类型对象
        /// </summary>
        private class MediaTypeHeaderValue
        {
            /// <summary>
            /// mine类型
            /// </summary>
            public string MineType { get; set; }
            /// <summary>
            /// 类型的权重0-1之间
            /// </summary>
            public float Q { get; set; }
        }

        /// <summary>
        /// 用于内容协商
        /// </summary>
        private static Dictionary<string, ResponseFormat> mineTypeMapping = new Dictionary<string, ResponseFormat>();

        /// <summary>
        /// 
        /// </summary>
        private RequestContext _requestContext;

        /// <summary>
        /// 
        /// </summary>
        static MediaTypeFormatterMappingManager()
        {
            mineTypeMapping.Add("text/html", ResponseFormat.VIEW);
            mineTypeMapping.Add("text/xml", ResponseFormat.XML);
            mineTypeMapping.Add("application/xhtml+xml", ResponseFormat.VIEW);
            mineTypeMapping.Add("application/xml", ResponseFormat.XML);
            mineTypeMapping.Add("application/json", ResponseFormat.JSON);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        public MediaTypeFormatterMappingManager(RequestContext requestContext)
        {
            requestContext.CheckNullThrowArgumentNullException("requestContext");
            this._requestContext = requestContext;
        }

        /// <summary>
        /// 获取输出格式化器
        /// </summary>
        /// <returns></returns>
        public ResponseFormat GetResponseFormat()
        {
            return new Enum<ResponseFormat>().GetItem(this._requestContext.RawRequestParams.Format, () =>
            {
                IList<MediaTypeHeaderValue> mediaTypeValues = new List<MediaTypeHeaderValue>();

                //获取客户端所有能接受的MineType类型
                foreach (var item in this._requestContext.HttpContext.Request.AcceptTypes)
                {
                    var mineTypeInfo = item.Split(new char[] { ';' });
                    if (mineTypeInfo.Length == 1)
                    {
                        mediaTypeValues.Add(new MediaTypeHeaderValue() { MineType = mineTypeInfo[0], Q = 0 });
                    }
                    else
                    {
                        mediaTypeValues.Add(new MediaTypeHeaderValue()
                        {
                            MineType = mineTypeInfo[0],
                            Q = mineTypeInfo[1].Split(new char[] { '=' })[1].AsFloat()
                        });
                    }
                }

                //按照权重大小排序
                foreach (var item in mediaTypeValues.OrderByDescending(o => o.Q))
                {
                    if (mineTypeMapping.Keys.Contains(item.MineType))
                    {
                        return mineTypeMapping[item.MineType];
                    }
                }

                //都找不到的情况下，返回JSON数据
                return ResponseFormat.JSON;
            });
        }
    }
}
