namespace easy_control_UI
{
    partial class ModeDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddPoseCombinationButton = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.AddPoseCombinationButton, 0, 2);
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
            // AddPoseCombinationButton
            // 
            this.AddPoseCombinationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPoseCombinationButton.Location = new System.Drawing.Point(3, 380);
            this.AddPoseCombinationButton.Name = "AddPoseCombinationButton";
            this.AddPoseCombinationButton.Size = new System.Drawing.Size(401, 24);
            this.AddPoseCombinationButton.TabIndex = 17;
            this.AddPoseCombinationButton.Text = "+Add";
            this.AddPoseCombinationButton.UseVisualStyleBackColor = true;
            this.AddPoseCombinationButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _poseCombinationGridView
            // 
            this._poseCombinationGridView.AllowUserToAddRows = false;
            this._poseCombinationGridView.AllowUserToDeleteRows = false;
            this._poseCombinationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._poseCombinationGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._poseCombinationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._poseCombinationGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._poseCombinationGridView.Location = new System.Drawing.Point(3, 63);
            this._poseCombinationGridView.Name = "_poseCombinationGridView";
            this._poseCombinationGridView.ReadOnly = true;
            this._poseCombinationGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this._poseCombinationGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this._poseCombinationGridView.RowTemplate.Height = 52;
            this._poseCombinationGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._poseCombinationGridView.Size = new System.Drawing.Size(401, 311);
            this._poseCombinationGridView.TabIndex = 16;
            this._poseCombinationGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PoseCombinationGridViewCellClick);
            this._poseCombinationGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PoseCombinationGridViewCellFormatting);
            // 
            // _modePictureBox
            // 
            this._modePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._modePictureBox.Location = new System.Drawing.Point(3, 3);
            this._modePictureBox.Name = "_modePictureBox";
            this._modePictureBox.Size = new System.Drawing.Size(401, 54);
            this._modePictureBox.TabIndex = 14;
            this._modePictureBox.TabStop = false;
            this._modePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ModePictureBoxOnPaint);
            // 
            // ModeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 407);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ModeDetail";
            this.Text = "ModeDetail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModeDetailFormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._poseCombinationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._modePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddPoseCombinationButton;
        private System.Windows.Forms.DataGridView _poseCombinationGridView;
        private System.Windows.Forms.PictureBox _modePictureBox;
    }
}