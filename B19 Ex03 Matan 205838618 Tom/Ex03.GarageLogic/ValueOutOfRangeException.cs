using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {

        }

        public ValueOutOfRangeException(string i_Message, Exception innerException)
    : base(i_Message, innerException) { }
    }
}
