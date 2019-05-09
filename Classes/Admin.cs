using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otlob.Classes
{
    public class Admin :Account
    {
        public Admin()
        {
            
        }
        public Admin(string user, string pass, string n, string e, int i,string phoneNumber) : base(user, pass, n, e ,i , phoneNumber)
        {

        }
        
    }
}
