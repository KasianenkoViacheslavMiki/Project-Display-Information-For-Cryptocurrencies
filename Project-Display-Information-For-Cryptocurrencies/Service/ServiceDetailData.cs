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

        private DetailStore store;

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

        public string Image => store.CurrencyDetailData.Image.Small;
        public string Price => store.CurrencyDetailData.Market_Data.Price_Change_24h_In_Currency[priceCurrent].ToString();
        public string Volume => store.CurrencyDetailData.Market_Data.Total_Volume[priceCurrent].ToString();
        public List<Ticker> Ticker { get; set; }


    }
}
