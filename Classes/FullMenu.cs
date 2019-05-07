using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class FullMenu : MenuComponent
    {
        public List<MenuComponent> childern{ get; set; }
        
        public FullMenu()
        {
            childern = new List<MenuComponent>();
        }
        public FullMenu(List<MenuComponent> sections)
        {
            childern = sections;
        }
        public void addChildern(MenuComponent child)
        {
            if(!childern.Contains(child))
                childern.Add(child);
        }
        public void removeChildern(MenuComponent child)
        {
            if(childern.Contains(child))
                childern.Remove(child);
        }
    }
}
