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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace otlob.UserControls
{
    /// <summary>
    /// Interaction logic for MenuItemPanel.xaml
    /// </summary>
    public partial class MenuItemPanel : UserControl
    {
        public Classes.MenuItem menuItem;
        public MenuItemPanel()
        {
            InitializeComponent();
        }

        private void DockPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            ((DockPanel)sender).Background = Brushes.PowderBlue;
        }

        private void DockPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            ((DockPanel)sender).Background = Brushes.White;
        }
    }
}
