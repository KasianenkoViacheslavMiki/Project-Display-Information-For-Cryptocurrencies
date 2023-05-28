using Project_Display_Information_For_Cryptocurrencies.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.Service
{
    public class ControlPing
    {
        IPing ping;
        private bool hasConnection;
        private string messageConnection;
        private Task pingToAPI;
        private CancellationTokenSource cancellationTokenPingToAPI;

        public ControlPing(IPing ping)
        {
            this.ping = ping;
            this.hasConnection = false;
        }

        public event Action OnHasConnection;
        public event Action OnNotHasConnection;

        private static ControlPing instance;
        private static ControlPing Instance
        {
            get => instance;
            set => instance = value;
        }
        public static ControlPing GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ControlPing(ServiceAPI.GetInstance());
            }
            return Instance;
        }
        public ControlPing SettingInstance(Action OnNotHasConnection, Action OnHasConnection)
        {
            Instance.OnNotHasConnection = OnNotHasConnection;
            Instance.OnHasConnection = OnHasConnection;
            return Instance;
        }
        public void StartPing()
        {
            cancellationTokenPingToAPI = new CancellationTokenSource();
            pingToAPI = Task.Run(async delegate
            {
                while (true)
                {
                    HttpResponseMessage pingResponce = await ping.Ping();
                    if (pingResponce != null)
                    {
                        if (pingResponce.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            OnHasConnection?.Invoke();
                        }
                        else
                        {
                            OnNotHasConnection?.Invoke();
                        }
                    }
                    else
                        throw new Exception("Null responce message");
                    await Task.Delay(TimeSpan.FromSeconds(15), cancellationTokenPingToAPI.Token);
                }
            });
        }

        public void StopPing()
        {
            cancellationTokenPingToAPI.Cancel();
        }

    }
}
