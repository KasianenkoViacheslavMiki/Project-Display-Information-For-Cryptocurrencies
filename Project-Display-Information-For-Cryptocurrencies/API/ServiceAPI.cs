using Project_Display_Information_For_Cryptocurrencies.API.Interface;
using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Project_Display_Information_For_Cryptocurrencies.API
{
    public class ServiceAPI : IPing, ICoins, ISearch
    {
        readonly string urlAPI = "https://api.coingecko.com/api/v3";

        HttpClient httpClient = new HttpClient();

        private static ServiceAPI instance;
        private static ServiceAPI Instance
        {
            get => instance;
            set => instance = value;
        }
        private ServiceAPI()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent",
                                 "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
        }
        public static ServiceAPI GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ServiceAPI();
            }
            return Instance;
        }

        public Task<HttpResponseMessage> Ping()
        {
            return httpClient.GetAsync(urlAPI + "/ping");
        }

        public async Task<IEnumerable<Item>> Trending()
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<Trending>(urlAPI + "/search/trending");

                if (responce == null)
                {
                    throw new ArgumentNullException("Responce is null");
                }
                if (responce.Coins.Length == 0)
                {
                    throw new Exception("Have`t data");
                }

                List<Item> result = new List<Item>();
                foreach (var item in responce.Coins)
                {
                    result.Add(item.Item);
                }

                return result;
            }
            catch (Exception ex) 
            {
                return new List<Item>();
            }
        }

        public async Task<CurrencyDetailData> GetDetailData(string id)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<CurrencyDetailData>(urlAPI + "/coins/" + id + "?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=false");
                if (responce == null)
                {
                    throw new ArgumentNullException("Responce is null");
                }
                return responce;
            }
            catch (Exception ex)
            {
                return new CurrencyDetailData();
            }
        }

        public async Task<List<Coin>> GetCoins(int page, string vs_currency = "usd", int per_page = 100)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<List<Coin>>(urlAPI + "/coins/markets?vs_currency=" + vs_currency + "&order=market_cap_desc&per_page=" + per_page + "&page=" + page + "&locale=en");
                if (responce == null)
                {
                    throw new ArgumentNullException("Responce is null");
                }
                return responce;
            }
            catch (Exception ex)
            {
                return new List<Coin>();
            }
        }

        public async Task<List<Coin>> GetCoinsAsync(string query)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<SearchCoin>(urlAPI + "/search?query=" + query);
                if (responce == null)
                {
                    throw new ArgumentNullException("Responce is null");
                }
                return responce.Coins.ToList();
            }
            catch (Exception ex)
            {
                return new List<Coin>();
            }
        }
    }
}
