using MarsRover.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MarsRover.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        const string expected = "1 - 3 - N";
        const string expected2 = "5 - 1 - E";
        const string expected3 = "1 - 3 - N\r\n5 - 1 - E";

        [DataTestMethod]
        [DataRow(1, 2, RoverDirection.N, "LMLMLMLMM", expected)]
        [DataRow(3, 3, RoverDirection.E, "MMRMMRMRRM", expected2)]
        public void Scenerio1(int x, int y, RoverDirection startPosition, string movements, string expected)
        {
            Area.MaxX = 5;
            Area.MaxY = 5;

            Rover rover = new Rover(x, y, startPosition);
            VehicleCommander commander = new VehicleCommander();

            commander.Add(rover, movements);
            commander.ExecuteCommand();
            Assert.AreEqual(expected, rover.ToString());
        }

        [TestMethod()]
        public void Scenerio2()
        {
            Area.MaxX = 5;
            Area.MaxY = 5;
            Rover rover1 = new Rover (1, 2, RoverDirection.N);
            Rover rover2 = new Rover(3, 3, RoverDirection.E );

            VehicleCommander commander = new VehicleCommander();
            commander.Add(rover1, "LMLMLMLMM");
            commander.Add(rover2, "MMRMMRMRRM");
            commander.ExecuteCommand();

            Assert.AreEqual(expected3, commander.GetAllVehiclesLastPositions());
        }

        [TestMethod()]
        public void FailScenerio1()
        {
            Area.MaxX = 5;
            Area.MaxY = 5;
            Rover rover = new Rover(3, 3, RoverDirection.E);

            VehicleCommander commander = new VehicleCommander();
            commander.Add(rover, "MMMMMMMMMMMMMMMMMMMMMMMMMMMM");
            commander.ExecuteCommand();

            Assert.IsTrue(Area.flagAreas.Any());
        }
    }
}