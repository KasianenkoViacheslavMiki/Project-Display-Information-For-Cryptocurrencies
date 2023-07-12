using Project_Display_Information_For_Cryptocurrencies.API;
using Project_Display_Information_For_Cryptocurrencies.API.Interface;
using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Instance
{
    public class InstanceStoreListCoin
    {

        private string priceCurrent = "usd";

        private ListCoinStore listCoinStore;
        private ISearch searchControl;

        private static InstanceStoreListCoin instance;
        private static InstanceStoreListCoin Instance
        {
            get => instance;
            set => instance = value;
        }
        public ListCoinStore ListCoinStore 
        { 
            get => listCoinStore; 
            set => listCoinStore = value; 
        }

        public InstanceStoreListCoin()
        {
            searchControl = ServiceAPI.GetInstance();
            listCoinStore = ListCoinStore.GetInstance();
        }
        public static InstanceStoreListCoin GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InstanceStoreListCoin();
            }
            return Instance;
        }
        public InstanceStoreListCoin SettingInstance(Action action)
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
            ListChanged?.Invoke();
            return coinsAPI;
        }

    }
}
