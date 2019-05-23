using System;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.8f;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxWheelAirPressure = 31f;
        private CarProperties m_CarProperties;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eCarColor i_Color, eDoorsNumber i_DoorNumber, Wheel[] i_Wheels) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, k_MaxBatteryTime, k_NumberOfWheels, i_Wheels, k_MaxWheelAirPressure)
        {
            m_CarProperties = new CarProperties(i_Color, i_DoorNumber);
        }

        public override string ToString() 
        {
            string electricCarInfo = base.ToString() + Environment.NewLine + m_CarProperties.ToString();

            return electricCarInfo;
        }
    }
}
