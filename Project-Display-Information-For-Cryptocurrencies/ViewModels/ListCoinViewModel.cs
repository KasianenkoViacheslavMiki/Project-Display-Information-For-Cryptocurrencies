﻿using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class ListCoinViewModel:BaseViewModel
    {
        private ServiceListCoinStore serviceListCoinStore;
        private ControlCoin coinsSystem;

        private int page=1;

        public ListCoinViewModel()
        {
            NextPageCommand = new EventCommand(OnNextPage);
            PrevPageCommand = new EventCommand(OnPrevPage);
            EnterCommand = new EventCommand(OnEnter);

            coinsSystem = ControlCoin.GetInstance();
            this.serviceListCoinStore = ServiceListCoinStore.GetInstance()
                                                            .SettingInstance(OnListCoinChanged);
            EnableNextButton = true;
            EnablePrevButton = true;
            UpdateData();
        }
        private bool enableNextButton;
        public bool EnableNextButton
        {
            get
            {
                return enableNextButton;
            }
            set
            {
                enableNextButton = value;
                OnPropertyChanged(nameof(EnableNextButton));
            }
        }
        private bool enablePrevtButton;
        public bool EnablePrevButton
        {
            get
            {
                return enablePrevtButton;
            }
            set
            {
                enablePrevtButton = value;
                OnPropertyChanged(nameof(EnablePrevButton));
            }
        }
        private string searchString;
        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        private void OnEnter()
        {
            SearchData(SearchString);
        }

        private void OnNextPage()
        {
            ++page;
            EnablePrevButton = true;
            OnFirstPage();
            OnLastPage();
            UpdateData();
        }
        private void OnPrevPage()
        {
            --page;
            enableNextButton = true;
            OnFirstPage();
            OnLastPage();
            UpdateData();
        }

        private void OnFirstPage()
        {
            if (page == 1)
            {
                EnablePrevButton = false;
            }
        }

        private void OnLastPage()
        {
            if (serviceListCoinStore.ListCoinStore.ListCoins.Count == 0)
            {
                EnableNextButton = false;
            }
        }

        public  EventCommand NextPageCommand { get; set; }
        public EventCommand PrevPageCommand { get; set; }
        public EventCommand EnterCommand { get; set; }



        public List<Coin> CoinList=>serviceListCoinStore.ListCoinStore.ListCoins;

        public async void UpdateData()
        {
            serviceListCoinStore.ListCoinStore.ListCoins = await coinsSystem.GetCoinsAsync(page);
            OnFirstPage();
            OnLastPage();
        }
        public async void SearchData(string id)
        {
            serviceListCoinStore.ListCoinStore.ListCoins = await coinsSystem.GetCoinsAsync(page,id.ToLower());
            OnFirstPage();
            OnLastPage();
        }

        private void OnListCoinChanged()
        {
            OnPropertyChanged(nameof(CoinList));
        }
    }
}
