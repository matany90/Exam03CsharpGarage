using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : FuelVehicle
    {
        private bool? m_IsTransferHazardousMaterials;
        private int m_TruckLoadSize;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, bool i_IsTransferHazardousMaterials, int i_TruckLoadSize/*,*//* Wheel[] i_Wheels*/)
    : base(i_ModelName, i_LicenseNumber, eFuelType.Soler, i_CurrentFuelQuantity, 110f, 12/*, i_Wheels*/)
        {
            m_IsTransferHazardousMaterials = i_IsTransferHazardousMaterials;
            m_TruckLoadSize = i_TruckLoadSize;
            //m_Wheels = i_Wheels;
        }


        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(bool), typeof(int), typeof(Truck) };

            return types;
        }

        public override string ToString() // to delete
        {
            return (string.Format(
@"Model: {0}
License Number: {1}
Fuel type: {2}
Current Fuel Quantity: {3}
Max Fuel Quantity: {4}
Energy left by %: {5}
Truck Properties:
Transfer Hazardous Materials: {6}
Load Size: {7}
", m_ModelName, m_LicenseNumber, m_FuelType, m_CurrentFuelQuantity, m_MaxFuelQuantity, m_EnergyLeftByPercentages, m_IsTransferHazardousMaterials, m_TruckLoadSize));
        }
    }
}
