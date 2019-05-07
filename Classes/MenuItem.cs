using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class MenuItem :MenuComponent
    {
        public double price{ get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public string imagePath{ get; set; }
        public MenuItem()
        {
            price = 0;
            description = "";
            name = "";
            rating = 0;
            imagePath = "";
        }
    }
}
