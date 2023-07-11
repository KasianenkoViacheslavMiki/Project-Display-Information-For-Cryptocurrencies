using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using Project_Display_Information_For_Cryptocurrencies.Control;
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
        private bool hasConnection;
        private string messageConnection;
        private NavigationStore viewStore;
        private ControlPing pingSystem;

        public bool HasConnection
        {
            get
            {
                return hasConnection;
            }
            set
            {
                hasConnection = value;
                OnPropertyChanged(nameof(HasConnection));
                OnPropertyChanged(nameof(MessageConnection));
                OnPropertyChanged(nameof(ColorMessageConnection));
            }
        }
        public string MessageConnection
        {
            get
            {
                return HasConnection ? "Connected" : "Not connected";
            }
        }
        public string ColorMessageConnection
        {
            get
            {
                return HasConnection ? "Green" : "Red";
            }
        }

        public MainViewModel(NavigationStore viewStore)
        {
            hasConnection = false;

            viewStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            this.viewStore = viewStore;
            this.pingSystem = ControlPing.GetInstance()
                                         .SettingInstance(OnSetFalseConnection, OnSetTrueConnection);
            this.pingSystem.StartPing();
        }

        public BaseViewModel SelectedViewModel => viewStore.CurrentViewModel;
        
        public BaseViewModel NavigationBar => new NavigationVerticalBarViewModel();

        public void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }

        public void OnSetTrueConnection()
        {
            HasConnection = true;
        }
        public void OnSetFalseConnection()
        {
            HasConnection = false;
        }
    }
}
