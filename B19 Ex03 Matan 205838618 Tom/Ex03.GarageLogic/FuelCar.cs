using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;

        public FuelCar(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity, eCarColor i_CarColor, eDoorsNumber i_DoorsNumber, int i_NumberOfWheels, Wheel i_Wheel)
            : base(i_ModelName, i_LicenseNumber, i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity, i_NumberOfWheels, i_Wheel)
        {
            m_CarProperties = new CarProperties(i_CarColor, i_DoorsNumber);
        }

        public override string ToString() // to delete
        {
             string toShow = string.Format(
@"Model: {0}
License Number: {1}
Fuel type: {2}
Current Fuel Quantity: {3}
Max Fuel Quantity: {4}
Energy left by %: {5}
", m_ModelName, m_LicenseNumber, m_FuelType, m_CurrentFuelQuantity, m_MaxFuelQuantity,  m_EnergyLeftByPercentages);
            toShow += m_CarProperties.ToString() + Environment.NewLine;

            return toShow;
        }

        public CarProperties CarProperties
        {
            get { return m_CarProperties; }
        }
    }
}
