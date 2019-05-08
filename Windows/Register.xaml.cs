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
using Otlob_WPF_Project.Classes;
namespace Otlob_WPF_Project.Windows
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
            OtlobSystem.addNewUser("CUSTOMER");
            int index = OtlobSystem.accounts.Count - 1;
            OtlobSystem.accounts[index].email = EmailTextBox.Text;
            OtlobSystem.accounts[index].name = NameTextBox.Text;
            OtlobSystem.accounts[index].password = PasswordTextBox.Password;
            OtlobSystem.accounts[index].phoneNumber = PhoneNumberTextBox.Text;
            int id = 0;
            for (int i = 0; i < OtlobSystem.accounts.Count; i++)
            {
                id = Math.Max(id, OtlobSystem.accounts[i].id);
            }
            id += 1;
            OtlobSystem.accounts[index].id = id;
            MessageBox.Show("Added Account :)");
        }
    }
}
