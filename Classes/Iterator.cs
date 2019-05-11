using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    interface Iterator
    {
        void moveToNextElement();
        bool gotNext();
        MenuComponent getCurrentElement();
    }
}
