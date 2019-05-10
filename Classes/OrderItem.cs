using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class OrderItem
    {
        protected double price;

        public virtual double Getprice()
        {
            return price;
        }

        public virtual void Setprice(double value)
        {
            price = value;
        }

        protected string name;

        public virtual string GetName()
        {
            return name;
        }

        public virtual void SetName(string value)
        {
            name = value;
        }

        protected int quantity;

        public virtual int Getquantity()
        {
            return quantity;
        }

        public virtual void Setquantity(int value)
        {
            quantity = value;
        }
        
        public void increaseQuantity(int q)
        {
            Setquantity(Getquantity() + q);
        }
        public void decreaseQuantity(int q)
        {
            Setquantity(Getquantity() - q);
        }

    }
}
