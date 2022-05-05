namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    public class VehicleType
    {
        public enum eTypeVehicles
        {
            FuelCar = 1,
            FuelTruck,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
        }

        public static List<string> getListOfTypes()
        {
            List<string> types = new List<string>();

            foreach (string  name in Enum.GetNames(typeof(eTypeVehicles)))
            {
                types.Add(name);
            }
            return types;
        }
    }
}
