using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public abstract class State
    {
        protected Order order;
        public String StateName { get; set; }
        
        public State()
        {
            order = new Order();
            StateName = "";
        }
        public State(Order order)
        {
            this.order = order;
        }
        public Order getOrder()
        {
            return order;
        }
        public void setOrder(Order order)
        {
            this.order = order;
        }
        public abstract void nextState();
    }
}
