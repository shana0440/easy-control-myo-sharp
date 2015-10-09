namespace easy_control_UI
{
    partial class PoseCombinationSelect
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
            this._keyPictureBox = new System.Windows.Forms.PictureBox();
            this._okButton = new System.Windows.Forms.Button();
            this._posePictureBox = new System.Windows.Forms.PictureBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._continueCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._keyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._posePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _keyPictureBox
            // 
            this._keyPictureBox.Location = new System.Drawing.Point(16, 435);
            this._keyPictureBox.Name = "_keyPictureBox";
            this._keyPictureBox.Size = new System.Drawing.Size(644, 172);
            this._keyPictureBox.TabIndex = 11;
            this._keyPictureBox.TabStop = false;
            this._keyPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyPictureBoxOnPaint);
            this._keyPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickKeyPictureBox);
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(585, 615);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 12;
            this._okButton.Text = "確定";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _posePictureBox
            // 
            this._posePictureBox.Location = new System.Drawing.Point(16, 12);
            this._posePictureBox.Name = "_posePictureBox";
            this._posePictureBox.Size = new System.Drawing.Size(644, 417);
            this._posePictureBox.TabIndex = 13;
            this._posePictureBox.TabStop = false;
            this._posePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PosePictureBoxOnPaint);
            this._posePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickPosePictureBox);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(504, 615);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 14;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _continueCheckBox
            // 
            this._continueCheckBox.AutoSize = true;
            this._continueCheckBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._continueCheckBox.Location = new System.Drawing.Point(34, 390);
            this._continueCheckBox.Name = "_continueCheckBox";
            this._continueCheckBox.Size = new System.Drawing.Size(44, 24);
            this._continueCheckBox.TabIndex = 15;
            this._continueCheckBox.Text = "是";
            this._continueCheckBox.UseVisualStyleBackColor = true;
            this._continueCheckBox.Click += new System.EventHandler(this.ClickContinueCheckBox);
            // 
            // PoseCombinationSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 648);
            this.Controls.Add(this._continueCheckBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._posePictureBox);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._keyPictureBox);
            this.Name = "PoseCombinationSelect";
            this.Text = "PoseCombinationSelect";
            ((System.ComponentModel.ISupportInitialize)(this._keyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._posePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _keyPictureBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.PictureBox _posePictureBox;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.CheckBox _continueCheckBox;
    }
}