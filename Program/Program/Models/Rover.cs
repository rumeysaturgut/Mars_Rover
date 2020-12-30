using Program.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class Rover
    {
        public Position Position { get; set; }

        public Rover(int x, int y, Direction d)
        {
            Position = new Position(x, y, d);
        }

        public Rover(string[] positionInformation)
        {
            // validate positionInformation
            Position = new Position(int.Parse(positionInformation[0]), int.Parse(positionInformation[1]),
                (Direction)Enum.Parse(typeof(Direction), positionInformation[2].ToUpper()));
        }

        public void RotateLeft()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Direction = Direction.W;
                    break;
                case Direction.W:
                    Position.Direction = Direction.S;
                    break;
                case Direction.S:
                    Position.Direction = Direction.E;
                    break;
                case Direction.E:
                    Position.Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Direction = Direction.E;
                    break;
                case Direction.E:
                    Position.Direction = Direction.S;
                    break;
                case Direction.S:
                    Position.Direction = Direction.W;
                    break;
                case Direction.W:
                    Position.Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Y += 1;
                    break;
                case Direction.S:
                    Position.Y -= 1;
                    break;
                case Direction.E:
                    Position.X += 1;
                    break;
                case Direction.W:
                    Position.X -= 1;
                    break;
                default:
                    break;
            }
        }

    }
}
