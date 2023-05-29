using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class ListCoinViewModel:BaseViewModel
    {
        private ServiceListCoinStore serviceListCoinStore;
        private ControlCoin coinsSystem;

        private int page=1;

        public ListCoinViewModel()
        {
            coinsSystem = ControlCoin.GetInstance();
            this.serviceListCoinStore = ServiceListCoinStore.GetInstance()
                                                            .SettingInstance(OnListCoinChanged);
            UpdateData();
        }

        public List<Coin> CoinList=>serviceListCoinStore.ListCoinStore.ListCoins;

        public async void UpdateData()
        {
            serviceListCoinStore.ListCoinStore.ListCoins = await coinsSystem.GetCoinsAsync(page);
        }
        public async void SearchData(string id)
        {
            serviceListCoinStore.ListCoinStore.ListCoins = await coinsSystem.GetCoinsAsync(page,id);
        }

        private void OnListCoinChanged()
        {
            OnPropertyChanged(nameof(CoinList));
        }
    }
}
