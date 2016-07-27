/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/12/2016 11:39:18 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 注册作业任务调度
    /// </summary>
    internal class TaskSchedulerRegistar : ITaskSchedulerRegistar
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Order { get { return 0; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskSchedulerCollection"></param>
        public void Register(ITaskSchedulerCollection taskSchedulerCollection)
        {
            //注册(站点启动后多少秒启动同步组件)
            taskSchedulerCollection.Register<SaveMessage2DBTask>(name: "同步消息到数据库", seconds: 10);

            //注册清理程序(一个小时)
            taskSchedulerCollection.Register<ClearExpiredMessageTask>(name: "清理过期消息", seconds: 60 * 60);
        }
    }
}
