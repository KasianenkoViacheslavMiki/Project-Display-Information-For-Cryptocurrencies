﻿using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class NavigationVerticalBarViewModel:BaseViewModel
    {
        public NavigationVerticalBarViewModel()
        {
            HomeCommand = new NavigationCommand<HomeViewModel>(NavigationStore.GetInstance() ,()=>new HomeViewModel());
            ListCommand = new NavigationCommand<ListCoinViewModel>(NavigationStore.GetInstance(), () => new ListCoinViewModel());
            SearchCommand = new NavigationCommand<SearchViewModel>(NavigationStore.GetInstance(), () => new SearchViewModel());
        }

        public ICommand HomeCommand{ get;}
        public ICommand ListCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand SettingsCommand { get; }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
