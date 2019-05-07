using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otlob_WPF_Project.Classes
{
    class System
    {
        public List<Resturant> resturants{ get; set; }
        public List<Account> accounts{ get; set; }
        public SearchMethod searchMethod{ get; set; }

        public AccountFactory accountFactory { get; set; }
        private static System systemInstance;

        System()
        {
            resturants = new List<Resturant>();
            accounts = new List<Account>();
            searchMethod = new SearchByName();
            accountFactory = new AccountFactory();
            
        }
        public List<Resturant> searchResturants(string tofind)
        {
            return searchMethod.search(this.resturants, tofind);
        }
        
        public static System getInstance()
        {
            if (systemInstance == null)
            {
                systemInstance = new System();
            }
            return systemInstance;
        }

        public bool accountRegistrationValidation(Account a)
        {
            //validate info
            //validate not exits
            return true;
        }
        public bool loginValidation(Account a)
        {
            //check if account exist in accounts array


            return false;
        }
        public bool resturantAddvalidation(Resturant r)
        {
            // check if entered data valid , check if already exists
            return true;
        }
        public void addNewUser(string create)
        {
            accounts.Add(accountFactory.getAccount(create));
        }


    }
}
