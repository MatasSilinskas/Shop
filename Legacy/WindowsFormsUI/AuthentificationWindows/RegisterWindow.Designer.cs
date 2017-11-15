namespace Shop
{
    partial class RegisterWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.register_username = new System.Windows.Forms.TextBox();
            this.register_email = new System.Windows.Forms.TextBox();
            this.register_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.register_button = new System.Windows.Forms.Button();
            this.register_loginlink = new System.Windows.Forms.LinkLabel();
            this.register_male = new System.Windows.Forms.RadioButton();
            this.register_female = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // register_username
            // 
            this.register_username.Location = new System.Drawing.Point(134, 143);
            this.register_username.Name = "register_username";
            this.register_username.Size = new System.Drawing.Size(308, 22);
            this.register_username.TabIndex = 3;
            // 
            // register_email
            // 
            this.register_email.Location = new System.Drawing.Point(134, 196);
            this.register_email.Name = "register_email";
            this.register_email.Size = new System.Drawing.Size(308, 22);
            this.register_email.TabIndex = 4;
            // 
            // register_password
            // 
            this.register_password.Location = new System.Drawing.Point(134, 252);
            this.register_password.Name = "register_password";
            this.register_password.Size = new System.Drawing.Size(308, 22);
            this.register_password.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gender:";
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(153, 366);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(195, 43);
            this.register_button.TabIndex = 8;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // register_loginlink
            // 
            this.register_loginlink.AutoSize = true;
            this.register_loginlink.Location = new System.Drawing.Point(153, 436);
            this.register_loginlink.Name = "register_loginlink";
            this.register_loginlink.Size = new System.Drawing.Size(195, 17);
            this.register_loginlink.TabIndex = 9;
            this.register_loginlink.TabStop = true;
            this.register_loginlink.Text = "Have an account? Login now.";
            this.register_loginlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_loginlink_LinkClicked);
            // 
            // register_male
            // 
            this.register_male.AutoSize = true;
            this.register_male.Location = new System.Drawing.Point(134, 302);
            this.register_male.Name = "register_male";
            this.register_male.Size = new System.Drawing.Size(59, 21);
            this.register_male.TabIndex = 10;
            this.register_male.TabStop = true;
            this.register_male.Text = "Male";
            this.register_male.UseVisualStyleBackColor = true;
            // 
            // register_female
            // 
            this.register_female.AutoSize = true;
            this.register_female.Location = new System.Drawing.Point(224, 302);
            this.register_female.Name = "register_female";
            this.register_female.Size = new System.Drawing.Size(75, 21);
            this.register_female.TabIndex = 11;
            this.register_female.TabStop = true;
            this.register_female.Text = "Female";
            this.register_female.UseVisualStyleBackColor = true;
            // 
            // RegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(507, 660);
            this.Controls.Add(this.register_female);
            this.Controls.Add(this.register_male);
            this.Controls.Add(this.register_loginlink);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.register_password);
            this.Controls.Add(this.register_email);
            this.Controls.Add(this.register_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterWindow";
            this.Text = "CSE - Registration Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox register_username;
        private System.Windows.Forms.TextBox register_email;
        private System.Windows.Forms.TextBox register_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.LinkLabel register_loginlink;
        private System.Windows.Forms.RadioButton register_male;
        private System.Windows.Forms.RadioButton register_female;
    }
}