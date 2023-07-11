using Project_Display_Information_For_Cryptocurrencies.Stores;
using Project_Display_Information_For_Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_Display_Information_For_Cryptocurrencies.Commands.UICommands
{
    public class ButtonViewCommand : CommandBase
    {
        private readonly object id;
        
        public ButtonViewCommand(object id)
        {
            this.id = id;
        }

        public override void Execute(object? parameter)
        {
            Type myType = id.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(id, null);

                if (prop.Name == "Id")
                {
                    new NavigationCommand<DetailViewModel>(NavigationStore.GetInstance(), () => new DetailViewModel(propValue.ToString())).Execute(null);
                }
            }
        }
    }
}
