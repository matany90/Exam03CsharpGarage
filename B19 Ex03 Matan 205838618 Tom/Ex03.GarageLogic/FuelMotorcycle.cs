using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelMotorcycle : FuelVehicle
    {
        private MotorcycleProperties m_MotorcycleProperties;

        public FuelMotorcycle(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity, eLicenseTypes i_LicenseType, int i_EngineVolume, int i_NumberOfWheels, Wheel i_Wheel)
            : base(i_ModelName, i_LicenseNumber, i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity, i_NumberOfWheels, i_Wheel)
        {
            m_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
        }

        public override string ToString()
        {
            string toShow = string.Format(
@"Model: {0}
License Number: {1}
Fuel type: {2}
Current Fuel Quantity: {3}
Max Fuel Quantity: {4}
Energy left by %: {5}
", m_ModelName, m_LicenseNumber, m_FuelType, m_CurrentFuelQuantity, m_MaxFuelQuantity, m_EnergyLeftByPercentages);
            toShow += m_MotorcycleProperties.ToString() + Environment.NewLine;

            return toShow;
        }

        public MotorcycleProperties MotorcycleProperties
        {
            get { return m_MotorcycleProperties; }
        }

    }
}
