/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/6/8 13:59:45
 * *******************************************************/
using System.Net.Http;
using System;

namespace Frxs.ServiceCenter.Api.Core.Host
{
    /// <summary>
    /// 保持站点激活作业任务
    /// </summary>
    public class KeepAliveTask : ITask
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;
        private readonly SystemOptions _systemOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="systemOptions">系统配置</param>
        public KeepAliveTask(ILogger logger, SystemOptions systemOptions)
        {
            this._logger = logger ?? NullLogger.Instance;
            this._systemOptions = systemOptions;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute(TaskExecuteContext taskExecuteContext)
        {
            //未设置站点域名，直接返回，不执行
            if (this._systemOptions.HttpHost.IsNullOrEmpty())
            {
                return;
            }

            //System.Threading.Thread.Sleep(10000);

            //访问一次远程站点
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var resp = httpClient.GetStringAsync("http://{0}/api/keepalive?format=json"
                        .With(this._systemOptions.HttpHost)).Result;

                    //将返回数据记录到日志
                    this._logger.Information("{0}\r\n{1}".With(taskExecuteContext.TaskScheduler.Name, resp));
                }
                catch (Exception ex)
                {
                    this._logger.Error(ex);
                }
            }
        }
    }
}
