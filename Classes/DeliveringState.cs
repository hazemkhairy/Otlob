using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class DeliveringState :State
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
