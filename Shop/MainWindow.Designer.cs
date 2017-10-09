namespace Shop
{
    partial class MainWindow
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
            this.HelloLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ScanButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Top5Button = new System.Windows.Forms.Button();
            this.RandomPickedButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CloseProgramButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel.Location = new System.Drawing.Point(39, 25);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(184, 69);
            this.HelloLabel.TabIndex = 0;
            this.HelloLabel.Text = "Hello,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select this option in order to scan bills.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(205, 214);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(143, 50);
            this.ScanButton.TabIndex = 2;
            this.ScanButton.Text = "SCAN";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select this option in order to get suggestion according your TOP 5 purchases";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Top5Button
            // 
            this.Top5Button.Location = new System.Drawing.Point(205, 354);
            this.Top5Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Top5Button.Name = "Top5Button";
            this.Top5Button.Size = new System.Drawing.Size(143, 50);
            this.Top5Button.TabIndex = 4;
            this.Top5Button.Text = "TOP 5 Suggest";
            this.Top5Button.UseVisualStyleBackColor = true;
            this.Top5Button.Click += new System.EventHandler(this.Top5Button_Click);
            // 
            // RandomPickedButton
            // 
            this.RandomPickedButton.Location = new System.Drawing.Point(205, 478);
            this.RandomPickedButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RandomPickedButton.Name = "RandomPickedButton";
            this.RandomPickedButton.Size = new System.Drawing.Size(143, 50);
            this.RandomPickedButton.TabIndex = 5;
            this.RandomPickedButton.Text = "Your Picked Suggest";
            this.RandomPickedButton.UseVisualStyleBackColor = true;
            this.RandomPickedButton.Click += new System.EventHandler(this.RandomPickedButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(514, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select this option in order to get optimal suggest according your picked products" +
    "";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CloseProgramButton
            // 
            this.CloseProgramButton.Location = new System.Drawing.Point(419, 556);
            this.CloseProgramButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseProgramButton.Name = "CloseProgramButton";
            this.CloseProgramButton.Size = new System.Drawing.Size(123, 32);
            this.CloseProgramButton.TabIndex = 7;
            this.CloseProgramButton.Text = "Close program";
            this.CloseProgramButton.UseVisualStyleBackColor = true;
            this.CloseProgramButton.Click += new System.EventHandler(this.CloseProgramButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(564, 601);
            this.Controls.Add(this.CloseProgramButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RandomPickedButton);
            this.Controls.Add(this.Top5Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HelloLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Top5Button;
        private System.Windows.Forms.Button RandomPickedButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CloseProgramButton;
    }
}