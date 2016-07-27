/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/6/12 17:51:30
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.Api.Host.Tasks
{
    /// <summary>
    /// 演示作业任务，可以使用特性方式来注册作业任务调度
    /// </summary>
    [TaskScheduler("sys", seconds: 20, enabled: true)]
    public class TestTask : ITask
    {
        /// <summary>
        /// 
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionSelector"></param>
        /// <param name="machineNameProvider"></param>
        /// <param name="logger"></param>
        public TestTask(IActionSelector actionSelector, IMachineNameProvider machineNameProvider, ILogger logger)
        {
            //演示构造函数注入
            var sy = machineNameProvider.GetMachineName();
            this._logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskExecuteContext"></param>
        public void Execute(TaskExecuteContext taskExecuteContext)
        {
            var messagePort = new MessagePost(".\\private$\\message");
            messagePort.Receive<Data.Domain.Warehouse>(o =>
            {
                this._logger.Information("消费了消息：{0}".With(o.WHID));
            });
        }
    }
}
