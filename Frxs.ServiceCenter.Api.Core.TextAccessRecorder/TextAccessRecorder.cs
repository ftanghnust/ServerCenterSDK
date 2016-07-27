/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/1 10:22:47
 * *******************************************************/
using System;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core.TextAccessRecorder
{
    /// <summary>
    /// 用于测试记录访问接口
    /// </summary>
    public class TextAccessRecorder : IApiAccessRecorder
    {
        /// <summary>
        /// 使用日志记录器作为临时的接口访问记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 默认初始化空的日志接口
        /// </summary>
        public TextAccessRecorder()
        {
            this.Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Record(ApiAccessRecorderArgs args)
        {
            this.Logger.Debug(
                "{0}{1}{2}{3}".With(
                 "{0}=============={1}================={0}".With(Environment.NewLine, args.ActionDescriptor.ActionName),
                string.Join(Environment.NewLine, (from item in args.ActionDescriptor.GetAttributes() select "{0}:{1}".With(item.Key, item.Value)).ToArray()),
                 "{0}==============Request/Response================={0}".With(Environment.NewLine),
                string.Join(Environment.NewLine, (from item in args.GetAttributes().Where(o => o.Key != "ActionDescriptor") select "{0}:{1}".With(item.Key, item.Value)).ToArray())));
        }

        /// <summary>
        /// 
        /// </summary>
        public int Priority
        {
            get { return 0; }
        }
    }
}