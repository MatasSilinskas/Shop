using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using Logic;

namespace Shop
{
    public partial class MainWindow : Form
    {
        LoginWindow _loginWindow;
        string _user;

        public string User { get => _user; }

        public MainWindow(string user, LoginWindow loginWindow)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
            _user = user;
            HelloLabel.Text = "Hello, " + _user + "!";

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            ScanWindow scan = new ScanWindow(_user);
            scan.Show();
        }

        private void CloseProgramButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Top5Button_Click(object sender, EventArgs e)
        {
            Top5Window top5 = new Top5Window(_user);
            top5.Show();
        }

        private void RandomPickedButton_Click(object sender, EventArgs e)
        {
            StoreFromListWindow list = new StoreFromListWindow(_user);
            list.Show();

        }

        private void MoreOptionsButton_Click(object sender, EventArgs e)
        {
            MoreOptionsWindow moreOptions = new MoreOptionsWindow(_user);
            moreOptions.Show();
        }
    }
}
