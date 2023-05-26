using Project_Display_Information_For_Cryptocurrencies.Stores;
using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    class NavigationCommand<TBaseView> : CommandBase
        where TBaseView : BaseViewModel
    {
        private readonly NavigationStore store;
        private readonly Func<TBaseView> _createViewModel;

        public NavigationCommand(NavigationStore store, Func<TBaseView> createViewModel)
        {
            this.store = store;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            store.CurrentViewModel = _createViewModel();
        }
    }
}
