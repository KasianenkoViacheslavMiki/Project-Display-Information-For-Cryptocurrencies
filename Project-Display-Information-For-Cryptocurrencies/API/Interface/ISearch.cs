using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.API.Interface
{
    public interface ISearch
    {
        public Task<List<Coin>> GetCoinsAsync(string query);
    }
}
