using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class OrderAdapter :Order
    {
        private Cart cart;
        public OrderAdapter():base()
        {
            
            cart = new Cart();
        }
        public OrderAdapter(Cart cart)
        {
            this.cart = cart;
        }
        public void setCart(Cart cart)
        {
            this.cart = cart;
        }
        public override List<OrderItem> getItems()
        {
            return cart.items;
        }
        public override void setItems(List<OrderItem> items)
        {
            cart.items=items;
        }

    }
}
