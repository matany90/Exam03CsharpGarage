using System;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftByPercentage, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime) : base(i_ModelName, i_LicenseNumber, i_EnergyLeftByPercentage, i_BatteryTimeLeftByHours, i_MaxBatteryTime)
        {
            
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
