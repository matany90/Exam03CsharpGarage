using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelMotorcycle : FuelVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, eLicenseTypes i_LicenseType, int i_EngineVolume, Wheel[] i_Wheel)
            : base(i_ModelName, i_LicenseNumber, eFuelType.Octan95, i_CurrentFuelQuantity, 8f, 2, i_Wheel)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(eLicenseTypes), typeof(int), typeof(FuelMotorcycle) };

            return types;
        }

        public override string ToString() // to delete
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
