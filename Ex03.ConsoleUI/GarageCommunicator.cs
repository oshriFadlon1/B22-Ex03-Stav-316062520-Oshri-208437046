namespace Ex03.ConsoleUI
{
    using System;
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
                catch (FormatException ex)
                {
                    // invalid input
                }
                catch (ArgumentException ex)
                {
                    // invalid input in logic means
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    // value out of range
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
                //PrintList
            }
            else
            {

                AskUserLisencePlateNumber(out string lisencePlateNumber);
                bool isVehicleExist = CheckIfVehicleExist(lisencePlateNumber);
                if (i_UserChoice == eMenuOption.NewVehicle && !isVehicleExist)
                {
                    AddVehicle(lisencePlateNumber);

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
                            UserChangeVehicleState(lisencePlateNumber);
                            break;
                        case eMenuOption.InflationWheelAirToMax:
                            m_GarageManager.InflateWheels(lisencePlateNumber);
                            break;
                        case eMenuOption.FuelVehicle:
                            if (isVehicleExist)
                            {
                                FuelVehicle(lisencePlateNumber);
                            }

                            break;
                        case eMenuOption.ChargingVehicle:
                            if (isVehicleExist)
                            {
                                ChargeVehicle(lisencePlateNumber);
                            }

                            break;
                        case eMenuOption.FullDetailsOnVehicle:
                            if (isVehicleExist)
                            {
                                // tostring in override to vehicle and currentVehicle
                            }
                            break;
                    }
                }
            }
        }

        private void AddVehicle(string i_LisencePlateNumber)
        {
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
            if (o_LisencePlateNumber.Length == 0)
            {
                throw new FormatException();
            }
        }

        private void UserChangeVehicleState(string i_LisencePlateNumber)
        {
            bool legalInput = false;
            VehicleState.eVehicleState newState = VehicleState.eVehicleState.InRepair;
            do
            {
                try
                {
                    legalInput = VehicleState.TryParse(Console.ReadLine(), out newState);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!legalInput);

            m_GarageManager.ChangeVehicleState(i_LisencePlateNumber, newState);
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
                    Console.WriteLine("Enter how much to Charge you would like to refuel.");
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

        public static void PrintAllTypeOfFuel()
        {
            string fuelName;
            for (int i = 1; i < Enum.GetNames(typeof(EnergySourceType.eEnergySourceType)).Length; i++)
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
    }
}
