using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class MenuItem :MenuComponent
    {
        public double price{ get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int likes { get; set; }
        public string imagePath{ get; set; }
        public MenuItem()
        {
            price = 0;
            description = "";
            name = "";
            likes = 0;
            imagePath = "";
        }

        public void addChildern(MenuComponent child)
        {
            throw new NotImplementedException();
        }

        public void removeChildern(MenuComponent child)
        {
            throw new NotImplementedException();
        }

        public MenuComponent getChildAt(int index)
        {
            throw new NotImplementedException();
        }

        public List<MenuComponent> getChildrens()
        {
            throw new NotImplementedException();
        }
    }
}
