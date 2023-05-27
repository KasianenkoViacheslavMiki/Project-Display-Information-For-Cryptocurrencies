using Project_Display_Information_For_Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Service.Interface
{
    public interface ICoins
    {
        public Task<IEnumerable<CoinData>> Trending();
    }
}
