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
        public ScanWindow(string user)
        {
            InitializeComponent();
            _user = user;
        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFd = new OpenFileDialog();
            OpenFd.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";
            DialogResult dg = OpenFd.ShowDialog();
            bill_path.Text = OpenFd.FileName;
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (tesseractOption.Checked)
            {
                TesseractRecognition recognition = new TesseractRecognition(bill_path.Text, _user);
                if (!recognition.DoRecognition(new WriteLogic()))
                {
                    MessageBox.Show("Scanning Failed: Check Settings", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Scanned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if (visionOption.Checked)
                {
                    GoogleRecognition google = new GoogleRecognition(bill_path.Text, _user);
                    if (!google.DoRecognition(new WriteLogic()))
                    {
                        MessageBox.Show("Scanning Failed: Check Settings", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Scanned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
    }
}
