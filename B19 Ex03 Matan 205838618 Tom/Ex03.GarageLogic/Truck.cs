using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : FuelVehicle
    {
        private bool? m_IsTransferHazardousMaterials;
        private int m_TruckLoadSize;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, bool i_IsTransferHazardousMaterials, int i_TruckLoadSize, Wheel[] i_Wheels)
    : base(i_ModelName, i_LicenseNumber, eFuelType.Soler, i_CurrentFuelQuantity, 110f, 12, i_Wheels)
        {
            m_IsTransferHazardousMaterials = i_IsTransferHazardousMaterials;
            m_TruckLoadSize = i_TruckLoadSize;
        }


        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(bool), typeof(int), typeof(Truck) };

            return types;
        }

        public override string ToString() // to delete
        {
            string truckInfo = string.Format(
@"{0}
Truck Properties:
Is Truck Transfer Hazardous Materials? {1}
Truck load size: {2}", base.ToString(), m_IsTransferHazardousMaterials, m_TruckLoadSize);

            return truckInfo;
        }
    }
}
