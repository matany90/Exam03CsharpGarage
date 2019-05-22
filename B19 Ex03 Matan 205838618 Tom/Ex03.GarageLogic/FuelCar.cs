using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_CurrentFuelQuantity, eCarColor i_CarColor, eDoorsNumber i_DoorsNumber, Wheel[] i_Wheel)
            : base(i_ModelName, i_LicenseNumber, eFuelType.Octan96, i_CurrentFuelQuantity, 55f, 4, i_Wheel, 31f)
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
