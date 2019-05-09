using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class SectionItem : FullMenu
    {
        public string sectionName { get; set; }
        public SectionItem()
        {
            sectionName = "";
        }
        public SectionItem(string n)
        {
            sectionName = n;
            
        }
    }
}
