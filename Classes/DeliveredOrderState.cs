using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    class DeliveredOrderState : State
    {
        public DeliveredOrderState(Order order) : base(order)
        {
            this.order = order;
            this.order.setDeliveredDate(DateTime.Now);

            StateName = "Order Delivered";
        }
        public override void nextState()
        {
            
        }
    }
}
