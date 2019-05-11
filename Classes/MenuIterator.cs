using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class MenuIterator : Iterator
    {

        public List<MenuComponent> childrens { get; set; }
        public int index { get; set; }
        public MenuIterator()
        {
            childrens = new List<MenuComponent>();
            index = 0;
        }
        public MenuIterator(List<MenuComponent> menuComponents)
        {
            childrens = menuComponents;
            index = 0;
        }
        public MenuComponent getCurrentElement()
        {
            return childrens[index];
        }

        public bool gotNext()
        {
            return index < childrens.Count;
        }

        public void moveToNextElement()
        {
            index++;
        }
    }
}
