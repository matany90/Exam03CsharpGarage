using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                GarageUI garageUI = new GarageUI();
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
