using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Instance
{
    public class InstanceDetailData
    {
        private string priceCurrent = "usd";

        public DetailStore store;

        private static InstanceDetailData instance;
        private static InstanceDetailData Instance
        {
            get => instance;
            set => instance = value;
        }
        public InstanceDetailData() 
        {
            store = DetailStore.GetInstance();
        }
        public static InstanceDetailData GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InstanceDetailData();
            }
            return Instance;
        }
        public InstanceDetailData SettingInstance(Action action)
        {
            if (CurrentCurrencyChanged == null)
            {
                CurrentCurrencyChanged = action;
                store.CurrentCurrencyChanged += action;
            }
            else
            {
                store.CurrentCurrencyChanged -= CurrentCurrencyChanged;
                store.CurrentCurrencyChanged += action;
                CurrentCurrencyChanged = action;
            }
            return Instance;
        }

        public event Action? CurrentCurrencyChanged;

        public string? Name
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.Name;
                }
                return "";
            }
        }
        public string? Image  
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.Image.Large;
                }
                return "https://bitcoin.org/img/icons/opengraph.png?1682978874";
            }
        }
        public string? Price
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.MarketData.PriceChange24hInCurrency[priceCurrent].ToString();
                }
                return "";
            }
        }
        public string? Volume
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.MarketData.TotalVolume[priceCurrent].ToString();
                }
                return "";
            }
        }
        public string? PriceChange
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.MarketData.PriceChange24hInCurrency[priceCurrent].ToString();
                }
                return "";
            }
        }

        public IEnumerable<Ticker> Tickers 
        { 
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    foreach (var ticker in store.CurrencyDetailData.Tickers)
                    {
                        ticker.TargetCurrencies = priceCurrent;
                        yield return ticker;
                    }
                }
            } 
        }
    }
}
