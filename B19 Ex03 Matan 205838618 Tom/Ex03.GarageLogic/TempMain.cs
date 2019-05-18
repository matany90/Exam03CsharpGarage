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
                ((FuelCar)v).AddFuel(61f, eFuelType.Octan96);
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
