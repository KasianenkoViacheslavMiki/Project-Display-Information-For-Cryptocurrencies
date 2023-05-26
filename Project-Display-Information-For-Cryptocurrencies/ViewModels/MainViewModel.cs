using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class MainViewModel:BaseViewModel
    {

        private NavigationStore viewStore;
        private NavigationBarStore navigationStore;

        public MainViewModel(NavigationStore viewStore, NavigationBarStore navigationStore)
        {
            viewStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.viewStore = viewStore;
            this.navigationStore = navigationStore;
        }

        public BaseViewModel SelectedViewModel => viewStore.CurrentViewModel;
        public BaseViewModel NavigationBar => navigationStore.CurrentViewModel;


        public void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
