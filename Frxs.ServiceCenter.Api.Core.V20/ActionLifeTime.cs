/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/25 12:26:39
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口执行的时间对象
    /// </summary>
    [Serializable]
    internal sealed class ActionLifeTime
    {
        /// <summary>
        /// 当前请求上下文信息
        /// </summary>
        private DateTime _startTime;
        private DateTime _endTime;

        /// <summary>
        /// 接口执行的时间对象，方便计算执行时间使用；会提取出RequestContext请求上下文当中的StartTime时间作为执行起始时间
        /// </summary>
        /// <param name="requestContext">当前请求上下文信息</param>
        public ActionLifeTime(RequestContext requestContext)
        {
            //开始时间默认当前时间
            this._startTime = DateTime.Now;

            //请求上下文存在就使用请求上下文里面保存的开始时间
            if (!requestContext.IsNull())
            {
                //开始时间;请求上下文里开始记录了起始时间，先取出来保存，防止新线程下，当前上下文被主线程释放掉了
                object startTime = null;
                if (requestContext.AdditionDatas.TryGetValue("startTime", out startTime))
                {
                    this._startTime = (DateTime)startTime;
                }
            }

            //结束时间；直接使用当前类实例化的时候时间
            this._endTime = DateTime.Now;
        }

        /// <summary>
        /// 接口执行时间对象
        /// </summary>
        /// <param name="startTime">初始化开始时间</param>
        public ActionLifeTime(DateTime startTime)
        {
            this._startTime = startTime;
        }

        /// <summary>
        /// 设置结束时间
        /// </summary>
        /// <param name="endTime">结束时间</param>
        public void SetEndTime(DateTime endTime)
        {
            this._endTime = endTime;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return this._startTime;
            }
        }

        /// <summary>
        /// 结束时间，直接获取当前时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return this._endTime;
            }
        }

        /// <summary>
        /// 总共使用的毫秒数
        /// </summary>
        public double UsedTotalMilliseconds
        {
            get
            {
                return (this.EndTime - this.StartTime).TotalMilliseconds;
            }
        }
    }
}
