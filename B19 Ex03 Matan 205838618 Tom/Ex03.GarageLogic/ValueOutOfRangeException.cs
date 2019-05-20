using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {

        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MaxValue, float i_MinValue) : base(string.Format("Error, the value is out of range between {0} and {1}", i_MinValue, i_MaxValue), i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
