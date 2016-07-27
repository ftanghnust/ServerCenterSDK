/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/12/18 10:39:40
 * *******************************************************/
using System;
using System.Xml.Serialization;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口项目语言包序列化类
    /// </summary>
    [Serializable, XmlRoot("resource")]
    public class LanguageResource
    {
        /// <summary>
        /// 所有的接口集合
        /// </summary>
        [XmlArray("actions"), XmlArrayItem("action")]
        public LanguageResourceAction[] Actions { get; set; }
    }
}
