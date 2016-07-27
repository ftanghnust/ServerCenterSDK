/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// action激活器实现
    /// </summary>
    public class DefaultActionActivator : IActionActivator
    {
        /// <summary>
        /// 使用属性注入的方式注入日志组件
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 为了不让写日志出错（属性注入是惰性注入，因此需要进行构造函数指定一个空的日志实现）
        /// </summary>
        public DefaultActionActivator()
        {
            this.Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 创建指定类型的 Action 对象
        /// </summary>
        /// <param name="actionType">实现ActionBase的实现类类型</param>
        /// <returns></returns>
        public virtual IAction Create(Type actionType)
        {
            //actionType不能为null
            actionType.CheckNullThrowArgumentNullException("actionType");

            //没有继承自ActionBase抽象基类
            if (!actionType.IsAssignableToActionBase())
            {
                throw new ApiException(Resource.CoreResource.DefaultActionActivator_TypeError
                    .With(actionType.FullName));
            }

            //从IOC容器里创建一个新的Action接口对象
            try
            {
                return (IAction)ServicesContainer.Current.Resolver(actionType);
            }
            catch (Exception exception)
            {
                this.Logger.Error(exception.StackTrace);
                throw new ApiException(exception.Message, exception.InnerException);
            }
        }
    }
}