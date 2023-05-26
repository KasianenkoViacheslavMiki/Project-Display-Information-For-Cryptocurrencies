using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Stores
{
    public class NavigationBarStore
    {
        private BaseViewModel _currentViewModel = new NavigationVerticalBarViewModel();

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

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private static NavigationBarStore instance;
        private static NavigationBarStore Instance
        {
            get => instance;
            set => instance = value;
        }
        public NavigationBarStore() { }
        public NavigationBarStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new NavigationBarStore();
            }
            return Instance;
        }
    }
}
