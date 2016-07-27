/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/29 12:18:22
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Host
{
    /// <summary>
    /// 动态注册接口框架配置
    /// 注意：此文件需要单独放置于网站根目录；系统框架将会在启动的时候自动进行注册配置；如果修改了文件内容，需要重启IIS
    /// 开发的时候此文件生成操作设置成：编译；编译的时候，请将此文件生成操作设置为：内容
    /// </summary>
    public class DynamicCompiledDependencyRegistar : IDynamicCompiledDependencyRegistar
    {
        /// <summary>
        /// 注册各种需要初始化的数据
        /// </summary>
        public void Register()
        {
            //1.注册全局配置信息
            SystemOptionsManager.Current = new SystemOptions()
            {
                //是否开启接口访问记录器，此开关为全局，不管是否实现了具体的接口访问记录器，如果此开关关闭，都将无法记录(系统框架默认开启false)
                EnableAccessRecorder = false,

                //服务器名称；正式环境里，请将不同的API服务器名称分别配置，便于在分布式接口中跟踪调试服务器
                ServerName = string.Format("frxs-server-{0}", new System.Random().Next(1, 100)),
                //ACTION项目语言资源包地址(可以为空，系统将使用默认的语言包)
                LanguageResourcePath = System.Web.HttpContext.Current.Server.MapPath("~/Config/LanguageResource.config"),
                //接口描述文档
                ActionDocResourcePaths = new string[] {
                    //System.Web.HttpContext.Current.Server.MapPath("~/Config/Frxs.Erp.ServiceCenter.Order.Model.XML")  
                },
                //自动输出SDK命名空间
                SdkNamespace = "Frxs.Erp.ServiceCenter.Order.SDK",
                //检测用户ID和用户名称是否提交(交给外部来配置怎么检测用户名称和用户ID是的提交了)
                ValidUserIdAndUserNameFun = (requestDto) =>
                {
                    //皮之不存毛将焉附?
                    if (null == requestDto)
                    {
                        return false;
                    }
                    if (0 > requestDto.UserId || string.IsNullOrWhiteSpace(requestDto.UserName))
                    {
                        return false;
                    }
                    return true;
                }
            };

            //自定义数据（其他第三方扩展项目可以进行数据的配置）
            SystemOptionsManager.Current.AdditionDatas.Add("System-StartTime", DateTime.Now);

            //2.注册IP白名单(正式环境根据安全性需要来进行配置)
            //WhiteIpManager.Add("192.168.0.11", "192.168.3.24", "192.168.2.20","192.168.3.122");

            //3.注册全局拦截器
            //GlobalActionFiltersManager.Add(new GlobalRequestHanderInterceptors.DefaultGlobalRequestHanderInterceptor());
        }
    }
}