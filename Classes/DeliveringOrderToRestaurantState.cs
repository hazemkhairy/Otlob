using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    class DeliveringOrderToRestaurantState : State
    {
        public DeliveringOrderToRestaurantState(Order order) : base(order)
        {
            this.order = order;
            this.order.setInitDate(DateTime.Now);

            StateName = "Delivering Order to Restaurant";
        }
        public override void nextState()
        {
            order.setState(new RestaurantPerparingMealState(this.order));
        }
    }
}
