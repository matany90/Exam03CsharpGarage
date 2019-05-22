using System;

namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        private CarProperties m_CarProperties;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_BatteryTimeLeftByHours, eCarColor i_Color, eDoorsNumber i_DoorNumber, Wheel[] i_Wheels) 
            : base(i_ModelName, i_LicenseNumber, i_BatteryTimeLeftByHours, 1.8f, 2, i_Wheels)
        {
            m_CarProperties = new CarProperties(i_Color, i_DoorNumber);
        }

        public static Type[] GetParamsTypesArray()
        {
            Type[] types = { typeof(string), typeof(string), typeof(float), typeof(eCarColor), typeof(eDoorsNumber), typeof(ElectricCar) };

            return types;
        }

        public override string ToString() // to delete
        {
            string electricCarInfo = base.ToString() + Environment.NewLine + m_CarProperties.ToString();

            return electricCarInfo;
        }
    }
}
