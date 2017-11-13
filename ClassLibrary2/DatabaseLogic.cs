using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Shop 
{
    public class DatabaseLogic
    {
        public void AddUser(string userName, string password, string email, string gender)
        {
            using (ShoppingDataEntities context = new ShoppingDataEntities())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    Gender = gender
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

        }
        public void AddItem(string userName, string shopName, string itemName, string price, string date)
        {
            using (ShoppingDataEntities context = new ShoppingDataEntities())
            {
                User user = context.Users.FirstOrDefault(r => r.UserName == userName);
                Purchase items = new Purchase()
                {
                    UserId = user.Id,
                    ShopName = shopName,
                    ItemName = itemName,
                    Price = float.Parse(price),
                    Date = DateTime.Parse(date)
                };
                context.Purchases.Add(items);
                context.SaveChanges();
            }
        }


    }
}
