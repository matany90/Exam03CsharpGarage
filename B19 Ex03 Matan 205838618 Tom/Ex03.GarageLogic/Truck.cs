using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuelQuantity = 110f;
        private const int k_NumberOfWheels = 12;
        private const float k_MaxWheelAirPressure = 26f;
        private bool? m_IsTransferHazardousMaterials;
        private int m_TruckLoadSize;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, bool i_IsTransferHazardousMaterials, int i_TruckLoadSize, Wheel[] i_Wheels)
    : base(i_ModelName, i_LicenseNumber, k_FuelType, i_CurrentFuelQuantity, k_MaxFuelQuantity, k_NumberOfWheels, i_Wheels, k_MaxWheelAirPressure)
        {
            m_IsTransferHazardousMaterials = i_IsTransferHazardousMaterials;
            m_TruckLoadSize = i_TruckLoadSize;
        }

        public override string ToString() 
        {
            string truckInfo = string.Format(
@"{0}
Truck Properties:
Is Truck Transfer Hazardous Materials? {1}
Truck load size: {2}", 
base.ToString(), 
m_IsTransferHazardousMaterials, 
m_TruckLoadSize);

            return truckInfo;
        }
    }
}
