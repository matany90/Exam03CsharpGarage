using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class FuelVehicle : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_CurrentFuelQuantity;
        protected float m_MaxFuelQuantity;

        public FuelVehicle(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity)
            : base(i_ModelName, i_LicenseNumber, 100 - ((i_CurrentFuelQuantity * i_MaxFuelQuantity) / 100))
        {
            m_FuelType = i_FuelType;
            m_CurrentFuelQuantity = i_CurrentFuelQuantity;
            m_MaxFuelQuantity = i_MaxFuelQuantity;
        }

        public override void AddFuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            try
            {
                defineExceptions(i_FuelAmountToAdd, i_FuelType);
                m_CurrentFuelQuantity += i_FuelAmountToAdd;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message); // console for testing
            }
            catch (ValueOutOfRangeException ve)
            {
                Console.WriteLine(ve.Message);// console for testing
            } 
        }

        private void defineExceptions(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException(string.Format(
@"Invalid arguments.
{0} is not equal to {1}
", i_FuelType, m_FuelType));
            }

            if (i_FuelAmountToAdd + m_CurrentFuelQuantity > m_MaxFuelQuantity)
            {
                throw new ValueOutOfRangeException(string.Format(
@"Out of range Error.
You try to add more fuel than the vehicle's fuel capacity"));
            }
        }
    }
}
