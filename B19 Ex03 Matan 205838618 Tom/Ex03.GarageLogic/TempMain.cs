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
                Vehicle v = new FuelCar("Mazda 3", "37483995", eFuelType.Octan96, 20f, 80f, new CarProperties(eCarColor.Black, eDoorsNumber.Four));
                ((FuelCar)v).AddFuel(60f, eFuelType.Octan96);
                Vehicle a = new FuelMotorcycle("Tustus Motorcycle", "1222223", eFuelType.Octan98, 10f, 80f, new MotorcycleProperties(eLicenseTypes.A, 20));
                ((FuelMotorcycle)a).AddFuel(70f, eFuelType.Octan98);
                Vehicle b = new Truck("ISUZU TRUCK", "458748574", eFuelType.Soler, 15f, 90f, true, 600);
                Vehicle e = new ElectricMotorcycle("ISUZU TRUCK", "458748574", eFuelType.Soler, 15f, 90f, true, 600);
                a.show();
                b.show();
                v.show();
                
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
            }
            catch (ValueOutOfRangeException vr)
            {
                Console.WriteLine(vr.Message);
            }

        }
    }
}
