using System;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        private CarProperties m_CarProperties;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, float i_MaxBatteryTime, eCarColor i_Color, eDoorsNumber i_DoorNumber) : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, i_MaxBatteryTime)
        {
            m_CarProperties = new CarProperties(i_Color, i_DoorNumber);
        }

        public override string ToString() // to delete
        {
            string toShow = string.Format(
@"Model: {0}
License Number: {1}
Current Time Left: {2}
Max Battery Time: {3}
Energy left by %: {4}
", m_ModelName, m_LicenseNumber, m_BatteryTimeLeftByHours, m_MaxBatteryTime, m_EnergyLeftByPercentages);
            toShow += m_CarProperties.ToString() + Environment.NewLine;

            return toShow;
        }
    }
}
