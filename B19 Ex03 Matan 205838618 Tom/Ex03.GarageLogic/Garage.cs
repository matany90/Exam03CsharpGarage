using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage;

        public bool AddCarToGarage(Owner i_Owner, Vehicle i_Vehicle)
        {
        }

        public List<int> ShowLicenseNumbers()//add parameters
        {
        }

        public void ChangeVehicleState(string i_LicensePlate, int i_State)
        {
        }

        public void FillWheelsToMax(string i_LicenseNumber)
        {
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
        }

        public void ChargeBattery(string i_LicenseNumber, float i_NumOfMinutesToAdd)
        {
        }

        public string ShowVehicleInfo(string i_LicenseNumber)
        {
        }
    }
}