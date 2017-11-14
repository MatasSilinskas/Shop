namespace Shop
{
    partial class ScanWindow
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
            this.bill_path = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ScanButton = new System.Windows.Forms.Button();
            this.tesseractOption = new System.Windows.Forms.RadioButton();
            this.visionOption = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select bill image to scan it";
            // 
            // bill_path
            // 
            this.bill_path.Location = new System.Drawing.Point(17, 140);
            this.bill_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bill_path.Name = "bill_path";
            this.bill_path.Size = new System.Drawing.Size(276, 22);
            this.bill_path.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(312, 132);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 38);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(163, 263);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(91, 32);
            this.ScanButton.TabIndex = 3;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // tesseractOption
            // 
            this.tesseractOption.AutoSize = true;
            this.tesseractOption.Location = new System.Drawing.Point(17, 212);
            this.tesseractOption.Name = "tesseractOption";
            this.tesseractOption.Size = new System.Drawing.Size(92, 21);
            this.tesseractOption.TabIndex = 4;
            this.tesseractOption.TabStop = true;
            this.tesseractOption.Text = "Tesseract";
            this.tesseractOption.UseVisualStyleBackColor = true;
            // 
            // visionOption
            // 
            this.visionOption.AutoSize = true;
            this.visionOption.Location = new System.Drawing.Point(115, 212);
            this.visionOption.Name = "visionOption";
            this.visionOption.Size = new System.Drawing.Size(303, 21);
            this.visionOption.TabIndex = 5;
            this.visionOption.TabStop = true;
            this.visionOption.Text = "Google Vision API (not recommended ATM)";
            this.visionOption.UseVisualStyleBackColor = true;
            // 
            // ScanWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(420, 367);
            this.Controls.Add(this.visionOption);
            this.Controls.Add(this.tesseractOption);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.bill_path);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ScanWindow";
            this.Text = "CSE - Scan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bill_path;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.RadioButton tesseractOption;
        private System.Windows.Forms.RadioButton visionOption;
    }
}