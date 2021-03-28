using ParkingLot.Comman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Storage
{
    public interface IParkingData
    {
        /// <summary>
        /// number of slots in the parking lot
        /// </summary>
        int SlotsLength { get; }

        /// <summary>
        /// Creates a number of slots available for parking
        /// </summary>
        /// <param name="slots"></param>
        /// <returns>true if the slots were successfully created and false otherwise</returns>
        bool CreateParkingLot(int slots);

        /// <summary>
        /// Associates a valid slot number to the parking ticket and add it in the system
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>true if the vehicle is suitable for parking and false otherwise</returns>
        bool AddTicket(ParkingTicket ticket);

        /// <summary>
        /// Vacates the slot when vehicle is removed from the parking lot
        /// </summary>
        /// <param name="slot"></param>
        /// <returns>true if the slot is vacated successfully and false otherwise</returns>
        bool VacateSlot(int slot);

        /// <summary>
        /// Gets the parking ticket for the car from the database
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>parking ticket for the car with the vehicle number</returns>
        ParkingTicket FindTicketForCar(string vehicle);

        /// <summary>
        /// Gets the list of all the parking tickets whose driver is of specific age
        /// </summary>
        /// <param name="age"></param>
        /// <returns>a list of all the parking tickets of the vehicles whose driver has a particular age</returns>
        List<ParkingTicket> FindTicketsForAge(int age);
    }
}
