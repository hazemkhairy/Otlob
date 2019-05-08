using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public class AccountFactory
    {
        public AccountFactory()
        {

        }
        public Account getAccount(string type )
        {
            Account ret = null;
            if (type.ToLower() == "customer")
            {
                ret = new Customer();
            }
            else if (type.ToLower() =="admin")
            {
                ret = new Admin();
            }
            return ret;
        }
    }
}
