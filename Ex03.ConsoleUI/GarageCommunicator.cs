namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;

    public class GarageCommunicator
    {
        GarageManager m_GarageManager = new GarageManager();

        public static void RunMenu()
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
                switch (i_UserChoice)
                {
                    case eMenuOption.NewVehicle:
                        CheckIfVehicleExist(lisencePlateNumber);
                        break;
                    case eMenuOption.ChangeVehicleState:
                        UserChangeVehicleState(lisencePlateNumber);
                        break;
                    case eMenuOption.InflationWheelAirToMax:
                        m_GarageManager.InflateWheels(lisencePlateNumber);
                        break;
                    case eMenuOption.FuelVehicle:
                        //garage manager checks if is fuel vehicle

                        FuelVehicle(lisencePlateNumber);
                        break;
                    case eMenuOption.ChargingVehicle:
                        break;
                    case eMenuOption.FullDetailsOnVehicle:
                        break;
                }
            }
        }

        private void CheckIfVehicleExist(string i_LisencePlateNumber)
        {
            if (IsLisencePlateNumberExist(i_LisencePlateNumber)) // LogicMethod
            {
                Console.WriteLine("This vehicle has already in the garage!");
                //change the vehicle state - logic method
            }
            else
            {
                //AddNewVehicle(i_LisencePlateNumber); - LogicMethod
            }
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

        //private void ParsingUserChoices<T>(string i_LisencePlateNumber)
        //{
        //    bool legalInput = false;
        //    T newParse;
        //    do
        //    {
        //        try
        //        {
        //            legalInput = T.TryParse(Console.ReadLine(), out newState);
        //        }
        //        catch (FormatException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        catch (ValueOutOfRangeException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }

        //    } while (!legalInput);
        //}

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

            } while (!legalInput);

            m_GarageManager.ChangeVehicleState(i_LisencePlateNumber, newState);
        }

        private void FuelVehicle(string i_LisencePlateNumber)
        {
            bool legalInput = false;
            while(!legalInput)
            {
                try
                {
                    legalInput = float.TryParse(Console.ReadLine(), out float amountOfFuel);
                    legalInput = FuelType.eFuelType.TryParse(Console.ReadLine(), out FuelType.eFuelType userFuelType);
                    m_GarageManager.LoadEnergySource(i_LisencePlateNumber);
                }
                catch(FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException rangeException)
                {
                    Console.WriteLine(rangeException.Message);
                }

                
            }

        }
    }
}
