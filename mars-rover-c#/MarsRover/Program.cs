using MarsRover.Enums;
using System;
using System.Linq;

namespace MarsRover
{
    static class Program
    {
        static void Main()
        {

            VehicleCommander commander = new VehicleCommander();

            Area.MaxX = 5;
            Area.MaxY = 5;

            Rover rover1 = new Rover(1, 2, RoverDirection.N);
            Rover rover2 = new Rover(3, 3, RoverDirection.E);

            commander.Add(rover1, "LMLMLMLMM");
            commander.Add(rover2, "MMRMMRMRRM");

            commander.ExecuteCommand();

            Console.WriteLine(rover1.ToString());
            Console.WriteLine(rover2.ToString());
        }
    }
}
