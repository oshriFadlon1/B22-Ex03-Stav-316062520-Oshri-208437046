namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Ex03.GarageLogic;

    public class GarageCommunicator
    {
        GarageManager m_GarageManager = new GarageManager();

        public void RunMenu()
        {
            eMenuOption userChoice = eMenuOption.Start;
            Console.WriteLine("Hello! Welcome to the GARAGE!");
            System.Threading.Thread.Sleep(2000);
            do
            {
                PrintMenu();
                try
                {
                    GetChoice(ref userChoice);
                    ExecuteUserChoice(userChoice);
                }
                catch (FormatException formatException)
                {
                    FormatExceptionMessage(formatException);
                }
                catch (ArgumentException argumentException)
                {
                    ArgumentExceptionMessage(argumentException);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException valueOutOfRangeException)
                {
                    ValueOutOfRangeExceptionMessage(valueOutOfRangeException);
                }
                catch (Exception exception)
                {
                    GeneralExceptionMessage();
                }

            }
            while (userChoice != eMenuOption.Exit);
        }

        private static void PrintMenu()
        {
            System.Console.Clear();
            Console.WriteLine(@"Please enter your choice:
1. Enter new vehicle
2. Show the garage's vehicle license numbers list.
3. Change vehicle state.
4. Inflate air in the vehicle wheels.
5. Fuel a regular vehicle.
6. Charge an elecric vehicle.
7. Show vehicle's full details.
8. Exit");
        }

        private static void GetChoice(ref eMenuOption io_UserChoice)
        {
            bool legalInput;
            int userChoice;
            legalInput = int.TryParse(Console.ReadLine(), out userChoice);
            if (legalInput && userChoice > 0 && userChoice <= 8)
            {
                io_UserChoice = (eMenuOption)userChoice;
            }
            else
            {
                legalInput = false;
            }

            while (!legalInput)
            {
                Console.WriteLine("Invalid input, please enter input between 1 and 8");
                legalInput = int.TryParse(Console.ReadLine(), out userChoice);
                if (legalInput && userChoice > 0 && userChoice <= 8)
                {
                    io_UserChoice = (eMenuOption)userChoice;
                    continue;
                }
                else
                {
                    legalInput = false;
                }
            }
        }

        private void ExecuteUserChoice(eMenuOption i_UserChoice)
        {
            if(i_UserChoice == eMenuOption.Exit)
            {
                Console.WriteLine("Goodbye!");
                System.Threading.Thread.Sleep(1500);
            }
            else if (i_UserChoice == eMenuOption.LicenseNumbersList)
            {
                PrintAllLicenseNumbers();
            }
            else
            {
                AskUserLisencePlateNumber(out string lisencePlateNumber);
                bool isVehicleExist = CheckIfVehicleExist(lisencePlateNumber);

                if (i_UserChoice == eMenuOption.NewVehicle && !isVehicleExist)
                {
                    VehicleCreator.eTypeVehicles userVehicle = UserChooseHisVehicleType();
                    AddVehicle(lisencePlateNumber, userVehicle);
                }
                else if (isVehicleExist)
                {
                    switch (i_UserChoice)
                    {
                        case eMenuOption.NewVehicle:
                            Console.WriteLine("This vehicle has already in the garage!");
                            Console.WriteLine("the state of this vehicle has changed to in repair.");
                            System.Threading.Thread.Sleep(1500);
                            m_GarageManager.ChangeVehicleState(lisencePlateNumber, VehicleState.eVehicleState.InRepair);
                            break;
                        case eMenuOption.ChangeVehicleState:
                            VehicleState.eVehicleState newState = UserChooseVehicleState();
                            m_GarageManager.ChangeVehicleState(lisencePlateNumber, newState);
                            Console.WriteLine("The vehicle state has changed.");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case eMenuOption.InflationWheelAirToMax:
                            m_GarageManager.InflateWheels(lisencePlateNumber);
                            Console.WriteLine("All the wheels are inflated to max!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case eMenuOption.FuelVehicle:
                            FuelVehicle(lisencePlateNumber);
                            Console.WriteLine("The vehicle is successfully refueled!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case eMenuOption.ChargingVehicle:
                            ChargeVehicle(lisencePlateNumber);
                            Console.WriteLine("The vehicle is successfully charged!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case eMenuOption.FullDetailsOnVehicle:
                            PrintAllDataOfCurrentVehicle(lisencePlateNumber);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You inserted a license plate that does not exist in the system.");
                    System.Threading.Thread.Sleep(1500);
                }
            }
        }

        private static VehicleCreator.eTypeVehicles UserChooseHisVehicleType()
        {
            bool legalInput = false;
            VehicleCreator.eTypeVehicles userVehicle = VehicleCreator.eTypeVehicles.RegularCar;
            string input;
            int userChioce;

            do
            {
                try
                {
                    PrintAllTypeOfVehicles();
                    input = Console.ReadLine();
                    userChioce = int.Parse(input);
                    if (userChioce > 0 && userChioce <= Enum.GetNames(typeof(VehicleCreator.eTypeVehicles)).Length)
                    {
                        userVehicle = (VehicleCreator.eTypeVehicles)Enum.Parse(typeof(VehicleCreator.eTypeVehicles), input);
                        legalInput = true;
                    }
                    else
                    {
                        Console.WriteLine("invalid input. try again.");
                    }

                }
                catch (ArgumentException argumentException)
                {
                    ArgumentExceptionMessage(argumentException);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            while (!legalInput);

            return userVehicle;

        }

        private void AddVehicle(string i_lisencePlateNumber, VehicleCreator.eTypeVehicles i_UserVehicle)
        {
            Dictionary<string, Type> moreInfoNeedForUser;
            bool isInputCorrect = false;
            object userInput = null;
            List<object> userInfoNeeded = new List<object>();

            UserInsertSpecificName(out string modelName, "model vehicle");
            float amountOfEnergy = UserInsertAmountOf("vehicle energy");
            UserInsertSpecificName(out string manufactureName, "wheel manufacturer");
            float currentAirPressure = UserInsertAmountOf("wheels air pressure");
            UserInsertHisPersonalDetails(out Customer owner);

            VehicleCreator.GetMoreInfo(i_UserVehicle, out moreInfoNeedForUser);
            foreach (KeyValuePair<string, Type> entry in moreInfoNeedForUser)
            {
                Console.WriteLine(entry.Key);
                string userInputInString = Console.ReadLine();
                while (!isInputCorrect)
                {
                    try
                    {
                        if (entry.Value == typeof(bool))
                        {
                            if (userInputInString != "yes" && userInputInString != "no")
                            {
                                Console.WriteLine("You have to insert yes/no");
                                userInputInString = Console.ReadLine();
                                continue;
                            }
                            else if (userInputInString == "yes")
                            {
                                userInput = Convert.ChangeType(true, typeof(bool));
                            }
                            else if (userInputInString == "no")
                            {
                                userInput = Convert.ChangeType(false, typeof(bool));
                            }
                        }
                        else
                        {
                            userInput = Convert.ChangeType(userInputInString, entry.Value);
                        }

                        isInputCorrect = true;
                        userInfoNeeded.Add(userInput);
                    }
                    catch (FormatException formatException)
                    {
                        FormatExceptionMessage(formatException);
                        userInputInString = Console.ReadLine();
                        isInputCorrect = false;
                    }
                    catch (Exception generalException)
                    {
                        Console.WriteLine("Your input is invalid. Please try again: ");
                        userInputInString = Console.ReadLine();
                        isInputCorrect = false;
                    }
                }

                isInputCorrect = false;
            }

            m_GarageManager.AddNewVehicle(i_UserVehicle, modelName, i_lisencePlateNumber, owner, manufactureName, currentAirPressure, userInfoNeeded, amountOfEnergy);
            Console.WriteLine("vehicle is created succefully.");
            System.Threading.Thread.Sleep(2000);
        }

        private bool CheckIfVehicleExist(string i_LisencePlateNumber)
        {
            bool isVehicleExist = false;
            if (m_GarageManager.IsLisencePlateNumberExist(i_LisencePlateNumber))
            {
                isVehicleExist = true;
            }

            return isVehicleExist;
        }

        private void AskUserLisencePlateNumber(out string o_LisencePlateNumber)
        {
            Console.WriteLine("Please enter your lisence plate number: ");
            o_LisencePlateNumber = Console.ReadLine();
            while (o_LisencePlateNumber.Length == 0)
            {
                Console.WriteLine("lisence plate number most contain at least 1 character.");
                Console.WriteLine("Please enter your lisence plate number: ");
                o_LisencePlateNumber = Console.ReadLine();
            }
        }

        private static float UserInsertAmountOf(string i_DescriptionAmount)
        {
            Console.WriteLine("Please enter the current amount of {0}: ", i_DescriptionAmount);
            bool legalAmout = false;
            float amountOf = 0;
            while (!legalAmout)
            {
                try
                {
                    amountOf = float.Parse(Console.ReadLine());
                    if (amountOf < 0)
                    {
                        legalAmout = false;
                        Console.WriteLine("the amount can`t be negative. Please try again: ");
                    }
                    else
                    {
                        legalAmout = true;
                    }
                }
                catch
                {
                    GeneralExceptionMessage();
                }
            }

            return amountOf;
        }

        private static void UserInsertSpecificName(out string o_Name, string i_NameDescription)
        {
            bool legalName = false, isWithoutSigns = true;
            Console.WriteLine("Please enter the {0} name: ", i_NameDescription);
            o_Name = Console.ReadLine();
            while (!legalName)
            {
                if (o_Name.Length == 0)
                {
                    Console.WriteLine("You inserted an empty name. Please try again: ");
                    o_Name = Console.ReadLine();
                    continue;
                }
                else
                {
                    foreach (char letter in o_Name)
                    {
                        if (!char.IsLetter(letter) && letter != ' ' && !char.IsDigit(letter))
                        {
                            isWithoutSigns = false;
                            Console.WriteLine("Wrong Input. Please enter letters only: ");
                            o_Name = Console.ReadLine();
                            break;
                        }
                    }
                }

                if (isWithoutSigns)
                {
                    legalName = true;
                }
                else
                {
                    isWithoutSigns = true;
                }

            }
        }

        private static void UserInsertPhoneNumber(out string o_PhoneNumber)
        {
            bool legalPhoneNumber = false, isDigitsOnly = true;
            Console.WriteLine("Please enter your phone number (10 digits): ");
            o_PhoneNumber = Console.ReadLine();
            while (!legalPhoneNumber)
            {
                if (o_PhoneNumber.Length != 10)
                {
                    Console.WriteLine("your has to insert exactly 10 digits. Try again: ");
                    o_PhoneNumber = Console.ReadLine();
                    continue;
                }
                else
                {
                    foreach (char digit in o_PhoneNumber)
                    {
                        if (!char.IsDigit(digit))
                        {
                            isDigitsOnly = false;
                            Console.WriteLine("Wrong Input. Please enter digits only: ");
                            o_PhoneNumber = Console.ReadLine();
                            break;
                        }

                    }
                }

                if (isDigitsOnly)
                {
                    legalPhoneNumber = true;
                }
                else
                {
                    isDigitsOnly = true;
                }
            }
        }

        private static void UserInsertHisPersonalDetails(out Customer o_Owner)
        {
            UserInsertSpecificName(out string ownerName, "vehicle owner");
            UserInsertPhoneNumber(out string phoneNumber);
            o_Owner = new Customer(ownerName, phoneNumber);
        }

        private static VehicleState.eVehicleState UserChooseVehicleState()
        {
            bool legalInput = false;
            VehicleState.eVehicleState newState = VehicleState.eVehicleState.InRepair;
            do
            {
                try
                {
                    PrintAllTypeOfState();
                    legalInput = VehicleState.TryParse(Console.ReadLine(), out newState);
                }
                catch (FormatException formatException)
                {
                    FormatExceptionMessage(formatException);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    ValueOutOfRangeExceptionMessage(valueOutOfRangeException);
                }
            }
            while (!legalInput);

            return newState;
        }

        private void FuelVehicle(string i_LisencePlateNumber)
        {
            float amountOfFuel;
            bool legalInput = false;
            while (!legalInput)
            {
                try
                {
                    Console.WriteLine("Enter how much liters of fuel you would like to refuel:");
                    amountOfFuel = float.Parse(Console.ReadLine());

                    PrintAllTypeOfFuel();
                    legalInput = EnergySourceType.eEnergySourceType.TryParse(Console.ReadLine(), out EnergySourceType.eEnergySourceType userFuelType);

                    m_GarageManager.LoadEnergySource(i_LisencePlateNumber, amountOfFuel, legalInput, userFuelType);
                }
                catch (FormatException formatException)
                {
                    legalInput = false;
                    FormatExceptionMessage(formatException);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    legalInput = false;
                    ValueOutOfRangeExceptionMessage(rangeException);
                }
            }
        }

        private void ChargeVehicle(string i_LisencePlateNumber)
        {
            float amountOfEnergy;
            bool legalInput = false;
            while (!legalInput)
            {
                try
                {
                    Console.WriteLine("Enter how much minutes to Charge you would like to recharge:");
                    amountOfEnergy = float.Parse(Console.ReadLine());
                    legalInput = true;
                    m_GarageManager.LoadEnergySource(i_LisencePlateNumber, amountOfEnergy, legalInput, EnergySourceType.eEnergySourceType.Electric);
                }
                catch (FormatException formatException)
                {
                    legalInput = false;
                    FormatExceptionMessage(formatException);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    legalInput = false;
                    ValueOutOfRangeExceptionMessage(rangeException);
                }
            }
        }

        public static void PrintAllTypeOfState()
        {
            string stateName;
            for (int i = 0; i < Enum.GetNames(typeof(VehicleState.eVehicleState)).Length; i++)
            {
                stateName = ((VehicleState.eVehicleState)i).ToString();
                Console.WriteLine("To select {0} press {1}.", stateName, i);
            }
        }

        public static void PrintAllTypeOfFuel()
        {
            string fuelName;
            for (int i = 2; i <= Enum.GetNames(typeof(EnergySourceType.eEnergySourceType)).Length; i++)
            {
                fuelName = ((EnergySourceType.eEnergySourceType)i).ToString();
                Console.WriteLine("To select {0} press {1}.", fuelName, i);
            }
        }

        public static void PrintAllTypeOfVehicles()
        {
            string vehicleType;
            for (int i = 1; i <= Enum.GetNames(typeof(VehicleCreator.eTypeVehicles)).Length; i++)
            {
                vehicleType = ((VehicleCreator.eTypeVehicles)i).ToString();
                Console.WriteLine("To select {0} press {1}.", vehicleType, i);
            }
        }

        public void PrintAllDataOfCurrentVehicle(string i_LisencePlateNumber)
        {
            Console.WriteLine(m_GarageManager.GetDataOfCurrentVehicle(i_LisencePlateNumber));
            System.Threading.Thread.Sleep(10000);
        }

        public void PrintAllLicenseNumbers()
        {
            char userChoice = 'n';
            bool legalInput = false;
            List<string> licenses = new List<string>();
            while (!legalInput)
            {
                try
                {
                    Console.WriteLine("Would you like to filter by the repair condition of the vehicle?");
                    Console.WriteLine("enter y for yes and n for no.");
                    userChoice = char.Parse(Console.ReadLine());
                    if (userChoice == 'n' || userChoice == 'y')
                    {
                        legalInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong character! let's try again.");
                    }
                }
                catch (Exception)
                {
                    GeneralExceptionMessage();
                }
            }

            if (userChoice == 'y')
            {
                VehicleState.eVehicleState newState = UserChooseVehicleState();
                m_GarageManager.GetAllLicenseNumbersByState(ref licenses, newState);
            }
            else
            {
                m_GarageManager.GetAllLicenseNumbers(ref licenses);
            }

            if (licenses.Count == 0)
            {
                Console.WriteLine("we don't have vehicles in the garage that answer you request yet.");
            }
            else
            {
                foreach (string licenseNumber in licenses)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            System.Threading.Thread.Sleep(6000);
        }

        private static void FormatExceptionMessage(FormatException i_FormatException)
        {
            System.Console.Clear();
            Console.WriteLine(i_FormatException.Message);
            System.Threading.Thread.Sleep(4000);
        }

        private static void ValueOutOfRangeExceptionMessage(ValueOutOfRangeException i_ValueOutOfRangeException)
        {
            System.Console.Clear();
            Console.WriteLine(i_ValueOutOfRangeException.Message);
            System.Threading.Thread.Sleep(4000);
        }

        private static void ArgumentExceptionMessage(ArgumentException i_ArgumentException)
        {
            System.Console.Clear();
            Console.WriteLine(i_ArgumentException.Message);
            System.Threading.Thread.Sleep(4000);
        }

        private static void GeneralExceptionMessage()
        {
            Console.WriteLine("something went wrong, try again.");
            System.Threading.Thread.Sleep(1500);
        }
    }
}