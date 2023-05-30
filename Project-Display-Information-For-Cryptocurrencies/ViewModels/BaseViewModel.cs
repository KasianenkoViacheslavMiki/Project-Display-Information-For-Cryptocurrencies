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
        protected ServiceSetting serviceSetting;

        public BaseViewModel()
        {
            this.serviceSetting = ServiceSetting.GetInstance()
                                                .SettingInstance(OnChangeTheme);
        }

        public void OnChangeTheme()
        {
            OnPropertyChanged(nameof(ButtonColor));
            OnPropertyChanged(nameof(BackgroundColor));
            OnPropertyChanged(nameof(ForegroundColor));
            OnPropertyChanged(nameof(Toogle));
        }
        public bool Toogle
        {
            get
            {
                return serviceSetting.Toggle;
            }
            set
            {
                serviceSetting.Toggle = value;
            }
        }
        public string ButtonColor => serviceSetting.ButtonColor;
        public string BackgroundColor => serviceSetting.BackgroundColor;
        public string ForegroundColor => serviceSetting.ForegroundColor;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {   
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual void Dispose() { }

    }
}
