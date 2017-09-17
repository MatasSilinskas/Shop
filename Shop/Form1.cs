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

namespace Shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "cekis.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string parduotuvesPavadinimas = sr.ReadLine();
                richTextBox1.Text = parduotuvesPavadinimas;
            }
        }
    }
}
