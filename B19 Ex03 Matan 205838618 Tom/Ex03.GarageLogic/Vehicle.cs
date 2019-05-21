using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyLeftByPercentages;
        protected Wheel[] m_Wheels;
        protected int m_NumberOfWheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentages, int i_NumberOfWheels/*, Wheel[] i_Wheels*/)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeftByPercentages = i_EnergyLeftByPercentages;
            m_NumberOfWheels = i_NumberOfWheels;

            //m_Wheels = new Wheel[i_NumberOfWheels];
            //for (int i = 0; i < i_NumberOfWheels; i++)
            //{
            //    m_Wheels[i] = new Wheel(i_Wheels[i].ManufactorName, i_Wheels[i].CurrentAirPressure, i_Wheels[i].MaxAirPressure);
            //}
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public int WheelsNumber
        {
            get { return m_NumberOfWheels; }
        }

        public float EnergyLeftByPercentages
        {
            get { return m_EnergyLeftByPercentages; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }
    }
}
