using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /////TEST CLASS
    public class VehicleFactory
    {
        public static Vehicle Create(eVehicleTypes i_Identifier, string i_Model, string i_License, float i_CurrentEnergySourceAmount, string i_WheelManufactor, float i_CurrentAirPressure, object param6, object param7)
        {
            Vehicle vehicleToReturn = null;
            eLicenseTypes licenseType;
            eCarColor carColor;
            eDoorsNumber doorsNumber;
            int engineVolume;

                switch (i_Identifier)
                {
                    case eVehicleTypes.FuelCar:
                        carColor = (eCarColor)Enum.ToObject(typeof(eCarColor), param6);
                        doorsNumber = (eDoorsNumber)Enum.ToObject(typeof(eDoorsNumber), param7);
                    vehicleToReturn = new FuelCar(i_Model, i_License, eFuelType.Octan96, i_CurrentEnergySourceAmount, 55f, carColor, doorsNumber, 4, new Wheel(i_WheelManufactor, i_CurrentAirPressure, 31f));
                        break;
                    case eVehicleTypes.FuelMotorcycle:
                        licenseType = (eLicenseTypes)Enum.ToObject(typeof(eLicenseTypes), param6);
                        engineVolume = (int)param7;
                    vehicleToReturn = new FuelMotorcycle(i_Model, i_License, eFuelType.Octan95, i_CurrentEnergySourceAmount, 8f, licenseType, engineVolume, 2, new Wheel(i_WheelManufactor, i_CurrentAirPressure, 33f));
                        break;
                    case eVehicleTypes.ElectricMotorcycle:
                        licenseType = (eLicenseTypes)Enum.ToObject(typeof(eLicenseTypes), param6);
                        engineVolume = (int)param7;
                    vehicleToReturn = new ElectricMotorcycle(i_Model, i_License, i_CurrentEnergySourceAmount, 1.4f, licenseType, engineVolume, 2, new Wheel(i_WheelManufactor, i_CurrentAirPressure, 33f));
                        break;
                    case eVehicleTypes.ElectricCar:
                        carColor = (eCarColor)Enum.ToObject(typeof(eCarColor), param6);
                        doorsNumber = (eDoorsNumber)Enum.ToObject(typeof(eDoorsNumber), param7);
                    vehicleToReturn = new ElectricCar(i_Model, i_License, i_CurrentEnergySourceAmount, 1.8f, carColor, doorsNumber, 4, new Wheel(i_WheelManufactor, i_CurrentAirPressure, 31f));
                        break;
                    case eVehicleTypes.Truck:
                        bool? isTransferHazardousMaterials = param6 as bool?;
                        if (isTransferHazardousMaterials == null)
                        {
                            throw new FormatException("Convert failier");
                        }
                        int truckLoadSize = (int)param7;
                    vehicleToReturn = new Truck(i_Model, i_License, eFuelType.Soler, i_CurrentEnergySourceAmount, 110f, isTransferHazardousMaterials, truckLoadSize, 12, new Wheel(i_WheelManufactor, i_CurrentAirPressure, 26f));
                        break;
                    default:
                        break;
                }

            return vehicleToReturn;
        }
    }
    /////TEST CLASS
}
