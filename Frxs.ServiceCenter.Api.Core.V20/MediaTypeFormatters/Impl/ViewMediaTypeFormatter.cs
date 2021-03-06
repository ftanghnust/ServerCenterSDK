﻿using Frxs.ServiceCenter.Api.Core.ViewEngine;
/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/12/10 18:28:55
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// IAction接口文档生成器；如果是第三方插件内嵌资源视图文件，
    /// </summary>
    public class ViewMediaTypeFormatter : IMediaTypeFormatter
    {
        /// <summary>
        /// 程序集内嵌资源实体查找器
        /// </summary>
        private readonly IResourceFinderManager _viewFinderManager;
        private readonly IEnumerable<IViewEngine> _apiViewEngines;

        /// <summary>
        /// 内嵌资源路径规则
        /// </summary>
        private const string ManifestResourceViewSearchPath = "{0}.Views.{1}.{2}";

        /// <summary>
        /// 视图搜索路径地址：如：~/views/{0}.aspx
        /// </summary>
        private string[] ViewLocationFormats = new string[] { "~/Views/{0}.{1}", "~/Views/T.{1}" };

        /// <summary>
        /// 接口框架命名空间
        /// </summary>
        private static readonly string Namespace = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// 换行符
        /// </summary>
        private static readonly string NewLine = Environment.NewLine;

        /// <summary>
        /// 初始化下默认的搜索地址
        /// </summary>
        /// <param name="viewFinderManager">资源查找器</param>
        /// <param name="apiViewEngines">视图引擎</param>
        public ViewMediaTypeFormatter(IResourceFinderManager viewFinderManager, IEnumerable<IViewEngine> apiViewEngines)
        {
            viewFinderManager.CheckNullThrowArgumentNullException("viewFinderManager");
            apiViewEngines.CheckNullThrowArgumentNullException("apiViewEngines");

            //按照优先级排序下
            this._viewFinderManager = viewFinderManager;

            //系统所有注册的视图引擎
            this._apiViewEngines = apiViewEngines;
        }

        /// <summary>
        /// 返回待搜索列表
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <returns>返回当前接口需要搜索的资源</returns>
        private IEnumerable<string> GetSearchedViewPath(RequestContext requestContext)
        {
            //所有视图引擎的合法后缀
            var supportedExtensions = this._apiViewEngines.Select(x => x.SupportedExtension.StartsWith(".") ?
                          x.SupportedExtension.Substring(1, x.SupportedExtension.Length - 1) : x.SupportedExtension)
                          .ToArray();
            //接口名称
            string actionName = requestContext.RawRequestParams.ActionName;

            //合法的视图名称集合
            var viewNames = new string[] { actionName, actionName.Replace(".", "") };

            //循环下看下是否存在自定义的视图文件路径(优先级最高1)
            IList<string> searchedViewPath = (from locationPath in this.ViewLocationFormats
                                              from viewName in viewNames
                                              from supportedExtension in supportedExtensions
                                              select requestContext.HttpContext
                                              .Server.MapPath(locationPath.With(viewName, supportedExtension)))
                                              .ToList();

            //当前插件所在程序集Views文件夹查找（程序集自定义的内嵌资源文件优先级2）
            if (!requestContext.ActionDescriptor.IsNull())
            {
                //当前接口所在程序集
                Assembly assembly = requestContext.ActionDescriptor.ActionType.Assembly;

                //检测所有视图命名规则是否存在
                searchedViewPath.Append((from viewName in viewNames
                                         from supportedExtension in supportedExtensions
                                         select ManifestResourceViewSearchPath
                                         .With(assembly.GetName().Name, viewName, supportedExtension))
                                        .ToArray());
            }

            //全局默认（兜底）
            foreach (var supportedExtension in supportedExtensions)
            {
                searchedViewPath.Add(ManifestResourceViewSearchPath.With(Namespace, "T", supportedExtension));
            }

            //返回所有的待搜索路径
            return searchedViewPath;
        }

        /// <summary>
        /// 根据上下文获取当前接口视图源代码
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="searchedViewPaths">待搜索的路径集合</param>
        /// <param name="supportedExtension">筛选出后缀，如：.cshtml</param>
        /// <returns>返回接口视图源文件；注意：在未找到对应实体源文件，会抛出异常</returns>
        private Tuple<string, string, string> GetViewSource(RequestContext requestContext,
            IEnumerable<string> searchedViewPaths,
            string supportedExtension)
        {
            //循环搜索列表
            foreach (var viewPath in searchedViewPaths.Where(o => o.EndsWith(supportedExtension)))
            {
                //找到对应的模板源码，直接返回
                var viewSource = this._viewFinderManager.GetResource(viewPath);

                //根据优先级找到了视图文件
                if (!viewSource.IsNull())
                {
                    return new Tuple<string, string, string>(Path.GetExtension(viewPath), viewSource, viewPath);
                }
            }

            return null;
        }

        /// <summary>
        /// 搜索视图，读取视图，然后执行视图，返回执行后的视图内容
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="actionResult">IAction执行结果</param>
        /// <returns>返回格式化后的字符串</returns>
        public string SerializedActionResultToString(RequestContext requestContext, ActionResult actionResult)
        {
            requestContext.CheckNullThrowArgumentNullException("requestContext");
            requestContext.RawRequestParams.CheckNullThrowArgumentNullException("requestContext.RawRequestParams");

            var viewParameters = new ViewParameterCollection();
            //视图模板文件始终只会包含RequestContext，ActionResult这2个对象
            viewParameters.Add(new ViewParameter("RequestContext", requestContext));
            //在需要输出复杂类型的时候，所有的数据请挂靠在ActionResult.Data属性下，这样外部可以根据此对象来进行视图解析
            viewParameters.Add(new ViewParameter("ActionResult", actionResult));

            //获取所有待搜索的视图路径集合
            var searchedViewPaths = this.GetSearchedViewPath(requestContext);

            //循环所有视图引擎
            foreach (var apiViewEngine in this._apiViewEngines)
            {
                //资源模板文件
                var result = this.GetViewSource(requestContext, searchedViewPaths, apiViewEngine.SupportedExtension);

                //视图模板未找到，继续下一个视图引擎
                if (result.IsNull())
                {
                    continue;
                }

                return apiViewEngine.CompileByViewSource(result.Item2, viewParameters, Encoding.UTF8);
            }

            //直接返回空
            throw new ApiException(Resource.CoreResource.View_Not_Exists.With(NewLine, string.Join(NewLine, searchedViewPaths)));
        }
    }
}
