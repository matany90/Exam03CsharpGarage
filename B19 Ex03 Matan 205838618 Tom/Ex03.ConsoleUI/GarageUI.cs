using System;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        public GarageUI()
        {
            try
            {
                Console.WriteLine("Welcome to Tom and Matan's garage!" + Environment.NewLine);
                eMenuOptions userChoise = mainMenu();
                garageOperations(userChoise);
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Format error");
            }
            catch(Exception ex)
            {
                Console.WriteLine("error general");
            }
            
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

        private void handleAddVehicle(Garage garage)
        {
            Dictionary<eVehicleTypes, VehicleParametersTypes> vehicles = VehicleFactory.Vehicles; ////get types VehicleFactory

            string ownerName = string.Empty;
            string ownerPhone = string.Empty;
            List<object> paramsToSend = new List<object>();
            eVehicleTypes vehicleChoise;

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
            paramsToSend = getParamsFromUser(vehicles[vehicleChoise].ParameterTypes, vehicles[vehicleChoise].ParameterDescription);

            garage.AddVehicleToGarage(ownerName, ownerPhone, vehicleChoise, paramsToSend);
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

            return objToReturn;
        }



        private bool checkInputValidation(string i_Choise, string i_Pattern)
        {
            return Regex.IsMatch(i_Choise, i_Pattern);
        }



    }
}
