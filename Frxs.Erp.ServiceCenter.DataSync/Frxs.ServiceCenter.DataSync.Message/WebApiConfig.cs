/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/29 12:18:22
 * *******************************************************/
using System;
using System.Linq;
using Frxs.ServiceCenter.Api.Core;
using Autofac;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 动态编译并注册接口框架配置
    /// 注意：此文件需要单独放置于网站根目录；系统框架将会在启动的时候自动进行注册配置；
    /// 开发的时候此文件生成操作设置成：编译；发布的时候，请将此文件生成操作设置为：内容
    /// </summary>
    public class WebApiConfig : IDynamicCompiledDependencyRegistar
    {
        /// <summary>
        /// 注册各种需要初始化的数据
        /// </summary>
        public void Register()
        {
            // 1.注册全局配置信息
            SystemOptionsManager.Current = new SystemOptions()
            {
                // 是否开启接口访问记录器，此开关为全局，不管是否实现了具体的接口访问记录器，如果此开关关闭，都将无法记录(系统框架默认false)
                EnableAccessRecorder = false,

                // 服务器名称；正式环境里，请将不同的API服务器名称分别配置，便于在分布式接口中跟踪调试服务器
                ServerName = string.Format("frxs-server-{0}", new System.Random().Next(1, 100)),

                // ACTION项目语言资源包地址(可以为空，系统将使用默认的语言包，如果配置了，就必须保证文件是存在的)
                //LanguageResourcePath = System.Web.HttpContext.Current.Server.MapPath("~/Config/LanguageResource.config"),

                // 接口描述文档(针对多个接口项目分开开发的情况下，请指定多个注释文档即可，正式环境里可以将此配置标注掉)
                ActionDocResourcePaths = new string[] {
                    //请注意，文件必须存在，要不框架调用会出现，如果不存在，可以标注掉此配置即可
                    //System.Web.HttpContext.Current.Server.MapPath("~/bin/Frxs.ServiceCenter.Api.Host.XML"),
                    //System.Web.HttpContext.Current.Server.MapPath("~/config/Frxs.Erp.ServiceCenter.ID.Actions.XML"),
                    //System.Web.HttpContext.Current.Server.MapPath("~/config/Frxs.Erp.ServiceCenter.Product.Actions.XML"),
                    //System.Web.HttpContext.Current.Server.MapPath("~/config/Frxs.Erp.ServiceCenter.Product.Model.XML"),
                    //System.Web.HttpContext.Current.Server.MapPath("~/config/Frxs.ServiceCenter.Api.Core.XML")
                },

                // 配置SDK开发包命名空间
                SdkNamespace = "Frxs.ServiceCenter.DataSync.Message.PublisherClient",

                // HOST站点地址，如果是IP配置的站点，格式为：192.x.x.x 或者 192.x.x.x:80 等
                HttpHost = "m.api.com",

                // 此属性指示：当客户端指定参数Version后，服务未找到对应的接口是否再次搜索最高的同名接口版本;系统框架默认为false
                DefaultActionVersionFailToHighestActionVersion = false,

                // 检测用户ID和用户名称是否提交(框架里只定义接口，具体不实现。交给外部配置来检测用户名称和用户ID是否提交了)
                ValidUserIdAndUserNameFun = (requestDto) =>
                {
                    //皮之不存毛将焉附?
                    if (requestDto.IsNull())
                    {
                        return false;
                    }
                    return 0 <= requestDto.UserId && !string.IsNullOrWhiteSpace(requestDto.UserName);
                }

            };

            // 自定义数据（其他第三方扩展项目可以进行数据的配置）
            SystemOptionsManager.Current.AdditionDatas.Add("Api-System-StartTime", DateTime.Now);

            // 比如现在有个针对接口框架扩展出来的项目，需要进行数据配置，可以进行如下配置
            //SystemOptionsManager.Current.AdditionDatas.Add("System-{AppName}-{ParamName}", "参数值");

            // 2.注册IP白名单(正式环境根据安全性需要来进行配置)
            //WhiteIpManager.Ips.Add("192.168.0.11", "192.168.3.24", "192.168.2.20", "192.168.3.122");

            // 3.注册全局拦截器
            //GlobalActionFiltersManager.Filters.Add(new GlobalRequestHanderInterceptors.DefaultGlobalRequestHanderInterceptor());

            // 4.如果需要给接口配置不同的策略，可以按照下面方式来配置注意先后顺序，后注册的配置文件会覆盖掉前面注册的属性配置
            ApiConfigManager.Configs

            .Register(new ActionConfigItem()
            {
                //框架级别全局接口配置，全部接口都会生效，同时会覆盖掉对应接口框架默认的参数设置(兜底设置)

                //缓存过期时间设置（>0为启用缓存，时间单位为：分钟）
                //CacheTime                     = 0,

                //是否允许Ajax访问
                //EnableAjaxRequest             = false,

                //允许客户端提交方式
                //HttpMethod                    = HttpMethod.POST | HttpMethod.GET,

                //接口是否过期
                //Obsolete                      = false,

                //是否需要安全连接访问
                //RequireHttps                  = false,

                //是否进行全局校验
                //AllowAnonymous                = true,

                //是否允许打包到SDK
                //CanPackageToSdk               = true,

                //是否允许记录日志
                //EnableRecordApiLog            = true,

                //上送参数是否需要进行用户ID和用户名称校验
                //RequiredUserIdAndUserName     = false
            })

            // 接口注销(正式环境下需要将将界面显示的接口注销掉)
            // .Obsolete("API.BuildSDK", "Api.Doc", "Api.Doc.Builder", "API.Logs.Get", "API.Logs.List", "API.TestTool")
            // .Obsolete("API.BuildSDK", "1.0")
            // .ObsoleteSystemActions()

            //注册特性路由
            .Route("API.ServerTime.Get", "api/gettime")

            //注册配置
            .Register("API.ServerTime.Get", new ActionConfigItem()
            {
                // 单一接口未指定版本全局配
                AllowAnonymous = true,
                EnableAjaxRequest = false,
                EnableRecordApiLog = true,
                HttpMethod = HttpMethod.POST | HttpMethod.GET,
                Obsolete = false,
                RequireHttps = false
            })

            // 匿名方式进行注册，只要匿名对象属性与配置对象参数一致既可(参数不区分大小写)
            .Register("API.ServerTime.Get", new { RequireHttps = false, CacheTime = 10 })

            //接口分组
            .Group("API.ServerTime.Get", "公共接口")

            // 注册1.0
            .Register("API.ServerTime.Get", "1.0", new ActionConfigItem()
            {
                //是否忽略掉操作用户
                HttpMethod = HttpMethod.POST | HttpMethod.GET

                // 1.0版本值配置了缓存配置，但是系统框架会自动将此属性赋值到此接口未指定版本号的配置上面，
                // 这样此接口配置的真实配置为

                // ********************************************************
                // AllowAnonymous       = true
                // CacheTime            = 100
                // EnableAjaxRequest    = false
                // EnableRecordApiLog   = true
                // HttpMethod           = HttpMethod.POST | HttpMethod.GET
                // Obsolete             = false
                // RequireHttps         = false
                // ********************************************************

            })

            .Register("API.ServerTime.Get", "1.0", new ActionConfigItem()
            {
                // 特定版本配置会覆盖全局配置
                RequiredUserIdAndUserName = false,

                //不走加解密流程
                DataSignatureTransmission = false,

                //执行完事件后，会自动执行此缓存键清理
                UnloadCacheKeys = new[] { "API.Logs" }
            })

            .Register("API.ServerTime.Get", "1.1", new ActionConfigItem()
            {
                // 特定版本配置会覆盖全局配置
                RequireHttps = false,

                // 配置前缀
                CachePrefix = "API.ServerTime",

                //忽略掉操作用户
                CacheKeyIgnoreUserIdAndUserName = true,

                // 重新配置缓存为10分钟
                CacheTime = 10
            });
        }
    }
}