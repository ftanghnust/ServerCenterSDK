/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/13 15:08:29
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 系统框架配置类
    /// </summary>
    public class SystemOptions
    {
        /// <summary>
        /// 构造一个默认的自定义数据记录容器(方便其他扩展存储全局数据)
        /// </summary>
        private readonly IDictionary<string, object> _customerParameters = new Dictionary<string, object>();

        /// <summary>
        /// 构造函数已经设置参数值
        /// </summary>
        public SystemOptions()
        {
            this.ServerName = string.Format("frxs-server-{0}", new Random().Next(1, 100));
            this.EnableAccessRecorder = false;
            this.LanguageResourcePath = string.Empty;
            this.ActionDocResourcePaths = new string[] { };
            this.SdkNamespace = "Api.SDK";
            this.DefaultActionVersionFailToHighestActionVersion = false;
            this.ValidUserIdAndUserNameFun = (requestDto) =>
            {
                if (requestDto.IsNull())
                {
                    return false;
                }
                if (0 > requestDto.UserId || string.IsNullOrWhiteSpace(requestDto.UserName))
                {
                    return false;
                }
                return true;
            };
        }

        /// <summary>
        /// 服务器名称，使用分布式的时候，这个比较有用，设置服务器名称，便于调试发现那台服务器出现问题
        /// 默认名称为：frxs-server-{0}后面格式化为1-100数字
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// 是否开启接口访问记录器，此开关为全局，不管是否实现了具体的接口访问记录器，如果此开关关闭，都将无法记录(系统框架默认开启true)
        /// </summary>
        public bool EnableAccessRecorder { get; set; }

        /// <summary>
        /// 接口使用的语言包地址，请使用绝对路径比如：g:\\web\app_data\r.xml
        /// </summary>
        public string LanguageResourcePath { get; set; }

        /// <summary>
        /// 接口描述文档地址，请使用绝对地址，比如：g:\\web\app_data\xxx.xml
        /// </summary>
        public string[] ActionDocResourcePaths { get; set; }

        /// <summary>
        /// 验证UserId和用户名称是否合法(因为框架系统无法判断当前接口系统的用户ID和用户名称如何判断才算合法的，所以需要外部来指定一个委托判断)
        /// </summary>
        public Func<IRequestDto, bool> ValidUserIdAndUserNameFun { get; set; }

        /// <summary>
        /// 输出SDK命名空间
        /// </summary>
        public string SdkNamespace { get; set; }

        /// <summary>
        /// 用于保存其他全局数据，比如扩展插件保存数据等（全局）
        /// </summary>
        public IDictionary<string, object> AdditionDatas
        {
            get
            {
                return this._customerParameters;
            }
        }

        /// <summary>
        /// 当前接口站点服务器地址比如：www.domain.com，不带http和任何/字符。
        /// </summary>
        public string HttpHost { get; set; }

        /// <summary>
        /// 此属性指示：当指定接口后，未找到对应的接口是否再次搜索最高的同名接口版本;系统框架默认为false
        /// </summary>
        public bool DefaultActionVersionFailToHighestActionVersion { get; set; }

    }
}
