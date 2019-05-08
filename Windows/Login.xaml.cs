using otlob.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        OracleConnection conn;
        string ordb = "Data Source=orcl;User Id=HR;Password=HR;";
        public static Account LogedAccount;
        Otlob_WPF_Project.Classes.System system;
        public Login()
        {
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
            system = Otlob_WPF_Project.Classes.System.getInstance();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            otlob.Classes.System system = otlob.Classes.System.getInstance();
            bool found = false;
            for (int i = 0; i < system.accounts.Count; i++)
            {
                if (EmailTextBox.Text == system.accounts[i].email && PasswordTextBox.Password == system.accounts[i].password)
                {
                    LogedAccount = system.accounts[i];
                    found = true;
                    break;
                }
            }
            if (found)
            {
                var profile = new otlob.Windows.Profile();
                this.Hide();
                profile.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Info");
            }

        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var window = new otlob.Windows.Register();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FetchDataIntoSystem();
        }
        private void FetchDataIntoSystem()
        {
            FillRestraunts();
            FillAccounts();

        }
        private void FillAccounts()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Account";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Account tempaccount = system.accountFactory.getAccount("customer");
                tempaccount.email = dr["email"].ToString();
                tempaccount.id =Convert.ToInt32(dr["id"].ToString());
                tempaccount.name = dr["name"].ToString();
                tempaccount.password = dr["password"].ToString();
                tempaccount.address = dr["address"].ToString();
                tempaccount.phoneNumber = dr["phonenumber"].ToString();
                AddNotifications(tempaccount);
                system.accounts.Add(tempaccount);
            }
            AddSubscribersToRestraunts();
            dr.Close();
        }
        private void AddSubscribersToRestraunts()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from RestrauntSubscribers";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            List<Tuple<int, int>> UserRes = new List<Tuple<int, int>>();
            while (dr.Read())
            {
                Tuple<int, int> temp = new Tuple<int, int>(Convert.ToInt32(dr["Account_ID"].ToString()),Convert.ToInt32(dr["Restraunt_ID"].ToString()));
                UserRes.Add(temp);
            }
            dr.Close();
            for (int i = 0; i < UserRes.Count; i++)
            {
                for (int j = 0; j < system.resturants.Count; j++)
                {
                    if (UserRes[i].Item2 == system.resturants[j].id)
                    {
                        for (int k = 0; k < system.accounts.Count; k++)
                        {
                            if (system.accounts[k].id == UserRes[i].Item1)
                            {
                                system.resturants[j].subscibers.Add(system.accounts[k]);
                            }
                        }
                    }
                }
            }
        }
        private void AddNotifications(Account tempaccount)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from notification where Account_ID = :id";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("id", tempaccount.id);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Notification tempnotification = new Notification();
                tempnotification.id = Convert.ToInt32(dr["id"]);
                tempnotification.text = dr["text"].ToString();
                int res_id =Convert.ToInt32(dr["Restraunt_ID"].ToString());
                tempnotification.from = getRestraunt(res_id);
                tempaccount.notifications.Add(tempnotification);
            }
            dr.Close();
        }
        private Otlob_WPF_Project.Classes.Resturant getRestraunt(int id)
        {
            for (int i = 0; i < system.resturants.Count; i++)
            {
                if (system.resturants[i].id == id)
                    return system.resturants[i];
            }
            return null; 
        }
        private void FillRestraunts()
        {
            OracleCommand getRestraunts = new OracleCommand();
            getRestraunts.Connection = conn;
            getRestraunts.CommandText = "select * from Restraunt";
            getRestraunts.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = getRestraunts.ExecuteReader();
            while (dr.Read())
            {
                Otlob_WPF_Project.Classes.Resturant temp = new Resturant();
                temp.address = dr["address"].ToString();
                temp.description = dr["Description"].ToString();
                temp.categoryType = dr["CategoryType"].ToString();
                temp.id =Convert.ToInt32(dr["id"].ToString());
                temp.imagePath = dr["imagepath"].ToString();
                temp.rating =Convert.ToInt32(dr["rating"].ToString());
                AddMenuToRestraunt(temp);
                system.resturants.Add(temp);
            }
            dr.Close();
        }
        private void AddMenuToRestraunt(Otlob_WPF_Project.Classes.Resturant temp)
        {
            FullMenu tempmenu = new FullMenu();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ID from Menu where Restraunt_ID = :id";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("id", temp.id);
            OracleDataReader dr = cmd.ExecuteReader();
            int MenuID=-1;
            if (dr.Read())
            MenuID = Convert.ToInt32(dr[0].ToString());
            dr.Close();
            List<MenuComponent> Sections = new List<MenuComponent>();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select Name,ID from MenuSection where Restraunt_ID = :res and Menu_ID = :men ";
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.Parameters.Add("res", temp.id);
            cmd1.Parameters.Add("men", MenuID);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                Otlob_WPF_Project.Classes.SectionItem section = new Otlob_WPF_Project.Classes.SectionItem();
                section.sectionName = dr1["name"].ToString();
                AddSectionItems(section,Convert.ToInt32(dr1["ID"].ToString()),MenuID,temp.id);
                Sections.Add(section);
            }
            dr1.Close();
            tempmenu.childern = Sections;
            temp.menu = tempmenu;
        }
        private void AddSectionItems(Otlob_WPF_Project.Classes.SectionItem section, int sectionid, int menuid, int resid)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Menutem where MenuSection_id = :sectionid and Menu_ID = :menuid and Restraunt_ID = :resid";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("sectionid", sectionid);
            cmd.Parameters.Add("menuid", menuid);
            cmd.Parameters.Add("resid", resid);
            OracleDataReader dr = cmd.ExecuteReader();
            List<MenuComponent> SectionItems = new List<MenuComponent>();
            while (dr.Read())
            {
                Otlob_WPF_Project.Classes.MenuItem item = new Otlob_WPF_Project.Classes.MenuItem();
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
