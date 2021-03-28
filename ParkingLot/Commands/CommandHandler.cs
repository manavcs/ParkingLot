using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Commands
{
    /// <summary>
    /// Listens to all sorts of commands in the parking system
    /// </summary>
    public class CommandHandler
    {
        public void HandleCommand(string command)
        {
            var args = command.Trim().ToLower().Split(' ').Where(arg=>!string.IsNullOrEmpty(arg)).ToArray();

            switch(args[0])
            {
                case "park":
                    var park = new Park();
                    park.Execute(args);
                    break;
                case "slot_numbers_for_driver_of_age":
                    var slotForAge = new SlotsForAge();
                    slotForAge.Execute(args);
                    break;
                case "slot_number_for_car_with_number":
                    var slotForCar = new SlotForCar();
                    slotForCar.Execute(args);
                    break;
                case "vehicle_registration_number_for_driver_of_age":
                    var vehiclesForAge = new VehiclesForAge();
                    vehiclesForAge.Execute(args);
                    break;
                case "leave":
                    var leave = new LeaveSlot();
                    leave.Execute(args);
                    break;
                case "show_commands":
                    var show = new ShowCommands();
                    show.Execute(args);
                    break;
                case "create_parking_lot":
                    var create = new CreateParkingLot();
                    create.Execute(args);
                    break;
                default:
                    Console.WriteLine("Incorrect command! type show_commands to get the list of all supported commands");
                    break;

            }
        }
    }
}
