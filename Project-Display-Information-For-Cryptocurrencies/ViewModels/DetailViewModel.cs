using Project_Display_Information_For_Cryptocurrencies.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Display_Information_For_Cryptocurrencies.Instance;
using Project_Display_Information_For_Cryptocurrencies.DTOModels;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {

        private readonly InstanceDetailData serviceDetailData;

        private string id;
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

        public DetailViewModel(string id)
        {
            this.id = id;
            coinsSystem = ControlCoin.GetInstance();
            serviceDetailData = InstanceDetailData.GetInstance()
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
            serviceDetailData.store.CurrencyDetailData = await coinsSystem.GetCurrencyDetailAsync(id);
        }
    }
}
