using ParkingLot.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    public class ShowCommands : IParkingCommand
    {
        private IOutput _output;
        public ShowCommands()
        {
            _output = new Output();
        }

        /// <summary>
        /// for testing purpose
        /// </summary>
        public ShowCommands(IOutput output)
        {
            _output = output;
        }

        public void Execute(string[] args)
        {
            if (args[0].Trim().ToLower() != "show_command")
            {
                _output.PrintLine(Messages.ShowCommand);
                return;
            }

            _output.PrintLine("park, slot_numbers_for_driver_of_age, slot_number_for_car_with_number, vehicle_registration_number_for_driver_of_age, leave");
        }

    }
}
