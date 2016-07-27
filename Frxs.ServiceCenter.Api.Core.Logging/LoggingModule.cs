/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using Autofac;
using Autofac.Core;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core.Logging
{
    /// <summary>
    /// 继承自AutoFac.Module，系统框架会自动进行搜索注册
    /// </summary>
    public class LoggingModule : Autofac.Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleBuilder"></param>
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            //系统默认使用Log4Net日志记录器
            moduleBuilder.RegisterType<Log4NetLoggerFactory>()
                .As<ILoggerFactory>()
                .InstancePerLifetimeScope();

            //在需要对MVC的Filter进行属性注入的时候使用或者在global.asax里进行注册(无法关联当前使用日志类)
            moduleBuilder.Register(cx => cx.Resolve<ILoggerFactory>().CreateLogger(this.GetType())).As<ILogger>();

            base.Load(moduleBuilder);
        }

        /// <summary>
        /// logger在注册的时候，需要记录日志关联的类，这里重新设置
        /// </summary>
        /// <param name="componentRegistry"></param>
        /// <param name="registration"></param>
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            //构造函数（先准备参数对象）
            registration.Preparing += (object sender, PreparingEventArgs e) =>
            {
                var type = e.Component.Activator.LimitType;
                bool hasLogger = type.GetConstructors().Select(p => p.GetParameters()).Any(constructor => constructor.Any(item => item.ParameterType == typeof(ILogger)));
                if (!hasLogger)
                {
                    return;
                }
                e.Parameters = e.Parameters.Concat(new[]
                {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILogger), 
                        (p, i) => e.Context.Resolve<ILoggerFactory>().CreateLogger(p.Member.DeclaringType))
                });
            };

            //日志的属性注入，不使用AutoFac自动，这里手动先反射检索出对象的属性，然后进行赋值操作
            registration.Activated += (sender, e) =>
            {
                //当前正在创建的对象类型
                var type = e.Component.Activator.LimitType;
                //获取当前对象(与上一致)
                var instanceType = e.Instance.GetType();
                //检索需要注入的对象，是否包含ILogger属性
                var properties = instanceType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.PropertyType == typeof(ILogger) && p.CanWrite && p.GetIndexParameters().Length == 0);
                //可能存在多个ILogger属性，直接注入日志对象
                foreach (var propToSet in properties)
                {
                    propToSet.SetValue(e.Instance, e.Context.Resolve<ILoggerFactory>().CreateLogger(instanceType), null);
                }
            };
        }
    }
}
