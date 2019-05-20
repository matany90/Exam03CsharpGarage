using System;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        public GarageUI()
        {

            Console.WriteLine("Welcome to Tom and Matan's garage!" + Environment.NewLine);
            eMenuOptions userChoise = mainMenu();
            garageOperations(userChoise);

        }

        private eMenuOptions mainMenu()
        {
            string choise = string.Empty;

            Console.WriteLine(
@"What would you like to do?
Please select one of the options by selecting the option's number (1-7), then press enter:
1. Add Vehicle to garage
2. Show all vehicles in the garage, with the option to filter vehicles by status
3. Change Vehicle status
4. Inflate vehicle's wheels
5. Add fuel to vehicle
6. Charge an electric vehicle
7. Show vehicle details");
            choise = Console.ReadLine();
            while (!checkInputValidation(choise, "^[1-7]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choise = Console.ReadLine();
            }

            return (eMenuOptions)Enum.Parse(typeof(eMenuOptions), choise);
        }

        private bool checkInputValidation(string i_Choise, string i_Pattern)
        {
            return Regex.IsMatch(i_Choise, i_Pattern);
        }

        private void garageOperations(eMenuOptions i_userChoise)
        {
            Garage garage = new Garage();

            switch (i_userChoise)
            {
                case eMenuOptions.AddVehicle:
                    handleAddVehicle(garage);
                    break;
                case eMenuOptions.ShowAllVehicle:
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    break;
                case eMenuOptions.AddAirPressure:
                    break;
                case eMenuOptions.AddFuelVehicle:
                    break;
                case eMenuOptions.ChargeBatteryVehicle:
                    break;
                case eMenuOptions.ShowVehicleByLicense:
                    break;
                default:
                    break;
            }
        }

        private void handleAddVehicle(Garage i_Garage)
        {
            string ownerName = string.Empty;
            string ownerPhone = string.Empty;
            eVehicleTypes vehicleChoise;
            string model = string.Empty;
            string license = string.Empty;
            float currentEnergySource;
            string wheelManufacturer = string.Empty;
            float[] currentAirPressure;
            object VehicleSpecificParameter1;
            object VehicleSpecificParameter2;

            Console.WriteLine(
@"Details of vehicle owner:
Please enter the name of the vehicle owner, then press enter:");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter the phone number of the vehicle owner, then press enter:");
            ownerPhone = Console.ReadLine();
            Console.WriteLine(
@"Vehicle details:
Please enter the type of vehicle you want to insert into the garage.
Please select one of the options (1-5), then press enter:
1. FuelCar
2. FuelMotorcycle
3. ElectricMotorcycle
4. Truck
5. ElectricCar");
            string vehicleChoiseString = string.Empty;
            vehicleChoiseString = Console.ReadLine();
            while (!checkInputValidation(vehicleChoiseString, "^[1-5]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                vehicleChoiseString = Console.ReadLine();
            }
            vehicleChoise = (eVehicleTypes)Enum.Parse(typeof(eVehicleTypes), vehicleChoiseString);
            Console.WriteLine("Please enter the vehicle model, and then press enter:");
            model = Console.ReadLine();
            Console.WriteLine("Please enter the license number of the vehicle, and then press enter:");
            license = Console.ReadLine();

            if (isElectricVehicle(vehicleChoise))
            {
                Console.WriteLine("Please enter the number of hours the vehicle is charged, and then press enter:");
            }
            else
            {
                Console.WriteLine("Please enter the number of fuel liters in the vehicle, and then press enter:");
            }
            currentEnergySource = float.Parse(Console.ReadLine());
            handleWheelsInput(out currentAirPressure, out wheelManufacturer, vehicleChoise);

            if (isCar(vehicleChoise))
            {
                handleInputCarProperties(out VehicleSpecificParameter1, out VehicleSpecificParameter2);

            }
            else if (isMotorcycle(vehicleChoise))
            {
                handleInputMotorcycleProperties(out VehicleSpecificParameter1, out VehicleSpecificParameter2);
            }
            else
            {
                handleInputTruckProperties(out VehicleSpecificParameter1, out VehicleSpecificParameter2);
            }

            i_Garage.AddVehicleToGarage(ownerName, ownerPhone, vehicleChoise, model, license, currentEnergySource, wheelManufacturer, currentAirPressure, VehicleSpecificParameter1, VehicleSpecificParameter2);
        }

        private void handleInputTruckProperties(out object o_VehicleSpecificParameter1, out object o_VehicleSpecificParameter2)
        {
            Console.WriteLine(
@"Does the truck transfers hazardous materials? Please select Y/N");
            string choiseString = Console.ReadLine().ToLower();
            while (!checkInputValidation(choiseString, "^[y|n]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choiseString = Console.ReadLine().ToLower();
            }
            o_VehicleSpecificParameter1 = choiseString.Equals("y");

            Console.WriteLine("Please enter the truck load size, and then press enter:");
            o_VehicleSpecificParameter2 = int.Parse(Console.ReadLine());
        }

        private void handleInputMotorcycleProperties(out object o_VehicleSpecificParameter1, out object o_VehicleSpecificParameter2)
        {
            Console.WriteLine(@"Please enter the license type for the motorcycle
by selecting the relevant number, then press enter:
1. A 
2. A1
3. A2
4. B ");
            string choiseString = Console.ReadLine();
            while (!checkInputValidation(choiseString, "^[1-4]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choiseString = Console.ReadLine();
            }
            o_VehicleSpecificParameter1 = (eLicenseTypes)Enum.Parse(typeof(eLicenseTypes), choiseString);

            Console.WriteLine("Please enter engine volume of the motorcycle, and then press enter:");
            o_VehicleSpecificParameter2 = int.Parse(Console.ReadLine());
        }

        private void handleInputCarProperties(out object o_VehicleSpecificParameter1, out object io_VehicleSpecificParameter2)
        {
            Console.WriteLine(
@"Please select the vehicle color by selecting the relevant number, then press enter:
1. Red
2. Blue
3. Black
4. Gray");
            string choiseString = Console.ReadLine();
            while (!checkInputValidation(choiseString, "^[1-4]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choiseString = Console.ReadLine();
            }
            o_VehicleSpecificParameter1 = (eCarColor)Enum.Parse(typeof(eCarColor), choiseString);

            Console.WriteLine(
@"Please select the vehicle doors number by selecting the relevant number, then press enter:
1. Two
2. Three
3. Four
4. Five");
            choiseString = Console.ReadLine();
            while (!checkInputValidation(choiseString, "^[1-4]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choiseString = Console.ReadLine();
            }
            io_VehicleSpecificParameter2 = (eDoorsNumber)Enum.Parse(typeof(eDoorsNumber), choiseString);
        }

        private bool isCar(eVehicleTypes i_Vehicle)
        {
            return i_Vehicle.Equals(eVehicleTypes.ElectricCar) || i_Vehicle.Equals(eVehicleTypes.FuelCar);
        }

        private bool isMotorcycle(eVehicleTypes i_Vehicle)
        {
            return i_Vehicle.Equals(eVehicleTypes.ElectricMotorcycle) || i_Vehicle.Equals(eVehicleTypes.FuelMotorcycle);
        }

        private void handleWheelsInput(out float[] i_CurrentAirPressure, out string io_WheelManufacturer, eVehicleTypes i_Vehicle)
        {
            Console.WriteLine("Please enter the wheel manufacturer of the vehicle, and then press enter:");
            io_WheelManufacturer = Console.ReadLine();
            int numOfWheels = getNumOfWheels(i_Vehicle);
            i_CurrentAirPressure = new float[numOfWheels];
            for (int i = 0; i < numOfWheels; i++)
            {
                Console.WriteLine(@"Please enter the air pressure for wheel number {0}", (i + 1));
                i_CurrentAirPressure[i] = float.Parse(Console.ReadLine());
            }
        }

        private bool isElectricVehicle(eVehicleTypes i_Vehicle)
        {
            return i_Vehicle.Equals(eVehicleTypes.ElectricCar) || i_Vehicle.Equals(eVehicleTypes.ElectricMotorcycle);
        }

        private int getNumOfWheels(eVehicleTypes i_VehicleType)
        {
            int numOfWheels = 4;

            if (i_VehicleType.Equals(eVehicleTypes.Truck))
            {
                numOfWheels = 12;
            }
            else if (i_VehicleType.Equals(eVehicleTypes.ElectricMotorcycle) || i_VehicleType.Equals(eVehicleTypes.FuelMotorcycle))
            {
                numOfWheels = 2;
            }

            return numOfWheels;
        }
    }
}
