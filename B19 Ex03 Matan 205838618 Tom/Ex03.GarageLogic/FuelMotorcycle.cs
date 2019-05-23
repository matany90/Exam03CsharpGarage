using System;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelQuantity = 8f;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxWheelAirPressure = 33f;
        private MotorcycleProperties m_MotorcycleProperties;

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, eLicenseTypes i_LicenseType, int i_EngineVolume, Wheel[] i_Wheel)
            : base(i_ModelName, i_LicenseNumber, k_FuelType, i_CurrentFuelQuantity, k_MaxFuelQuantity, k_NumberOfWheels, i_Wheel, k_MaxWheelAirPressure)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public override string ToString() 
        {
            string fuelMotorcycleInfo = base.ToString() + Environment.NewLine + m_MotorcycleProperties.ToString();

            return fuelMotorcycleInfo;
        }

        public MotorcycleProperties MotorcycleProperties
        {
            get { return m_MotorcycleProperties; }
        }
    }
}
