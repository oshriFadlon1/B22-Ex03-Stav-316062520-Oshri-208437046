namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class VehicleCreator
    {
        public enum eTypeVehicles
        {
            RegularCar = 1,
            RegularTruck,
            RegularMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
        }

        public static Vehicle CreateNewVehicle(eTypeVehicles i_UserVehicle, string i_ModelName, string i_LicensePlateNumber,
            Customer i_Owner, string i_ManufacturerName, float i_CurrentAirPressure,List<object> i_MoreInfoFromUser, float i_CurrentEnergy)
        {
            Vehicle newVehcle = null;

            switch (i_UserVehicle)
            {
                case eTypeVehicles.RegularCar:
                    newVehcle = new RegularCar(i_ModelName, i_LicensePlateNumber, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                        (eCarColor)i_MoreInfoFromUser[0], (eNumberOfDoors)i_MoreInfoFromUser[1], i_CurrentEnergy);
                    break;
                case eTypeVehicles.ElectricCar:
                    newVehcle = new ElectricCar(i_ModelName, i_LicensePlateNumber, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                        (eCarColor)i_MoreInfoFromUser[0], (eNumberOfDoors)i_MoreInfoFromUser[1], i_CurrentEnergy);
                    break;
                case eTypeVehicles.RegularMotorcycle:
                    newVehcle = new RegularMotorcycle(i_ModelName, i_LicensePlateNumber, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                        (eMotorcycleLicense)i_MoreInfoFromUser[0], (int)i_MoreInfoFromUser[1], i_CurrentEnergy);
                    break;
                case eTypeVehicles.ElectricMotorcycle:
                    newVehcle = new ElectricMotorcycle(i_ModelName, i_LicensePlateNumber, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                        (eMotorcycleLicense)i_MoreInfoFromUser[0], (int)i_MoreInfoFromUser[1], i_CurrentEnergy);
                    break;
                case eTypeVehicles.RegularTruck:
                    newVehcle = new RegularTruck(i_ModelName, i_LicensePlateNumber, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                        (bool)i_MoreInfoFromUser[0], (float)i_MoreInfoFromUser[1], i_CurrentEnergy);
                    break;
            }

            return newVehcle;
        }

        public static void GetMoreInfo(eTypeVehicles i_UserVehicle, out Dictionary<string, Type> o_MoreInfoNeedForUser)
        {
            o_MoreInfoNeedForUser = null;
            // switch which vehicle more info we need return in out dictionery
            if (i_UserVehicle == eTypeVehicles.ElectricCar
                || i_UserVehicle == eTypeVehicles.RegularCar)
            {
                o_MoreInfoNeedForUser = Car.s_CarInformation;
            }
            else if (i_UserVehicle == eTypeVehicles.ElectricMotorcycle
                || i_UserVehicle == eTypeVehicles.RegularMotorcycle)
            {
                o_MoreInfoNeedForUser = Motorcycle.s_MotorcycleInformation;
            }
            else if (i_UserVehicle == eTypeVehicles.RegularTruck)
            {
                o_MoreInfoNeedForUser = Truck.s_TruckleInformation;
            }
        }
    }
}
