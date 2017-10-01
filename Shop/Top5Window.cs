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
        public Top5Window(string username)
        {
            InitializeComponent();

            _user = username;

        }

        private void top5Table_Paint(object sender, PaintEventArgs e)
        {
            /* bugs when trying to add items dynamically, so here goes.. */

            TopFive top = new TopFive(_user);
            var items = top.ObtainData();

            item1.Text = items[0].ToString();
            item2.Text = items[1].ToString();
            item3.Text = items[2].ToString();
            item4.Text = items[3].ToString();
            item5.Text = items[4].ToString();

            shopName1.Text = (items[0] as Item).CheapestPrice().Key;
            shopName2.Text = (items[1] as Item).CheapestPrice().Key;
            shopName3.Text = (items[2] as Item).CheapestPrice().Key;
            shopName4.Text = (items[3] as Item).CheapestPrice().Key;
            shopName5.Text = (items[4] as Item).CheapestPrice().Key;

            price1.Text = (items[0] as Item).CheapestPrice().Value.ToString();
            price2.Text = (items[1] as Item).CheapestPrice().Value.ToString();
            price3.Text = (items[2] as Item).CheapestPrice().Value.ToString();
            price4.Text = (items[3] as Item).CheapestPrice().Value.ToString();
            price5.Text = (items[4] as Item).CheapestPrice().Value.ToString();

            recommend.Text = top.ShopRecommendation();


        }
    }
}
