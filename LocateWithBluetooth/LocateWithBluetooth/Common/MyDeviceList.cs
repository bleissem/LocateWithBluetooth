using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LocateWithBluetooth.Common
{
    public class MyDeviceList
    {
        public MyDeviceList()
        {
            this.Devices = new ObservableCollection<MyDevice>();
        }

        public void AddOrUpdate(MyDevice device)
        {
            if (Devices.Contains(device))
            {
                Devices[Devices.IndexOf(device)] = device;
            }
            else
            {
                Devices.Add(device);
            }
        }

        public ObservableCollection<MyDevice> Devices { get; set; }
    }
}
