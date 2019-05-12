using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace otlob.Classes
{
    public class System
    {
        public List<Resturant> resturants{ get; set; }
        public List<Account> accounts{ get; set; }
        public SearchMethod searchMethod{ get; set; }
        public AccountFactory accountFactory { get; set; }
        private static System systemInstance;
        OracleConnection conn;
        string ordb = "Data Source=orcl;User Id=HR;Password=HR;";
        System()
        {
            resturants = new List<Resturant>();
            accounts = new List<Account>();
            searchMethod = new SearchByName();
            accountFactory = new AccountFactory();
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        public static System getInstance()
        {
            if (systemInstance == null)
            {
                systemInstance = new System();
            }
            return systemInstance;
        }
        public List<Resturant> searchResturants(string tofind)
        {
            return searchMethod.search(this.resturants, tofind);
        }
        
        

        public bool accountRegistrationValidation(Account newaccount)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].email == newaccount.email || accounts[i].phoneNumber == newaccount.phoneNumber)
                    return false;
            }
            return true;
        }
        public void CommitDataToDataBase()
        {
            ClearTables();
            AddDataToTables();
        }
        public void AddDataToTables()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into account values(:accountid,:accountemail,:accountname,:accountnumber,:accountpass,:accaddress)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("accountid", accounts[i].id);
                cmd.Parameters.Add("accountemail", accounts[i].email);
                cmd.Parameters.Add("accountname", accounts[i].name);
                cmd.Parameters.Add("accountnumber", accounts[i].phoneNumber);
                cmd.Parameters.Add("accountpass", accounts[i].password);
                cmd.Parameters.Add("accaddress", accounts[i].address);

                cmd.ExecuteNonQuery();

                if(accounts[i] is Admin )
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into admin values(:adminId)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("adminId", accounts[i].id);
                    cmd2.ExecuteNonQuery();

                }
                else
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into customer values(:adminId)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("adminId", accounts[i].id);
                    cmd2.ExecuteNonQuery();
                }

            }
            for (int i = 0; i < resturants.Count; i++)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into restraunt values(:res_id,:res_description,:res_rating,:res_name,:res_number,:res_address,:res_ImagePath,:res_category)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("res_id", resturants[i].id);
                cmd.Parameters.Add("res_description", resturants[i].description);
                cmd.Parameters.Add("res_rating", resturants[i].rating);
                cmd.Parameters.Add("res_name", resturants[i].name);
                cmd.Parameters.Add("res_number", resturants[i].phoneNumber);
                cmd.Parameters.Add("res_address", resturants[i].address);
                cmd.Parameters.Add("res_ImagePath", resturants[i].imagePath);
                cmd.Parameters.Add("res_category", resturants[i].categoryType);
                cmd.ExecuteNonQuery();
                for (int j = 0; j < resturants[i].subscibers.Count; j++)
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into restrauntsubscribers values (:sub_accountid,:sub_restrauntid)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("sub_accountid", resturants[i].subscibers[j].id);
                    cmd2.Parameters.Add("sub_restrauntid", resturants[i].id);
                    cmd2.ExecuteNonQuery();
                }

                for (int j = 0; j < resturants[i].menu.childern.Count; j++)
                {
                    SectionItem sectionItem = (SectionItem)resturants[i].menu.childern[j];
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "insert into MenuSection values(:sec_id,:sec_name,:sec_restrauntid)";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("sec_id", j);
                    cmd3.Parameters.Add("sec_name", sectionItem.sectionName);
                    cmd3.Parameters.Add("sec_restrauntid", resturants[i].id);
                    cmd3.ExecuteNonQuery();

                    for (int k = 0; k < sectionItem.childern.Count;k++)
                    {
                        Classes.MenuItem menuItem = (Classes.MenuItem)sectionItem.childern[k];
                        OracleCommand cmd4 = new OracleCommand();
                        cmd4.Connection = conn;
                        cmd4.CommandText = "insert into MenuItem values(:mi_id,:mi_price,:mi_imagepath,:mi_description,:mi_name,:mi_rating,:mi_menuSection_id,:mi_restrauntid)";
                        cmd4.CommandType = CommandType.Text;
                        cmd4.Parameters.Add("mi_id", k);
                        cmd4.Parameters.Add("mi_price", menuItem.price);
                        cmd4.Parameters.Add("mi_imagepath", menuItem.imagePath);
                        cmd4.Parameters.Add("mi_description", menuItem.description);
                        cmd4.Parameters.Add("mi_name", menuItem.name);
                        cmd4.Parameters.Add("mi_rating", menuItem.likes);
                        cmd4.Parameters.Add("mi_menuSection_id", j);
                        cmd4.Parameters.Add("mi_restrauntid", resturants[i].id);
                        cmd4.ExecuteNonQuery();
                    }


                }
            }
            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 0; j < accounts[i].notifications.Count; j++)
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into notification values (:not_id,:not_accountid,:not_restrauntid,:not_text,:not_state)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("not_id", accounts[i].notifications[j].id);
                    cmd2.Parameters.Add("not_text", accounts[i].notifications[j].text);
                    cmd2.Parameters.Add("not_state", accounts[i].notifications[j].readed.ToString());
                    cmd2.Parameters.Add("not_accountid", accounts[i].id);
                    cmd2.Parameters.Add("not_restrauntid", accounts[i].notifications[j].from.id);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
        public void ClearTables()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from RestrauntSubscribers";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "delete from MenuItem";
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "delete from MenuSection";
            cmd2.CommandType = CommandType.Text;
            cmd2.ExecuteNonQuery();
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;
            cmd4.CommandText = "delete from notification";
            cmd4.CommandType = CommandType.Text;
            cmd4.ExecuteNonQuery();
            OracleCommand cmd5 = new OracleCommand();
            cmd5.Connection = conn;
            cmd5.CommandText = "delete from restraunt";
            cmd5.CommandType = CommandType.Text;
            cmd5.ExecuteNonQuery();
            OracleCommand cmd6 = new OracleCommand();
            cmd6.Connection = conn;
            cmd6.CommandText = "delete from Admin";
            cmd6.CommandType = CommandType.Text;
            cmd6.ExecuteNonQuery();
            OracleCommand cmd7 = new OracleCommand();
            cmd6.Connection = conn;
            cmd6.CommandText = "delete from Customer";
            cmd6.CommandType = CommandType.Text;
            cmd6.ExecuteNonQuery();
            OracleCommand cmd8 = new OracleCommand();
            cmd6.Connection = conn;
            cmd6.CommandText = "delete from Account";
            cmd6.CommandType = CommandType.Text;
            cmd6.ExecuteNonQuery();
        }
        public Account loginValidation(string Email , string Password)
        {
            Account LoggedAccount;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (Email == accounts[i].email && Password == accounts[i].password)
                {
                    LoggedAccount = accounts[i];
                    return LoggedAccount;
                }
            }
            return null;
        }
        
        public void addNewUser(string create)
        {
            accounts.Add(accountFactory.getAccount(create));
        }
        public void FetchDataFromDataBase()
        {
            FillRestraunts();
            FillAccounts();
        }
        private void FillAccounts()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ac.email , ac.address , ac.id , ac.name , ac.password , ac.phonenumber from account ac , admin ad where ac.id = ad.id";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Account tempaccount = accountFactory.getAccount("admin");
                tempaccount.email = dr["email"].ToString();
                tempaccount.id = Convert.ToInt32(dr["id"].ToString());
                tempaccount.name = dr["name"].ToString();
                tempaccount.password = dr["password"].ToString();
                tempaccount.address = dr["address"].ToString();
                tempaccount.phoneNumber = dr["phonenumber"].ToString();
                AddNotifications(tempaccount);
                accounts.Add(tempaccount);
            }
            dr.Close();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ac.email , ac.address , ac.id , ac.name , ac.password , ac.phonenumber from account ac , customer cu where ac.id = cu.id";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Account tempaccount = accountFactory.getAccount("customer");
                tempaccount.email = dr["email"].ToString();
                tempaccount.id = Convert.ToInt32(dr["id"].ToString());
                tempaccount.name = dr["name"].ToString();
                tempaccount.password = dr["password"].ToString();
                tempaccount.address = dr["address"].ToString();
                tempaccount.phoneNumber = dr["phonenumber"].ToString();
                AddNotifications(tempaccount);
                accounts.Add(tempaccount);
            }
            dr.Close();
            AddSubscribersToRestraunts();
        }
        private void AddSubscribersToRestraunts()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from RestrauntSubscribers";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            Dictionary<int, List<Account>> dic = new Dictionary<int, List<Account>>();
            List<Tuple<int, int>> UserRes = new List<Tuple<int, int>>();
            while (dr.Read())
            {
                Tuple<int, int> temp = new Tuple<int, int>(Convert.ToInt32(dr["Account_ID"].ToString()), Convert.ToInt32(dr["Restraunt_ID"].ToString()));
                for (int i = 0; i < accounts.Count; i++)
                {
                    if(temp.Item1==accounts[i].id)
                    {
                        if(dic.ContainsKey(temp.Item2)==false)
                        {
                            dic[temp.Item2] = new List<Account>();
                        }
                        dic[temp.Item2].Add(accounts[i]);
                        break;
                    }
                }
            }
            dr.Close();
            foreach (var item in dic)
            {
                for (int i = 0; i < resturants.Count;i++)
                {
                    if(resturants[i].id==item.Key)
                    {
                        resturants[i].subscibers = item.Value;
                        break;
                    }
                }
            }
            /*for (int i = 0; i < UserRes.Count; i++)
            {
                for (int j = 0; j < resturants.Count; j++)
                {
                    if (UserRes[i].Item2 == resturants[j].id)
                    {
                        for (int k = 0; k < accounts.Count; k++)
                        {
                            if (accounts[k].id == UserRes[i].Item1)
                            {
                                resturants[j].subscibers.Add(accounts[k]);
                            }
                        }
                    }
                }
            }
            */
        }
        private void AddNotifications(Account tempaccount)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from notification where Account_ID = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", tempaccount.id);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Notification tempnotification = new Notification();
                tempnotification.id = Convert.ToInt32(dr["id"]);
                tempnotification.text = dr["text"].ToString();
                int res_id = Convert.ToInt32(dr["Restraunt_ID"].ToString());
                tempnotification.from = getRestraunt(res_id);
                tempnotification.readed = Convert.ToBoolean(dr["state"].ToString());
                tempaccount.notifications.Add(tempnotification);
            }
            dr.Close();
        }
        private otlob.Classes.Resturant getRestraunt(int id)
        {
            for (int i = 0; i < resturants.Count; i++)
            {
                if (resturants[i].id == id)
                    return resturants[i];
            }
            return null;
        }
        private void FillRestraunts()
        {
            OracleCommand getRestraunts = new OracleCommand();
            getRestraunts.Connection = conn;
            getRestraunts.CommandText = "select * from Restraunt";
            getRestraunts.CommandType = CommandType.Text;
            OracleDataReader dr = getRestraunts.ExecuteReader();
            while (dr.Read())
            {
                otlob.Classes.Resturant temp = new Resturant();
                temp.name = dr["name"].ToString();
                temp.phoneNumber = dr["phonenumber"].ToString();
                temp.address = dr["address"].ToString();
                temp.description = dr["Description"].ToString();
                temp.categoryType = dr["CategoryType"].ToString();
                temp.id = Convert.ToInt32(dr["id"].ToString());
                temp.imagePath = dr["imagepath"].ToString();
                temp.rating = Convert.ToInt32(dr["rating"].ToString());
                AddMenuToRestraunt(temp);
                resturants.Add(temp);
            }
            dr.Close();
        }
        private void AddMenuToRestraunt(otlob.Classes.Resturant temp)
        {
            temp.menu = new FullMenu();

            List <MenuComponent> Sections = new List<MenuComponent>();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select Name,ID from MenuSection where Restraunt_ID = :res";
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("res", temp.id);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                otlob.Classes.SectionItem section = new otlob.Classes.SectionItem();
                section.sectionName = dr1["name"].ToString();
                AddSectionItems(section, Convert.ToInt32(dr1["ID"].ToString()),temp.id);
                Sections.Add(section);
            }
            dr1.Close();
            temp.menu.childern = Sections;
        }
        private void AddSectionItems(otlob.Classes.SectionItem section, int sectionid,int resid)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from MenuItem where MenuSection_id = :sectionid and Restraunt_ID = :resid";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("sectionid", sectionid);
            cmd.Parameters.Add("resid", resid);
            OracleDataReader dr = cmd.ExecuteReader();
            List<MenuComponent> SectionItems = new List<MenuComponent>();
            while (dr.Read())
            {
                otlob.Classes.MenuItem item = new otlob.Classes.MenuItem();
                item.description = dr["Description"].ToString();
                item.imagePath = dr["imagepath"].ToString();
                item.name = dr["name"].ToString();
                item.price = Convert.ToDouble(dr["price"].ToString());
                item.likes  = Convert.ToInt32(dr["rating"].ToString());
                SectionItems.Add(item);
            }
            dr.Close();
            section.childern = SectionItems;
        }
        public int generatenotificationid(Account account)
        {
            int id = 0;
            for (int i = 0; i < account.notifications.Count; i++)
                id = Math.Max(account.notifications[i].id, id);
            
            return (id+1);
        }
    }
}
