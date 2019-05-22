using System;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eLicenseTypes i_LicenseType, int i_EngineVolume, Wheel[] i_Wheels) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, 1.4f, 2, i_Wheels, 33f)
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
