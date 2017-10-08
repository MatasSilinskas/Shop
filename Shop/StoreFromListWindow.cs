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
    public partial class StoreFromListWindow : Form
    {
        string _user;
        List<string> shoppingList = new List<string>();
        public StoreFromListWindow(string username)
        {
            InitializeComponent();
            _user = username;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(textBox1.Text + Environment.NewLine);
            shoppingList.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Lines.Count() == 0)
            {
                MessageBox.Show("Please add items to your shopping list or let us choose a store for you based on your top 5", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StoreList store = new Logic.StoreList(shoppingList);
                textBox2.Text = store.ReturnStoreName();

            }
        }

        private void StoreFromListWindow_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreList store = new StoreList(shoppingList);
            textBox3.Text = store.ReturnPrice().ToString();
        }
    }
}
