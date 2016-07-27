/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/21 13:43:41
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 框架系统初始化管理
    /// </summary>
    public class SystemOptionsManager
    {
        /// <summary>
        /// 静态系统设置，用于全局缓存
        /// </summary>
        private static SystemOptions _systemOptions;
        private static readonly object Locker = new object();

        /// <summary>
        /// 获取或者设置系统设置
        /// </summary>
        public static SystemOptions Current
        {
            get
            {
                //如果不存在就直接构造出一个默认的配置
                if (!_systemOptions.IsNull())
                {
                    return _systemOptions;
                }

                lock (Locker)
                {
                    if (_systemOptions.IsNull())
                    {
                        _systemOptions = new SystemOptions();
                    }
                }

                //返回系统配置信息
                return _systemOptions;
            }
            set
            {
                lock (Locker)
                {
                    _systemOptions = value;
                }
            }
        }
    }
}
