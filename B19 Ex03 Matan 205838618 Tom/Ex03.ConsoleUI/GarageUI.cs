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
2. Show all license numbers in the garage, with the option to filter vehicles by status
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
                case eMenuOptions.ShowLicenses:
                    handleShowLicenses(i_garage);
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

        private void handleShowLicenses(Garage i_Garage)
        {
            eVehicleConditions? vehicleStatusToFilter = null;
            bool toFilter;

            Console.WriteLine(
@"Would you like to filter license numbers by vehicle status?
Choose Y/N, and then press enter:");
            string choise = Console.ReadLine().ToLower();
            while (!checkInputValidation(choise, "^[y|n]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                choise = Console.ReadLine();
            }
            toFilter = choise.Equals("y");
            if (toFilter)
            {
                Console.WriteLine(
@"Which status would you like to filter?
Select one of the options by selecting the option's number (1-3), then press enter:
1. InRepair
2. Repaired
3. Paid");
                choise = Console.ReadLine();
                while (!checkInputValidation(choise, "^[1-3]{1}$"))
                {
                    Console.WriteLine("Invalid choise. please try again, and then press enter:");
                    choise = Console.ReadLine();
                }
                vehicleStatusToFilter = (eVehicleConditions)Enum.Parse(typeof(eVehicleConditions), choise);
            }

            List<string> licenseToShow = i_Garage.ShowLicenseNumbersbool(toFilter, vehicleStatusToFilter);
            int indexLicense = 1;
            foreach (string license in licenseToShow)
            {
                Console.WriteLine(indexLicense + ". " + license);
                indexLicense++;
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
            Dictionary<eVehicleTypes, int> wheelsNumber = VehicleFactory.WheelsNumberPerVehicle;

             string ownerName = string.Empty;
            string ownerPhone = string.Empty;
            Wheel[] wheelsArray;
            List<object> paramsToBuildVehicle = new List<object>();
            eVehicleTypes vehicleChoise;

            getOwnerNameAndPhone(out ownerName, out ownerPhone);
            vehicleChoise = getVehicleTypeToInsertGarage(vehicles.Keys);
            paramsToBuildVehicle = getParamsFromUser(vehicles[vehicleChoise].ParameterTypes, vehicles[vehicleChoise].ParameterDescription);
            wheelsArray = getWheelsArray(wheelsNumber[vehicleChoise]);

            garage.AddVehicleToGarage(ownerName, ownerPhone, vehicleChoise, paramsToBuildVehicle, wheelsArray);
        }
        
        private Wheel[] getWheelsArray(int i_WheelsNumber)
        {
            Wheel[] wheels = new Wheel[i_WheelsNumber];
            string manufacturerName = string.Empty;
            float currentAirPressure, maxAirPressure;

            for (int i = 0; i < i_WheelsNumber; i++)
            {
                Console.WriteLine("Please enter the manufacturer name for wheel number " + (i + 1));
                manufacturerName = Console.ReadLine();
                Console.WriteLine("Please enter current air pressure for wheel number " + (i + 1));
                currentAirPressure = float.Parse(Console.ReadLine());
                Console.WriteLine("Please enter maximum air pressure set by the manufacturer for wheel number " + (i + 1));
                maxAirPressure = float.Parse(Console.ReadLine());
                wheels[i] = new Wheel(manufacturerName, currentAirPressure, maxAirPressure);
            }

            return wheels;
        }

        private eVehicleTypes getVehicleTypeToInsertGarage(Dictionary<eVehicleTypes, VehicleParametersTypes>.KeyCollection i_VehicleTypes)
        {
            string keysValues = string.Empty;
            int vehicleIndex = 1;
            foreach (eVehicleTypes key in i_VehicleTypes)
            {
                keysValues += vehicleIndex + ". " + key + Environment.NewLine;
                vehicleIndex++;
            }
            Console.Write(string.Format(
@"Vehicle details:
Please enter the type of vehicle you want to insert into the garage.
Please select one of the options (1-{0}), then press enter:
{1}", i_VehicleTypes.Count, keysValues));
            string vehicleChoiseString = string.Empty;
            vehicleChoiseString = Console.ReadLine();
            while (!checkInputValidation(vehicleChoiseString, "^[1-" + i_VehicleTypes.Count + "]{1}$"))
            {
                Console.WriteLine("Invalid choise. please try again, and then press enter:");
                vehicleChoiseString = Console.ReadLine();
            }
            return (eVehicleTypes)Enum.Parse(typeof(eVehicleTypes), vehicleChoiseString);
        }

        private void getOwnerNameAndPhone(out string o_ownerName, out string o_ownerPhone)
        {
            Console.WriteLine(
@"Details of vehicle owner:
Please enter the name of the vehicle owner, then press enter:");
            o_ownerName = Console.ReadLine();
            Console.WriteLine("Please enter the phone number of the vehicle owner, then press enter:");
            o_ownerPhone = Console.ReadLine();
            while (!checkInputValidation(o_ownerPhone, "^[0-9]*$"))
            {
                Console.WriteLine("Invalid Input. Phone number can contain digits only.");
                o_ownerPhone = Console.ReadLine();
            }
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
