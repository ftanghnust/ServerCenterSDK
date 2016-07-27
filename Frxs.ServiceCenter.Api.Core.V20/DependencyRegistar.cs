/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/27/2015 2:29:27 PM
 * *******************************************************/
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Frxs.ServiceCenter.Api.Core.Caching.Impl;
using Frxs.ServiceCenter.Api.Core.Infrastructure;
using Frxs.ServiceCenter.Api.Core.Tasks.Impl;
using Frxs.ServiceCenter.Api.Core.ViewEngine.Impl;
using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 注册系统默认实现的接口服务类
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 优先级比较低，但是又不配置为最低，给外部有机会以最低的方式来注入(比如：DBContext的扩展项目等)
        /// 方便外部程序重写框架里的实现，覆盖掉系统默认的实现
        /// 最先注册下系统默认的实现；这样外部实现才能覆盖掉原始的实现
        /// </summary>
        public int Order
        {
            get
            {
                return int.MinValue + 9999;
            }
        }

        /// <summary>
        /// 注册特定的类型到容器
        /// </summary>
        /// <param name="containerBuilder">注册容器</param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions">系统框架配置参数</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            //注册下当前http请求上下文抽象类
            containerBuilder.Register(c => (new HttpContextWrapper(HttpContext.Current) as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            containerBuilder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            containerBuilder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            containerBuilder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            containerBuilder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //接口处理器
            containerBuilder.RegisterType<ActionRequestHander>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口查找器
            containerBuilder.RegisterType<DefaultActionSelector>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口创建工厂
            containerBuilder.RegisterType<DefaultActionFactory>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口激活器
            containerBuilder.RegisterType<DefaultActionActivator>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口执行器
            containerBuilder.RegisterType<DefaultActionInvoker>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口执行结果格式化器
            containerBuilder.RegisterType<DefaultMediaTypeFormatterFactory>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口格式化字符串输出器
            containerBuilder.RegisterType<DefaultResponse>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口访问记录器，默认访问记录器未实现任何功能
            containerBuilder.RegisterType<DefaultApiAccessRecorder>()
                .AsImplementedInterfaces()
                .SingleInstance();

            //上送请求参数绑定器
            containerBuilder.RegisterType<DefaultRequestParamsBinder>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //上送业务参数绑定器
            containerBuilder.RegisterType<DefaultRequestDtoBinder>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //http-post参数值提供器
            containerBuilder.RegisterType<FormValueProvider>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //http-get参数值提供器
            containerBuilder.RegisterType<QueryStringValueProvider>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //服务器环境变量值提供器
            containerBuilder.RegisterType<ServerVariablesValueProvider>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //路由值提供器
            containerBuilder.RegisterType<RouteDataValueProvider>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //值提供器管理器
            containerBuilder.RegisterType<DefaultValueProvidersManager>()
                .As<IValueProvidersManager>()
                .InstancePerLifetimeScope();

            //默认身份验证器（空实现）
            containerBuilder.RegisterType<DefaultAuthentication>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口加密解密器(空实现)
            containerBuilder.RegisterType<DefaultApiSecurity>()
                .AsImplementedInterfaces()
                .SingleInstance();

            //接口缓存器，默认使用当前进程内存作为缓存器
            containerBuilder.RegisterType<PerRequestCacheManager>()
                .AsImplementedInterfaces()
                .Named<ICacheManager>("PerRequestCacheManager")
                .SingleInstance();
            //默认内存缓存实现
            containerBuilder.RegisterType<MemoryCacheManager>()
                .AsImplementedInterfaces()
                .Named<ICacheManager>("MemoryCacheManager")
                .SingleInstance();

            //资源文件查找器（注意必须将自身也注册成服务）-资源搜索器使用HOST内存
            containerBuilder.RegisterType<LocalFileViewResourceFinder>()
                .AsImplementedInterfaces()
                //.AsSelf()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("MemoryCacheManager"))
                .SingleInstance();
            //搜索内嵌资源
            containerBuilder.RegisterType<AssemblyResourceFinder>()
                .AsImplementedInterfaces()
                //.AsSelf()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("MemoryCacheManager"))
                .SingleInstance();
            //资源查找管理器
            containerBuilder.RegisterType<DefaultResourceFinderManager>()
                .AsImplementedInterfaces()
                .SingleInstance();

            //json格式化器
            containerBuilder.RegisterType<JsonMediaTypeFormatter>()
                .As<IMediaTypeFormatter>()
                .Named<IMediaTypeFormatter>("Json_MediaTypeFormatter")
                .InstancePerLifetimeScope();
            //xml格式化器
            containerBuilder.RegisterType<XmlMediaTypeFormatter>()
                .As<IMediaTypeFormatter>()
                .Named<IMediaTypeFormatter>("Xml_MediaTypeFormatter")
                .InstancePerLifetimeScope();
            //html格式化器
            containerBuilder.RegisterType<ViewMediaTypeFormatter>()
                .As<IMediaTypeFormatter>()
                .Named<IMediaTypeFormatter>("View_MediaTypeFormatter")
                .InstancePerLifetimeScope();

            //SDK代码生成器
            containerBuilder.RegisterType<DefaultCodeGeneratorFactory>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //安卓
            containerBuilder.RegisterType<AndroidSdkCodeGenerator>()
                .AsSelf()
                .InstancePerLifetimeScope();
            //C#
            containerBuilder.RegisterType<CSharpSdkCodeGenerator>()
                .AsSelf()
                .InstancePerLifetimeScope();

            //接口仿真数据生成器
            containerBuilder.RegisterType<DefaultIApiDocBuilder>()
                .As<IApiDocBuilder>()
                .SingleInstance();

            //运行的机器
            containerBuilder.RegisterType<DefaultMachineNameProvider>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //分布式作业任务协调器
            containerBuilder.RegisterType<DefaultTaskSchedulerDistributedLocker>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //注册默认的视图引擎
            containerBuilder.RegisterType<ApiViewEngine>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //RequestDto验证管理类
            containerBuilder.RegisterType<DefaultRequestDtoValidatorManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //RequestDto视图默认实现验证类
            containerBuilder.RegisterType<DefaultRequestDtoValidator>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //JSON序列化
            containerBuilder.RegisterType<DefaultJosnSerializer>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //DTO Mapper
            containerBuilder.RegisterType<DefaultObjectMapper>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //注册所有实现IConfigurationSectionHandler配置参数对象
            typeFinder.FindClassesOfType<System.Configuration.IConfigurationSectionHandler>()
                .Where(type => !type.IsAbstract)
                .ToList().ForEach(type =>
                {
                    //改变下注册策略，当配置类含有ConfigurationSectionNameAttribute特性的时候，就自动进行注册，未配置就不自动注册，需要手工获取
                    if (!type.IsDefined(typeof(ConfigurationSectionNameAttribute))) return;

                    //配置对象映射的节点名称特性
                    var configurationSectionNameAttribute = (ConfigurationSectionNameAttribute)type.GetCustomAttributes(typeof(ConfigurationSectionNameAttribute)).FirstOrDefault();

                    //特性映射不存在
                    if (configurationSectionNameAttribute.IsNull()) return;

                    //显示说明了不自动注册到IOC容器
                    if (!configurationSectionNameAttribute.IsAutoRegister) return;

                    //节点名称
                    var sectionName = configurationSectionNameAttribute.SectionName;

                    //web.config节点，映射到配置对象
                    var sectionConfiguration = ConfigurationSectionManager.GetSection(sectionName);

                    if (sectionConfiguration.IsNull())
                    {
                        throw new ApiException(
                            "未找到web.config配置节点：\r\n<configuration>\r\n<configSections>\r\n<section name=\"{0}\" type=\"{1},{2}\">\r\n</configSections>\r\n</configuration>"
                                .With(sectionName, type.FullName, type.Assembly.GetName().Name));
                    }

                    //配置文件注册
                    containerBuilder.RegisterInstance(sectionConfiguration)
                        .As(sectionConfiguration.GetType())
                        .AsImplementedInterfaces()
                        .SingleInstance();
                });

            //框架自动搜索bin目录程序集，注册所有实现了IAction接口的类；
            typeFinder.FindClassesOfType(typeof(IAction))
                .Where(type => type.IsAssignableToActionBase())
                .ToList().ForEach(type =>
                {
                    containerBuilder.RegisterType(type).PropertiesAutowired().InstancePerLifetimeScope();
                });

            //注册下本程序集里的控制器
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}