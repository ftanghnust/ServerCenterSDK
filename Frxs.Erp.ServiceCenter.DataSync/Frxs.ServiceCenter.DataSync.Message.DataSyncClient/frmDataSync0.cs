/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:42:08 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDataSync0 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private DataSync _dataSync;
        private BackgroundWorker _worker = null;
        private bool _isSync = false;
        private string _title = "{0}，共需同步数据源：{2}";
        private int _totalSync = 0;
        private static object _locker = new object();
        private List<ProgressBar> progressBars = new List<ProgressBar>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSync"></param>
        public frmDataSync0(DataSync dataSync)
        {
            InitializeComponent();
            this._dataSync = dataSync;
            this.Text = string.Format(this._title, this._dataSync.Name, 0, this._dataSync.Steps.Count(), "-");
            this.labelProgress.Text = string.Empty;
            int y = 0;
            for (int i = 0; i < dataSync.Steps.Length; i++)
            {
                string desc = dataSync.Steps[i].Description;
                string name = dataSync.Steps[i].Name;
                y = i * 28;
                var label = new Label();
                label.Location = new Point(5, y);
                label.Text = (string.IsNullOrWhiteSpace(desc) ? name : desc) + ": ";
                label.TextAlign = ContentAlignment.MiddleRight;
                label.Width = 100;
                label.Height = 30;
                this.panelProInfo.Controls.Add(label);
                var progressBar = new ProgressBar() { Value = 0, Width = 250, Height = 23 };
                progressBar.Location = new Point(label.Width + 5, y);
                this.panelProInfo.Controls.Add(progressBar);
                this.progressBars.Add(progressBar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataSync_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("同步数据将会清空掉原始数据！确定全量同步？",
                "系统消息",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync(true);

            this._isSync = true;
            this._totalSync = 0;
            this.btnDataSync.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var p = this.progressBars[int.Parse(e.UserState.ToString())];
            p.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._isSync = false;
            this.btnDataSync.Enabled = true;
            this.btnCancel.Enabled = true;
            MessageBox.Show(string.Format("全量同步数据完成，一共同步【{0}】条数据", this._totalSync),
                "系统消息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Parallel.For(0, this._dataSync.Steps.Length, (i) =>
            {
                //获取全量同步处理器类型
                var type = Type.GetType(this._dataSync.Steps[i].Type);

                //创建新的同步器
                var dataSyncHandler = Activator.CreateInstance(type) as DataSyncHandler;
                //dataSyncHandler.PageSize = 600;

                //执行同步前触发
                dataSyncHandler.OnExecuting = (eventArgs) =>
                {
                    this.progressBars[i].Invoke(new MethodInvoker(() =>
                    {
                        this.progressBars[i].Maximum = eventArgs.TotalCount;
                        this.progressBars[i].Value = 0;
                    }));
                };

                //同步成功触发
                dataSyncHandler.OnItemSyncComplete = (eventArgs) =>
                {
                    lock (_locker)
                    {
                        this._totalSync++;
                        ((BackgroundWorker)sender).ReportProgress(eventArgs.Index, i);
                    }
                };

                //执行完成触发
                dataSyncHandler.OnExecuted = (eventArgs) =>
                {
                    //this.progressBar.Invoke(new MethodInvoker(() => { this.progressBar.Value = 0; }));
                };

                dataSyncHandler.Execute();
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDataSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._isSync)
            {
                e.Cancel = true;
                MessageBox.Show("系统正在同步数据，请稍等片刻....",
                    "系统消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
