using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Output : IOutput
    {
        public void PrintLine(object text)
        {
            Console.WriteLine(text.ToString());
        }
    }
}
