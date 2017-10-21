using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace Shop
{
    public partial class RegisterWindow : Form
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            if (register_male.Checked)
            {
                Registration register = new Registration(register_username.Text, register_email.Text, register_password.Text, "Male");
                if (register.RegisteredSuccessfully)
                {
                   DialogResult dialog = MessageBox.Show("Successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Registration failed! Check entered info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (register_female.Checked)
                {
                    Registration register = new Registration(register_username.Text, register_email.Text, register_password.Text, "Female");
                    if (register.RegisteredSuccessfully)
                    {
                        MessageBox.Show("Successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registration failed! Check entered info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select gender!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
        }

        private void register_loginlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
