/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/14 12:53:52
 * *******************************************************/
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//[assembly: PreApplicationStartMethod(typeof(Frxs.ServiceCenter.Api.Core.ServicesContainer), "Init")]
namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// see AutoFac link to:http://docs.autofac.org
    /// </summary>
    public class ServicesContainer
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly object Locker = new object();
        private static IContainer _container;
        private static ServicesContainer _servicesContainer;

        /// <summary>
        /// 系统框架服务注册类
        /// </summary>
        private ServicesContainer() { }

        /// <summary>
        /// 获取当前服务容器
        /// </summary>
        public static ServicesContainer Current
        {
            get
            {
                if (!_servicesContainer.IsNull()) return _servicesContainer;

                lock (Locker)
                {
                    if (_servicesContainer.IsNull())
                    {
                        _servicesContainer = new ServicesContainer();
                    }
                }

                return _servicesContainer;
            }
        }

        /// <summary>
        /// 对外公开的IOC容器访问接口
        /// </summary>
        public IContainer Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// IOC容器初始化，系统框架初始化等
        /// </summary>
        /// <returns></returns>
        public IContainer Initialize(SystemOptions systemOptions)
        {
            //已经初始化了，直接返还
            if (!_container.IsNull())
            {
                return _container;
            }

            //初始化注册容器
            var builder = new ContainerBuilder();

            //查询器注册（默认使用WebAppTypeFinder）
            var typeFinder = new WebAppTypeFinder { EnsureBinFolderAssembliesLoaded = true };
            //默认自动搜索BIN目录
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //注册系统框架配置参数
            builder.RegisterInstance(systemOptions).As<SystemOptions>().SingleInstance();

            //注册module
            typeFinder.FindClassesOfType<Autofac.Core.IModule>()
                .Where(type => !type.IsAbstract && type.IsPublic && typeof(Module).IsAssignableFrom(type))
                .ToList().ForEach(type =>
                {
                    builder.RegisterModule((Autofac.Core.IModule)Activator.CreateInstance(type));
                });

            //所有实现IDependencyRegistar的接口进行初始化
            typeFinder.FindClassesOfType<IDependencyRegistar>()
                .Select(type => (IDependencyRegistar)Activator.CreateInstance(type))
                .OrderBy(o => o.Order).ToList().ForEach(a => { a.Register(builder, typeFinder, systemOptions); });

            //build
            _container = builder.Build();

            //返回注册容器
            return _container;
        }

        /// <summary>
        /// 根据类型创建出对象实例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="lifetimeScope">生命周期作用域</param>
        /// <returns></returns>
        public TService Resolver<TService>(ILifetimeScope lifetimeScope = null)
        {
            return (TService)Resolver(typeof(TService), lifetimeScope);
        }

        /// <summary>
        /// 根据类型创建出所有注册的实现类型
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="namedServices"></param>
        /// <param name="lifetimeScope">生命周期作用域</param>
        /// <returns></returns>
        public TService[] ResolverAll<TService>(string namedServices = "", ILifetimeScope lifetimeScope = null)
        {
            //返回生命域
            lifetimeScope = lifetimeScope.NullBackDefault(() => this.Scope());

            return string.IsNullOrWhiteSpace(namedServices)
                ? lifetimeScope.Resolve<IEnumerable<TService>>().ToArray()
                : lifetimeScope.ResolveNamed<IEnumerable<TService>>(namedServices).ToArray();
        }

        /// <summary>
        /// 根据类型创建对象
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifetimeScope">生命周期作用域</param>
        /// <returns></returns>
        public object Resolver(Type serviceType, ILifetimeScope lifetimeScope = null)
        {
            return lifetimeScope.NullBackDefault(() => this.Scope()).Resolve(serviceType);
        }

        /// <summary>
        /// 尝试创建指定类型，不会抛出异常
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">返回的实例</param>
        /// <param name="lifetimeScope">生命周期作用域，可以为null</param>
        /// <returns>创建是否成功true/false</returns>
        public bool TryResolver(Type serviceType, ILifetimeScope lifetimeScope, out object instance)
        {
            return lifetimeScope.NullBackDefault(() => this.Scope()).TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 创建未注册的类型（类型没有在容器里注册过）；但是创建的类型有可能会引用容器里注册的类型
        /// </summary>
        /// <param name="type">待创建服务类型</param>
        /// <param name="lifetimeScope">生命周期作用域，可为null</param>
        /// <returns></returns>
        public object ResolverUnregistered(Type type, ILifetimeScope lifetimeScope = null)
        {

            lifetimeScope = lifetimeScope.NullBackDefault(() => this.Scope());

            //获取类型的构造函数集合(优先使用最多参数的构造函数)
            var constructors = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length);

            //循环构造函数集合，创建对象
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = this.Resolver(parameter.ParameterType, lifetimeScope);
                        if (service.IsNull())
                        {
                            throw new ApiException("依赖{0}未注册，请先注册服务".With(parameter.ParameterType.FullName));
                        }
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (ApiException ex)
                {
                    //
                }
            }
            throw new ApiException("未找到构造函数，创建对象失败");
        }

        /// <summary>
        /// 判断一个类型是否注册
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifetimeScope">生命周期作用域</param>
        /// <returns></returns>
        public bool IsRegistered(Type serviceType, ILifetimeScope lifetimeScope = null)
        {
            return lifetimeScope.NullBackDefault(() => this.Scope()).IsRegistered(serviceType);
        }

        /// <summary>
        /// 如果反转不成功，则返回null
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="lifetimeScope">生命周期作用域</param>
        /// <returns></returns>
        public object ResolveOptional(Type serviceType, ILifetimeScope lifetimeScope = null)
        {
            return lifetimeScope.NullBackDefault(() => this.Scope()).ResolveOptional(serviceType);
        }

        /// <summary>
        /// 获取当前请求生命周期
        /// </summary>
        /// <returns></returns>
        public virtual ILifetimeScope Scope()
        {
            try
            {
                //基于一个当前请求的生命周期（一个生命周期后，系统资源会释放）
                if (!HttpContext.Current.IsNull())
                {
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;
                }
                return this.Container.BeginLifetimeScope("AutofacWebRequest");
            }
            catch (Exception)
            {
                return this.Container.BeginLifetimeScope("AutofacWebRequest");
            }
        }
    }
}
