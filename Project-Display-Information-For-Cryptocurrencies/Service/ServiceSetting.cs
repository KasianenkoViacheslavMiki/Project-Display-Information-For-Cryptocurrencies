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
    public class ServiceSetting
    {

        public SettingStore store;

        public bool Toggle
        {
            get
            {
                return store.ToogleTheme;
            }
            set
            {
                store.ToogleTheme = value;
                OnToggleThere();
            }
        }

        public string ButtonColor
        {
            get
            {
                if (store.ToogleTheme)
                {
                    return "#edeced";
                }
                return "#121212";
            }
        }

        public string BackgroundColor
        {
            get
            {
                if (store.ToogleTheme)
                {
                    return "#edeced";
                }
                return "#121212";
            }
        }
        public string ForegroundColor
        {
            get
            {
                if (store.ToogleTheme)
                {
                    return "#121212";
                }
                return "#edeced";
            }
        }


        public Action OnToggleTheme;
        public void OnToggleThere()
        {
            OnToggleTheme?.Invoke();
        }

        private static ServiceSetting instance;
        private static ServiceSetting Instance
        {
            get => instance;
            set => instance = value;
        }
        public ServiceSetting() 
        { 
            store = SettingStore.GetInstance();
        }
        public static ServiceSetting GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceSetting();
            }
            return Instance;
        }
        public ServiceSetting SettingInstance(Action action)
        {
            OnToggleTheme = action;
            return Instance;
        }
    }
}
