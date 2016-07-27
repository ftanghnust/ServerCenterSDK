/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/28 21:43:25
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口是否允许记录访问日志，如果设置为false，实现第三方日志的接口将无法记录此接口访问的记录
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EnableRecordApiLogAttribute : Attribute
    {
        /// <summary>
        /// 接口是否允许记录访问
        /// </summary>
        public bool EnableRecordApiLog { get; private set; }

        /// <summary>
        /// 接口是否允许记录访问
        /// </summary>
        /// <param name="enableRecordApiLog">默认true（第三方实现日志记录记录接口日志）</param>
        public EnableRecordApiLogAttribute(bool enableRecordApiLog = true)
        {
            this.EnableRecordApiLog = enableRecordApiLog;
        }
    }
}
