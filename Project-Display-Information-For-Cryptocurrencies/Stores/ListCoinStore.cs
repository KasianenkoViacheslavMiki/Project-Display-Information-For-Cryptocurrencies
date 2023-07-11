using Project_Display_Information_For_Cryptocurrencies.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Stores
{
    public class ListCoinStore
    {
        private List<Coin> listCoins;

        public event Action? ListCoinChanged;
        private void OnListCoinsChanged()
        {
            ListCoinChanged?.Invoke();
        }

        private static ListCoinStore instance;
        private static ListCoinStore Instance
        {
            get => instance;
            set => instance = value;
        }
        public List<Coin> ListCoins
        {
            get => listCoins;
            set
            {
                listCoins = value;
                OnListCoinsChanged();
            }
        }

        public ListCoinStore() { }
        public static ListCoinStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ListCoinStore();
            }
            return Instance;
        }
    }
}
