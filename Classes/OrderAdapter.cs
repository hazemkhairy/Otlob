using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class OrderAdapter :Order
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
        public override double getTotalPrice()
        {
            double ret = 0;
            for (int i = 0; i < cart.items.Count; i++)
            {
                ret += ( cart.items[i].Getquantity()* cart.items[i].Getprice());
            }
            return ret;
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
