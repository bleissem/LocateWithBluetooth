using System;
using System.Collections.Generic;
using System.Text;

namespace LocateWithBluetooth.Common
{
    public class MyDevice: IEquatable<MyDevice>
    {
        public MyDevice(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }

        public int Rssi { get; set; }

        public string Name { get; set; }

        public bool Equals(MyDevice other)
        {
            return this.Id == other?.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is MyDevice)
            {
                return this.Equals(obj as MyDevice);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
