using Otlob_WPF_Project.Classes;
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
        public static Account LogedAccount;
        Otlob_WPF_Project.Classes.System system;
        public Login()
        {
            InitializeComponent();
            system = Otlob_WPF_Project.Classes.System.getInstance();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogedAccount = system.loginValidation(EmailTextBox.Text, PasswordTextBox.Password);
            if (LogedAccount != null)
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
            var window = new Otlob_WPF_Project.Windows.Register();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }
    }
}
