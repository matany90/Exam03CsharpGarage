using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class TempMain
    {
        public static void Main()
        {   
            try
            {
                Garage garage = new Garage();
                Vehicle v = new FuelCar("Mazda 3", "37483995", eFuelType.Octan96, 20f, 80f, new CarProperties(eCarColor.Black, eDoorsNumber.Four));
                //((FuelCar)v).AddFuel(60f, eFuelType.Octan96);
                Vehicle a = new FuelMotorcycle("Motorcycle Fuel", "1222223", eFuelType.Octan98, 10f, 80f, new MotorcycleProperties(eLicenseTypes.A, 20));
                ((FuelMotorcycle)a).AddFuel(70f, eFuelType.Octan98);
                Vehicle b = new Truck("TRUCK", "458748574", eFuelType.Soler, 15f, 90f, true, 600);
                Vehicle e = new ElectricMotorcycle("Motorcycle Electric", "111111", 15f, 90f, eLicenseTypes.A, 600);
                garage.AddVehicleToGarage(new Owner("matan", "0522542570"), v);
                //garage.AddVehicleToGarage(new Owner("tom", "06283849"), a);
                Console.WriteLine(garage.ShowVehicleInfo("37483995"));
                garage.AddFuel("37483995", eFuelType.Octan96, 20f);
                Console.WriteLine(garage.ShowVehicleInfo("37483995"));


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
