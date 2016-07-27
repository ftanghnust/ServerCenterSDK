/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/5/2016 11:53:09 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.StartUp
{
    /// <summary>
    /// 系统初始化需要做的一些事件
    /// </summary>
    public class StartUp : IStartUp
    {
        /// <summary>
        /// 站点启动的时候会自动运行此方法
        /// </summary>
        public void Init()
        {
            //throw new NotImplementedException();
        }
    }
}