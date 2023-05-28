using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.WebBrowser
{
    public class OpenBrowserCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter == null)
            {
                return;
            }
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = parameter as string,
                UseShellExecute = true
            });
        }
    }
}
