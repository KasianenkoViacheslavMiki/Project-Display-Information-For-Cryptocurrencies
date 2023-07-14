using Project_Display_Information_For_Cryptocurrencies.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        protected ServiceTheme serviceTheme;

        public BaseViewModel()
        {
            this.serviceTheme = ServiceTheme.GetInstance()
                                                .SettingInstance(OnChangeTheme);
        }

        public void OnChangeTheme()
        {
            OnPropertyChanged(nameof(Toogle));
        }
        public bool Toogle
        {
            get
            {
                return serviceTheme.Toggle;
            }
            set
            {
                serviceTheme.Toggle = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {   
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual void Dispose() { }

    }
}
