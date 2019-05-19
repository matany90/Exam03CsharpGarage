using System;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime, eLicenseTypes i_LicenseType, int i_EngineVolume) : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, i_MaxBatteryTime)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public override string ToString() 
        {
            string toShow = string.Format(
@"Model: {0}
License Number: {1}
Current Time Left: {2}
Max Battery Time: {3}
Energy left by %: {4}
", m_ModelName, m_LicenseNumber, m_BatteryTimeLeftByHours, m_MaxBatteryTime, m_EnergyLeftByPercentages);
            toShow += m_MotorcycleProperties.ToString();

            return toShow;
        }
    }
}
