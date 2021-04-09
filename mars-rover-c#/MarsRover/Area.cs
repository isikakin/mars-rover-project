using MarsRover.Enums;
using System.Collections.Generic;

namespace MarsRover
{
    public static class Area
    {

        public static int MaxX { get; set; }
        public static int MaxY { get; set; }

        public static List<FlagArea> flagAreas { get; set; }

        static Area()
        {
            flagAreas = new List<FlagArea>();
        }
    }

    public class FlagArea
    {
        public int X { get; set; }
        public int y { get; set; }
        public RoverDirection Direction { get; set; }
    }
}
