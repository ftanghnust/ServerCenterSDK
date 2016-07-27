/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/18 19:22:39
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 本地SDK缓存设置参数
    /// </summary>
    public sealed class CacheOptions
    {
        /// <summary>
        /// 本地SDK缓存设置参数
        /// 是否启用本地缓存，默认为false，默认缓存时间60分钟
        /// 如果需要启用本地缓存，请设置属性FromLocalCache=true
        /// </summary>
        public CacheOptions()
        {
            //默认不启用本地SDK缓存
            this.FromLocalCache = false;

            //默认的缓存时间60分钟
            this.CacheTime = 60;
        }

        /// <summary>
        /// 是否启用本地缓存，默认false
        /// </summary>
        public bool FromLocalCache { get; set; }

        /// <summary>
        /// 缓存时间，缓存时间单位为分钟(系统默认60分钟)
        /// </summary>
        public int CacheTime { get; set; }
    }
}
