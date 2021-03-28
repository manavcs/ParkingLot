using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingLot.Comman
{
    public class Utility
    {
        public static bool ValidateVehicleNumber(string vehicleNumber)
        {
            var regex = new Regex("^[a-z]{2}-[0-9]{2}-[a-z]{2}-[0-9]{4}$");

            return regex.IsMatch(vehicleNumber);
        }
    }
}
