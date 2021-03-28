using ParkingLot.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var inputFile = dir + "input.txt";

            var handler = new CommandHandler();

            using (StreamReader sr = new StreamReader(inputFile))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    handler.HandleCommand(line);
                }
            }

            Console.ReadKey();
  
        }
    }
}
