using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /////TEST CLASS
    public class VehicleFactory
    {
        public static Vehicle Create(eVehicleTypes i_Identifier, string i_Model, string i_License, float i_CurrentEnergySourceAmount, object param4, object param5)
        {
            Vehicle vehicleToReturn = null;
            eLicenseTypes licenseType;
            eCarColor carColor;
            eDoorsNumber doorsNumber;
            int engineVolume;

                switch (i_Identifier)
                {
                    case eVehicleTypes.FuelCar:
                        carColor = (eCarColor)Enum.ToObject(typeof(eCarColor), param4);
                        doorsNumber = (eDoorsNumber)Enum.ToObject(typeof(eDoorsNumber), param5);
                        vehicleToReturn = new FuelCar(i_Model, i_License, eFuelType.Octan96, i_CurrentEnergySourceAmount, 55f, carColor, doorsNumber);
                        break;
                    case eVehicleTypes.FuelMotorcycle:
                        licenseType = (eLicenseTypes)Enum.ToObject(typeof(eLicenseTypes), param4);
                        engineVolume = (int)param5;
                        vehicleToReturn = new FuelMotorcycle(i_Model, i_License, eFuelType.Octan95, i_CurrentEnergySourceAmount, 8f, licenseType, engineVolume);
                        break;
                    case eVehicleTypes.ElectricMotorcycle:
                        licenseType = (eLicenseTypes)Enum.ToObject(typeof(eLicenseTypes), param4);
                        engineVolume = (int)param5;
                        vehicleToReturn = new ElectricMotorcycle(i_Model, i_License, i_CurrentEnergySourceAmount, 1.4f, licenseType, engineVolume);
                        break;
                    case eVehicleTypes.ElectricCar:
                        carColor = (eCarColor)Enum.ToObject(typeof(eCarColor), param4);
                        doorsNumber = (eDoorsNumber)Enum.ToObject(typeof(eDoorsNumber), param5);
                        vehicleToReturn = new ElectricCar(i_Model, i_License, i_CurrentEnergySourceAmount, 1.8f, carColor, doorsNumber);
                        break;
                    case eVehicleTypes.Truck:
                        bool? isTransferHazardousMaterials = param4 as bool?;
                        if (isTransferHazardousMaterials == null)
                        {
                            throw new FormatException("Convert failier");
                        }
                        int truckLoadSize = (int)param5;
                        vehicleToReturn = new Truck(i_Model, i_License, eFuelType.Soler, i_CurrentEnergySourceAmount, 110f, isTransferHazardousMaterials, truckLoadSize);
                        break;
                    default:
                        break;
                }

            return vehicleToReturn;
        }
    }
    /////TEST CLASS
}
