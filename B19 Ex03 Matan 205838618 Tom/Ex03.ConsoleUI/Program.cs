using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Vehicle test1 = VehicleFactory.Create(eVehicleTypes.FuelCar, "Mazda 3", "123456", 30f, eCarColor.Black, eDoorsNumber.Three);
                Vehicle test2 = VehicleFactory.Create(eVehicleTypes.ElectricMotorcycle, "TustusElectric", "3245456", 1.4f, eLicenseTypes.A1, 200);
                Vehicle test3 = VehicleFactory.Create(eVehicleTypes.Truck, "Isuzu Truck", "43746374", 40f, true, 500);
                Vehicle test4 = VehicleFactory.Create(eVehicleTypes.ElectricCar, "hibridi mazda", "334364", 1.1f, eCarColor.Red, eDoorsNumber.Two);
                Vehicle test5 = VehicleFactory.Create(eVehicleTypes.FuelMotorcycle, "fuel tustus", "35554364", 1f, eLicenseTypes.B, 300);
                Console.WriteLine(test1);
                Console.WriteLine(test2);
                Console.WriteLine(test3);
                Console.WriteLine(test4);
                Console.WriteLine(test5);

            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
            }
            catch (ValueOutOfRangeException vr)
            {
                Console.WriteLine(vr.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
