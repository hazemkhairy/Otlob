using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public abstract class Account : Subscriber
    {

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public int id { get; set; }
        public Cart cart{ get; set; }
        public Order order { get; set; }

        public Account()
        {
            username = "";
            password = "";
            name = "";
            email = "";
            id = -1;
            cart = new Cart();
            order = new Order();
            phoneNumber = "";
        }
        public Account(string user , string pass , string n , string e , int i , string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            username = user;
            password = pass;
            name = n;
            email = e;
            id = i;
            cart = new Cart();
            order = new Order();
        }

        public void updateInfo(Account a)
        {
            username = a.username;
            password = a.password;
            name = a.name;
            email = a.email;
            id = a.id;
            cart = a.cart;
            order = a.order;
        }

        public void addToCart(OrderItem oi)
        {
            cart.addItem(oi);
        }
        public void removeFromCart(OrderItem oi)
        {
            cart.removeItem(oi);
        }
        public void placeOrder()
        {
            OrderAdapter adapter = new OrderAdapter();
            adapter.setCart(cart);
            order=adapter;
        }
    }
}
