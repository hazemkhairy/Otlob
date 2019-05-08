using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public interface SearchMethod
    {
         List<Resturant> search(List<Resturant> resturants, string tofind);
    }
}
