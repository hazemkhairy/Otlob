using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public abstract class State
    {
        protected Order order;
        public State()
        {
            order = new Order();
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
