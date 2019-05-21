using System;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        public GarageUI()
        {
            try
            {
                Garage garage = new Garage();
                Console.WriteLine("Welcome to Tom and Matan's garage!" + Environment.NewLine);
                eMenuOptions userChoise = mainMenu();
                while (eMenuOptions.Exit != userChoise)
                {
                    garageOperations(userChoise, garage);
                    userChoise = mainMenu();
                }

            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private eMenuOptions mainMenu()
        {
            string choise = string.Empty;

            Console.WriteLine(
@"What would you like to do?
Please select one of the options by selecting the option's number (1-8), then press enter:
1. Add Vehicle to garage
2. Show all vehicles in the garage, with the option to filter vehicles by status
3. Change Vehicle status
4. Inflate vehicle's wheels
5. Add fuel to vehicle
6. Charge an electric vehicle
7. Show vehicle details
8. Exit");
            choise = Console.ReadLine();
            while (!checkInputValidation(choise, "^[1-8]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choise = Console.ReadLine();
            }

            return (eMenuOptions)Enum.Parse(typeof(eMenuOptions), choise);
        }

        private void garageOperations(eMenuOptions i_userChoise, Garage i_garage)
        {

            switch (i_userChoise)
            {
                case eMenuOptions.AddVehicle:
                    handleAddVehicle(i_garage);
                    break;
                case eMenuOptions.ShowAllVehicle:
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    handleChangeStatus(i_garage);
                    break;
                case eMenuOptions.AddAirPressure:
                    break;
                case eMenuOptions.AddFuelVehicle:
                    handleAddFuel(i_garage);
                    break;
                case eMenuOptions.ChargeBatteryVehicle:
                    handleChargeBattery(i_garage);
                    break;
                case eMenuOptions.ShowVehicleByLicense:
                    handleShowVehicle(i_garage);
                    break;
                default:
                    break;
            }
        }

        private void handleChangeStatus(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            eVehicleConditions vehicleConditions;
  
            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(
@"Please select a new status for vehicle:
Select one of the options by selecting the option's number (1-3), then press enter:
1. InRepair
2. Repaired
3. Paid");
            string strChoise = Console.ReadLine();
            while (!checkInputValidation(strChoise, "^[1-3]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                strChoise = Console.ReadLine();
            }
            vehicleConditions = (eVehicleConditions)Enum.Parse(typeof(eVehicleConditions), strChoise);

            i_Garage.ChangeVehicleState(licenseNumber, vehicleConditions);
        }

        private void handleAddFuel(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            eFuelType fuelType;
            float amountToFill;
            
            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(
@"Please select a fuel type:
Select one of the options by selecting the option's number (1-4), then press enter:
1. Octan98
2. Octan96
3. Octan95
4. Soler");
            string strChoise = Console.ReadLine();
            while (!checkInputValidation(strChoise, "^[1-4]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                strChoise = Console.ReadLine();
            }
            fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), strChoise);
            Console.WriteLine("Please enter the amount of liters of fuel to add, and then press enter:");
            amountToFill = float.Parse(Console.ReadLine());

            i_Garage.AddFuel(licenseNumber, fuelType, amountToFill);
        }

        private void handleChargeBattery(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            float chargeByMinutes;

            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the number of minutes to charge the vehicle, and then press enter:");
            chargeByMinutes = float.Parse(Console.ReadLine());
            i_Garage.ChargeBattery(licenseNumber, chargeByMinutes);
        }

        private void handleShowVehicle(Garage i_Garage)
        {
            string licenseNumber = string.Empty;

            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.ShowVehicleInfo(licenseNumber)); 
        }

        private void handleAddVehicle(Garage garage)
        {
            Dictionary<eVehicleTypes, VehicleParametersTypes> vehicles = VehicleFactory.Vehicles; ////get types VehicleFactory

            string ownerName = string.Empty;
            string ownerPhone = string.Empty;
            string manufacturerName = string.Empty;
            List<object> paramsToBuildVehicle = new List<object>();
            eVehicleTypes vehicleChoise;

            Console.WriteLine(
@"Details of vehicle owner:
Please enter the name of the vehicle owner, then press enter:");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter the phone number of the vehicle owner, then press enter:");
            ownerPhone = Console.ReadLine();
            while (!checkInputValidation(ownerPhone, "^[0-9]*$"))
            {
                Console.WriteLine("Invalid Input. Phone number can contain digits only.");
                ownerPhone = Console.ReadLine();
            }
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
            paramsToBuildVehicle = getParamsFromUser(vehicles[vehicleChoise].ParameterTypes, vehicles[vehicleChoise].ParameterDescription);
            //Console.WriteLine("Please enter wheel manufacturer name:");
            //manufacturerName = Console.ReadLine();
            //Console.WriteLine("Please enter current air pressure for the wheel:");
            //paramsToBuildVehicle.Add(float.Parse(Console.ReadLine()));

            garage.AddVehicleToGarage(ownerName, ownerPhone, vehicleChoise, paramsToBuildVehicle);
        }
        
        private List<object> getParamsFromUser(Type[] i_ParameterTypes, string[] i_ParamDescription)
        {
            List<object> paramsToSend = new List<object>();
            for (int i = 0; i < i_ParamDescription.Length; i++)
            {
                paramsToSend.Add(getSingleParamFromUser(i_ParameterTypes[i], i_ParamDescription[i]));
            }


            return paramsToSend;
        }

        private object getSingleParamFromUser(Type i_ParameterType, string i_ParamDescription)
        {
            object objToReturn = new object();
            string requestFromUser = "Please enter " + i_ParamDescription;

            if (i_ParameterType == typeof(string))
            {
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                objToReturn = Console.ReadLine();
            }
            else if (i_ParameterType == typeof(int))
            {
                int toConvert;
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                bool isSucceed = int.TryParse(Console.ReadLine(), out toConvert);
                if (isSucceed)
                {
                    objToReturn = toConvert;
                }
                else
                {
                    throw new FormatException("Format fail");
                }
            }
            else if (i_ParameterType.IsEnum)
            {
                int numberOfEnumValues = Enum.GetValues(i_ParameterType).Length;
                string toShow = string.Format(
@"Please select one of the options by selecting the option's number (1-{0}),
then press enter:", numberOfEnumValues);
                int indexEnum = 1;
               foreach (var valEnum in Enum.GetValues(i_ParameterType))
               {
                    toShow += Environment.NewLine + indexEnum + ". " + valEnum;
                    indexEnum++;
               }
               Console.WriteLine(toShow);
                string choiseString = Console.ReadLine(); 
                while (!checkInputValidation(choiseString, "^[1-" + numberOfEnumValues + "]{1}$"))
                {
                    Console.WriteLine("Invalid choise. please try again, and then press enter:");
                    choiseString = Console.ReadLine();
                }
                objToReturn = Enum.Parse(i_ParameterType, choiseString);
            }
            else if (i_ParameterType == typeof(float))
            {
                float toConvert;
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                bool isSucceed = float.TryParse(Console.ReadLine(), out toConvert);
                if (isSucceed)
                {
                    objToReturn = toConvert;
                }
                else
                {
                    throw new FormatException("Format fail");
                }
            }
            else if (i_ParameterType == typeof(bool))
            {
                Console.WriteLine("Please enter Y if " + i_ParamDescription + " and N if not");
                string choise = Console.ReadLine().ToLower();
                while (!checkInputValidation(choise, "^[y|n]{1}$"))
                {
                    Console.WriteLine("Invalid choise. please try again, and then press enter:");
                    choise = Console.ReadLine().ToLower();
                }
                objToReturn = choise.Equals("y");
            }
            //else if (i_ParameterType.IsSubclassOf(typeof(Vehicle)))
            //{
            //    Type obj = ()Activator.CreateInstance(i_ParameterType);
            //}

            return objToReturn;
        }

        private bool checkInputValidation(string i_Choise, string i_Pattern)
        {
            return Regex.IsMatch(i_Choise, i_Pattern);
        }

    }
}
