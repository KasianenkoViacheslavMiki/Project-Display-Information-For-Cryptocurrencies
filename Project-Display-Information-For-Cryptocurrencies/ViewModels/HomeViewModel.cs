using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service;
using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        ControlCoin coinSystem;

        private List<Item> coins;

        public List<Item> Coins
        {
            get 
            { 
                return coins; 
            }
            set 
            { 
                coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }


        public HomeViewModel()
        {
            coinSystem = ControlCoin.GetInstance();
            InitData();
        }

        public async void InitData()
        {
            Coins = await coinSystem.Trending();
        }
    }
}
