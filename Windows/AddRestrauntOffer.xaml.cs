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
namespace otlob.Windows
{
    /// <summary>
    /// Interaction logic for AddRestrauntOffer.xaml
    /// </summary>
    public partial class AddRestrauntOffer : Window
    {
        Classes.System system = otlob.Classes.System.getInstance();
        Resturant temprestraunt;
        public AddRestrauntOffer()
        {
            InitializeComponent();
            for (int i = 0; i < system.resturants.Count; i++)
            {
                RestrauntsComboBox.Items.Add(system.resturants[i].name);
            }
            
        }

        private void RestrauntsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < system.resturants.Count; i++)
            {
                if (RestrauntsComboBox.SelectedItem.ToString() == system.resturants[i].name)
                {
                    temprestraunt = system.resturants[i];
                    break;
                }
            }
            for (int i = 0; i < temprestraunt.menu.childern.Count; i++)
            {
                RestrauntSectionsComboBox.Items.Add(((Classes.SectionItem)(temprestraunt.menu.childern[i])).sectionName);
            }
        }

        private void SubmitOffer_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < system.accounts.Count; i++)
            {
                temprestraunt.addSubscriber(system.accounts[i]);
            }
            if (RestrauntsComboBox.SelectedIndex != -1 && RestrauntSectionsComboBox.SelectedIndex != -1 && DiscountAmount.Text != "")
            {
                Notification newNotification = new Notification();
                newNotification.from = temprestraunt;
                newNotification.readed = false;
                newNotification.text = temprestraunt.name + " Added "+ DiscountAmount.Text +"% Discount On Section : " + RestrauntSectionsComboBox.SelectedItem.ToString();
                int id = system.generatenotificationid(Login.LogedAccount);
                temprestraunt.notifySubscribers(newNotification);
                for (int i = 0; i < temprestraunt.menu.childern.Count; i++)
                {
                        SectionItem sectionItem = (Classes.SectionItem)temprestraunt.menu.childern[i];
                    
                    if (sectionItem.sectionName == RestrauntSectionsComboBox.SelectedItem.ToString())
                    {
                        for (int j = 0; j < sectionItem.childern.Count; j++)
                        {
                            Classes.MenuItem menuItem = (Classes.MenuItem)sectionItem.childern[j];
                            menuItem.price -= (Convert.ToDouble(DiscountAmount.Text) /100.0)* menuItem.price;
                        }
                        break;
                    }
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainMenu();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }
    }
}
