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
    public partial class ScanWindow : Form
    {
        string _user;
        public ScanWindow(string username)
        {
            InitializeComponent();
            _user = username;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFd = new OpenFileDialog();
            OpenFd.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";
            DialogResult dg = OpenFd.ShowDialog();
            bill_path.Text = OpenFd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OCR recognition = new OCR(bill_path.Text, _user);
            if (!recognition.DoRecognition())
            {
                MessageBox.Show("Scanning Failed: Check Settings", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Scanned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void bill_path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
