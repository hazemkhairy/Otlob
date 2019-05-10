using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    class WaitingDeliveryBoyState : State
    {
        public WaitingDeliveryBoyState(Order order) : base(order)
        {
            this.order = order;
            this.order.setInitDate(DateTime.Now);

            StateName = "Waiting Delivering Boy";
        }
        public override void nextState()
        {
            order.setState(new DeliveringState(this.order));
        }
    }
}
