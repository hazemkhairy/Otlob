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
        public Notification(string text , Resturant from , bool readed, int id )
        {
            this.text = text;
            this.from = from;
            this.readed = readed;
            this.id = id;
            
        }
    }
}
