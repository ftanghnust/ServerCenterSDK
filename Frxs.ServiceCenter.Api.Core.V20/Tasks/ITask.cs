/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/8/2016 10:35:19 AM
 * *******************************************************/
namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 外部作业任务都需要实现此类
    /// 注意外部的实现类里不能注入：
    /// HttpContextBase,HttpRequestBase，
    /// HttpResponseBase，
    /// HttpServerUtilityBase，
    /// HttpSessionStateBase；因为在新开的线程里无法使用http管道
    /// 其他的IOC容器里的注入类都可以
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// 执行作业任务
        /// </summary>
        /// <param name="taskExecuteContext">执行作业任务上下文</param>
        void Execute(TaskExecuteContext taskExecuteContext);
    }
}
