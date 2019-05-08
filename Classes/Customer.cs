using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    public class Customer :Account
    {
        public Customer()
        {

        }
        public Customer(string user, string pass, string n, string e, int i , string phoneNumber) : base(user, pass, n, e, i , phoneNumber)
        {

        }
    }
}
