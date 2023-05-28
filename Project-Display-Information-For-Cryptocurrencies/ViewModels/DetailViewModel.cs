using Project_Display_Information_For_Cryptocurrencies.Commands.WebBrowser;
using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service;
using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {

        private readonly DetailStore store;

        private Item viewDetail;
        private ControlCoin coinsSystem;

        public OpenBrowserCommand OpenBrowserCommand { get; set; }

        public CurrencyDetailData CurrencyData
        {
            get => store.CurrencyDetailData;
        }

        public DetailViewModel(Item viewDetail)
        {
            this.viewDetail = viewDetail;
            coinsSystem = ControlCoin.GetInstance();
            store = DetailStore.GetInstance();
            store.CurrentCurrencyChanged += OnCurrentCurrencyChanged;
            OpenBrowserCommand = new OpenBrowserCommand();
            InitDetail();
        }

        private void OnCurrentCurrencyChanged()
        {
            OnPropertyChanged(nameof(CurrencyData));
        }

        public async void InitDetail()
        {
            store.CurrencyDetailData = await coinsSystem.GetCurrencyDetailAsync(viewDetail.Id);
            store.CurrencyDetailData.Market_Data.targetCurrent = "usd";
        }
    }
}
