using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using Logic;


namespace Shop
{
    public partial class StoreFromListWindow : Form
    {
        string _user;
        List<string> _shoppingList = new List<string>();
        Map _map;
        public StoreFromListWindow(string user)
        {
            InitializeComponent();
            _user = user;
        }

        private void AddToList_Click(object sender, EventArgs e)
        {
            ProductsTextBox.AppendText(addList.Text + Environment.NewLine);
            _shoppingList.Add(addList.Text);
            addList.Clear();
        }

        private void ChooseStore_Click(object sender, EventArgs e)
        {
            if(ProductsTextBox.Lines.Count() == 0)
            {
                MessageBox.Show("Please add items to your shopping list or let us choose a store for you based on your top 5", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MoreOptionsWindow more = new MoreOptionsWindow(_user);
                StoreList store = new Logic.StoreList(_shoppingList, more._date);
                storeName.Text = store.ReturnStoreName();
                _map.UpdateMapWithShopSuggestion(storeName.Text);
            }
        }

        private void EstimatePrice_Click(object sender, EventArgs e)
        {
            MoreOptionsWindow more = new MoreOptionsWindow(_user);
            StoreList store = new StoreList(_shoppingList, more._date);
            totalPrice.Text = store.ReturnPrice().ToString();
        }

        private void StoreFromListWindow_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("100");
            comboBox1.Items.Add("500");
            comboBox1.Items.Add("1000");
            comboBox1.Items.Add("2000");
            comboBox1.Items.Add("3000");
            comboBox1.Items.Add("5000");
            comboBox1.Items.Add("10000");
            comboBox1.Items.Add("50000");
            comboBox1.SelectedIndex = 3;
            toolStripStatusLabel1.Text = "Loading Map...";
            _map = new Map(gmap, toolStripProgressBar1, toolStripStatusLabel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _map.UpdateMapWithShopSuggestion(storeName.Text, Int32.Parse(comboBox1.GetItemText(comboBox1.SelectedItem)));
        }
    }
}
