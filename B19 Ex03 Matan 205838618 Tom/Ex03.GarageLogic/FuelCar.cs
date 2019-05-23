using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const float k_MaxFuelQuantity = 55f;
        private const int k_NumberOfWheels = 4;
        private const float k_MaxWheelAirPressure = 31f;
        private CarProperties m_CarProperties;

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, eCarColor i_CarColor, eDoorsNumber i_DoorsNumber, Wheel[] i_Wheel)
            : base(i_ModelName, i_LicenseNumber, k_FuelType, i_CurrentFuelQuantity, k_MaxFuelQuantity, k_NumberOfWheels, i_Wheel, k_MaxWheelAirPressure)
        {
            m_CarProperties = new CarProperties(i_CarColor, i_DoorsNumber);
        }

        public override string ToString() 
        {
            string fuelCarInfo = base.ToString() + Environment.NewLine + m_CarProperties.ToString();

            return fuelCarInfo;
        }

        public CarProperties CarProperties
        {
            get { return m_CarProperties; }
        }
    }
}
