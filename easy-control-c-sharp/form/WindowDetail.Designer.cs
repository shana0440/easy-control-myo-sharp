namespace easy_control_c_sharp
{
    partial class WindowDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowDetail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._addPoseCombinationButton = new System.Windows.Forms.Button();
            this._poseCombinationGridView = new System.Windows.Forms.DataGridView();
            this._modePictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._poseCombinationGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._modePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._addPoseCombinationButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._poseCombinationGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._modePictureBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 407);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // _addPoseCombinationButton
            // 
            this._addPoseCombinationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addPoseCombinationButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addPoseCombinationButton.Location = new System.Drawing.Point(3, 380);
            this._addPoseCombinationButton.Name = "_addPoseCombinationButton";
            this._addPoseCombinationButton.Size = new System.Drawing.Size(401, 24);
            this._addPoseCombinationButton.TabIndex = 17;
            this._addPoseCombinationButton.Text = "+Add";
            this._addPoseCombinationButton.UseVisualStyleBackColor = true;
            this._addPoseCombinationButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _poseCombinationGridView
            // 
            this._poseCombinationGridView.AllowUserToAddRows = false;
            this._poseCombinationGridView.AllowUserToDeleteRows = false;
            this._poseCombinationGridView.AllowUserToResizeColumns = false;
            this._poseCombinationGridView.AllowUserToResizeRows = false;
            this._poseCombinationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._poseCombinationGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._poseCombinationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._poseCombinationGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this._poseCombinationGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._poseCombinationGridView.Location = new System.Drawing.Point(3, 63);
            this._poseCombinationGridView.Name = "_poseCombinationGridView";
            this._poseCombinationGridView.ReadOnly = true;
            this._poseCombinationGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 11.25F);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._poseCombinationGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this._poseCombinationGridView.RowTemplate.Height = 52;
            this._poseCombinationGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._poseCombinationGridView.Size = new System.Drawing.Size(401, 311);
            this._poseCombinationGridView.TabIndex = 16;
            this._poseCombinationGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PoseCombinationGridViewCellClick);
            this._poseCombinationGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PoseCombinationGridViewCellFormatting);
            this._poseCombinationGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveMouseInPoseCombinationGridView);
            // 
            // _modePictureBox
            // 
            this._modePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._modePictureBox.Location = new System.Drawing.Point(3, 3);
            this._modePictureBox.Name = "_modePictureBox";
            this._modePictureBox.Size = new System.Drawing.Size(401, 54);
            this._modePictureBox.TabIndex = 14;
            this._modePictureBox.TabStop = false;
            this._modePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WindowPictureBoxOnPaint);
            // 
            // WindowDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 407);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowDetail";
            this.Text = "ModeDetail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindowDetailFormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._poseCombinationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._modePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _addPoseCombinationButton;
        private System.Windows.Forms.DataGridView _poseCombinationGridView;
        private System.Windows.Forms.PictureBox _modePictureBox;
    }
}