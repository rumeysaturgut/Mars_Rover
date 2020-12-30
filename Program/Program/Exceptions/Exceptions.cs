using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Exceptions
{
    public class EnteredBoundariesCouldNotBeNullException : Exception
    {
        public EnteredBoundariesCouldNotBeNullException() : base("Entered boundaries could not be null!")
        {

        }
    }

    public class TwoValuesMustBeEnteredException : Exception
    {
        public TwoValuesMustBeEnteredException() : base("Two values must be entered!")
        {

        }
    }

    public class BoundariesMustBeNumericException : Exception
    {
        public BoundariesMustBeNumericException() : base("Boundaries must be numeric values!")
        {

        }
    }

    public class InvalidTypeOfValuesException : Exception
    {
        public InvalidTypeOfValuesException() : base("Boundaries must be numeric values!")
        {

        }
    }

    public class ThreeValuesMustBeEnteredException : Exception
    {
        public ThreeValuesMustBeEnteredException() : base("Three values must be entered!")
        {

        }
    }

    public class ThisLocationIsNotAvailable : Exception
    {
        public ThisLocationIsNotAvailable() : base("This location is not available!")
        {

        }
    }

    public class RoverLocationMustBeInRangeException : Exception
    {
        public RoverLocationMustBeInRangeException() : base("Rover's location must be in range!")
        {

        }
    }
}
