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

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentages, int i_NumberOfWheels, Wheel[] i_Wheel)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeftByPercentages = i_EnergyLeftByPercentages;
            m_Wheels = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_Wheel[i].ManufactorName, i_Wheel[i].CurrentAirPressure, i_Wheel[i].MaxAirPressure);
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
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
