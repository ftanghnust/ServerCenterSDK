namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MessageHandlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSyncOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCloseSync = new System.Windows.Forms.ToolStripMenuItem();
            this.DataSyncsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWid = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLastCus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvLogs = new Frxs.ServiceCenter.DataSync.Message.DataSyncClient.UI.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.按时间段批量更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MessageHandlerToolStripMenuItem,
            this.DataSyncsToolStripMenuItem,
            this.按时间段批量更新ToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MessageHandlerToolStripMenuItem
            // 
            this.MessageHandlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSyncOpen,
            this.ToolStripMenuItemCloseSync});
            this.MessageHandlerToolStripMenuItem.Name = "MessageHandlerToolStripMenuItem";
            this.MessageHandlerToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.MessageHandlerToolStripMenuItem.Text = "增量同步(&A)";
            // 
            // ToolStripMenuItemSyncOpen
            // 
            this.ToolStripMenuItemSyncOpen.Name = "ToolStripMenuItemSyncOpen";
            this.ToolStripMenuItemSyncOpen.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemSyncOpen.Text = "开启增量同步";
            this.ToolStripMenuItemSyncOpen.Click += new System.EventHandler(this.ToolStripMenuItemSyncOpen_Click);
            // 
            // ToolStripMenuItemCloseSync
            // 
            this.ToolStripMenuItemCloseSync.Name = "ToolStripMenuItemCloseSync";
            this.ToolStripMenuItemCloseSync.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemCloseSync.Text = "关闭增量同步";
            this.ToolStripMenuItemCloseSync.Click += new System.EventHandler(this.ToolStripMenuItemCloseSync_Click);
            // 
            // DataSyncsToolStripMenuItem
            // 
            this.DataSyncsToolStripMenuItem.Name = "DataSyncsToolStripMenuItem";
            this.DataSyncsToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.DataSyncsToolStripMenuItem.Text = "全量同步(&M)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpToolStripMenuItem.Text = "关于(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWid,
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelLastCus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1064, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelWid
            // 
            this.toolStripStatusLabelWid.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelWid.Name = "toolStripStatusLabelWid";
            this.toolStripStatusLabelWid.Size = new System.Drawing.Size(135, 21);
            this.toolStripStatusLabelWid.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(131, 21);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(652, 21);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelLastCus
            // 
            this.toolStripStatusLabelLastCus.Name = "toolStripStatusLabelLastCus";
            this.toolStripStatusLabelLastCus.Size = new System.Drawing.Size(131, 21);
            this.toolStripStatusLabelLastCus.Text = "toolStripStatusLabel2";
            // 
            // lvLogs
            // 
            this.lvLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.Location = new System.Drawing.Point(0, 28);
            this.lvLogs.Margin = new System.Windows.Forms.Padding(0);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(1064, 527);
            this.lvLogs.TabIndex = 2;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "消息ID";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "事件名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "处理状态";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "创建时间";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "消息摘要";
            this.columnHeader5.Width = 300;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "处理时间";
            this.columnHeader6.Width = 100;
            // 
            // 按时间段批量更新ToolStripMenuItem
            // 
            this.按时间段批量更新ToolStripMenuItem.Name = "按时间段批量更新ToolStripMenuItem";
            this.按时间段批量更新ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.按时间段批量更新ToolStripMenuItem.Text = "按时间段批量更新";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 578);
            this.Controls.Add(this.lvLogs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1080, 616);
            this.Name = "frmMain";
            this.Text = "业务系统数据同步客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem MessageHandlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCloseSync;
        private UI.ListViewEx lvLogs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSyncOpen;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataSyncsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLastCus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWid;
        private System.Windows.Forms.ToolStripMenuItem 按时间段批量更新ToolStripMenuItem;
    }
}

