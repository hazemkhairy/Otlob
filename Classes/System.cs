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
                cmd.CommandText = "insert into account values(:id,:email,:name,:number,:password,:address)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", accounts[i].id);
                cmd.Parameters.Add("email", accounts[i].email);
                cmd.Parameters.Add("name", accounts[i].name);
                cmd.Parameters.Add("number", accounts[i].phoneNumber);
                cmd.Parameters.Add("password", accounts[i].password);
                cmd.Parameters.Add("address", accounts[i].address);
                cmd.ExecuteNonQuery();
                for (int j = 0; j < accounts[i].notifications.Count; j++)
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into notification values (:id,:accountid,:restrauntid,:text,:state)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("id", accounts[i].notifications[j].id);
                    cmd2.Parameters.Add("accountid", accounts[i].id);
                    cmd2.Parameters.Add("restrauntid", accounts[i].notifications[j].from.id);
                    cmd2.Parameters.Add("text", accounts[i].notifications[j].text);
                    cmd2.Parameters.Add("state", accounts[i].notifications[j].readed.ToString());
                }
            }
            for (int i = 0; i < resturants.Count; i++)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into restraunt values(:id,:description,:rating,:name,:number,:address,:ImagePath,:category)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", resturants[i].id);
                cmd.Parameters.Add("description", resturants[i].description);
                cmd.Parameters.Add("rating", resturants[i].rating);
                cmd.Parameters.Add("name", resturants[i].name);
                cmd.Parameters.Add("number", resturants[i].phoneNumber);
                cmd.Parameters.Add("address", resturants[i].address);
                cmd.Parameters.Add("ImagePath", resturants[i].imagePath);
                cmd.Parameters.Add("category", resturants[i].categoryType);
                cmd.ExecuteNonQuery();
                for (int j = 0; j < resturants[i].subscibers.Count; j++)
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into restrauntsubscribers values (:accountid,:restrauntid)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("accountid", resturants[i].subscibers[j].id);
                    cmd2.Parameters.Add("restrauntid", resturants[i].id);
                }

                for (int j = 0; j < resturants[i].menu.childern.Count; j++)
                {
                    SectionItem sectionItem = (SectionItem)resturants[i].menu.childern[j];
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "insert into MenuSection values(:id,:name,:restrauntid)";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("id", j);
                    cmd3.Parameters.Add("name", sectionItem.sectionName);
                    cmd3.Parameters.Add("restrauntid", resturants[i].id);
                    cmd3.ExecuteNonQuery();

                    for (int k = 0; k < sectionItem.childern.Count;k++)
                    {
                        

                        Classes.MenuItem menuItem = (Classes.MenuItem)sectionItem.childern[j];
                        OracleCommand cmd4 = new OracleCommand();
                        cmd4.Connection = conn;
                        cmd4.CommandText = "insert into MenuItem values(:id,:price,:imagepath,:description,:name,:rating,:menuSection_id,:restrauntid)";
                        cmd4.CommandType = CommandType.Text;
                        cmd4.Parameters.Add("id", k);
                        cmd4.Parameters.Add("price", menuItem.price);
                        cmd4.Parameters.Add("imagepath", menuItem.imagePath);
                        cmd4.Parameters.Add("description", menuItem.description);
                        cmd4.Parameters.Add("name", menuItem.name);
                        cmd4.Parameters.Add("rating", menuItem.rating);
                        cmd4.Parameters.Add("menuSection_id", j);
                        cmd4.Parameters.Add("restrauntid", resturants[i].id);
                        cmd4.ExecuteNonQuery();
                    }


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
            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "delete from Menu";
            cmd3.CommandType = CommandType.Text;
            cmd3.ExecuteNonQuery();
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
        public bool resturantAddvalidation(Resturant r)
        {
            // check if entered data valid , check if already exists
            return true;
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
            cmd.CommandText = "select * from Account";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
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
            AddSubscribersToRestraunts();
            dr.Close();
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
                item.price = Convert.ToInt32(dr["price"].ToString());
                item.rating = Convert.ToInt32(dr["rating"].ToString());
                SectionItems.Add(item);
            }
            dr.Close();
            section.childern = SectionItems;
        }

    }
}
