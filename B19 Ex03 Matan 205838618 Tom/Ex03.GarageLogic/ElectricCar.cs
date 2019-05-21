using System;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        private CarProperties m_CarProperties;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eCarColor i_Color, eDoorsNumber i_DoorNumber/*, Wheel i_Wheels*/) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, 1.8f, 2/*, i_Wheels*/)
        {
            m_CarProperties = new CarProperties(i_Color, i_DoorNumber);
        }

        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(eCarColor), typeof(eDoorsNumber), typeof(ElectricCar) };

            return types;
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
