using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ServiceTheme
    {

        private bool toggle = false;

        Dictionary<string, string> theme = new Dictionary<string, string>()
        {
            {"Dark","Resource/Theme/Dark.xaml" },
            {"Light","Resource/Theme/Light.xaml" }
        };
        public bool Toggle
        {
            get
            {
                return toggle;
            }
            set
            {
                toggle = value;
                OnToggleThere();
            }
        }

        public Action OnToggleTheme;
        public void OnToggleThere()
        {
            Uri uri = new Uri(toggle ? theme["Dark"] : theme["Light"], UriKind.Relative);
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = uri
            };
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            OnToggleTheme?.Invoke();
        }

        private static ServiceTheme instance;
        private static ServiceTheme Instance
        {
            get => instance;
            set => instance = value;
        }
        public ServiceTheme() 
        { 

        }
        public static ServiceTheme GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceTheme();
            }
            return Instance;
        }
        public ServiceTheme SettingInstance(Action action)
        {
            OnToggleTheme = action;
            return Instance;
        }
    }
}
