/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/12/2016 11:39:18 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Host
{
    /// <summary>
    /// 注册作业任务调度器
    /// </summary>
    public class TaskSchedulerRegistar : ITaskSchedulerRegistar
    {
        /// <summary>
        /// 默认最小，方便后面插件有机会修改
        /// </summary>
        public int Order
        {
            get
            {
                return int.MinValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskSchedulerCollection"></param>
        public void Register(ITaskSchedulerCollection taskSchedulerCollection)
        {
            //注册下作业任务
            taskSchedulerCollection.Register<KeepAliveTask>(name: "SYS.KeyAliveTask", seconds: 15 * 60, stopOnError: true);
        }
    }
}
