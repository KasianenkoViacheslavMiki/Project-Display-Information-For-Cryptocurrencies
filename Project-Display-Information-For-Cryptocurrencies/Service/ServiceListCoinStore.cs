using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ServiceListCoinStore
    {

        private string priceCurrent = "usd";

        private ListCoinStore listCoinStore;

        private static ServiceListCoinStore instance;
        private static ServiceListCoinStore Instance
        {
            get => instance;
            set => instance = value;
        }
        public ListCoinStore ListCoinStore 
        { 
            get => listCoinStore; 
            set => listCoinStore = value; 
        }

        public ServiceListCoinStore()
        {
            ListCoinStore = ListCoinStore.GetInstance();
        }
        public static ServiceListCoinStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceListCoinStore();
            }
            return Instance;
        }
        public ServiceListCoinStore SettingInstance(Action action)
        {
            if (ListChanged == null)
            {
                ListChanged = action;
                ListCoinStore.ListCoinChanged += action;
            }
            else
            {
                ListCoinStore.ListCoinChanged -= ListChanged;
                ListCoinStore.ListCoinChanged += action;
                ListChanged = action;
            }
            return Instance;
        }

        public event Action? ListChanged;



    }
}
