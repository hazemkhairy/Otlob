using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class Cart
    {
        public List<OrderItem> items{ get; set; }

        protected Resturant resturant;

        public Resturant getResturant()
        {
            return resturant;
        }

        public void setResturant(Resturant value)
        {
            resturant = value;
        }
        public Cart()
        {
            items = new List<OrderItem>();
        }
        public Cart(List<OrderItem> item)
        {
            items = item;
        }
        public void addItem(OrderItem  oi)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetName() == oi.GetName())
                {
                    items[i].Setquantity(items[i].Getquantity() + oi.Getquantity());
                    return;
                }
            }
            
                items.Add(oi);
        }
        public void removeOneFromItemFromCart(OrderItem oi)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetName() == oi.GetName())
                {
                    items[i].Setquantity(items[i].Getquantity() - 1);
                    if(items[i].Getquantity() == 0)
                        items.RemoveAt(i);
                    return;
                }
            }
        }
        public void removeItemFromCart(OrderItem oi)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].GetName() == oi.GetName())
                {
                    items.RemoveAt(i);
                    return;
                }
            }
            
        }
    }
}
