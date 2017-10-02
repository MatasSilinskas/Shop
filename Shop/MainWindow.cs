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
        LoginWindow loginWindow;
        string _user;

        public string User { get => _user; }

        public MainWindow(string username, LoginWindow login)
        {
            InitializeComponent();
            loginWindow = login;
            var testImagePath = @"..\..\example.jpg";
            _user = username;
            label1.Text = "Hello, " + username + "!";

            try
            {
                using (var engine = new TesseractEngine(@"..\..\..\", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                          //  var text = page.GetText();
                           // textBox1.Text = text;
                        }
                    }
                }
            }
            catch (Exception e)
            {
              //  Trace.TraceError(e.ToString());
               // Console.WriteLine("Unexpected Error: " + e.Message);
             //   Console.WriteLine("Details: ");
              //  Console.WriteLine(e.ToString());
            }
            //Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            ScanWindow scan = new ScanWindow(_user);
            scan.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Top5Window top5 = new Top5Window(_user);
            top5.Show();
            //MessageBox.Show(String.Join("\n", top.TakeDataFromFile()), "List", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void button3_Click(object sender, EventArgs e)
        {
            StoreFromListWindow list = new StoreFromListWindow(_user);
            list.Show();

        }
    }
}
