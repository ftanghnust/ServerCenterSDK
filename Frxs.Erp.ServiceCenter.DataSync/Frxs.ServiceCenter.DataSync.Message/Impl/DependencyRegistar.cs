/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/27/2015 2:29:27 PM
 * *******************************************************/
using Autofac;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 注册系统默认实现的接口服务类
    /// </summary>
    internal class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Order
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 注册特定的类型到容器
        /// </summary>
        /// <param name="containerBuilder">注册容器</param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions">系统框架配置信息</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            //消息发布器注册
            containerBuilder.RegisterType<DefaultMessagePublisher>()
                .As(typeof(IMessagePublisher<IMessageBody>))
                .InstancePerLifetimeScope();

            //消息消费器注册
            containerBuilder.RegisterType<DefaultMessageConsumer>()
                .As(typeof(IMessageConsumer<IMessageBody>))
                .InstancePerLifetimeScope();

            //消息参数格式器注册
            containerBuilder.RegisterType<JsonMessageBodyFormatter>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //事件查找器注册
            containerBuilder.RegisterType<DefaultEvenSelector>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //消息Id生成器注册
            containerBuilder.RegisterType<DefaultMessageIdGenerator>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //消息存储器注册
            containerBuilder.RegisterType<DefaultMessageStoreManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //存储介质映射配置成全局单列
            containerBuilder.RegisterType<MessageStoreCache>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}