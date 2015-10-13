namespace easy_control_c_sharp
{
    partial class EasyControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._modeGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開啟EasyControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._modeGridView)).BeginInit();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._modeGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 446);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // _modeGridView
            // 
            this._modeGridView.AllowUserToAddRows = false;
            this._modeGridView.AllowUserToDeleteRows = false;
            this._modeGridView.AllowUserToResizeColumns = false;
            this._modeGridView.AllowUserToResizeRows = false;
            this._modeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._modeGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._modeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._modeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._modeGridView.Location = new System.Drawing.Point(3, 3);
            this._modeGridView.Name = "_modeGridView";
            this._modeGridView.ReadOnly = true;
            this._modeGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this._modeGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this._modeGridView.RowTemplate.Height = 50;
            this._modeGridView.Size = new System.Drawing.Size(287, 410);
            this._modeGridView.TabIndex = 6;
            this._modeGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModeGridViewCellClick);
            this._modeGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ModeGridViewCellFormatting);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "+Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.ContextMenuStrip = this._contextMenuStrip;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "EasyControl";
            this._notifyIcon.Visible = true;
            this._notifyIcon.DoubleClick += new System.EventHandler(this.ClickNotifyIcon);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟EasyControlToolStripMenuItem,
            this.結束ToolStripMenuItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(168, 48);
            // 
            // 開啟EasyControlToolStripMenuItem
            // 
            this.開啟EasyControlToolStripMenuItem.Name = "開啟EasyControlToolStripMenuItem";
            this.開啟EasyControlToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.開啟EasyControlToolStripMenuItem.Text = "開啟EasyControl";
            this.開啟EasyControlToolStripMenuItem.Click += new System.EventHandler(this.ClickMenuStripOpen);
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            this.結束ToolStripMenuItem.Click += new System.EventHandler(this.ClickMenuStripClose);
            // 
            // EasyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(293, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EasyControl";
            this.Text = "easyControl";
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._modeGridView)).EndInit();
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView _modeGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 開啟EasyControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
    }
}