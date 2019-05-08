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
    /// Interaction logic for AddRestraunt.xaml
    /// </summary>
    public partial class AddRestraunt : Window
    {
        public static otlob.Classes.Resturant newRestraunt ;
        otlob.Classes.System system ;
        public AddRestraunt()
        {
            InitializeComponent();
            system = otlob.Classes.System.getInstance();
            newRestraunt = new otlob.Classes.Resturant();
            CategoryComboBox.Items.Add("Spicy");
            CityComboBox.Items.Add("Cairo");
            CountryComboBox.Items.Add("Egypt");
            for (int i = 0; i < 5; i++)
            {
                RatingComboBox.Items.Add(i + 1);
            }
            //load categories
            //load countries and cities
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //validate lel input 
            newRestraunt.address = CountryComboBox.SelectedItem.ToString()+" "+CityComboBox.SelectedItem.ToString();
            newRestraunt.categoryType = CategoryComboBox.SelectedItem.ToString();
            newRestraunt.description = DescirptionTextBox.Text;
            newRestraunt.name = RestrauntNameTextBox.Text;
            newRestraunt.phoneNumber = PhoneNumberTextBox.Text;
            newRestraunt.rating =Convert.ToInt32(RatingComboBox.SelectedItem.ToString());
            newRestraunt.imagePath = ImageUrlTextBox.Text;
            system.resturants.Add(newRestraunt);
            var AddMenu =new otlob.Windows.AddMenu();
            this.Hide();
            AddMenu.ShowDialog();
            this.Close();
            //go to add menu form
        }
    }
}
