using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public interface MenuComponent
    {
        void addChildern(MenuComponent child);
        void removeChildern(MenuComponent child);
        MenuComponent getChildAt(int index);
        List<MenuComponent> getChildrens();
    }
}
