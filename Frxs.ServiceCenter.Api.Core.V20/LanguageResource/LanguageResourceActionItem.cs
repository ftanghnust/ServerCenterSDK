/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/12/18 10:40:12
 * *******************************************************/
using System;
using System.Xml.Serialization;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 语言包键值对
    /// </summary>
    [Serializable]
    public class LanguageResourceActionItem
    {
        /// <summary>
        /// 键
        /// </summary>
        [XmlAttribute("key")]
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
