/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/12/2016 11:39:18 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Tasks
{
    /// <summary>
    /// 注册作业任务调度
    /// </summary>
    public class TaskSchedulerRegistar : ITaskSchedulerRegistar
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
            //更新系统作业任务管理器，5分钟执行一次
            TaskSchedulerManager.TaskSchedulers.Update(name: "SYS.KeyAliveTask", seconds: 60 * 5);
         }
    }
}
