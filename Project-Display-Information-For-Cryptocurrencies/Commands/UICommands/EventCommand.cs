using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    public class EventCommand : CommandBase
    {
        public Action OnEventCommand { get; set; }

        public EventCommand(Action onEventCommand)
        {
            OnEventCommand = onEventCommand;
        }

        public override void Execute(object? parameter)
        {
            OnEventCommand?.Invoke();
        }
    }
}
