using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    class RestaurantPerparingMealState : State
    {
        public RestaurantPerparingMealState(Order order) : base(order)
        {
            this.order = order;
            
            StateName = "Restaurant Preparing Meal";
        }
        public override void nextState()
        {
            order.setState(new WaitingDeliveryBoyState(this.order));
        }
    }
}
