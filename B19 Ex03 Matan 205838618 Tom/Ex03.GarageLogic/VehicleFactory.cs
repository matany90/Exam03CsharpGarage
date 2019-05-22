using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /////TEST CLASS
    public class VehicleFactory
    {
        public static Dictionary<eVehicleTypes, VehicleParametersTypes> Vehicles = new Dictionary<eVehicleTypes, VehicleParametersTypes>
        {
    {eVehicleTypes.FuelCar, new VehicleParametersTypes(FuelCar.GetParamsTypesArray(), new string[] { "Model Name", "License Number", "Current Fuel Quantity", "Car Color", "Doors Number"})},
    {eVehicleTypes.FuelMotorcycle, new VehicleParametersTypes(FuelMotorcycle.GetParamsTypesArray(), new string[] { "Model Name", "License Number", "Current Fuel Quantity", "License Types", "Engine Volume"})},
    {eVehicleTypes.ElectricMotorcycle, new VehicleParametersTypes(ElectricMotorcycle.GetParamsTypesArray(), new string[] { "Model Name", "License Number", "Energy time remaining in the battery by hours", "License Types", "Engine Volume"})},
    {eVehicleTypes.ElectricCar, new VehicleParametersTypes(ElectricCar.GetParamsTypesArray(), new string[] { "Model Name", "License Number", "Energy time remaining in the battery by hours", "Car Color", "Doors Number"})},
    {eVehicleTypes.Truck, new VehicleParametersTypes(Truck.GetParamsTypesArray(), new string[] { "Model Name", "License Number", "Current Fuel Quantity", "truck transfer hazardous materials", "Truck load size"})},
        };
        public static Dictionary<eVehicleTypes, int> WheelsNumberPerVehicle = new Dictionary<eVehicleTypes, int>
        {
     {eVehicleTypes.FuelCar, 4 } , {eVehicleTypes.FuelMotorcycle, 2 } , {eVehicleTypes.ElectricMotorcycle, 2 } , {eVehicleTypes.ElectricCar, 4} , {eVehicleTypes.Truck, 12 }
        };

        public static Vehicle Create(eVehicleTypes i_Identifier, List<object> i_ParamsArray, Wheel[] i_Wheels)
        {
            Vehicle vehicleToReturn = null;            
                switch (i_Identifier)
                {
                    case eVehicleTypes.FuelCar:
                    vehicleToReturn = new FuelCar((string)i_ParamsArray[0], (string)i_ParamsArray[1], (float)i_ParamsArray[2], (eCarColor)i_ParamsArray[3], (eDoorsNumber)i_ParamsArray[4], i_Wheels);
                        break;
                    case eVehicleTypes.FuelMotorcycle:
                    vehicleToReturn = new FuelMotorcycle((string)i_ParamsArray[0], (string)i_ParamsArray[1], (float)i_ParamsArray[2], (eLicenseTypes)i_ParamsArray[3], (int)i_ParamsArray[4], i_Wheels);
                        break;
                    case eVehicleTypes.ElectricMotorcycle:
                    vehicleToReturn = new ElectricMotorcycle((string)i_ParamsArray[0], (string)i_ParamsArray[1], (float)i_ParamsArray[2], (eLicenseTypes)i_ParamsArray[3], (int)i_ParamsArray[4], i_Wheels);
                        break;
                    case eVehicleTypes.ElectricCar:
                    vehicleToReturn = new ElectricCar((string)i_ParamsArray[0], (string)i_ParamsArray[1], (float)i_ParamsArray[2], (eCarColor)i_ParamsArray[3], (eDoorsNumber)i_ParamsArray[4], i_Wheels);
                        break;
                    case eVehicleTypes.Truck:
                    vehicleToReturn = new Truck((string)i_ParamsArray[0], (string)i_ParamsArray[1], (float)i_ParamsArray[2], (bool)i_ParamsArray[3], (int)i_ParamsArray[4], i_Wheels);
                        break;
                    default:
                        break;
                }

            return vehicleToReturn;
        }

        //public static Wheel[] CreateWheels(int i_NumberOfWheels, string i_Manufactor, float[] i_CurrentAirPressure, float i_MaxAirPressure)
        //{
        //    Wheel[] wheels = new Wheel[i_NumberOfWheels];

        //    for (int i = 0; i < i_NumberOfWheels; i++)
        //    {
        //        wheels[i] = new Wheel(i_Manufactor, i_CurrentAirPressure[i], i_MaxAirPressure);
        //    }

        //    return wheels;
        //}
    }
    /////TEST CLASS
}
