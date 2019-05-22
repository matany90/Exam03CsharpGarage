using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Dictionary<eVehicleTypes, Type> Vehicles = new Dictionary<eVehicleTypes, Type>
        {
    {eVehicleTypes.FuelCar, typeof(FuelCar)},
    {eVehicleTypes.FuelMotorcycle, typeof(FuelMotorcycle)},
    {eVehicleTypes.ElectricMotorcycle, typeof(ElectricMotorcycle)},
    {eVehicleTypes.ElectricCar, typeof(ElectricCar)},
    {eVehicleTypes.Truck, typeof(Truck)},
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
    }
}
