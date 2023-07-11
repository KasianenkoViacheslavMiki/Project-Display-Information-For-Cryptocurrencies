using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Stores
{
    public class SettingStore
    {
        //False = dark | True = ligth
        private bool toogleTheme = true;


        private static SettingStore instance;
        private static SettingStore Instance
        {
            get => instance;
            set => instance = value;
        }
        public bool ToogleTheme 
        { 
            get => toogleTheme; 
            set => toogleTheme = value; 
        }

        private SettingStore() 
        { 

        }
        public static SettingStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SettingStore();
            }
            return Instance;
        }
    }
}
