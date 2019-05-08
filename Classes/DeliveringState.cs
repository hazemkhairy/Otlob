using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class DeliveringState :State
    {
        public DeliveringState(Order order) : base(order)
        {
            this.order = order;
        }
        public override void nextState()
        {
            order.setState(new DeliverdState(this.order));
        }
    }
}
