using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class VehiclesForAge : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public VehiclesForAge()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public VehiclesForAge(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }


        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "vehicle_registration_number_for_driver_of_age")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 2)
            {
                _output.PrintLine(Messages.VehiclesForAgeInvalidArgument);
                return;
            }

            var parsed = int.TryParse(args[1].Trim().ToLower(), out var driverAge);

            if (!parsed)
            {
                _output.PrintLine(Messages.InvalidAge);
                return;
            }

            var vehicles = _ticketRepo.FindVehiclesForDriverAge(driverAge);

            if(vehicles != null)
            {
                vehicles = vehicles.Select(v => v.ToUpper()).ToArray();

                _output.PrintLine(string.Join(",", vehicles));
            }
        }
    }
}
