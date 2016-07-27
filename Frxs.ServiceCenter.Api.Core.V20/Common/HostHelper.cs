/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/25 13:23:07
 * *******************************************************/
using System;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 主机帮助
    /// </summary>
    public class HostHelper
    {
        /// <summary>
        /// 获取当前运行环境的bin文件夹物理路径
        /// </summary>
        /// <returns>获取当前运行环境的bin文件夹物理路径，如："c:\inetpub\wwwroot\bin"</returns>
        public static string GetBinDirectory()
        {
            return HostingEnvironment.IsHosted ? HttpRuntime.BinDirectory : AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 映射虚拟路径到实际物理路径
        /// </summary>
        /// <param name="path">虚拟路径，如： "~/bin"</param>
        /// <returns>返回物理路径，如： "c:\inetpub\wwwroot\bin"</returns>
        public static string MapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                return HostingEnvironment.MapPath(path);
            }

            //not hosted. For example, run in unit tests
            string baseDirectory = GetBinDirectory();
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(baseDirectory, path);
        }

        /// <summary>
        /// 尝试重写下web.config时间，用于重启应用程序域
        /// </summary>
        /// <returns></returns>
        public static bool TryWriteWebConfig()
        {
            try
            {
                File.SetLastWriteTimeUtc(MapPath("~/web.config"), DateTime.UtcNow);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 尝试重写下Global.asax时间，用于重启应用程序域
        /// </summary>
        /// <returns></returns>
        public static bool TryWriteGlobalAsax()
        {
            try
            {
                File.SetLastWriteTimeUtc(MapPath("~/global.asax"), DateTime.UtcNow);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
