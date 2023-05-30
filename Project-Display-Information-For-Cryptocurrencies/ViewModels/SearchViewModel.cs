using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    class SearchViewModel:BaseViewModel
    {
        private string searchString;
        private ServiceSearch searchSystem;

        public List<Coin> CoinList => searchSystem.ListCoinStore.ListCoins;


        public SearchViewModel()
        {
            EnterCommand = new EventCommand(OnEnter);
            this.searchSystem = ServiceSearch.GetInstance()
                                             .SettingInstance(OnListCoinChanged);
            if (CoinList == null || CoinList.Count == 0)
            {
                SearchData("");
            }
        }

        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        public EventCommand EnterCommand { get; set; }
        public async void SearchData(string id)
        {
            searchSystem.ListCoinStore.ListCoins = await searchSystem.Search(id);
        }
        private void OnEnter()
        {
            SearchData(SearchString);
        }
        private void OnListCoinChanged()
        {
            OnPropertyChanged(nameof(CoinList));
        }
    }
}
