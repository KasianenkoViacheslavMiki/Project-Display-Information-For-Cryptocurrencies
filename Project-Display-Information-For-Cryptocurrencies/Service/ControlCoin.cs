using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ControlCoin
    {
        private ICoins coins;

        private static ControlCoin instance;

        public ControlCoin(ICoins coins)
        {
            this.coins = coins;
        }

        private static ControlCoin Instance
        {
            get => instance;
            set => instance = value;
        }
        public static ControlCoin GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ControlCoin(ServiceAPI.GetInstance());
            }
            return Instance;
        }

        public async Task<List<Item>> Trending()
        {
            List<Item> list = new List<Item>();
            var coinsAPI = await coins.Trending();

            foreach (var item in coinsAPI)
            {
                list.Add(item.item);
            }
            return list;
        }
        public async Task<CurrencyDetailData> GetCurrencyDetailAsync(string id)
        {
            var coinsAPI = await coins.GetDetailData(id);
            return coinsAPI;
        }
    }
}
