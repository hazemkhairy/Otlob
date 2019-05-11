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
    /// Interaction logic for ViewNotfications.xaml
    /// </summary>
    public partial class ViewNotfications : Window
    {
        Account loggedAccount;
        public ViewNotfications()
        {
            InitializeComponent();
            loggedAccount = new Customer();
            if (Login.LogedAccount != null)
                loggedAccount = Login.LogedAccount;
            fillNotificationPanel();
        }
        private void fillNotificationPanel()
        {
            foreach ( Notification notification in loggedAccount.notifications)
            {
                
            }
        }
    }
}
