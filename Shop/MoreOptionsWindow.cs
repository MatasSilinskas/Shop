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
    public partial class MoreOptionsWindow : Form
    {
        string _pathToDatabase = @"../../" + "database.txt";
        string _shopName;
        string _user;
        public DateTime _date = DateTime.Today.Date.AddMonths(-1);
        public MoreOptionsWindow(string user)
        {
            InitializeComponent();
            _user = user;
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            _date = date;
        }
        private void ViewButton_Click(object sender, EventArgs e)
        {
            _shopName = textBox1.Text;
            ReadLogic read = new ReadLogic();
            string[] readAllLines = read.ReadFile(_pathToDatabase);
            foreach (string line in readAllLines)
            {
                Split split = new Split();
                string[] _data = split.SplitLine(line);
                if((_data[1]==_shopName)&&(DateTime.Parse(_data[4]).Date>=_date))
                {
                    richTextBox1.AppendText(_data[2] + ", " + _data[3] + Environment.NewLine);
                }
            }
        }

        private void RatingButton_Click(object sender, EventArgs e)
        {
            string rating = textBox2.Text;
            Store store = new Store(textBox1.Text);
            double avg = store.Rate(rating);
            textBox3.Text = avg.ToString();
        }
    }
}
