using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class SlotsForAge : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public SlotsForAge()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public SlotsForAge(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }

        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "slot_numbers_for_driver_of_age")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 2)
            {
                _output.PrintLine(Messages.SlotsForAgeInvalidArgument);
                return;
            }

            var parsed = int.TryParse(args[1].Trim().ToLower(), out var driverAge);

            if (!parsed)
            {
                _output.PrintLine(Messages.InvalidAge);
                return;
            }

            var slots = _ticketRepo.FindSlotsForDriverAge(driverAge);

            if(slots != null)
            {
                _output.PrintLine(string.Join(",", slots));
            }
        }
    }
}
