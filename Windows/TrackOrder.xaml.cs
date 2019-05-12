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
using System.Windows.Threading;
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for TrackOrder.xaml
    /// </summary>
    public partial class TrackOrder : Window
    {

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public Account LoggedAccount;
        public TrackOrder()
        {
            InitializeComponent();
            LoggedAccount = new Customer();
            if (ViewRestaurantMenu.LoggedAccount != null)
                LoggedAccount = ViewRestaurantMenu.LoggedAccount;
            BackToMainMenuBTN.IsEnabled = false;
            fillOrderList();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);
            dispatcherTimer.Start();
            StateTextBox.Text = LoggedAccount.order.getState().StateName;
            InitalDateTextBox.Text = LoggedAccount.order.getInitDate().ToString();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            StateProgressBar.Value += 1;
            if(StateProgressBar.Value%25==0 )
            {

                LoggedAccount.order.getState().nextState();
                StateTextBox.Text = LoggedAccount.order.getState().StateName;
            }
            if(StateProgressBar.Value==100)
            {
                BackToMainMenuBTN.IsEnabled = true;
                FinalDateTextBox.Text = LoggedAccount.order.getDeliveredDate().ToString();
            }
            // code goes here
        }

        private void fillOrderList()
        {
            for (int i = 0; i < LoggedAccount.order.getItems().Count; i++)
            {
                ItemsInOrder.Children.Add(getCartItemPanel(LoggedAccount.cart.items[i]));
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
            return ret;
        }

        private void BackToMainMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainMenu();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }
    }
}
