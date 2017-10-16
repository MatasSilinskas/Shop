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
    public partial class Top5Window : Form
    {
        string _user;
        public Top5Window(string user)
        {
            InitializeComponent();
            _user = user;
        }

        private void top5Table_Paint(object sender, PaintEventArgs e)
        {
            /* bugs when trying to add items dynamically, so here goes.. */

            TopFive top = new TopFive(_user);
            Items items = top.ObtainData();

            item1.Text = items[0].ToString();
            item2.Text = items[1].ToString();
            item3.Text = items[2].ToString();
            item4.Text = items[3].ToString();
            item5.Text = items[4].ToString();

            shopName1.Text = items[0].CheapestPrice().Key;
            shopName2.Text = items[1].CheapestPrice().Key;
            shopName3.Text = items[2].CheapestPrice().Key;
            shopName4.Text = items[3].CheapestPrice().Key;
            shopName5.Text = items[4].CheapestPrice().Key;

            price1.Text = items[0].CheapestPrice().Value.ToString();
            price2.Text = items[1].CheapestPrice().Value.ToString();
            price3.Text = items[2].CheapestPrice().Value.ToString();
            price4.Text = items[3].CheapestPrice().Value.ToString();
            price5.Text = items[4].CheapestPrice().Value.ToString();

            recommend.Text = "It is recommended that you shop in "
                + items.ShopRecommendation().Key + ". Total price: " 
                + items.ShopRecommendation().Value + items.Warning;
        }
    }
}
