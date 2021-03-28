using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class LeaveSlot : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public LeaveSlot()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public LeaveSlot(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }

        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "leave")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 2)
            {
                _output.PrintLine(Messages.SlotForCarInvalidArgument);
                return;
            }

            var parsed = int.TryParse(args[1].Trim().ToLower(), out var slot);

            if (!parsed)
            {
                _output.PrintLine(Messages.InvalidSlotNumber);
                return;
            }

            _ticketRepo.LeaveSlot(slot);
        }
    }
}
