namespace easy_control_UI
{
    partial class KeyMode
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
            this._press = new System.Windows.Forms.RadioButton();
            this._hold = new System.Windows.Forms.RadioButton();
            this._release = new System.Windows.Forms.RadioButton();
            this._okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _press
            // 
            this._press.AutoSize = true;
            this._press.Location = new System.Drawing.Point(13, 13);
            this._press.Name = "_press";
            this._press.Size = new System.Drawing.Size(46, 16);
            this._press.TabIndex = 0;
            this._press.TabStop = true;
            this._press.Text = "Press";
            this._press.UseVisualStyleBackColor = true;
            this._press.Click += new System.EventHandler(this.ClickPress);
            // 
            // _hold
            // 
            this._hold.AutoSize = true;
            this._hold.Location = new System.Drawing.Point(13, 36);
            this._hold.Name = "_hold";
            this._hold.Size = new System.Drawing.Size(46, 16);
            this._hold.TabIndex = 1;
            this._hold.TabStop = true;
            this._hold.Text = "Hold";
            this._hold.UseVisualStyleBackColor = true;
            this._hold.Click += new System.EventHandler(this.ClickHold);
            // 
            // _release
            // 
            this._release.AutoSize = true;
            this._release.Location = new System.Drawing.Point(13, 59);
            this._release.Name = "_release";
            this._release.Size = new System.Drawing.Size(58, 16);
            this._release.TabIndex = 2;
            this._release.TabStop = true;
            this._release.Text = "Release";
            this._release.UseVisualStyleBackColor = true;
            this._release.Click += new System.EventHandler(this.ClickRelease);
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(13, 81);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(51, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "確定";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // KeyMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(86, 116);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._release);
            this.Controls.Add(this._hold);
            this.Controls.Add(this._press);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "KeyMode";
            this.Text = "KeyMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton _press;
        private System.Windows.Forms.RadioButton _hold;
        private System.Windows.Forms.RadioButton _release;
        private System.Windows.Forms.Button _okButton;
    }
}