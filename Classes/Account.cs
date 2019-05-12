using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public abstract class Account : Subscriber
    {
        
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public int id { get; set; }
        public Cart cart{ get; set; }
        public Order order { get; set; }

        public Account()
        {
            address = "";
            password = "";
            name = "";
            email = "";
            id = -1;
            cart = new Cart();
            order = new Order();
            phoneNumber = "";
        }
        public void updateInfo(Account account)
        {
            this.address = account.address;
            this.cart = account.cart;
            this.email = account.email;
            this.id = account.id;
            this.name = account.name;
            this.notifications = account.notifications;
            this.order = account.order;
            this.password = account.password;
            this.phoneNumber = account.phoneNumber;

        }
        public void placeOrder()
        {
            OrderAdapter adapter = new OrderAdapter();
            adapter.setCart(cart);
            order=adapter;
            
        }
    }
}
