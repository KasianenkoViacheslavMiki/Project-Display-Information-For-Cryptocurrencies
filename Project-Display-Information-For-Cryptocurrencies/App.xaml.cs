using Project_Display_Information_For_Cryptocurrencies.Stores;
using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Display_Information_For_Cryptocurrencies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel( NavigationStore.GetInstance())
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
