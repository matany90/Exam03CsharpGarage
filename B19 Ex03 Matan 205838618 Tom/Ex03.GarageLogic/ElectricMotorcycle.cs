using System;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentage, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime, eLicenseTypes i_LicenseType, int i_EngineVolume) : base(i_ModelName, i_LicenseNumber, i_EnergyLeftByPercentage, i_BatteryTimeLeftByHours, i_MaxBatteryTime)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public override void show() // to delete
        {
            Console.WriteLine(
@"Model: {0}
License Number: {1}
Current Time Left: {3}
Max Battery Time: {4}
Energy left by %: {5}
", m_ModelName, m_LicenseNumber, m_BatteryTimeLeftByHours, m_MaxBatteryTime, m_EnergyLeftByPercentages);
        }
    }
}
