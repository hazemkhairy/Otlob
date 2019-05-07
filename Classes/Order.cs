using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class Order
    {
        protected State state;
        protected List<OrderItem> items;
        protected DateTime initDate;
        protected DateTime deliveredDate;

        public Order() {
            items = new List<OrderItem>();
            initDate = new DateTime();
            deliveredDate = new DateTime();
            state = new PayingState(this);
        }

        public DateTime getInitDate()
        {
            return initDate;
        }
        public void setInitDate(DateTime initDate)
        {
            this.initDate = initDate;
        }
        public DateTime getDeliveredDate()
        {
            return deliveredDate;
        }
        public void setDeliveredDate(DateTime deliveredDate)
        {
            this.deliveredDate = deliveredDate;
        }
        public State getState()
        {
            return state;
        }
        public void setState(State state)
        {
            this.state = state;
        }
        public virtual List<OrderItem> getItems()
        {
            return items;
        }
        public virtual void setItems(List<OrderItem> items)
        {
            this.items = items;
        }
    }
}
