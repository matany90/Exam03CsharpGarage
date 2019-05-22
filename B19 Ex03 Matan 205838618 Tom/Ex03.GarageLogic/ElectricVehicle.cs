using System;

namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryTimeLeftByHours;
        protected float m_MaxBatteryTime;

        public ElectricVehicle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime, int i_NumberOfWheels, Wheel[] i_Wheels, float i_VehicleMaxWheelAirPressure) 
            : base(i_ModelName, i_LicenseNumber, 100 * (i_BatteryTimeLeftByHours / i_MaxBatteryTime), i_NumberOfWheels, i_Wheels, i_VehicleMaxWheelAirPressure)
        {
            m_BatteryTimeLeftByHours = i_BatteryTimeLeftByHours;
            m_MaxBatteryTime = i_MaxBatteryTime;
            if (m_MaxBatteryTime < m_BatteryTimeLeftByHours)
            {
                throw new ValueOutOfRangeException(null, m_MaxBatteryTime, 0);
            }
        }

        public void ChargeBattery(float i_AmountToAdd)
        {
            if (m_BatteryTimeLeftByHours + i_AmountToAdd > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(null, m_MaxBatteryTime, 0);
            }
            else
            {
                m_BatteryTimeLeftByHours += i_AmountToAdd;
                m_EnergyLeftByPercentages = (m_BatteryTimeLeftByHours / m_MaxBatteryTime) * 100; 
            }
        }

        public override string ToString()
        {
            string electricVehicleInfo = string.Format(
@"{0}
Electric Info:
Current Time Left: {1}
Max Battery Time: {2}", base.ToString(), m_BatteryTimeLeftByHours, m_MaxBatteryTime);

            return electricVehicleInfo;
        }
    }
}
