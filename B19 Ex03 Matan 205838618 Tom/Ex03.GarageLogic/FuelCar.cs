using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;

        public FuelCar(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity, CarProperties i_CarProperties)
            : base(i_ModelName, i_LicenseNumber, i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity)
        {
            m_CarProperties = i_CarProperties;
        }

        public override void show() // to delete
        {
            Console.WriteLine(
@"Model: {0}
License Number: {1}
Fuel type: {2}
Current Fuel Quantity: {3}
Max Fuel Quantity: {4}
Energy left by %: {5}
Car Properties:
Car Color: {6}
Car Doors Number: {7}
", m_ModelName, m_LicenseNumber, m_FuelType, m_CurrentFuelQuantity, m_MaxFuelQuantity,  m_EnergyLeftByPercentages, m_CarProperties.CarColor, m_CarProperties.DoorsNumber);
        }
    }
}
