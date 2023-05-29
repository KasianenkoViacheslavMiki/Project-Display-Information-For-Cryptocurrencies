using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    public class ChangePageCommand : CommandBase
    {
        public Action OnNextPageCommand { get; set; }

        public ChangePageCommand(Action onNextPageCommand)
        {
            OnNextPageCommand = onNextPageCommand;
        }

        public override void Execute(object? parameter)
        {
            OnNextPageCommand?.Invoke();
        }
    }
}
