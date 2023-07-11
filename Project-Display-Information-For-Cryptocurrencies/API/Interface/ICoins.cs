using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.API.Interface
{
    public interface ICoins
    {
        public Task<IEnumerable<Item>> Trending();
        public Task<CurrencyDetailData> GetDetailData(string id);
        public Task<List<Coin>> GetCoins(int page, string vs_currency = "usd", int per_page = 100);
    }
}
