using System;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.4f;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxWheelAirPressure = 33f;
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eLicenseTypes i_LicenseType, int i_EngineVolume, Wheel[] i_Wheels) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, k_MaxBatteryTime, k_NumberOfWheels, i_Wheels, k_MaxWheelAirPressure)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public override string ToString() // to delete
        {
            string electricMotorcycleInfo = base.ToString() + Environment.NewLine + m_MotorcycleProperties.ToString();

            return electricMotorcycleInfo;
        }
    }
}
