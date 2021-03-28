using ParkingLot.Comman;
using ParkingLot.Comman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Storage
{
    /// <summary>
    /// ParkingData serves as a in memory database, it is also a singleton
    /// It uses three dictionaries for fast searching however in case of actual database, Indexing 
    /// can be done on age and vehicle number to achieve fast searching.
    /// </summary>
    public class ParkingData:IParkingData
    {
        /// <summary>
        /// Key - Age of the driver, Value - list of parking tickets which has the same driver age 
        /// </summary>
        public Dictionary<int, List<ParkingTicket>> AgeToTicketsMapper { get; set; }

        /// <summary>
        /// Key - vehicle registration number, Value - parking ticket for the vehicle number 
        /// </summary>
        public Dictionary<string, ParkingTicket> VehicleToTicketMapper { get; set; }

        /// <summary>
        /// Key - slot number, Value - parking ticket for the slot number 
        /// </summary>
        public Dictionary<int, ParkingTicket> SlotToTicketMapper { get; set; }
     
        /// <summary>
        /// Used to avoid multiple instances of ParkingData
        /// </summary>
        private static object _lockObject = new object();

        private static ParkingData _instance;

        private readonly IOutput _output;

        public int[] Slots { get; set; }

        public int SlotsLength => Slots == null ? 0 : Slots.Length;

        private ParkingData()
        {
            AgeToTicketsMapper = new Dictionary<int, List<ParkingTicket>>();
            VehicleToTicketMapper = new Dictionary<string, ParkingTicket>();
            SlotToTicketMapper = new Dictionary<int, ParkingTicket>();
            _output = new Output();
        }

        private ParkingData(IOutput output)
        {
            AgeToTicketsMapper = new Dictionary<int, List<ParkingTicket>>();
            VehicleToTicketMapper = new Dictionary<string, ParkingTicket>();
            SlotToTicketMapper = new Dictionary<int, ParkingTicket>();
            _output = output;
        }

        public bool CreateParkingLot(int slots)
        {
            if(Slots != null)
            {
                _output.PrintLine(Messages.SlotsAlreadtCreated);
                return false;
            }

            if(slots <= 0)
            {
                _output.PrintLine(Messages.InvalidSlotNumber);
                return false;
            }

            Slots = new int[slots];

            _output.PrintLine(string.Format(Messages.SlotsCreated, slots));

            return true;
        }

        public bool AddTicket(ParkingTicket ticket)
        {
            if (Slots == null)
            {
                _output.PrintLine(Messages.CreateSlotsFirst);
                return false;
            }

            if(VehicleToTicketMapper.ContainsKey(ticket.Vehicle))
            {
                _output.PrintLine(Messages.AlreadyParked);
                return false;
            }

            var slot = FindEmptySlot();

            if(slot == -1)
            {
                _output.PrintLine(Messages.SlotsFull);
                return false;
            }

            ticket.SlotNumber = slot;

            VehicleToTicketMapper[ticket.Vehicle] = ticket;

            if(AgeToTicketsMapper.ContainsKey(ticket.DriverAge))
            {
                AgeToTicketsMapper[ticket.DriverAge].Add(ticket);
            }
            else
            {
                AgeToTicketsMapper[ticket.DriverAge] = new List<ParkingTicket>() { ticket };
            }

            SlotToTicketMapper[slot] = ticket;

            Slots[slot - 1] = 1;

            _output.PrintLine(string.Format(Messages.CarParked, ticket.Vehicle.ToUpper(), ticket.SlotNumber));
         
            return true;
        }

        public bool VacateSlot(int slot)
        {
            if (Slots == null)
            {
                _output.PrintLine(Messages.CreateSlotsFirst);
                return false;
            }

            if (slot < 0 || slot-1 >= Slots.Length)
            {
                _output.PrintLine(Messages.InvalidSlotNumber);
                return false;
            }

            if(Slots[slot-1] == 0)
            {
                _output.PrintLine(Messages.AlreadyVacant);
                return false;
            }

            var ticket = SlotToTicketMapper[slot];

            VehicleToTicketMapper.Remove(ticket.Vehicle);
            SlotToTicketMapper.Remove(slot);
            AgeToTicketsMapper[ticket.DriverAge].Remove(ticket);

            Slots[slot - 1] = 0;
            _output.PrintLine(string.Format(Messages.SlotVacated, ticket.SlotNumber, ticket.Vehicle.ToUpper(), ticket.DriverAge));
            return true;
        }


        public ParkingTicket FindTicketForCar(string vehicle)
        {
            if (Slots == null)
            {
                _output.PrintLine(Messages.CreateSlotsFirst);
                return null;
            }

            vehicle = vehicle.Trim();

            if(!VehicleToTicketMapper.ContainsKey(vehicle))
            {
                _output.PrintLine(Messages.Null);
                return null;
            }

            var ticket = VehicleToTicketMapper[vehicle];

            return ticket;

        }

        public List<ParkingTicket> FindTicketsForAge(int age)
        {
            if (Slots == null)
            {
                _output.PrintLine(Messages.CreateSlotsFirst);
                return null;
            }

            if (!AgeToTicketsMapper.ContainsKey(age) || AgeToTicketsMapper[age].Count == 0)
            {
                _output.PrintLine(Messages.Null);
                return null;
            }

            var tickets = AgeToTicketsMapper[age];

            return tickets;

        }

        public static ParkingData Instance(IOutput output = null)
        {
            if(_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        if (output != null)
                        {
                            _instance = new ParkingData(output);
                        }
                        else
                        {
                            _instance = new ParkingData();
                        }
                    }
                }
            }
            
            return _instance;
        }


        /// <returns>First empty slot</returns>
        private int FindEmptySlot()
        {
            for(int i = 0; i < Slots.Length; i++)
            {
                if(Slots[i] == 0)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
