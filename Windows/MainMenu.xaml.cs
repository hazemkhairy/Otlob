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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            if (Login.LogedAccount is Admin)
                addRestaurantBTN.Visibility = Visibility.Hidden;
        }

        private void addRestaurantBTN_Click(object sender, RoutedEventArgs e)
        {
            AddRestraunt addRestraunt = new AddRestraunt();
            this.Hide();
            addRestraunt.ShowDialog();
            this.Close();
        }

        private void EditProfileBTN_Click(object sender, RoutedEventArgs e)
        {
            Profile window = new Profile();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void SearchRestaurantBTN_Click(object sender, RoutedEventArgs e)
        {
            SearchForRestaurant window = new SearchForRestaurant();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
