﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class TempMain
    {
        public static void Main()
        {            
            Vehicle v = new FuelCar("Mazda 3", "37483995", eFuelType.Octan96, 20f, 80f);
            ((FuelCar)v).AddFuel(61f, eFuelType.Octan96);
        }
    }
}