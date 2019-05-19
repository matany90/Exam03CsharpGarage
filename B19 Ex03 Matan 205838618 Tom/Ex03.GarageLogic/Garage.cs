using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage;

        public bool AddVehicleToGarage(Owner i_Owner, Vehicle i_Vehicle)
        {
            bool vehicleAlreadyInGarage = false;

            if (m_VehiclesInGarage.ContainsKey(i_Vehicle.LicenseNumber))
            {
                m_VehiclesInGarage[i_Vehicle.LicenseNumber].VehicleState = eVehicleConditions.InRepair;
                vehicleAlreadyInGarage = true;
            }
            else
            {
                m_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, new VehicleInGarage(i_Vehicle, i_Owner));
            }

            return vehicleAlreadyInGarage;
        }

        public List<int> ShowLicenseNumbersbool(bool i_UseFilter, int i_Filter)
        {
            List<int> licenseNumbers = new List<int>();

            foreach (VehicleInGarage vehicle in m_VehiclesInGarage.Values)
            {
                if (i_UseFilter)
                {
                    if (vehicle.VehicleState.ToString() == Enum.GetName(typeof(eVehicleConditions), i_Filter))
                    {
                        licenseNumbers.Add(int.Parse(vehicle.Vehicle.LicenseNumber));
                    }
                }
                else
                {
                    licenseNumbers.Add(int.Parse(vehicle.Vehicle.LicenseNumber));
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleState(string i_LicensePlate, int i_State)
        {
        }

        public void FillWheelsToMax(string i_LicenseNumber)
        {
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            Type vehicleType = m_VehiclesInGarage[i_LicenseNumber].Vehicle.GetType();

            if (vehicleType.IsSubclassOf(typeof(FuelVehicle)))
            {
                ((FuelVehicle)m_VehiclesInGarage[i_LicenseNumber].Vehicle).AddFuel(i_AmountToFill, i_FuelType);
            }
            else
            {
                throw new Exception("Error, Vehicle is not a fuel vehicle. Cannot add fuel!");
            }
        }

        public void ChargeBattery(string i_LicenseNumber, float i_NumOfMinutesToAdd)
        {
        }

        public string ShowVehicleInfo(string i_LicenseNumber)
        {
        }
    }
}