using ParkingLot.Comman.Model;
using ParkingLot.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Repository
{
    class TicketRepo:ITicketRepo
    {
        private readonly IParkingData _parkingData;
        private readonly IOutput _output;

        public TicketRepo()
        {
            _parkingData = ParkingData.Instance();
            _output = new Output();
        }

        public TicketRepo(IParkingData parkingData, IOutput output)
        {
            _parkingData = ParkingData.Instance();
        }

        public void AddTicket(string vehicleNumber, int driverAge)
        {
            var parkingTicket = new ParkingTicket(vehicleNumber, driverAge);
            
            _parkingData.AddTicket(parkingTicket);
        }

        public bool CreateParkingSlot(int slot)
        {
           return _parkingData.CreateParkingLot(slot);
        }

        public int FindSlotForCar(string vehicle)
        {
            var ticket = _parkingData.FindTicketForCar(vehicle);

            if(ticket == null)
            {
                return -1;
            }
            else
            {
                return ticket.SlotNumber;
            }
        }

        public int[] FindSlotsForDriverAge(int age)
        {
            var tickets = _parkingData.FindTicketsForAge(age);

            if(tickets == null)
            {
                return null;
            }
            else
            {
                return tickets.Select(t => t.SlotNumber).ToArray();
            }
        }

        public string[] FindVehiclesForDriverAge(int age)
        {
            var tickets = _parkingData.FindTicketsForAge(age);

            if (tickets == null)
            {
                return null;
            }
            else
            {
                return tickets.Select(t => t.Vehicle).ToArray();
            }
        }

        public bool LeaveSlot(int slot)
        {
            return _parkingData.VacateSlot(slot);
        }
    }
}
