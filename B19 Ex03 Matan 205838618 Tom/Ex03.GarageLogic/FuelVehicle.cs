using System;

namespace Ex03.GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_CurrentFuelQuantity;
        protected float m_MaxFuelQuantity;

        public FuelVehicle(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity, int i_NumberOfWheels, Wheel[] i_Wheels, float i_VehicleMaxWheelAirPressure)
            : base(i_ModelName, i_LicenseNumber, (i_CurrentFuelQuantity / i_MaxFuelQuantity) * 100, i_NumberOfWheels, i_Wheels, i_VehicleMaxWheelAirPressure)
        {
            m_FuelType = i_FuelType;
            m_CurrentFuelQuantity = i_CurrentFuelQuantity;
            m_MaxFuelQuantity = i_MaxFuelQuantity;
            if (i_MaxFuelQuantity < m_CurrentFuelQuantity)
            {
                throw new ValueOutOfRangeException(null, i_MaxFuelQuantity, 0);
            }
        }

        public void AddFuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
                defineExceptions(i_FuelAmountToAdd, i_FuelType);
                m_CurrentFuelQuantity += i_FuelAmountToAdd;
                m_EnergyLeftByPercentages = (m_CurrentFuelQuantity / m_MaxFuelQuantity) * 100;
        }

        private void defineExceptions(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException(string.Format(
@"Invalid arguments.
{0} is not equal to {1}
", 
i_FuelType, 
m_FuelType));
            }

            if (i_FuelAmountToAdd + m_CurrentFuelQuantity > m_MaxFuelQuantity)
            {
                throw new ValueOutOfRangeException(null, m_MaxFuelQuantity, 0f);
            }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public float CurrentFuelQuantity
        {
            get { return m_CurrentFuelQuantity; }
        }

        public float MaxFuelQuantity
        {
            get { return m_MaxFuelQuantity; }
        }

        public override string ToString()
        {
            string fuelVehicleInfo = string.Format(
@"{0}
Fuel Info:
Fuel type: {1}
Current Fuel Quantity: {2}
Max Fuel Quantity: {3}", 
base.ToString(), 
m_FuelType, 
m_CurrentFuelQuantity, 
m_MaxFuelQuantity);

            return fuelVehicleInfo;
        }
    }
}
