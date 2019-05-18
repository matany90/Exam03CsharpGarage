using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : FuelVehicle
    {
        protected bool m_IsTransferHazardousMaterials;
        protected int m_TruckLoadSize;

        public Truck(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity, bool i_IsTransferHazardousMaterials, int i_TruckLoadSize)
    : base(i_ModelName, i_LicenseNumber, i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity)
        {
            m_IsTransferHazardousMaterials = i_IsTransferHazardousMaterials;
            m_TruckLoadSize = i_TruckLoadSize;
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
Truck:
Transfer Hazardous Materials: {6}
Load Size: {7}
", m_ModelName, m_LicenseNumber, m_FuelType, m_CurrentFuelQuantity, m_MaxFuelQuantity, m_EnergyLeftByPercentages, m_IsTransferHazardousMaterials, m_TruckLoadSize);
        }
    }
}
