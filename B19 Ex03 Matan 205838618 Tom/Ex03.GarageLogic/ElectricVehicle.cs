using System;

namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryTimeLeftByHours;
        protected float m_MaxBatteryTime;

        public ElectricVehicle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime, int i_NumberOfWheels, Wheel[] i_Wheel) 
            : base(i_ModelName, i_LicenseNumber, 100 * (i_BatteryTimeLeftByHours / i_MaxBatteryTime), i_NumberOfWheels, i_Wheel)
        {
            m_BatteryTimeLeftByHours = i_BatteryTimeLeftByHours;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBattery(float i_AmountToAdd)
        {
            if (m_BatteryTimeLeftByHours + i_AmountToAdd > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException("");//Add Exception
            }
            else
            {
                m_BatteryTimeLeftByHours += i_AmountToAdd;
                m_EnergyLeftByPercentages = (m_BatteryTimeLeftByHours / m_MaxBatteryTime) * 100; 
            }
        }
    }
}
