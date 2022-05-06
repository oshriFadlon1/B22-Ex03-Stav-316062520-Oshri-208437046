namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(VehicleType.eTypeVehicles i_UserVehicle)
        {
            Vehicle newVehcle ;

            switch (i_UserVehicle)
            {
                case VehicleType.eTypeVehicles.RegularCar:
                    newVehcle = new RegularCar();
                    break;
                case VehicleType.eTypeVehicles.ElectricCar:
                    newVehcle = new ElectricCar();
                    break;
                case VehicleType.eTypeVehicles.RegularMotorcycle:
                    newVehcle = new RegularMotorcycle();
                    break;
                case VehicleType.eTypeVehicles.ElectricMotorcycle:
                    newVehcle = new ElectricMotorcycle();
                    break;
                case VehicleType.eTypeVehicles.RegularTruck:
                    newVehcle = new RegularTruck();
                    break;
            }

            return newVehcle;
        }

        public static void GetMoreInfo(VehicleType.eTypeVehicles i_UserVehicle, out Dictionary<string, Type> o_MoreInfoNeedForUser)
        {
            o_MoreInfoNeedForUser = null;
            // switch which vehicle more info we need return in out dictionery
            if (i_UserVehicle == VehicleType.eTypeVehicles.ElectricCar
                || i_UserVehicle == VehicleType.eTypeVehicles.RegularCar)
            {
                o_MoreInfoNeedForUser = Car.s_CarInformation;
            }
            else if (i_UserVehicle == VehicleType.eTypeVehicles.ElectricMotorcycle
                || i_UserVehicle == VehicleType.eTypeVehicles.RegularMotorcycle)
            {
                o_MoreInfoNeedForUser = Motorcycle.s_MotorcycleInformation;
            }
            else if (i_UserVehicle == VehicleType.eTypeVehicles.RegularTruck)
            {
                o_MoreInfoNeedForUser = Truck.s_TruckleInformation;
            }
        }
    }
}
