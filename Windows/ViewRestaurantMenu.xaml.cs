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
using otlob.UserControls;
using otlob.Windows;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for ViewRestaurantMenu.xaml
    /// </summary>
    public partial class ViewRestaurantMenu : Window
    {
        public static Resturant targetRestaurant;
        public static Account LoggedAccount;
        public ViewRestaurantMenu()
        {
            InitializeComponent();
            LoggedAccount = new Customer();
            if (Login.LogedAccount != null)
                LoggedAccount = Login.LogedAccount;
            targetRestaurant = new Resturant();
            if(SearchForRestaurant.targetRestaurant!=null)
            targetRestaurant = SearchForRestaurant.targetRestaurant;
            LoggedAccount.cart.setResturant(targetRestaurant);
            //LoggedAccount = new Customer();
            fillRestaurantInfoPanel();
            fillSectionsPanels();
        }
        private void fillSectionsPanels()
        {
            for (int i = 0; i < targetRestaurant.menu.getChildrens().Count; i++)
            {
                MenuSectionDisplayPanel temp = new MenuSectionDisplayPanel();
                SectionItem section = (SectionItem)targetRestaurant.menu.getChildAt(i);
                temp.SectionNameTextBlock.Text = section.sectionName;

                for (int j = 0; j < section.getChildrens().Count; j++)
                    temp.MenuItemsPanel.Children.Add(getMenuItemPanel((Classes.MenuItem)section.getChildAt(j)));

                MenuSections.Children.Add(temp);
            }
        }
        MenuItemPanel getMenuItemPanel(Classes.MenuItem menuItem)
        {
            MenuItemPanel ret = new MenuItemPanel();
            ret.MenuItemName.Text = "Name = " + menuItem.name;
            ret.MenuItemLikes.Text = "Likes = " + menuItem.likes.ToString();
            ret.MenuItemPrice.Text = "Price = " + menuItem.price.ToString();
            ret.MenuItemDescription.Text = "description = " + menuItem.description;
            ret.menuItem = menuItem;
            ret.MouseDown += menuItem_MouseDown;


            return ret;
        }
        private void fillRestaurantInfoPanel()
        {
            ResturantDisplayPanel display = new ResturantDisplayPanel();
            display.resturantName.Text = targetRestaurant.name;
            display.resturantDescription.Text = targetRestaurant.description;
            display.resturantCategory.Text = targetRestaurant.categoryType;
            display.resturantPhoneNumber.Text = targetRestaurant.phoneNumber;
            display.resturantLocation.Text = targetRestaurant.address;
            RestaurantInfoPanel.Children.Add(display);

        }

        private void menuItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MenuItemPanel target = (MenuItemPanel)sender;

            addItemToCart(target.menuItem);
        }

        private void addItemToCart(Classes.MenuItem menuItem)
        {
            OrderItemAdapter orderItemAdapter = new OrderItemAdapter(menuItem);
            LoggedAccount.cart.addItem(orderItemAdapter);
            displayCartPanel();
        }
        private void displayCartPanel()
        {
            ItemsInCart.Children.Clear();

            for (int i = 0; i < LoggedAccount.cart.items.Count; i++)
            {
                ItemsInCart.Children.Add(getCartItemPanel(LoggedAccount.cart.items[i]));
            }

        }
        CartItemPanel getCartItemPanel(OrderItem orderItem)
        {
            CartItemPanel ret = new CartItemPanel();
            ret.CartItemNameTextBlock.Text = "Name = " + orderItem.GetName();
            ret.CartItemPriceTextBlock.Text = "Price = " + orderItem.Getprice().ToString();
            ret.CartItemQuantityTextBlock.Text = "Quantity = " + orderItem.Getquantity().ToString();
            ret.CartItemTotalPriceTextBlock.Text = "Total Price = " + (orderItem.Getquantity() * orderItem.Getprice()).ToString();
            ret.orderItem = orderItem;

            ret.MouseDown += removeOneFromCartPanel_MouseDown;
            return ret;
        }

        private void removeOneFromCartPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CartItemPanel target = (CartItemPanel)sender;
            LoggedAccount.cart.removeOneFromItemFromCart(target.orderItem);
            //add to cart
            displayCartPanel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LoggedAccount.cart.items.Count==0)
            {
                MessageBox.Show("Please add items to cart to place order");
                    return;

            }
            LoggedAccount.placeOrder();
            TrackOrder window = new TrackOrder();
            this.Hide();
            window.ShowDialog();
            this.Close();
            //MessageBox.Show(LoggedAccount.order.getTotalPrice().ToString());
        }

        

        

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SearchForRestaurant window = new SearchForRestaurant();
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
