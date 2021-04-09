﻿using MarsRover.Enums;

namespace MarsRover
{
    public abstract class Vehicle
    {
        protected string Name { get; set; }
        protected int X { get; set; }
        protected int Y { get; set; }

        public bool RIP { get; set; }
        protected RoverDirection Direction { get; set; }

        public abstract void Move(string movement);
        protected abstract void Move(MovementType movementType);
        protected abstract void Go();
        protected abstract void Turn(MovementType movementType);

        public override string ToString()
        {
            return $"{this.X} - {this.Y} - {this.Direction}";
        }
    }
}
