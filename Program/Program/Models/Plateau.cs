using Program.Enumerations;
using Program.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class Plateau
    {
        public int UpperBound { get; set; }
        public int LowerBound { get; set; }
        public List<Rover> Rovers { get; private set; }

        // 5 5 
        public Plateau(string enteredBoundaries)
        {
            // Validate enteredBoundaries 
            if (string.IsNullOrEmpty(enteredBoundaries))
            {
                throw new EnteredBoundariesCouldNotBeNullException();
            }

            var boundaries = enteredBoundaries.Trim().Split(' ');

            if (boundaries.Length != 2)
            {
                throw new TwoValuesMustBeEnteredException();
            }

            int upperBound = 0, lowerBound;
            if (!Int32.TryParse(boundaries[0], out lowerBound) || !Int32.TryParse(boundaries[1], out upperBound))
            {
                throw new BoundariesMustBeNumericException();
            }

            if (upperBound == 0 || lowerBound == 0)
            {
                throw new InvalidTypeOfValuesException();
            }

            LowerBound = lowerBound;
            UpperBound = upperBound;
            Rovers = new List<Rover>();
        }

        // 1 2 N
        public Rover DeployRover(string deployPositions)
        {
            // validate deployPositions
            if (string.IsNullOrEmpty(deployPositions))
            {
                throw new EnteredBoundariesCouldNotBeNullException();
            }

            string[] positionInformation = deployPositions.Trim().Split(' ');
            // x = y
            // d valid ? // throw an exception

            if (int.Parse(positionInformation[0]) > UpperBound || int.Parse(positionInformation[1]) > LowerBound)
            {
                throw new RoverLocationMustBeInRangeException();
            }

            if (positionInformation.Length != 3)
            {
                throw new TwoValuesMustBeEnteredException();
            }

            int coordinateX;
            int coordinateY;
            if (!positionInformation[2].All(Char.IsLetter) || !Int32.TryParse(positionInformation[0], out coordinateX) || !Int32.TryParse(positionInformation[1], out coordinateY))
            {
                throw new InvalidTypeOfValuesException();
            }

            if(!IsInBoundaries(coordinateX, coordinateY))
            {
                throw new RoverLocationMustBeInRangeException();
            }

            if (!HasAnyRoverInCurrentPosition(Int32.Parse(positionInformation[0]), Int32.Parse(positionInformation[1]), (Direction)Enum.Parse(typeof(Direction), positionInformation[2].ToUpper())))
            {
                return new Rover(positionInformation);
            }
            else
                throw new ThisLocationIsNotAvailable();
        }

        public void Run(Rover rover, string instructions)
        {
            Rover tempRover = new Rover(rover.Position.X, rover.Position.Y, rover.Position.Direction);
            foreach (char c in instructions.ToUpper())
            {
                switch (c)
                {
                    case 'L':
                        tempRover.RotateLeft();
                        break;
                    case 'R':
                        tempRover.RotateRight();
                        break;
                    case 'M':
                        tempRover.MoveForward();
                        break;
                }
            }

            if (!HasAnyRoverInCurrentPosition(tempRover.Position.X, tempRover.Position.Y, tempRover.Position.Direction) && IsInBoundaries(tempRover.Position.X, tempRover.Position.Y))
            {
                Rovers.Add(tempRover);
                Console.WriteLine(tempRover.Position.X + " " + tempRover.Position.Y + " " + tempRover.Position.Direction);
            }
            else
                throw new ThisLocationIsNotAvailable();

        }

        public bool HasAnyRoverInCurrentPosition(int x, int y, Direction d)
        {
            return Rovers.Any(r => r.Position.X == x && r.Position.Y == y && r.Position.Direction == d);
        }

        private bool IsInBoundaries(int x, int y)
        {
            return 0 <= x && x <= LowerBound && 0 <= y && y <= UpperBound;

        }
    }
}
