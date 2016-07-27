/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 默认的接口激活器实现类，内部使用了缓存提高执行效率
    /// </summary>
    public class DefaultActionFactory : IActionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IActionActivator _actionActivator;
        private readonly IActionSelector _actionSelector;

        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 方便注入新的激活器
        /// </summary>
        /// <param name="actionSelector">合法的Action接口查找器</param>
        /// <param name="actionActivator">需要定义接口激活器</param>
        public DefaultActionFactory(IActionSelector actionSelector, IActionActivator actionActivator)
        {
            //判断null
            actionActivator.CheckNullThrowArgumentNullException("actionActivator");
            actionSelector.CheckNullThrowArgumentNullException("actionSelector");

            this._actionActivator = actionActivator;
            this._actionSelector = actionSelector;
            this.Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 根据接口名称，创建对应的接口实例
        /// </summary>
        /// <param name="requestContext">当前请求上下文信息</param>
        /// <param name="actionName">大小写不敏感</param>
        /// <param name="version">接口版本</param>
        /// <returns></returns>
        public virtual IAction Create(RequestContext requestContext, string actionName, string version)
        {
            try
            {
                //requestContext参数不能为null；系统框架级错误，直接抛出异常
                requestContext.CheckNullThrowArgumentNullException("requestContext");

                //接口名称未提供
                if (actionName.IsNullOrEmpty())
                {
                    return new ErrorAction(new Exception(Resource.CoreResource.DefaultActionFactory_ActionNameIsNullOrString), requestContext);
                }

                //获取到接口描述
                var actionDescriptor = this._actionSelector.GetActionDescriptor(actionName, version);

                //未找到接口(忽略大小写)
                if (actionDescriptor.IsNull())
                {
                    return new ErrorAction(new Exception(Resource.CoreResource.DefaultActionFactory_ActionNameNotFound.With(actionName)), requestContext);
                }

                //进行接口激活，创建接口实例
                return this.Create(requestContext, actionDescriptor);
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex);
                return new ErrorAction(ex, requestContext);
            }
        }

        /// <summary>
        /// 接口描述对象
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="actionDescriptor">接口描述对象</param>
        /// <returns>返回一个接口实例</returns>
        public virtual IAction Create(RequestContext requestContext, ActionDescriptor actionDescriptor)
        {
            requestContext.CheckNullThrowArgumentNullException("requestContext");
            actionDescriptor.CheckNullThrowArgumentNullException("actionDescriptor");

            //进行接口激活，创建接口实例
            var action = (IAction)this._actionActivator.Create(actionDescriptor.ActionType);

            //赋值接口描述对象
            action.ActionDescriptor = actionDescriptor;

            //请求上下文
            action.RequestContext = requestContext;

            //上送参数对象赋值
            action.RequestDto = requestContext.RequestDto;

            //返回接口实例
            return action;
        }

        /// <summary>
        /// 释放资源直接看action继承了IDisposable;如果继承了，直接调用IDisposable.Dispose()方法
        /// </summary>
        /// <param name="action">action实例</param>
        public virtual void ReleaseAction(IAction action)
        {
            IDisposable disposable = action as IDisposable;
            if (!disposable.IsNull())
            {
                disposable.Dispose();
            }
        }
    }
}