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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._windowGridView = new System.Windows.Forms.DataGridView();
            this._addButton = new System.Windows.Forms.Button();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開啟EasyControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._windowGridView)).BeginInit();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._windowGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._addButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 446);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // _windowGridView
            // 
            this._windowGridView.AllowUserToAddRows = false;
            this._windowGridView.AllowUserToDeleteRows = false;
            this._windowGridView.AllowUserToResizeColumns = false;
            this._windowGridView.AllowUserToResizeRows = false;
            this._windowGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._windowGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._windowGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._windowGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowGridView.Location = new System.Drawing.Point(3, 3);
            this._windowGridView.Name = "_windowGridView";
            this._windowGridView.ReadOnly = true;
            this._windowGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._windowGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this._windowGridView.RowTemplate.Height = 50;
            this._windowGridView.Size = new System.Drawing.Size(341, 410);
            this._windowGridView.TabIndex = 6;
            this._windowGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModeGridViewCellClick);
            this._windowGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ModeGridViewCellFormatting);
            // 
            // _addButton
            // 
            this._addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addButton.Location = new System.Drawing.Point(3, 419);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(341, 24);
            this._addButton.TabIndex = 7;
            this._addButton.Text = "+Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.ClickAddButton);
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
            this._contextMenuStrip.Size = new System.Drawing.Size(166, 48);
            // 
            // 開啟EasyControlToolStripMenuItem
            // 
            this.開啟EasyControlToolStripMenuItem.Name = "開啟EasyControlToolStripMenuItem";
            this.開啟EasyControlToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.開啟EasyControlToolStripMenuItem.Text = "開啟EasyControl";
            this.開啟EasyControlToolStripMenuItem.Click += new System.EventHandler(this.ClickMenuStripOpen);
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            this.結束ToolStripMenuItem.Click += new System.EventHandler(this.ClickMenuStripClose);
            // 
            // EasyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(347, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EasyControl";
            this.Text = "easyControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseForm);
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._windowGridView)).EndInit();
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView _windowGridView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 開啟EasyControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
    }
}