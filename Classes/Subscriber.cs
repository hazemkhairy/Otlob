using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    abstract class Subscriber
    {
        
        public List<Notification> notifications { get;  }
        public Subscriber()
        {
            notifications = new List<Notification>();
            
        }
        public void addNotification(Notification n)
        {
            notifications.Add(n);
        }
        public void deleteAllNotifications()
        {
            notifications.Clear();
        }
        
    }
}
