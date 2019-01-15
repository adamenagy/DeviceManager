namespace DeviceManager
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.computerList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.copyProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Books";
            // 
            // computerList
            // 
            this.computerList.FormattingEnabled = true;
            this.computerList.Location = new System.Drawing.Point(15, 25);
            this.computerList.Name = "computerList";
            this.computerList.Size = new System.Drawing.Size(175, 173);
            this.computerList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Books on Device";
            // 
            // deviceList
            // 
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(239, 25);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(188, 173);
            this.deviceList.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(196, 52);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(37, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = ">>";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(196, 131);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(37, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "<<";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // copyProgress
            // 
            this.copyProgress.Location = new System.Drawing.Point(15, 204);
            this.copyProgress.Name = "copyProgress";
            this.copyProgress.Size = new System.Drawing.Size(412, 11);
            this.copyProgress.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 228);
            this.Controls.Add(this.copyProgress);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.computerList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Device Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox computerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ProgressBar copyProgress;
    }
}

