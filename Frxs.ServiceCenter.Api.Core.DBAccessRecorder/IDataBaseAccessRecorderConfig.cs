/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/24 15:06:15
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// 连接字符串配置文件
    /// </summary>
    public interface IDataBaseAccessRecorderConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionStringName
        {
            get;
        }

        /// <summary>
        /// 是否记录日志;默认true
        /// </summary>
        bool EnableAccessRecorder
        {
            get;
        }
    }
}
