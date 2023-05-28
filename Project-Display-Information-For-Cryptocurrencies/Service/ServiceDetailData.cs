using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ServiceDetailData
    {
        private string priceCurrent = "usd";

        public DetailStore store;

        private static ServiceDetailData instance;
        private static ServiceDetailData Instance
        {
            get => instance;
            set => instance = value;
        }
        public ServiceDetailData() 
        {
            store = DetailStore.GetInstance();
        }
        public static ServiceDetailData GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceDetailData();
            }
            return Instance;
        }
        public ServiceDetailData SettingInstance(Action action)
        {
            store.CurrentCurrencyChanged += action;
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
                return "";
            }
        }
        public string? Price
        {
            get
            {
                if (store.CurrencyDetailData != null)
                {
                    return store.CurrencyDetailData.Market_Data.Price_Change_24h_In_Currency[priceCurrent].ToString();
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
                    return store.CurrencyDetailData.Market_Data.Total_Volume[priceCurrent].ToString();
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
                    return store.CurrencyDetailData.Market_Data.Price_Change_24h_In_Currency[priceCurrent].ToString();
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
