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
using System.Web;
using System.Net;

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
            for (int i = 0; i < 5; i++)
            {
                RatingComboBox.Items.Add(i + 1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AddressTextBox.Text == "" || CategoryTextBox.Text == "" || DescirptionTextBox.Text == "" || RestrauntNameTextBox.Text == "" || PhoneNumberTextBox.Text == "" || ImageUrlTextBox.Text ==""|| RatingComboBox.SelectedIndex == -1)
                MessageBox.Show("Please Fill All The Data");
            else
            {
            newRestraunt.address = AddressTextBox.Text;
            newRestraunt.categoryType = CategoryTextBox.Text;
            newRestraunt.description = DescirptionTextBox.Text;
            newRestraunt.name = RestrauntNameTextBox.Text;
            newRestraunt.phoneNumber = PhoneNumberTextBox.Text;
            newRestraunt.rating =Convert.ToInt32(RatingComboBox.SelectedItem.ToString());
            newRestraunt.imagePath = ImageUrlTextBox.Text;
            int id = 0;
            for (int i = 0; i < system.resturants.Count; i++)
            {
                    id = Math.Max(id, system.resturants[i].id);
            }
             newRestraunt.id=id + 1;
             
            system.resturants.Add(newRestraunt);

            WebClient client = new WebClient();
            client.DownloadFile(new Uri(newRestraunt.imagePath), @"..\..\Images\" + newRestraunt.name +".jpg");
            var AddMenu =new otlob.Windows.AddMenu();
            this.Hide();
            AddMenu.ShowDialog();
            this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu login = new MainMenu();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
