using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Comman
{
    public class Messages
    {
        #region Commands
        public static string ParkInvalidArgument = "Invalid format for park, for example, the right format is 'park KA-01-HH-1234 driver_age 21'";
        public static string InvalidVehicleNumber = "Invalid format for vehicle number, for example, the right format will be KA-01-HH-1234'";
        public static string InvalidAge = "Invalid age for driver, Also make sure that age can not be greater than 150'";
        public static string SlotsForAgeInvalidArgument = "Invalid format for slot_numbers_for_driver_of_age, for example, the right format is 'slot_numbers_for_driver_of_age 21'";
        public static string VehiclesForAgeInvalidArgument = "Invalid format for vehicle_registration_number_for_driver_of_age, for example, the right format is 'vehicle_registration_number_for_driver_of_age 21'";
        public static string SlotForCarInvalidArgument = "Invalid format for slot_number_for_car_with_number, for example, the right format is 'slot_number_for_car_with_number PB-01-HH-1234'";
        public static string LeaveSlotInvalidArgument = "Invalid format for leave, for example, the right format is 'leave 2(slotnumber)'";
        public static string InvalidSlotNumber = "Invalid slot number";
        public static string CreateSlotInvalidSlotNumber = "Invalid slot number, can not create slots";
        public static string CreateParkingLotInvalidArgument = "Invalid format for create_parking_lot, for example, the right format is 'create_parking_lot 6(the number of slots)'";
        #endregion

        #region ParkingData
        public static string SlotsAlreadtCreated = "Slots already created";
        public static string CreateSlotsFirst = "Slots are not created, please create slots first";
        public static string SlotsFull = "Parking is Full, no empty slot available";
        public static string AlreadyParked = "Invalid parking, Vehicle is already parked";
        public static string AlreadyVacant = "Slot already vacant";
        public static string NotParked = "Vehicle is not parked yet";
        public static string NoVehicleIsParkedWithAge = "No vehicle is parked with this driver age";
        public static string CarParked = "Car with vehicle registration number \"{0}\" has been parked at slot number {1}";
        public static string SlotsCreated = "Created parking of {0} slots";
        public static string SlotVacated = "Slot number {0} vacated, the car with registration number \"{1}\" left the space, the driver of the car was of age {2}";

        #endregion

        public static string Null = "null";
        public static string ShowCommand = "Incorrect command! type show_commands to get the list of all supported commands";
    }
}
