/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/16 9:20:51
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 本地文件视图查找器
    /// </summary>
    public class LocalFileViewResourceFinder : ResourceFinderBase, IStartUp
    {
        /// <summary>
        /// 用于缓存所有系统框架的文本资源
        /// </summary>
        private static readonly Dictionary<string, string> CachedeLocalResourceNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
        private static bool _initializationed = false;
        private readonly HttpContextBase _httpContext;
        private ICacheManager _cacheManager;

        /// <summary>
        /// 视图文件保存的本地文件夹
        /// </summary>
        private const string ViewDirectory = "~/Views";

        /// <summary>
        /// 本地文件资源查找器
        /// </summary>
        /// <param name="httpContext">当前http请求上下文</param>
        /// <param name="cacheManager">缓存接口</param>
        public LocalFileViewResourceFinder(HttpContextBase httpContext, ICacheManager cacheManager)
        {
            this._httpContext = httpContext;
            this._cacheManager = cacheManager;
        }

        /// <summary>
        /// 获取所有查找器
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetResources()
        {
            //已经初始化了
            if (_initializationed)
            {
                return CachedeLocalResourceNames;
            }

            using (new WriteLockDisposable(Locker))
            {
                //初始化了
                if (_initializationed)
                {
                    return CachedeLocalResourceNames;
                }

                _initializationed = true;

                //获取物理路径
                string physicalPath = this._httpContext.Server.MapPath(ViewDirectory);

                //获取所有文件夹下面的文件
                if (Directory.Exists(physicalPath))
                {
                    //找出合法的后缀文件
                    var fiels = Directory.GetFiles(physicalPath, "*", SearchOption.AllDirectories)
                        .Where(fileName => this.SupportedFileExtensions.Any(ex => ex.Equals(Path.GetExtension(fileName), StringComparison.OrdinalIgnoreCase))).ToList();

                    //循环读取本地资源
                    foreach (var file in fiels)
                    {
                        //缓存里已经存在指定文件
                        if (CachedeLocalResourceNames.ContainsKey(file))
                        {
                            continue;
                        }
                        //添加到缓存
                        using (StreamReader streamReader = new StreamReader(file))
                        {
                            CachedeLocalResourceNames.Add(file, streamReader.ReadToEnd());
                        }
                    }
                }
            }

            //返回缓存本地资源文件
            return CachedeLocalResourceNames;
        }

        /// <summary>
        /// 优先级(重写下是为了系统自定义文件夹配置高于程序集)
        /// </summary>
        public override int Order
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 预热下，系统启动时候执行一次
        /// </summary>
        void IStartUp.Init()
        {
            this.GetResources();
        }
    }
}
