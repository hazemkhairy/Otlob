using System;
using System.Collections.Generic;
using System.Data;
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
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        Classes.System OtlobSystem;
        public Register()
        {
            InitializeComponent();
            OtlobSystem = Classes.System.getInstance();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Account newaccount = OtlobSystem.accountFactory.getAccount("customer");
            newaccount.address = AddressTextBox.Text;
            newaccount.email = EmailTextBox.Text;
            newaccount.password = PasswordTextBox.Password;
            newaccount.name = NameTextBox.Text;
            newaccount.phoneNumber = PhoneNumberTextBox.Text;
            int id = 0;
            for (int i = 0; i < OtlobSystem.accounts.Count; i++)
            {
                id = Math.Max(id, OtlobSystem.accounts[i].id);
            }
            id += 1;
            newaccount.id = id;
            if (OtlobSystem.accountRegistrationValidation(newaccount))
            {
                OtlobSystem.accounts.Add(newaccount);
                MessageBox.Show("Added Account :)");
                var Login = new otlob.Windows.Login();
                this.Hide();
                Login.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("this info is already used");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new otlob.Windows.Login();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }
    }
}
