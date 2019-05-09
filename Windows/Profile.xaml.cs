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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameDisplay.Content = otlob.Windows.Login.LogedAccount.name;
            EmailDisplay.Content = otlob.Windows.Login.LogedAccount.email;
            PhoneNumberDisplay.Content = otlob.Windows.Login.LogedAccount.phoneNumber;
            AddressDisplay.Content = otlob.Windows.Login.LogedAccount.address;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new otlob.Windows.EditAccount();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }
    }
}
