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
        protected float m_VehicleMaxWheelAirPressure;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentages, int i_NumberOfWheels, Wheel[] i_Wheels, float i_VehicleMaxWheelAirPressure)
        {
            m_VehicleMaxWheelAirPressure = i_VehicleMaxWheelAirPressure;
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeftByPercentages = i_EnergyLeftByPercentages;
            m_Wheels = i_Wheels;
            m_NumberOfWheels = i_NumberOfWheels;
            foreach (Wheel wheel in m_Wheels)
            {
                if (wheel.MaxAirPressure > m_VehicleMaxWheelAirPressure)
                {
                    throw new ValueOutOfRangeException(null, m_VehicleMaxWheelAirPressure, 0);
                }
            }
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

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public override string ToString()
        {
            string vehicleInfo = string.Format(
@"Wheels Info:
Model: {0}
License Number: {1}
Energy left by %: {2}

Wheels Info:
Number of wheels: {3} 
", 
m_ModelName, 
m_LicenseNumber, 
m_EnergyLeftByPercentages, 
m_NumberOfWheels);
            int wheelIndex = 1;
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleInfo += "Wheel number " + wheelIndex + ":" + Environment.NewLine + wheel.ToString() + Environment.NewLine;
                wheelIndex++;
            }

            return vehicleInfo;
        }
    }
}
