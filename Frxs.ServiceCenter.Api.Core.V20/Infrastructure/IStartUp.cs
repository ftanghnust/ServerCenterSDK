/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/16 15:23:12
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 用于系统初始化，此接口会在系统启动的时候自动进行初始化，全局只会执行一次
    /// </summary>
    public interface IStartUp
    {
        /// <summary>
        /// 需要在系统启动的时候初始化方法，启动时会自动执行此方法
        /// </summary>
        void Init();
    }
}
