using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public class PayingState : State
    {
        public PayingState(Order order) : base(order)
        {
            this.order = order;
            this.order.setInitDate(DateTime.Now);
        }
        public override void nextState()
        {
            order.setState(new DeliveringState(this.order));
        }
    }
}
