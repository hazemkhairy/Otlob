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
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        otlob.Classes.System system;
        public EditAccount()
        {
            InitializeComponent();
            system = otlob.Classes.System.getInstance();
            AddressTextBox.Text = Login.LogedAccount.address;
            PhoneNumberTextBox.Text = Login.LogedAccount.phoneNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AddressTextBox.Text != "" && PhoneNumberTextBox.Text != ""  && OldPasswordTextBox.Password==Login.LogedAccount.password)
            {
                Login.LogedAccount.address = AddressTextBox.Text;
                Login.LogedAccount.phoneNumber = PhoneNumberTextBox.Text;
                if(NewPasswordTextBox.Password!=""&&NewPasswordTextBox.Password==ConfirmPasswordTextBox.Password)
                    Login.LogedAccount.password= NewPasswordTextBox.Password;

                 MessageBox.Show("Edited Successfully");
            }
            else
            {
                MessageBox.Show("Please Enter Data To Edit");
            }
        }
    }
}
