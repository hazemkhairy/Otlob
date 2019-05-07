using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class OrderItemAdapter :OrderItem
    {
        public MenuItem menuItem { get; set; }
        OrderItemAdapter( MenuItem mi)
        {
            menuItem = mi;
            
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
        
    }
}
