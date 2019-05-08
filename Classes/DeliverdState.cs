using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class DeliverdState :State
    {
        public DeliverdState(Order order) : base(order)
        {
            this.order = order;
        }
        public override void nextState()
        {
            this.order.setDeliveredDate(DateTime.Now);
        }
    }
}
