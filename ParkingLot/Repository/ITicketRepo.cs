using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Repository
{
    public interface ITicketRepo
    {
        void AddTicket(string vehicleNumber, int driverAge);
        int[] FindSlotsForDriverAge(int age);
        string[] FindVehiclesForDriverAge(int age);
        int FindSlotForCar(string vehicle);
        bool LeaveSlot(int slot);
        bool CreateParkingSlot(int slot);
    }
}
