using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class OrderItemAdapter :OrderItem
    {
        public MenuItem menuItem { get; set; }
        public OrderItemAdapter( MenuItem mi)
        {
            menuItem = mi;
            name = mi.name;
            price = mi.price;
            quantity = 1;
            
        }
        public override string GetName()
        {
            return menuItem.name;
        }
        public override void SetName(string value)
        {
            menuItem.name = value;
        }
        public override void Setprice(double value)
        {
            menuItem.price = value ;
        }

        public override double Getprice()
        {
            return menuItem.price;
        }
        public override  int Getquantity()
        {
            return quantity;
        }

        public override  void Setquantity(int value)
        {
            quantity = value;
        }

    }
}
