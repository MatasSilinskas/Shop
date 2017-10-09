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
        List<string> _shoppingList = new List<string>();
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
                StoreList store = new Logic.StoreList(_shoppingList);
                storeName.Text = store.ReturnStoreName();

            }
        }

        private void EstimatePrice_Click(object sender, EventArgs e)
        {
            StoreList store = new StoreList(_shoppingList);
            totalPrice.Text = store.ReturnPrice().ToString();
        }
    }
}
