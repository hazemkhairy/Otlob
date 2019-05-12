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
using System.IO;

namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for ViewNotifications.xaml
    /// </summary>
    public partial class ViewNotifications : Window
    {
        Account loggedAccount;
        private Notification selectedNotification;
        public ViewNotifications()
        {
            InitializeComponent();
            loggedAccount = new Customer();
            if (Login.LogedAccount != null)
                loggedAccount = Login.LogedAccount;
            fillNotificationsPanel();
        }
        private void fillNotificationsPanel()
        {
            ReadNotificationsPanel.Children.Clear();
            UnreadNotificationsPanel.Children.Clear();
            foreach (Notification notificiation in loggedAccount.notifications)
            {
                NotificationCard card = new NotificationCard();

                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(Directory.GetCurrentDirectory()+ @"\..\..\Images\"+ notificiation.from.name+".jpg");

                
                myBitmapImage.EndInit();
                card.RestaurantImageBox.Source = myBitmapImage;

                card.RestaurantNameTextBlock.Text = notificiation.from.name;
                card.NotificationDateTextBlock.Text = notificiation.text;
                
                card.notification = notificiation;
                    card.MouseLeftButtonDown += StackPanel_MouseLeftButtonDown;
                if (notificiation.readed)
                {
                    ReadNotificationsPanel.Children.Add(card);
                }
                else
                {
                    UnreadNotificationsPanel.Children.Add(card);

                }
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            var newform = new MainMenu();
            this.Hide();
            newform.ShowDialog();
            this.Close();
        }
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((NotificationCard)sender).notification.readed = !((NotificationCard)sender).notification.readed;
            fillNotificationsPanel();
        }
        
    }
}
