using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        public bool AddVehicleToGarage(string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_Identifier, string i_Model, string i_License, float i_CurrentEnergySourceAmount, string i_WheelManufactor, float[] i_CurrentAirPressure, object i_VehicleSpecificParameter1, object i_VehicleSpecificParameter2)
        {
            bool vehicleAlreadyInGarage = false;
            Owner vehicleOwner = new Owner(i_OwnerName, i_OwnerPhone);
            Vehicle vehicleToAdd = VehicleFactory.Create(i_Identifier, i_Model, i_License, i_CurrentEnergySourceAmount, i_WheelManufactor, i_CurrentAirPressure, i_VehicleSpecificParameter1, i_VehicleSpecificParameter2);

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
            }
            if (!isVehicleExists)
            {
                throw new Exception("Error, This license number does not exist in the garage!");
            }
        }

        public string ShowVehicleInfo(string i_LicenseNumber)
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