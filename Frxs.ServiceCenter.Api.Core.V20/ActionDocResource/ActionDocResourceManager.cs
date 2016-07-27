/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/4 11:16:36
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口描述文档对象
    /// </summary>
    public class ActionDocResourceManager
    {
        /// <summary>
        /// 用于保存DLL类，方法，属性注释文档信息，转化成字典方便后续快速获取摘要信息
        /// </summary>
        private readonly Dictionary<string, DllXmlDocMember> _xmlDocMembers = new Dictionary<string, DllXmlDocMember>();
        private static ActionDocResourceManager _instance;
        private static readonly object Locker = new object();

        /// <summary>
        /// 获取文档描述对象
        /// </summary>
        public static ActionDocResourceManager Instance
        {
            get
            {
                if (!_instance.IsNull())
                {
                    return _instance;
                }
                lock (Locker)
                {
                    if (_instance.IsNull())
                    {
                        _instance = new ActionDocResourceManager(SystemOptionsManager.Current.ActionDocResourcePaths);
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 初始化一下接口描述文档
        /// </summary>
        /// <param name="actionDocResourcePaths">文档接口描述路径</param>
        private ActionDocResourceManager(string[] actionDocResourcePaths)
        {
            this.Init(actionDocResourcePaths);
        }

        /// <summary>
        /// 初始化接口描述文件
        /// </summary>
        /// <param name="actionDocResourcePaths">接口文件注释文档路径，绝对路径</param>
        private void Init(string[] actionDocResourcePaths)
        {
            //未定义外部注释文档地址
            if (actionDocResourcePaths.IsNull() || actionDocResourcePaths.IsEmpty())
            {
                return;
            }

            //多个接口项目合并到一个接口服务器上访问，会生成多个注释文档
            IList<DllXmlDoc> dllXmlDocs = new List<DllXmlDoc>();
            foreach (var actionDocResourcePath in actionDocResourcePaths)
            {
                //不存在路径，直接抛出异常，方便开发人员发现问题
                if (!File.Exists(actionDocResourcePath))
                {
                    throw new ApiException("文件 {0} 未找到".With(actionDocResourcePath));
                }
                dllXmlDocs.Add(DefaultXmlSerializer.XmlDeserializeFromFile<DllXmlDoc>(actionDocResourcePath));
            }

            //将外部自动生成的文档，转换成接口框架内部可以识别的对象集合
            dllXmlDocs.ToList().ForEach(x =>
            {
                x.Members.ToList().ForEach(o =>
                {
                    string key = o.Name.Split(new char[] { ':' })[1];
                    if (!this._xmlDocMembers.ContainsKey(key))
                    {
                        this._xmlDocMembers.Add(key, o);
                    }
                });
            });
        }

        /// <summary>
        /// 直接从XML文件里获取到描述信息
        /// </summary>
        /// <param name="typeFullName">属性或者对象类型全称</param>
        /// <returns></returns>
        public string GetDescription(string typeFullName)
        {
            //内部类生成文档会将+设置成.号
            string _typeFullName = typeFullName.Replace("+", ".");
            if (this._xmlDocMembers.ContainsKey(_typeFullName))
            {
                return this._xmlDocMembers[_typeFullName].Summary.Trim();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取接口描述
        /// </summary>
        /// <param name="type">属性或者对象类型</param>
        /// <returns></returns>
        public string GetDescription(Type type)
        {
            return this.GetDescription(type.FullName);
        }

        /// <summary>
        /// 获取描述文档，输出行
        /// </summary>
        /// <param name="typeFullName">属性或者对象类型全称</param>
        /// <returns></returns>
        public string[] GetDescriptionLines(string typeFullName)
        {
            return this.GetDescription(typeFullName).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        /// <summary>
        ///  获取描述文档，输出行
        /// </summary>
        /// <param name="type">属性或者对象类型</param>
        /// <returns></returns>
        public string[] GetDescriptionLines(Type type)
        {
            return this.GetDescriptionLines(type.FullName);
        }
    }
}
