using ParkingLot.Comman;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class CreateParkingLot : IParkingCommand
    {
        private readonly ITicketRepo _ticketRepo;
        private IOutput _output;
        public CreateParkingLot()
        {
            _ticketRepo = new TicketRepo();
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public CreateParkingLot(ITicketRepo ticketRepo, IOutput output)
        {
            _ticketRepo = ticketRepo;
            _output = output;
        }

        public void Execute(string[] args)
        {
            if(args[0].Trim().ToLower() != "create_parking_lot")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            if (args.Length != 2)
            {
                _output.PrintLine(Messages.CreateParkingLotInvalidArgument);
                return;
            }

            var parsed = int.TryParse(args[1].Trim().ToLower(), out var numOfSlots);

            if (!parsed)
            {
                _output.PrintLine(Messages.CreateSlotInvalidSlotNumber);
                return;
            }

            _ticketRepo.CreateParkingSlot(numOfSlots);
        }
    }
}
