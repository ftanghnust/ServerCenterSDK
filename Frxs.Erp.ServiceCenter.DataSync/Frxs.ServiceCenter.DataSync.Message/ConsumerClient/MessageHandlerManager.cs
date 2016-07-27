/* **************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/11 10:45:00.451
 * **************************************************************************/
using System;
using System.Threading;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 消息消费客户端管理类
    /// </summary>
    public class MessageHandlerManager
    {
        /// <summary>
        /// 消息消息
        /// </summary>
        private Timer _timer;
        private bool _disposed;
        private MessageHandler _messageHandler;
        private Func<string> _startMessageId;
        private bool _isStop = false;

        /// <summary>
        /// 消息消费客户端管理类
        /// </summary>
        /// <param name="messageHandler">消息消费客户端</param>
        /// <param name="startMessageId">获取起始编号委托</param>
        public MessageHandlerManager(MessageHandler messageHandler, Func<string> startMessageId)
        {
            if (null == messageHandler)
                throw new ArgumentNullException("messageHandler");
            if (null == startMessageId)
                throw new ArgumentNullException("startMessageId");

            this._messageHandler = messageHandler;
            this._startMessageId = startMessageId;
            this.Number = 100;
            this.Seconds = 30;
        }

        /// <summary>
        /// 每次消费的消息条数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 作业执行间隔，单位：秒
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 执行作业任务间隔，单位：毫秒，内部使用
        /// </summary>
        private int Interval
        {
            get
            {
                return this.Seconds * 1000;
            }
        }

        /// <summary>
        /// 作业线程启动时间，一旦启动器时间不会变化
        /// </summary>
        public DateTime Started { get; private set; }

        /// <summary>
        /// 最后一次执行作业任务时间
        /// </summary>
        public DateTime LastRuned { get; private set; }
        /// <summary>
        /// 显示当前作业线程是否正在执行作业
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// 是否停止中
        /// </summary>
        public bool IsStop { get { return this._isStop; } }

        /// <summary>
        /// timer每次触发的时候执行的委托方法
        /// </summary>
        /// <param name="state"></param>
        private void TimerHandler(object state)
        {
            //停止timer触发
            this._timer.Change(-1, -1);

            //执行作业任务
            this.Run();

            if (!this._isStop)
            {
                //重新开始
                this._timer.Change(this.Interval, this.Interval);
            }
        }

        /// <summary>
        /// 真正执行作业线程里的所有作业任务
        /// </summary>
        private void Run()
        {
            if (Seconds <= 0)
            {
                return;
            }

            this.LastRuned = DateTime.Now;
            this.IsRunning = true;

            //开始执行
            this._messageHandler.Start(this._startMessageId(), this.Number);

            //当前是否正在执行
            this.IsRunning = false;
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            this._isStop = false;
            if (this._timer == null)
            {
                this._timer = new Timer(new TimerCallback(this.TimerHandler), null, this.Interval, this.Interval);
                this.Started = DateTime.Now;
            }
            else
            {
                this._timer.Change(this.Interval, this.Interval);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public bool Stop()
        {
            if (this._timer == null)
            {
                return false;
            }

            //关闭同步
            this._isStop = true;

            //停止成功
            return true;
        }

        /// <summary>
        /// 释放作业线程
        /// </summary>
        public void Dispose()
        {
            if ((this._timer != null) && !this._disposed)
            {
                lock (this)
                {
                    this._timer.Dispose();
                    this._timer = null;
                    this._disposed = true;
                }
            }
        }
    }
}
