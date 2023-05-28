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

        private readonly ServiceDetailData serviceDetailData;

        private Item viewDetail;
        private ControlCoin coinsSystem;

        public string NameCurrency => serviceDetailData.Name;
        public string PriceCurrency => serviceDetailData.Price;
        public string VolumeCurrency => serviceDetailData.Volume;
        public string ImageCurrency => serviceDetailData.Image;
        public string PriceChangeCurrency => serviceDetailData.PriceChange;

        public List<Ticker> Tickers
        {
            get => serviceDetailData.Tickers.ToList();
        }

        public DetailViewModel(Item viewDetail)
        {
            this.viewDetail = viewDetail;
            coinsSystem = ControlCoin.GetInstance();
            serviceDetailData = ServiceDetailData.GetInstance()
                                                 .SettingInstance(OnCurrentCurrencyChanged);
            InitDetail();
        }

        private void OnCurrentCurrencyChanged()
        {
            OnPropertyChanged(nameof(NameCurrency));
            OnPropertyChanged(nameof(PriceCurrency));
            OnPropertyChanged(nameof(VolumeCurrency));
            OnPropertyChanged(nameof(ImageCurrency));
            OnPropertyChanged(nameof(PriceChangeCurrency));
            OnPropertyChanged(nameof(Tickers));
        }

        public async void InitDetail()
        {
            serviceDetailData.store.CurrencyDetailData = await coinsSystem.GetCurrencyDetailAsync(viewDetail.Id);
        }
    }
}
