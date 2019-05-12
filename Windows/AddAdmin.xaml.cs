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
using otlob.Classes;
using otlob.Windows;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        Classes.System system;

        public AddAdmin()
        {
            InitializeComponent();
            system = Classes.System.getInstance();
            fillComboBox();
        }
        public void fillComboBox()
        {
            foreach (Account account in system.accounts)
            {
                if( !(account is Admin))
                {
                    CustomersComboBox.Items.Add(account.id.ToString() + ' '+account.name);
                }
            }
        }

        private void AddAdminBTN_Click(object sender, RoutedEventArgs e)
        {
            if(CustomersComboBox.SelectedIndex!=-1)
            {
                Account selectedAccount = system.accountFactory.getAccount("customer");
                int selectedId =int.Parse( CustomersComboBox.SelectedItem.ToString().Split(' ')[0] );
                foreach (Account account in system.accounts)
                {
                    if (account.id == selectedId)
                    {
                        selectedAccount = account;
                        system.accounts.Remove(account);
                        break;
                    }
                }
                Admin newAdmin = (Admin)system.accountFactory.getAccount("admin");

                newAdmin.updateInfo(selectedAccount);
                system.accounts.Add(newAdmin);
                MessageBox.Show("Admin " + newAdmin.name +" added Succesfully");
            }
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            MainMenu window = new MainMenu();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void LogOutBTN_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
