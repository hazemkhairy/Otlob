using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public class Cart
    {
        public List<OrderItem> items{ get; set; }
        
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
            if(items.Contains(oi))
            {
                items[items.IndexOf(oi)].Setquantity(items[items.IndexOf(oi)].Getquantity() + oi.Getquantity() );
            }
            else
                items.Add(oi);
        }
        public void removeItem(OrderItem oi)
        {
            if (items.Contains(oi))
            {
                items.Remove(oi);
            }
        }
    }
}
