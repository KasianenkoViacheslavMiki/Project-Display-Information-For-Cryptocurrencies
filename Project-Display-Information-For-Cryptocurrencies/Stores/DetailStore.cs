using Project_Display_Information_For_Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Stores
{
    public class DetailStore
    {
        private CurrencyDetailData currencyDetailData;

        public event Action? CurrentCurrencyChanged;
        private void OnCurrentCurrencyChanged()
        {
            CurrentCurrencyChanged?.Invoke();
        }

        private static DetailStore instance;
        private static DetailStore Instance
        {
            get => instance;
            set => instance = value;
        }
        public CurrencyDetailData CurrencyDetailData 
        { 
            get => currencyDetailData;
            set 
            { 
                currencyDetailData = value;
                OnCurrentCurrencyChanged();
            }
        }

        public DetailStore() { }
        public static DetailStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DetailStore();
            }
            return Instance;
        }
    }
}
