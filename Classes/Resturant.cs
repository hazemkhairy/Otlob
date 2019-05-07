using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class Resturant
    {
        public int id { get; set; }
        public string name { get; set; }
        public MenuComponent menu{ get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public string phoneNumber{ get; set; }
        public string address { get; set; }
        public string categoryType{ get; set; }
        public string imagePath { get; set; }
        public List<Account> subscibers { get; set; }
        public Resturant()
        {
            id = 0;
            name = "";
            menu = new FullMenu();
            description = "";
            rating = 5;
            phoneNumber = "";
            address = "";
            categoryType = "";
            imagePath = "";
            subscibers = new List<Account>();
        }
        public void updateInfo(Resturant r)
        {
            id = r.id;
            name = r.name;
            menu = r.menu;
            description = r.description;
            rating = r.rating;
            phoneNumber = r.phoneNumber;
            address = r.address;
            categoryType = r.categoryType;
            imagePath = r.imagePath;
            subscibers = r.subscibers;

        }
        public void addSubscriber(Account a)
        {
            if(!subscibers.Contains(a))
                subscibers.Add(a);
        }
        public void removeSubscriber(Account a)
        {
            if (subscibers.Contains(a))
                subscibers.Remove(a);
        }
        public void notifySubscribers(Notification n)
        {
            for(int i = 0; i < subscibers.Count; i++)
            {
                subscibers[i].addNotification(n);
            }
        }
    }
}
