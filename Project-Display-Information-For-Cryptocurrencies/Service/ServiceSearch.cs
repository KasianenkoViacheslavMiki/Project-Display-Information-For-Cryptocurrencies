using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ServiceSearch
    {
        private ListCoinStore listCoinStore;
        private ISearch searchControl; 
        public ListCoinStore ListCoinStore
        {
            get => listCoinStore;
            set => listCoinStore = value;
        }

        private static ServiceSearch instance;
        private static ServiceSearch Instance
        {
            get => instance;
            set => instance = value;
        }
        public ServiceSearch()
        {
            listCoinStore = ListCoinStore.GetInstance();
            searchControl = ServiceAPI.GetInstance();
        }
        public static ServiceSearch GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceSearch();
            }
            return Instance;
        }
        public ServiceSearch SettingInstance(Action action)
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

        public async Task<List<Coin>> Search(string query) 
        {
            var coinsAPI = await searchControl.GetCoinsAsync(query);
            return coinsAPI;
        }

    }
}
