using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using otlob.Classes;
namespace otlob
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            otlob.Classes.System system = otlob.Classes.System.getInstance();
            system.CommitDataToDataBase();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            otlob.Classes.System system = otlob.Classes.System.getInstance();
            system.FetchDataFromDataBase();
        }
    }
}
