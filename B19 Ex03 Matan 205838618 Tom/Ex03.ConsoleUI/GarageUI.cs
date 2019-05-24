using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageUI
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

        ////Show main menu and take user choise
        private eMenuOptions mainMenu()
        {
            string choise = string.Empty;
            bool isCaseSensitive = false;
            string optionalErrorToShow = "Invalid choise. please try again, and then press enter:";
            string regexPatternForInputValidation = "^[1-8]{1}$";

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
            checkInputValidation(ref choise, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);

            return (eMenuOptions)Enum.Parse(typeof(eMenuOptions), choise);
        }

        ////Invoke method according to the user selection
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
                case eMenuOptions.FillAirPressureToMax:
                    handleFillAirPressureToMax(i_garage);
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
                case eMenuOptions.Exit:
                    break;
                default:
                    break;
            }
        }

        ////Handle FillAirPressureToMax
        private void handleFillAirPressureToMax(Garage i_Garage)
        {
            string licenseNumber = string.Empty;

            Console.WriteLine("Please enter the license number of the vehicle you wish to inflate to maximum:");
            licenseNumber = Console.ReadLine();
            i_Garage.FillWheelsToMax(licenseNumber);
        }

        ////Handle ShowLicenses choise
        private void handleShowLicenses(Garage i_Garage)
        {
            const string userPressYes = "y";
            eVehicleConditions? vehicleStatusToFilter = null;
            bool toFilter;
            bool isCaseSensitive = true;
            string optionalErrorToShow = "Invalid choise. please try again, and then press enter:";
            string regexPatternForInputValidation = "^[y|n]{1}$";

            Console.WriteLine(
@"Would you like to filter license numbers by vehicle status?
Choose Y/N, and then press enter:");
            string choise = Console.ReadLine().ToLower();
            checkInputValidation(ref choise, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
            toFilter = choise.Equals(userPressYes);
            if (toFilter)
            {
                Console.WriteLine(
@"Which status would you like to filter?
Select one of the options by selecting the option's number (1-3), then press enter:
1. InRepair
2. Repaired
3. Paid");
                choise = Console.ReadLine();
                regexPatternForInputValidation = "^[1-3]{1}$";
                isCaseSensitive = false;
                checkInputValidation(ref choise, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
                vehicleStatusToFilter = (eVehicleConditions)Enum.Parse(typeof(eVehicleConditions), choise);
            }

            List<string> licenseToShow = i_Garage.ShowLicenseNumbersBool(toFilter, vehicleStatusToFilter);
            int indexLicense = 1;
            foreach (string license in licenseToShow)
            {
                Console.WriteLine(indexLicense + ". " + license);
                indexLicense++;
            }
        }

        ////Handle Change Status of Vehicle in garage
        private void handleChangeStatus(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            eVehicleConditions vehicleConditions;
            string optionalErrorToShow = "Invalid choise. please try again, and then press enter:";
            string regexPatternForInputValidation = "^[1-3]{1}$";

            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(
@"Please select a new status for vehicle:
Select one of the options by selecting the option's number (1-3), then press enter:
1. InRepair
2. Repaired
3. Paid");
            string choise = Console.ReadLine();
            bool isCaseSensitive = false;
            checkInputValidation(ref choise, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
            vehicleConditions = (eVehicleConditions)Enum.Parse(typeof(eVehicleConditions), choise);
            i_Garage.ChangeVehicleState(licenseNumber, vehicleConditions);
        }

        ////Handle Add Fuel by license Number
        private void handleAddFuel(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            eFuelType fuelType;
            float amountToFill;
            string regexPatternForInputValidation = "^[1-4]{1}$";
            string optionalErrorToShow = "Invalid choise. please try again, and then press enter:";

            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(
@"Please select a fuel type:
Select one of the options by selecting the option's number (1-4), then press enter:
1. Octan98
2. Octan96
3. Octan95
4. Soler");
            string choise = Console.ReadLine();
            bool isCaseSensitive = false;
            checkInputValidation(ref choise, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
            fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), choise);
            Console.WriteLine("Please enter the amount of liters of fuel to add, and then press enter:");
            amountToFill = float.Parse(Console.ReadLine());
            i_Garage.AddFuel(licenseNumber, fuelType, amountToFill);
        }

        ////Handle Charge battery by license Number
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

        ////Handle Show Vehicle by license Number
        private void handleShowVehicle(Garage i_Garage)
        {
            string licenseNumber = string.Empty;

            Console.WriteLine("Please enter a license number, and then press enter:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.GetVehicleInfo(licenseNumber)); 
        }

        ////Handle Add Veichle to garage
        ////Take all Vehicles types in garage from VehicleFactory class
        ////Building an object-type collection that will contain all the parameter-types for building the vehicle, according to user's choise
        ////Building a wheel-type collection according to vehicle-type user select
        private void handleAddVehicle(Garage garage)
        {
            Dictionary<eVehicleTypes, Type> vehicles = VehicleFactory.Vehicles;
            Dictionary<eVehicleTypes, int> wheelsNumber = VehicleFactory.WheelsNumberPerVehicle;
            Type[] parametersTypesFromConstructor;
            List<string> parametersDescription = new List<string>();
            string ownerName = string.Empty;
            string ownerPhone = string.Empty;
            Wheel[] wheelsArray;
            List<object> paramsToBuildVehicle = new List<object>();
            eVehicleTypes vehicleChoise;

            getOwnerNameAndPhone(out ownerName, out ownerPhone);
            vehicleChoise = getVehicleTypeFromUser(vehicles.Keys);
            parametersTypesFromConstructor = ConstructorReflection.GetConstructorParametersTypes(vehicles[vehicleChoise], parametersDescription);
            paramsToBuildVehicle = getParametersFromUserByVehicleType(parametersTypesFromConstructor, parametersDescription.ToArray());
            wheelsArray = getWheelsArray(wheelsNumber[vehicleChoise], vehicles[vehicleChoise]);
            garage.AddVehicleToGarage(ownerName, ownerPhone, vehicleChoise, paramsToBuildVehicle, wheelsArray);
        }

        ////Building wheels collection
        private Wheel[] getWheelsArray(int i_WheelsNumber, Type i_VehicleType)
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

        ////The user choose which vehicle he wants to add to the garage, according to the types of vehicles in VehicleFactory
        private eVehicleTypes getVehicleTypeFromUser(Dictionary<eVehicleTypes, Type>.KeyCollection i_VehicleTypes)
        {
            string keysValues = string.Empty;
            int vehicleIndex = 1;
            bool isCaseSensitive = false;
            string optionalErrorToShow = "Invalid choise. please try again, and then press enter:";

            foreach (eVehicleTypes key in i_VehicleTypes)
            {
                keysValues += vehicleIndex + ". " + key + Environment.NewLine;
                vehicleIndex++;
            }

            Console.Write(string.Format(
@"Vehicle details:
Please enter the type of vehicle you want to insert into the garage.
Please select one of the options (1-{0}), then press enter:
{1}", 
i_VehicleTypes.Count,
keysValues));
            string vehicleChoiseString = Console.ReadLine();
            string regexPatternForInputValidation = "^[1-" + i_VehicleTypes.Count + "]{1}$";
            checkInputValidation(ref vehicleChoiseString, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);

            return (eVehicleTypes)Enum.Parse(typeof(eVehicleTypes), vehicleChoiseString);
        }

        ////Take owner name and phone from user
        private void getOwnerNameAndPhone(out string o_ownerName, out string o_ownerPhone)
        {
            string regexPatternForInputValidation = "^[a-zA-Z]+$";
            string optionalErrorToShow = "Invalid Input. Name can contain letters only.";
            bool isCaseSensitive = false;

            Console.WriteLine(
@"Details of vehicle owner:
Please enter the name of the vehicle owner, then press enter:");
            o_ownerName = Console.ReadLine();
            checkInputValidation(ref o_ownerName, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
            Console.WriteLine("Please enter the phone number of the vehicle owner, then press enter:");
            o_ownerPhone = Console.ReadLine();
            regexPatternForInputValidation = "^[0-9]*$";
            optionalErrorToShow = "Invalid Input. Phone number can contain digits only.";
            checkInputValidation(ref o_ownerPhone, regexPatternForInputValidation, optionalErrorToShow, isCaseSensitive);
        }

        ////Take parameters by its type from user
        private List<object> getParametersFromUserByVehicleType(Type[] i_ParameterTypes, string[] i_ParamDescription)
        {
            List<object> paramsToBuildVehicle = new List<object>();

            for (int i = 0; i < i_ParamDescription.Length; i++)
            {
                paramsToBuildVehicle.Add(getSingleParameterFromUserByVehicleType(i_ParameterTypes[i], i_ParamDescription[i]));
            }

            return paramsToBuildVehicle;
        }

        ////Take a specific parameter by its type from user
        ////Uses a reflection to determine which type of parameter to take from user
        private object getSingleParameterFromUserByVehicleType(Type i_ParameterType, string i_ParamDescription)
        {
            const string userPressYes = "y"; 
            object buildParameterToReturn = new object();
            string errorMessageShowUser = "Invalid choise. please try again, and then press enter:";
            bool isCaseSensitive = false;
            string regexPatternForInputValidation = string.Empty;
            string requestFromUser = "Please enter " + i_ParamDescription;

            if (i_ParameterType == typeof(string))
            {
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                buildParameterToReturn = Console.ReadLine();
            }
            else if (i_ParameterType == typeof(int))
            {
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                buildParameterToReturn = int.Parse(Console.ReadLine());
            }
            else if (i_ParameterType.IsEnum)
            {
                int numberOfEnumValues = Enum.GetValues(i_ParameterType).Length;
                requestFromUser = string.Format(
@"Please Choose {0}:
Select one of the options by selecting the option's number (1-{1}),
then press enter:", 
i_ParamDescription, 
numberOfEnumValues);
                int indexEnum = 1;
               foreach (Enum valEnum in Enum.GetValues(i_ParameterType))
               {
                    requestFromUser += Environment.NewLine + indexEnum + ". " + valEnum;
                    indexEnum++;
               }

               Console.WriteLine(requestFromUser);
                string choiseString = Console.ReadLine();
                regexPatternForInputValidation = "^[1-" + numberOfEnumValues + "]{1}$";
                checkInputValidation(ref choiseString, regexPatternForInputValidation, errorMessageShowUser, isCaseSensitive);
                buildParameterToReturn = Enum.Parse(i_ParameterType, choiseString);
            }
            else if (i_ParameterType == typeof(float))
            {
                requestFromUser += ", and then press enter:";
                Console.WriteLine(requestFromUser);
                buildParameterToReturn = float.Parse(Console.ReadLine());
            }
            else if (i_ParameterType == typeof(bool))
            {
                Console.WriteLine("Please enter Y if " + i_ParamDescription + " and N if not");
                string choise = Console.ReadLine().ToLower();
                isCaseSensitive = true;
                regexPatternForInputValidation = "^[y|n]{1}$";
                checkInputValidation(ref choise, regexPatternForInputValidation, errorMessageShowUser, isCaseSensitive);
                buildParameterToReturn = choise.Equals(userPressYes);
            }

            return buildParameterToReturn;
        }

        ////Check input validation by regex expression
        private void checkInputValidation(ref string i_Choise, string i_PatternRegex, string i_ErrorMessage, bool toLower)
        {
            while (!Regex.IsMatch(i_Choise, i_PatternRegex))
            {
                Console.WriteLine(i_ErrorMessage);
                if (toLower)
                {
                    i_Choise = Console.ReadLine().ToLower();
                }
                else
                {
                    i_Choise = Console.ReadLine();
                }
            }
        }
    }
}
