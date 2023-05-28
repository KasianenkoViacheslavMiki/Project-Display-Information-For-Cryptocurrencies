using Project_Display_Information_For_Cryptocurrencies.Models;
using Project_Display_Information_For_Cryptocurrencies.Stores;
using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    public class ButtonViewCommand : CommandBase
    {
        private readonly Item viewDetail;
        
        public ButtonViewCommand(Item view )
        {
            this.viewDetail = view;
        }

        public override void Execute(object? parameter)
        {
            new NavigationCommand<DetailViewModel>(NavigationStore.GetInstance(), () => new DetailViewModel(viewDetail)).Execute(null);
        }
    }
}
