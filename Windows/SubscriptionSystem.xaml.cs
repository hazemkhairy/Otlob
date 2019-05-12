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
using System.IO;
using otlob.Classes;
using otlob.UserControls;
using otlob.Windows;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for SubscriptionSystem.xaml
    /// </summary>
    public partial class SubscriptionSystem : Window
    {
        Classes.System system;
        Account account;
        public SubscriptionSystem()
        {
            InitializeComponent();
            system = Classes.System.getInstance();
            account = Login.LogedAccount;

            fillPanels();

        }
        private void fillPanels()
        {
            SubscibedResturantsPanel.Children.Clear();
            UnSubscibedResturantsPanel.Children.Clear();
            foreach (Resturant resturant in system.resturants)
            {
                bool found = false;
                foreach (Subscriber subscriber in resturant.subscibers)
                {
                    if(account.id==((Account)subscriber).id)
                    {
                        found = true;
                        break;
                    }
                }
                ResturantDisplayPanel resturantDisplay = getResturantPanel(resturant);
                if(found == true)
                {
                    resturantDisplay.MouseLeftButtonDown += unSubscribeBTN;
                    SubscibedResturantsPanel.Children.Add(resturantDisplay);
                }
                else
                {
                    resturantDisplay.MouseLeftButtonDown += subscribeBTN;
                    UnSubscibedResturantsPanel.Children.Add(resturantDisplay);
                }
            }
        }

        private void unSubscribeBTN(object sender, MouseButtonEventArgs e)
        {
            ResturantDisplayPanel resturantDisplay = (ResturantDisplayPanel)sender;
            resturantDisplay.target.removeSubscriber(account);
            fillPanels();
        }
        private void subscribeBTN(object sender, MouseButtonEventArgs e)
        {
            ResturantDisplayPanel resturantDisplay = (ResturantDisplayPanel)sender;
            resturantDisplay.target.addSubscriber(account);
            fillPanels();
        }


        ResturantDisplayPanel getResturantPanel(Resturant resturant)
        {
            ResturantDisplayPanel ret = new ResturantDisplayPanel();
            ret.resturantName.Text = "name = " + resturant.name;
            ret.resturantDescription.Text = "Description = " + resturant.description;
            ret.resturantCategory.Text = "Category = " + resturant.categoryType;
            ret.resturantPhoneNumber.Text = "Phone Number = " + resturant.phoneNumber;
            ret.resturantLocation.Text = "Address = " + resturant.address;
            ret.target = resturant;


            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(Directory.GetCurrentDirectory() + @"\..\..\Images\" + resturant.name + ".jpg");


            myBitmapImage.EndInit();
            ret.resturantImage.Source = myBitmapImage;

            return ret;
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
