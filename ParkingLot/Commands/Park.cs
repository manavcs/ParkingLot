using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class Park : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public Park()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public Park(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }

        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "park")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 4 || args[2].Trim().ToLower() != "driver_age")
            {
                _output.PrintLine(Messages.ParkInvalidArgument);
                return;
            }

            var vehicleNumber = args[1].Trim().ToLower();

            if(!Utility.ValidateVehicleNumber(vehicleNumber))
            {
                _output.PrintLine(Messages.InvalidVehicleNumber);
                return;
            }

            var parsed = int.TryParse(args[3].Trim().ToLower(), out var driverAge);

            if(!parsed)
            {
                _output.PrintLine(Messages.InvalidAge);
                return;
            }

            _ticketRepo.AddTicket(vehicleNumber, driverAge);
        }

       
    }
}
