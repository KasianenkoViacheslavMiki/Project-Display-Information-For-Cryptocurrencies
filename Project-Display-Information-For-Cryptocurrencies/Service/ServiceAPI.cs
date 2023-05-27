using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
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

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ServiceAPI:IPing,ICoins
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
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpClient.BaseAddress = new Uri(urlAPI);
            httpClient.DefaultRequestHeaders.Accept.Clear();
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
            return httpClient.GetAsync(urlAPI+"/ping");
        }

        public async Task<IEnumerable<CoinData>> Trending()
        {
            var responce = await httpClient.GetFromJsonAsync<Root>(urlAPI + "/search/trending");
            if (responce == null)
            {
                throw new ArgumentNullException("Responce is null");
            }
            if (responce.coins.Count == 0)
            {
                throw new Exception("Have`t data");
            }
            return responce.coins.ToList();
        }
    }
}
