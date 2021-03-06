﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/27 12:26:22
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口创建描述基类
    /// </summary>
    public abstract class ApiPluginDescriptorBase : IApiPluginDescriptor
    {
        /// <summary>
        /// 资源查找器
        /// </summary>
        private readonly IResourceFinderManager _resourceFinderManager;

        /// <summary>
        /// 过滤掉一些系统自带的dll
        /// </summary>
        private const string AssemblySkipPattern = "^mscorlib"; // "^mscorlib|^System,|System.Xml,|System.Core,|System.Web,";

        /// <summary>
        /// 插件默认的LOGO地址
        /// </summary>
        private const string LogoUrl = "/GetResource?resourceName={0}";

        /// <summary>
        /// 插件LOGO合法的图片后缀集
        /// </summary>
        private static readonly string[] LogoFileExtensions = new string[] { "jpg", "png", "gif" };

        /// <summary>
        /// 组件描述说明文件
        /// </summary>
        private const string ProjectDescriptionFileName = "ProjectDescription.txt";

        /// <summary>
        /// 系统默认的插件logo
        /// </summary>
        private const string DefaultLogo = "SystemPlugin.png";

        /// <summary>
        /// 当前插件所属程序集
        /// </summary>
        private readonly Assembly _currenAssembly;

        /// <summary>
        /// 当前插件程序集命名空间
        /// </summary>
        private readonly string _currentAssemblyName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFinderManager">资源查找器</param>
        protected ApiPluginDescriptorBase(IResourceFinderManager resourceFinderManager)
        {
            this._resourceFinderManager = resourceFinderManager;
            this._currenAssembly = this.GetType().Assembly;
            this._currentAssemblyName = this._currenAssembly.GetName().Name;
        }

        /// <summary>
        /// 插件名称
        /// </summary>
        public abstract string DisplayName { get; }

        /// <summary>
        /// 插件首页地址;默认为空
        /// </summary>
        public virtual string IndexUrl
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 插件版本，默认直接获取当前插件程序集版本
        /// </summary>
        public virtual string Version
        {
            get { return this._currenAssembly.GetName().Version.ToString(); }
        }

        /// <summary>
        /// 插件LOGO;采取约定方式，默认会搜索DLL内嵌资源，根目录Logo.jpg,Logo.gif,Logo.Png和Resource/(Logo.jpg,Logo.gif,Logo.Png)
        /// </summary>
        public virtual string Logo
        {
            get
            {
                //Resource目录
                foreach (var fileExtension in LogoFileExtensions)
                {
                    var resourceName = "{0}.Resource.Logo.{1}".With(this._currentAssemblyName, fileExtension);

                    //是否存在LOGO资源缓存
                    var logoBase64String = this._resourceFinderManager.GetResource(resourceName);

                    if (!logoBase64String.IsNullOrEmpty())
                    {
                        return LogoUrl.With(resourceName);
                    }
                }

                //根目录
                foreach (var fileExtension in LogoFileExtensions)
                {
                    var resourceName = "{0}.Logo.{1}".With(this._currentAssemblyName, fileExtension);

                    //是否存在LOGO资源缓存
                    var logoBase64String = this._resourceFinderManager.GetResource(resourceName);

                    if (!logoBase64String.IsNullOrEmpty())
                    {
                        return LogoUrl.With(resourceName);
                    }
                }

                //返回默认的
                return LogoUrl.With("{0}".With(DefaultLogo));
            }
        }

        /// <summary>
        /// 插件作者，默认为string.Empty
        /// </summary>
        public virtual string Author
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 创建描述，使用约定方式，每个插件的根目录放置ProjectDescription.txt或者Resource/ProjectDescription.txt文件，系统框架自动回搜索读取此说明文件
        /// </summary>
        public virtual string Description
        {
            get
            {
                //资源名称
                var resourceName = "{0}.{1}".With(this._currentAssemblyName, ProjectDescriptionFileName);

                //先找根目录
                var projectDescription = this._resourceFinderManager.GetResource(resourceName);
                if (!projectDescription.IsNullOrEmpty())
                {
                    return projectDescription;
                }

                //再找Resource文件夹
                resourceName = "{0}.Resource.{1}".With(this._currentAssemblyName, ProjectDescriptionFileName);
                return this._resourceFinderManager.GetResource(resourceName);
            }
        }

        /// <summary>
        /// 创建依赖那些程序集，如果不存在则返回一个空的集合
        /// </summary>
        public virtual IEnumerable<string> ReferencedAssemblies
        {
            get { return FilterAssemblies(this._currenAssembly.GetReferencedAssemblies().Select(o => o.FullName)); }
        }

        /// <summary>
        /// 过滤一些系统级别的程序集
        /// </summary>
        /// <param name="referencedAssemblies">插件引用的程序集</param>
        /// <returns></returns>
        private static IEnumerable<string> FilterAssemblies(IEnumerable<string> referencedAssemblies)
        {
            return referencedAssemblies.Where(referencedAssembly =>
            !Regex.IsMatch(referencedAssembly, AssemblySkipPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            .ToList();
        }
    }
}
