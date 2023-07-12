using Project_Display_Information_For_Cryptocurrencies.API;
using Project_Display_Information_For_Cryptocurrencies.API.Interface;
using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Control
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
            var result = await coins.Trending();
            return (List<Item>) result;
        }
        public async Task<CurrencyDetailData> GetCurrencyDetailAsync(string id)
        {
            var coinsAPI = await coins.GetDetailData(id);
            return coinsAPI;
        }

        public async Task<List<Coin>> GetCoinsAsync(int page, string vs_currency = "usd", int per_page = 100)
        {
            var coinsAPI = await coins.GetCoins(page, vs_currency, per_page);
            return coinsAPI;
        }
    }
}
