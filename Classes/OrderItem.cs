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

        public int Getquantity()
        {
            return quantity;
        }

        public void Setquantity(int value)
        {
            quantity = value;
        }
        protected Resturant resturant;
        public Resturant getResturant()
        {
            return resturant;
        }

        public void setResturant(Resturant value)
        {
            resturant = value;
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
