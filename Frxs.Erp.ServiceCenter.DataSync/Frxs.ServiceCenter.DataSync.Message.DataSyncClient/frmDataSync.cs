/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:42:08 PM
 * *******************************************************/
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDataSync : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private DataSync _dataSync;
        private BackgroundWorker _worker = null;
        private bool _isSync = false;
        private string _title = "{0}：同步数据源：{1}/{2}，正同步数据源：{3}";
        private int _totalSync = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSync"></param>
        public frmDataSync(DataSync dataSync)
        {
            InitializeComponent();
            this._dataSync = dataSync;
            this.Text = string.Format(this._title, this._dataSync.Name, 0, this._dataSync.Steps.Count(), "-");
            this.labelProgress.Text = string.Empty;
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
            this.progressBar.Value = e.ProgressPercentage;
            this.labelProgress.Text = e.UserState.ToString();
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
            //同步表索引号
            int index = 0;

            foreach (var step in this._dataSync.Steps)
            {
                index++;

                //获取全量同步处理器类型
                var type = Type.GetType(step.Type);

                //创建新的同步器
                var dataSyncHandler = Activator.CreateInstance(type) as DataSyncHandler;
                //dataSyncHandler.PageSize = 600;

                //执行同步前触发
                dataSyncHandler.OnExecuting = (eventArgs) =>
                {
                    this.progressBar.Invoke(new MethodInvoker(() =>
                    {
                        this.progressBar.Maximum = eventArgs.TotalCount;
                        this.progressBar.Value = 0;
                    }));
                    this.Invoke(new MethodInvoker(() =>
                    {
                        this.Text = string.Format(this._title, this._dataSync.Name, index, this._dataSync.Steps.Count(), step.Name);
                    }));
                };

                //同步成功触发
                dataSyncHandler.OnItemSyncComplete = (eventArgs) =>
                {
                    this._totalSync++;
                    ((BackgroundWorker)sender).ReportProgress(eventArgs.Index, "同步：" + eventArgs.Message);
                };

                //执行完成触发
                dataSyncHandler.OnExecuted = (eventArgs) =>
                {
                    //this.progressBar.Invoke(new MethodInvoker(() => { this.progressBar.Value = 0; }));
                };

                dataSyncHandler.Execute();
            }
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
