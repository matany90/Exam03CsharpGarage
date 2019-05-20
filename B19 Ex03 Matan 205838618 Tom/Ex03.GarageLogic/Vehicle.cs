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
        protected List<Wheel> m_Wheels = new List<Wheel>();

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentages)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeftByPercentages = i_EnergyLeftByPercentages;
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public List<Wheel> Wheels
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
