using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Stores
{
    public class NavigationStore
    {

        private BaseViewModel _currentViewModel = new HomeViewModel();

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private static NavigationStore instance;
        private static NavigationStore Instance 
        { 
            get => instance;  
            set => instance = value; 
        }
        private NavigationStore() { }
        public static NavigationStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new NavigationStore();
            }
            return Instance;
        }
    }
}
