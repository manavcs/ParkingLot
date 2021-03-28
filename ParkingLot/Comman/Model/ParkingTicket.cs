using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Comman.Model
{
    public class ParkingTicket
    {
        public string Vehicle { get; set; }
        public int SlotNumber { get; set; }
        public int DriverAge { get; set; }

        public ParkingTicket(string vehicle, int driverAge)
        {
            Vehicle = vehicle;
            DriverAge = driverAge;
        }
    }
}
