/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:42:08 PM
 * *******************************************************/
using Frxs.ServiceCenter.DataSync.Message.ConsumerClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// 客户端自动同步管理器
        /// </summary>
        private MessageHandlerManager _messageHandlerManager;
        private SNFile _snFile;
        private Configuration _config;

        /// <summary>
        /// 已经自动处理的消息数
        /// </summary>
        private int _handledMessageCount = 0;

        /// <summary>
        /// 初始化同步管理器
        /// </summary>
        private void InitMessageHandlerManager()
        {
            //系统配置
            this._config = ConfigurationFactory.GetConfiguration();

            //流水号读取
            this._snFile = new SNFile("MessageId.sn");

            //消费端调用示例（ws://m.api.com/api)
            var messageHandler = new DefaultMessageHandler(this._config.MessageServerUrl,
                                                           //客户端自己实现的序列化与反序列化对象
                                                           new DefaultJosnSerializer(),
                                                           //获取仓库编号委托，需要客户端自己实现具体的获取方式
                                                           () => this._config.WID, ApiClientRoute.CreateApiClient())
            {
                //消息处理错误，重试多少次
                MaxRetries = this._config.MaxRetries
            };

            //消费端事件触发
            messageHandler.OnMessageRequestSuccess += messageHandler_OnMessageRequestSuccess;
            messageHandler.OnMessageConsumeComplete += messageHandler_OnMessageConsumeComplete;
            messageHandler.OnMessageRequestError += messageHandler_OnMessageRequestError;
            messageHandler.OnMessageExecutedException += MessageHandler_OnMessageExecutedException;
            messageHandler.OnMessageExecutedSuccess += MessageHandler_OnMessageExecutedSuccess;

            //客户端处理封装类
            _messageHandlerManager = new MessageHandlerManager(messageHandler, () =>
            {
                return this._snFile.Read();
            })
            {
                //每2秒读取一次消息
                Seconds = 2,
                //每次读取N条消息
                Number = this._config.Number
            };

        }

        /// <summary>
        /// 显示状态栏信息
        /// </summary>
        private void InitStatusLabel()
        {
            //状态栏
            this.toolStripStatusLabel.Text =
                this._messageHandlerManager == null ? "未知" :
                "增量同步：" + (this._messageHandlerManager.IsStop ? "关闭" : "启动");
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="e"></param>
        private void WriteLogs(EventArgsBase e, string status, string message)
        {
            this._handledMessageCount++;

            int maxShow = 500;

            if (this.lvLogs.Items.Count > maxShow)
            {
                for (int i = maxShow - 1; i < this.lvLogs.Items.Count; i++)
                    this.lvLogs.Items.RemoveAt(i);
            }

            var item = new ListViewItem(new string[] {
                e.Message.Id,
                e.Message.Topic,
                status,
                e.Message.Created.ToString(),
                message,
                DateTime.Now.ToString()
            });

            if (status != "OK")
            {
                item.UseItemStyleForSubItems = false;
                var checkedColor = ColorTranslator.FromHtml("#F5F5DC");
                item.BackColor = checkedColor;// F5F5DC
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].BackColor = checkedColor;
                }
            }

            this.lvLogs.Items.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageHandler_OnMessageExecutedSuccess(object sender, EventArgsBase e)
        {
            this.lvLogs.Invoke(new MethodInvoker(delegate { this.WriteLogs(e, "OK", "OK"); }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        private void MessageHandler_OnMessageExecutedException(object arg1, EventArgsBase arg2, Exception arg3)
        {
            lvLogs.Invoke(new MethodInvoker(delegate { this.WriteLogs(arg2, "ERR", arg3.Message); }));
        }

        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            //初始化消息处理器
            this.InitMessageHandlerManager();

            //启动作业任务
            this._messageHandlerManager.Start();

            //状态栏
            this.InitStatusLabel();

            //最后同步
            this.toolStripStatusLabelLastCus.Text = string.Empty;

            //仓库
            this.toolStripStatusLabelWid.Text = string.Format("当前仓库：{0}", this._config.WID);
        }

        /// <summary>
        /// 请求消息接口失败
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageHandler_OnMessageRequestError(object sender, MessageRequestErrorEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage, "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 消费当前批消息完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageHandler_OnMessageConsumeComplete(object sender, MessageConsumeCompleteEventArgs e)
        {
            //Console.WriteLine(e.MessageConsumeResult.LastConsumeMessageId ?? "等待消息....");
        }

        /// <summary>
        /// 消费消息成功（每一个）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageHandler_OnMessageRequestSuccess(object sender, MessageRequestSuccessEventArgs e)
        {
            this.toolStripStatusLabelLastCus.Text = string.Format("最后一次增量同步：{0}", DateTime.Now.ToString());
            //为空不记录到文件
            if (string.IsNullOrWhiteSpace(e.MessageConsumeResult.LastConsumeMessageId))
            {
                return;
            }

            //记录到文件
            this._snFile.Write(e.MessageConsumeResult.LastConsumeMessageId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            var dataSyncConfig = new DataSyncHandlerManager().GetDataSyncConfig();
            foreach (var item in dataSyncConfig.DataSyncs)
            {
                if (item.Type == "Line")
                {
                    var toolStripSeparator = new ToolStripSeparator { Text = item.Name, Tag = item };
                    this.DataSyncsToolStripMenuItem.DropDownItems.Add(toolStripSeparator);
                }
                else
                {
                    var dataSyncToolScriptMenuItem = new ToolStripMenuItem()
                    {
                        Text = string.Format("{0}(数据源：{1})", item.Name, item.Steps.Length),
                        Tag = item
                    };
                    dataSyncToolScriptMenuItem.Click += DataSyncToolScriptMenuItem_Click;
                    this.DataSyncsToolStripMenuItem.DropDownItems.Add(dataSyncToolScriptMenuItem);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataSyncToolScriptMenuItem_Click(object sender, EventArgs e)
        {
            //只有增量关闭的情况下才能全量同步
            if (!this._messageHandlerManager.IsStop)
            {
                MessageBox.Show("当前增量同步处于开启状态，全量同步需要先关闭增量同步", 
                    "系统消息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            var dataSync = ((ToolStripMenuItem)sender).Tag as DataSync;
            if (this._config.DataSyncType == "1")
            {
                new frmDataSync0(dataSync).ShowDialog();
            }
            else
            {
                new frmDataSync(dataSync).ShowDialog();
            }
        }

        /// <summary>
        /// 禁止关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AboutBox();
            frm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemSyncOpen_Click(object sender, EventArgs e)
        {
            this._messageHandlerManager.Start();
            this.InitStatusLabel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCloseSync_Click(object sender, EventArgs e)
        {
            var result = this._messageHandlerManager.Stop();
            if (result)
            {
                this.InitStatusLabel();
            }
        }
    }
}
