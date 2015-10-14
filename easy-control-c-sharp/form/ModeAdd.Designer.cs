namespace easy_control_c_sharp
{
    partial class ModeAdd
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
            this._nameLabel = new System.Windows.Forms.Label();
            this._imageLabel = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._imageTextBox = new System.Windows.Forms.TextBox();
            this._linkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(13, 13);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(32, 12);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Name";
            // 
            // _imageLabel
            // 
            this._imageLabel.AutoSize = true;
            this._imageLabel.Location = new System.Drawing.Point(13, 38);
            this._imageLabel.Name = "_imageLabel";
            this._imageLabel.Size = new System.Drawing.Size(34, 12);
            this._imageLabel.TabIndex = 1;
            this._imageLabel.Text = "Image";
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(15, 66);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _saveButton
            // 
            this._saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._saveButton.Enabled = false;
            this._saveButton.Location = new System.Drawing.Point(104, 66);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 3;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(79, 10);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(100, 22);
            this._nameTextBox.TabIndex = 4;
            this._nameTextBox.TextChanged += new System.EventHandler(this.ChangeText);
            // 
            // _imageTextBox
            // 
            this._imageTextBox.Enabled = false;
            this._imageTextBox.Location = new System.Drawing.Point(79, 38);
            this._imageTextBox.Name = "_imageTextBox";
            this._imageTextBox.Size = new System.Drawing.Size(100, 22);
            this._imageTextBox.TabIndex = 5;
            // 
            // _linkButton
            // 
            this._linkButton.Location = new System.Drawing.Point(186, 38);
            this._linkButton.Name = "_linkButton";
            this._linkButton.Size = new System.Drawing.Size(20, 23);
            this._linkButton.TabIndex = 6;
            this._linkButton.Text = "...";
            this._linkButton.UseVisualStyleBackColor = true;
            this._linkButton.Click += new System.EventHandler(this.ClickLinkButton);
            // 
            // ModeAdd
            // 
            this.AcceptButton = this._saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 99);
            this.Controls.Add(this._linkButton);
            this.Controls.Add(this._imageTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._imageLabel);
            this.Controls.Add(this._nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModeAdd";
            this.Text = "ModeAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _imageLabel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.TextBox _imageTextBox;
        private System.Windows.Forms.Button _linkButton;
    }
}