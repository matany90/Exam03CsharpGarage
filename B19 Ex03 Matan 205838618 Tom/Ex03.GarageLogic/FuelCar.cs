using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;
        //private const float k_MaxFuelQuantity = 55f;
        //private const int k_WheelsNumber = 4;
        //private const eFuelType k_FuelType = eFuelType.Octan96;

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, eCarColor i_CarColor, eDoorsNumber i_DoorsNumber/*, Wheel[] i_Wheel*/)
            : base(i_ModelName, i_LicenseNumber, eFuelType.Octan96, i_CurrentFuelQuantity, 55f, 4/*, i_Wheel*/)
        {
            m_CarProperties = new CarProperties(i_CarColor, i_DoorsNumber);
        }

        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(eCarColor), typeof(eDoorsNumber), typeof(FuelCar) };

            return types;
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
