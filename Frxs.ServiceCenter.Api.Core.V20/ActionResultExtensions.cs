/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// ActionResult扩展类
    /// </summary>
    internal static class ActionResultExtensions
    {
        /// <summary>
        /// 序列化成JSON格式
        /// </summary>
        /// <param name="actionResult">ActionResult对象</param>
        /// <returns></returns>
        public static string ToJson(this ActionResult actionResult)
        {
            return actionResult.SerializeObjectToJosn();
        }

        /// <summary>
        /// 默认使用UTF-8进行格式化
        /// </summary>
        /// <param name="actionResult">ActionResult对象</param>
        /// <param name="encode">字符编码;默认使用UTF-8</param>
        /// <returns></returns>
        public static string ToXml(this ActionResult actionResult, string encode = "UTF-8")
        {
            //由于输出的对象可能含有匿名对象，.NET框架提供的XML序列化类无法对匿名对象序列化
            //所以这里直接使用JSON序列化成XML，因此生成的客户端XML数据与JSON数据有一定的差异
            var xmlDocument = JsonConvert.DeserializeXmlNode(actionResult.ToJson(), "response");
            using (var stream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(xmlDocument.GetType());
                xmlSerializer.Serialize(stream, xmlDocument);
                //输出格式化XML字符串
                return Encoding.GetEncoding("UTF-8").GetString(stream.ToArray());
            }
        }
    }
}