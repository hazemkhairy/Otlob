using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public class SearchByName : SearchMethod
    {
        public List<Resturant> search(List<Resturant> resturants, string tofind)
        {
            List<Resturant> ret = new List<Resturant>();
            foreach (Resturant resturant in resturants)
            {
                if (resturant.name.ToLower().Contains(tofind.ToLower()))
                {
                    ret.Add(resturant);
                }
            }
            return ret;
        }
    }
}
