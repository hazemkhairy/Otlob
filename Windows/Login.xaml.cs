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
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static Account LogedAccount;
        public Login()
        {
            InitializeComponent();
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
                //go to search menu
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
    }
}
