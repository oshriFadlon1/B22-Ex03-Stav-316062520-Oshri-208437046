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
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }

            } while (userChoice != eMenuOption.Exit);
        }

        private static void PrintMenu()
        {
            Console.WriteLine(@"Please enter your choice:
1. Enter new vehicle
2. Show the garage's vehicle license numbers list.
3. Change vehicle state.
4. Infale air in the vehicle wheels.
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

            while (!legalInput)
            {
                Console.WriteLine("Invalid input, please enter input between 1 and 8");
                legalInput = int.TryParse(Console.ReadLine(), out userChoice);
                if (legalInput && userChoice > 0 && userChoice <= 8)
                {
                    io_UserChoice = (eMenuOption)userChoice;
                    continue;
                }
            }
        }

        private void ExecuteUserChoice(eMenuOption i_UserChoice)
        {
            if (i_UserChoice == eMenuOption.LicenseNumbersList)
            {
                PrintAllLicenseNumbers();
            }
            else
            {

                AskUserLisencePlateNumber(out string lisencePlateNumber);
                bool isVehicleExist = CheckIfVehicleExist(lisencePlateNumber);

                if (i_UserChoice == eMenuOption.NewVehicle && !isVehicleExist)
                {
                    VehicleType.eTypeVehicles userVehicle = UserChooseHisVehicleType();
                    AddVehicle(lisencePlateNumber, userVehicle);
                }

                if (isVehicleExist)
                {
                    switch (i_UserChoice)
                    {
                        case eMenuOption.NewVehicle:
                            Console.WriteLine("This vehicle has already in the garage!");
                            m_GarageManager.ChangeVehicleState(lisencePlateNumber, VehicleState.eVehicleState.InRepair);
                            break;
                        case eMenuOption.ChangeVehicleState:
                            VehicleState.eVehicleState newState = UserChooseVehicleState();
                            m_GarageManager.ChangeVehicleState(lisencePlateNumber, newState);
                            break;
                        case eMenuOption.InflationWheelAirToMax:
                            m_GarageManager.InflateWheels(lisencePlateNumber);
                            break;
                        case eMenuOption.FuelVehicle:
                            FuelVehicle(lisencePlateNumber);
                            break;
                        case eMenuOption.ChargingVehicle:
                            ChargeVehicle(lisencePlateNumber);
                            break;
                        case eMenuOption.FullDetailsOnVehicle:
                            PrintAllDataOfCurrentVehicle(lisencePlateNumber);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You inserted a license plate that does not exist in the system.");
                }
            }
        }

        private static VehicleType.eTypeVehicles UserChooseHisVehicleType()
        {
            bool legalInput = false;
            VehicleType.eTypeVehicles userVehicle = VehicleType.eTypeVehicles.RegularCar;

            do
            {
                try
                {
                    PrintAllTypeOfVehicles();
                    userVehicle = (VehicleType.eTypeVehicles)Enum.Parse(typeof(VehicleType.eTypeVehicles),Console.ReadLine());
                    legalInput = true;
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            while (!legalInput);

            return userVehicle;

        }

        private void AddVehicle(string i_lisencePlateNumber, VehicleType.eTypeVehicles i_UserVehicle)
        {
            Dictionary<string, Type> moreInfoNeedForUser;
            bool isInputCorrect = false;
            object userInput = null;
            List<object> userInfoNeeded = new List<object>();

            // to do: get out in method
            Console.WriteLine("Please enter vehicle model name: ");
            string modelName = Console.ReadLine();

            while (modelName.Length == 0)
            {
                Console.WriteLine("Wrong insert. Please try again: ");
                modelName = Console.ReadLine();
            }

            float amountOfEnergy = UserInsertAmountOfEnergy();
            UserInsertDetailsOfWheels(out string manufactureName, out float currentAirPressure);
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
                        userInput = Convert.ChangeType(userInputInString, entry.Value);
                        isInputCorrect = true;
                        userInfoNeeded.Add(userInput);
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine(formatException.Message);
                        userInputInString = Console.ReadLine();
                        isInputCorrect = false;
                    }
                }

                isInputCorrect = true;
            }
            // we send all to garage manager -> creator -> create new vehicle and insert to dictionery
            //AddNewVehicle(i_LisencePlateNumber); - LogicMethod
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

        private static float UserInsertAmountOfEnergy()
        {
            Console.WriteLine("Please enter the current amount of energy in the vehicle: ");
            bool legalAmoutOfEnergy = false;
            float amountOfEnergy = 0;
            while (!legalAmoutOfEnergy)
            {
                try
                {
                    amountOfEnergy = float.Parse(Console.ReadLine());
                    if (amountOfEnergy < 0)
                    {
                        legalAmoutOfEnergy = false;
                        Console.WriteLine("the amount of energy can`t be negative.");
                    }
                    else
                    {
                        legalAmoutOfEnergy = true;
                    }

                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }

            return amountOfEnergy;
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
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
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
                    Console.WriteLine("Enter how much fuel you would like to refuel.");
                    amountOfFuel = float.Parse(Console.ReadLine());

                    PrintAllTypeOfFuel();
                    legalInput = EnergySourceType.eEnergySourceType.TryParse(Console.ReadLine(), out EnergySourceType.eEnergySourceType userFuelType);

                    m_GarageManager.LoadEnergySource(i_LisencePlateNumber, amountOfFuel, legalInput, userFuelType);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    Console.WriteLine(rangeException.Message);
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
                    Console.WriteLine("Enter how much minutes to Charge you would like to recharge.");
                    amountOfEnergy = float.Parse(Console.ReadLine());
                    legalInput = true;
                    m_GarageManager.LoadEnergySource(i_LisencePlateNumber, amountOfEnergy, legalInput, EnergySourceType.eEnergySourceType.Electric);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    legalInput = false;
                    Console.WriteLine(rangeException.Message);
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
            for (int i = 1; i <= Enum.GetNames(typeof(EnergySourceType.eEnergySourceType)).Length; i++)
            {
                fuelName = ((EnergySourceType.eEnergySourceType)i).ToString();
                Console.WriteLine("To select {0} press {1}.", fuelName, i);
            }
        }

        public static void PrintAllTypeOfVehicles()
        {
            string vehicleType;
            for (int i = 0; i < Enum.GetNames(typeof(VehicleType.eTypeVehicles)).Length; i++)
            {
                vehicleType = ((VehicleType.eTypeVehicles)i).ToString();
                Console.WriteLine("To select {0} press {1}.", vehicleType, i + 1);
            }
        }

        public void PrintAllDataOfCurrentVehicle(string i_LisencePlateNumber)
        {
            Console.WriteLine(m_GarageManager.GetDataOfCurrentVehicle(i_LisencePlateNumber));
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
                    legalInput = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
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

            foreach (string licenseNumber in licenses)
            {
                Console.WriteLine(licenseNumber);
            }
        }
    }
}

//Type[] kindOfVehicls = Assembly.GetAssembly(typeof(Vehicle)).GetTypes();
//List<string> typesInEnum = VehicleType.getListOfTypes();
////string theUserVehicleType = typesInEnum[(int)i_UserVehicle];
//string typeName = typesInEnum[((int)i_UserVehicle) - 1];
//foreach(Type type in kindOfVehicls)
//{
//    if (type.IsSubclassOf(typeof(Vehicle)))
//    {
//        if (type.Name == typeName)
//        {
//            type.
//        }
//    }
//}
//    if (i_UserVehicle == VehicleType.eTypeVehicles.RegularCar || i_UserVehicle == VehicleType.eTypeVehicles.ElectricCar)
//{
//    foreach(KeyValuePair<string, Type> detail in Car.s_CarInformation)
//    {
//        Console.WriteLine(detail.Key);
//        Type type = detail.Value.GetType();
//    }
//}