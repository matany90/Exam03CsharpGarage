using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        public bool AddVehicleToGarage(string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_Identifier, List<object> i_ParametersToCreateVehicle, Wheel[] i_Wheels)
        {
            bool vehicleAlreadyInGarage = false;
            Owner vehicleOwner = new Owner(i_OwnerName, i_OwnerPhone);
            Vehicle vehicleToAdd = VehicleFactory.Create(i_Identifier, i_ParametersToCreateVehicle, i_Wheels);

            if (m_VehiclesInGarage.ContainsKey(vehicleToAdd.LicenseNumber))
            {
                m_VehiclesInGarage[vehicleToAdd.LicenseNumber].VehicleState = eVehicleConditions.InRepair;
                vehicleAlreadyInGarage = true;
            }
            else
            {
                m_VehiclesInGarage.Add(vehicleToAdd.LicenseNumber, new VehicleInGarage(vehicleToAdd, vehicleOwner));
            }

            return vehicleAlreadyInGarage;
        }

        public List<string> ShowLicenseNumbersBool(bool i_UseFilter, eVehicleConditions? i_Filter)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (VehicleInGarage vehicle in m_VehiclesInGarage.Values)
            {
                if (i_UseFilter)
                {
                    if (vehicle.VehicleState == i_Filter)
                    {
                        licenseNumbers.Add(vehicle.Vehicle.LicenseNumber);
                    }
                }
                else
                {
                    licenseNumbers.Add(vehicle.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleConditions i_State)
        {
            bool isVehicleExists = false;

            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].VehicleState = i_State;
                isVehicleExists = true;
            }

            if (!isVehicleExists)
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }
        }

        public void FillWheelsToMax(string i_LicenseNumber)
        {
            bool isVehicleExists = false;

            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                foreach (Wheel wheel in m_VehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
                {
                    wheel.AddAirPressure(wheel.MaxAirPressure - wheel.CurrentAirPressure);
                }

                isVehicleExists = true;
            }

            if (!isVehicleExists)
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {            
            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
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
            else
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }
        }

        public void ChargeBattery(string i_LicenseNumber, float i_NumOfMinutesToAdd)
        {
            bool isVehicleExists = false;
            Type vehicleType = m_VehiclesInGarage[i_LicenseNumber].Vehicle.GetType();

            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                if (vehicleType.IsSubclassOf(typeof(ElectricVehicle)))
                {
                    ((ElectricVehicle)m_VehiclesInGarage[i_LicenseNumber].Vehicle).ChargeBattery(i_NumOfMinutesToAdd / 60);
                    isVehicleExists = true;
                }
                else
                {
                    throw new Exception("Error, You can not charge a non-electric vehicle!");
                }
            }

            if (!isVehicleExists)
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            string toShow = string.Empty;

            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                toShow = m_VehiclesInGarage[i_LicenseNumber].ToString();
            }
            else
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }

            return toShow; 
        }
    }
}