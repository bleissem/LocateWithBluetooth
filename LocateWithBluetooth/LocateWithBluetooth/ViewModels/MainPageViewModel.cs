using LocateWithBluetooth.Common;
using Plugin.BluetoothLE;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LocateWithBluetooth.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            this.MyDevices = new MyDeviceList();

            this.DiscoverCommand = new DelegateCommand(() =>
            {
                if (null != _SubscribeBlueTooth)
                {
                    _SubscribeBlueTooth.Dispose();
                    _SubscribeBlueTooth = null;
                }

                // discover some devices
                _SubscribeBlueTooth = CrossBleAdapter.Current.Scan()?.Subscribe(scanResult =>
                {
                    MyDevices.AddOrUpdate(new MyDevice(scanResult.Device.Uuid)
                    {
                        Name = scanResult.Device.Name,
                        Rssi = scanResult.Rssi
                    });    
                });
            });
        }

        private IDisposable _SubscribeBlueTooth;

        public override void Destroy()
        {
            base.Destroy();
            if (null != _SubscribeBlueTooth)
            {
                _SubscribeBlueTooth.Dispose();
                _SubscribeBlueTooth = null;
            }
        }

        public ICommand DiscoverCommand { get; set; }


        public MyDeviceList MyDevices { get; set; }
    }
}
