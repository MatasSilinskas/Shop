using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace Shop
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Authentication login = new Authentication(usernameBox.Text, passwordBox.Text);
           if (login.Authenticated)
            {
                MainWindow main = new MainWindow(login.Username, this);
                main.Show();
            }
           else
            {
                MessageBox.Show("Error:Please enter correct username and password!", "Failed login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dontHaveAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterWindow reg = new RegisterWindow();
            reg.Show();
        }
    }
}
