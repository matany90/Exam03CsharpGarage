using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
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

        public abstract void show(); //to delete
    }
}
