﻿using System;
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

            StateName = "Delivering Order to Client";
        }
        public override void nextState()
        {
            order.setState(new DeliveredOrderState(this.order));
        }
    }
}
