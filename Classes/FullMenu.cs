using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class FullMenu : MenuComponent
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
        public MenuIterator getIterator()
        {
            return new MenuIterator(childern);
        }
        
        public virtual void addChildern(MenuComponent child)
        {
            if(!childern.Contains(child))
                childern.Add(child);
        }
        public virtual void removeChildern(MenuComponent child)
        {
            if(childern.Contains(child))
                childern.Remove(child);
        }

        public virtual MenuComponent getChildAt(int index)
        {
            return childern[index];
        }

        public virtual List<MenuComponent> getChildrens()
        {
            return childern;
        }
    }
}
