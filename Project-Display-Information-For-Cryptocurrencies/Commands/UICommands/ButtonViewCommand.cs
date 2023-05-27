using Project_Display_Information_For_Cryptocurrencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    public class ButtonViewCommand : CommandBase
    {
        Item viewDetail;

        public ButtonViewCommand(Item view)
        {
            this.viewDetail = view;
        }

        public override void Execute(object? parameter)
        {
            var l = viewDetail;
        }
    }
}
