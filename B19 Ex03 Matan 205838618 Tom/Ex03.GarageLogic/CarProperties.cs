using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class CarProperties
    {
        private eCarColor m_CarColor;
        private eDoorsNumber m_DoorsNumber;

        public CarProperties(eCarColor i_CarColor, eDoorsNumber i_DoorsNumber)
        {
            m_CarColor = i_CarColor;
            m_DoorsNumber = i_DoorsNumber;
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }

        public override string ToString()
        {
            string toShow = string.Format(
@"Car Properties:
Car Color: {0}
Car Doors Number: {1}", m_CarColor, m_DoorsNumber);

            return toShow;
        }
    }
}
