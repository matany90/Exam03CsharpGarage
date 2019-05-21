using System;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eLicenseTypes i_LicenseType, int i_EngineVolume/*,*/ /*Wheel[] i_Wheels*/) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, 1.4f, 2/*, i_Wheels*/)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }


        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(eLicenseTypes), typeof(int), typeof(ElectricMotorcycle) };

            return types;
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
            toShow += m_MotorcycleProperties.ToString() + Environment.NewLine;

            return toShow;
        }
    }
}
