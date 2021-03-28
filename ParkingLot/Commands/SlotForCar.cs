using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class SlotForCar : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public SlotForCar()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public SlotForCar(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }

        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "slot_number_for_car_with_number")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 2)
            {
                _output.PrintLine(Messages.SlotForCarInvalidArgument);
                return;
            }

            var vehicleNumber = args[1].ToLower().Trim();

            if (!Utility.ValidateVehicleNumber(vehicleNumber))
            {
                _output.PrintLine(Messages.InvalidVehicleNumber);
                return;
            }

            var slot = _ticketRepo.FindSlotForCar(vehicleNumber);

            if(slot != -1)
            {
                _output.PrintLine(slot);
            }
        }
    }
}
