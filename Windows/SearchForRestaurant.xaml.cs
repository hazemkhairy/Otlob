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
using otlob.UserControls;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for SearchForRestaurant.xaml
    /// </summary>
    public partial class SearchForRestaurant : Window
    {
        Classes.System otlobSystem;
        public static Resturant targetRestaurant;
        public SearchForRestaurant()
        {
            InitializeComponent();
            otlobSystem = Classes.System.getInstance();
            SearchMethodComboBox.Items.Add("Name");
            SearchMethodComboBox.Items.Add("Category");
            SearchMethodComboBox.Items.Add("Location");
            SearchMethodComboBox.SelectedItem = SearchMethodComboBox.Items[0];
            /*
            Resturant temp = new Resturant { name = "bashandy", description = "ay", categoryType = "asian" };
            SectionItem sectionItem = new SectionItem { sectionName = "sandwitches" };
            sectionItem.addChildern(new Classes.MenuItem { name = "kebda", price = 25, description = "sandwitch spice", likes = 12 });
            sectionItem.addChildern(new Classes.MenuItem { name = "sgo2", price = 25, description = "sandwitch spice awi", likes = 1 });
            sectionItem.addChildern(new Classes.MenuItem { name = "burgwer", price = 145, description = "sandwitch hady", likes = 50 });
            sectionItem.addChildern(new Classes.MenuItem { name = "burager", price = 45, description = "sandwitch hady", likes = 50 });
            sectionItem.addChildern(new Classes.MenuItem { name = "burgesr", price = 425, description = "sandwitch hady", likes = 50 });
            sectionItem.addChildern(new Classes.MenuItem { name = "burg12er", price = 45, description = "sandwitch hady", likes = 50 });
            sectionItem.addChildern(new Classes.MenuItem { name = "bur11ger", price = 45, description = "sandwitch hady", likes = 50 });
            sectionItem.addChildern(new Classes.MenuItem { name = "bu22rger", price = 45, description = "sandwitch hady", likes = 50 });
            temp.menu.addChildern(sectionItem);

            temp.menu.addChildern(new SectionItem { sectionName = "pizza" });
            temp.menu.addChildern(new SectionItem { sectionName = "crep" });
            temp.menu.addChildern(new SectionItem { sectionName = "sandwitches" });
            temp.menu.addChildern(new SectionItem { sectionName = "pizza" });
            temp.menu.addChildern(new SectionItem { sectionName = "crep" });
            otlobSystem.resturants.Add(temp);
            otlobSystem.resturants.Add(new Resturant { name = "hazem", description = "ay", categoryType = "italian" });
            otlobSystem.resturants.Add(new Resturant { name = "ali", description = "ay", categoryType = "egyptian" });
            otlobSystem.resturants.Add(new Resturant { name = "omar", description = "ay", categoryType = "western" });
            otlobSystem.resturants.Add(new Resturant { name = "alaa", description = "ay", categoryType = "mexico" });
            otlobSystem.resturants.Add(new Resturant { name = "alaa1", description = "ay", categoryType = "mexico" });
            otlobSystem.resturants.Add(new Resturant { name = "alaa3", description = "ay", categoryType = "mexico" });
            otlobSystem.resturants.Add(new Resturant { name = "alaa2", description = "ay", categoryType = "mexico" });
            otlobSystem.resturants.Add(new Resturant { name = "alaa4", description = "ay", categoryType = "mexico" });
            */
            fillResultPanel();

            
        }

        private void SearchMethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchMethodComboBox.SelectedItem.ToString() == "Name")
                otlobSystem.searchMethod = new SearchByName();
            else if (SearchMethodComboBox.SelectedItem.ToString() == "Category")
                otlobSystem.searchMethod = new SearchByCategory();
            else if (SearchMethodComboBox.SelectedItem.ToString() == "Location")
                otlobSystem.searchMethod = new SearchByLocation();
            fillResultPanel();
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            fillResultPanel();
        }
        ResturantDisplayPanel getRestaurantPanel (Resturant resturant)
        {
            ResturantDisplayPanel ret = new ResturantDisplayPanel();
            ret.resturantName.Text = resturant.name;
            ret.resturantDescription.Text = resturant.description;
            ret.resturantCategory.Text = resturant.categoryType;
            ret.resturantPhoneNumber.Text = resturant.phoneNumber;
            ret.resturantLocation.Text = resturant.address;
            ret.target = resturant;
            ret.MouseLeftButtonDown += DockPanel_MouseLeftButtonDown;
            return ret;
        }
        private void fillResultPanel()
        {
            displayPanel.Children.Clear();
            List<Resturant> resturants = otlobSystem.searchResturants(inputTextBox.Text);
            foreach (Resturant resturant in resturants)
            {
                displayPanel.Children.Add(getRestaurantPanel(resturant));
            }
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            targetRestaurant = ((ResturantDisplayPanel )sender).target;
            ViewRestaurantMenu temp = new ViewRestaurantMenu();
            this.Hide();
            temp.ShowDialog();
            this.Close();
        }
        private void LogOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
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
