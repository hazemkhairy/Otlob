using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class Notification
    {
        public string text { get; set; }
        public Resturant from { get; set; }
        public bool readed { get; set; }
        public int id { get; set; }
        
        public Notification()
        {
            text = "";
            from = new Resturant();
            readed = false;
            id = -1;
        }
        public Notification(string t , Resturant f , bool readee, int i )
        {
            text = t;
            from = f;
            readed = readee;
            id = i;
            
        }
    }
}
