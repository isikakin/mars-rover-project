using MarsRover.Enums;
using System;
using System.Linq;
using System.Threading;

namespace MarsRover
{
    public class Rover : Vehicle
    {
        public Rover()
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = RoverDirection.N;
        }

        public Rover(int x, int y, RoverDirection roverDirection)
        {
            this.X = x;
            this.Y = y;
            this.Direction = roverDirection;
        }

        protected override void Move(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.L:
                    Turn(movementType);
                    break;
                case MovementType.R:
                    Turn(movementType);
                    break;
                case MovementType.M:
                    Go();
                    break;
                default:
                    break;
            }
        }

        public override void Move(string movement)
        {
            for (int i = 0; i <= movement.Length - 1; i++)
            {
                Move((MovementType)Enum.Parse(typeof(MovementType), movement[i].ToString()));
            }
        }

        protected override void Go()
        {
            var control = Area.flagAreas.Any(x => x.X == X && x.y == Y && x.Direction == Direction);
            if (control || RIP)
            {
                return;
            }

            int previousX = X;
            int previousY = Y;

            switch (Direction)
            {
                case RoverDirection.N:
                    Y++;
                    break;
                case RoverDirection.S:
                    Y--;
                    break;
                case RoverDirection.W:
                    X--;
                    break;
                case RoverDirection.E:
                    X++;
                    break;
                default:
                    break;
            }

            if (X < 0 || X > Area.MaxX || Y < 0 || Y > Area.MaxY)
            {
                Area.flagAreas.Add(new FlagArea
                {
                    X = previousX,
                    Direction = Direction,
                    y = previousY
                });
                RIP = true;
                //throw new InvalidOperationException("Rover Position can not be bigger than max positions!");
            }
        }

        protected override void Turn(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.L:
                    Direction = (RoverDirection)((4 + (int)Direction - 1) % 4);
                    break;
                case MovementType.R:
                    Direction = (RoverDirection)(((int)Direction + 1) % 4);
                    break;
                default:
                    break;
            }
        }
    }
}

