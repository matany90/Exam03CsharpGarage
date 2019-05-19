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

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleConditions i_State)
        {
            bool isVehicleExists = false;

            foreach (KeyValuePair<string, VehicleInGarage> garageDicElement in m_VehiclesInGarage)
            {
                if (garageDicElement.Key.Equals(i_LicenseNumber))
                {
                    garageDicElement.Value.VehicleState = i_State;
                    isVehicleExists = true;
                }
            }
            if (!isVehicleExists)
            {
                throw new Exception("Value not found");
            }
        }

        public void FillWheelsToMax(string i_LicenseNumber)
        {
            bool isVehicleExists = false;

            foreach (KeyValuePair<string, VehicleInGarage> garageDicElement in m_VehiclesInGarage)
            {
                if (garageDicElement.Key.Equals(i_LicenseNumber))
                {
                    foreach (Wheel wheel in garageDicElement.Value.Vehicle.Wheels)
                    {
                        wheel.AddAirPressure(wheel.MaxAirPressure - wheel.CurrentAirPressure);
                    }
                    isVehicleExists = true;
                }
            }
            if (!isVehicleExists)
            {
                throw new Exception("Value not found");
            }
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
            bool isVehicleExists = false;
            Type vehicleType = m_VehiclesInGarage[i_LicenseNumber].Vehicle.GetType();

            foreach (KeyValuePair<string, VehicleInGarage> garageDicElement in m_VehiclesInGarage)
            {
                if (garageDicElement.Key.Equals(i_LicenseNumber) && vehicleType.IsSubclassOf(typeof(ElectricVehicle)))
                {
                    ((ElectricVehicle)garageDicElement.Value.Vehicle).ChargeBattery(i_NumOfMinutesToAdd);
                    isVehicleExists = true;
                }
            }
            if (!isVehicleExists)
            {
                throw new Exception("Value not found");
            }
        }

        //public string ShowVehicleInfo(string i_LicenseNumber)
        //{
        //}
    }
}