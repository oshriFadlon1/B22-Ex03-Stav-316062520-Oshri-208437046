namespace Ex03.GarageLogic
{
    public class RegularTruck : Truck
    {
        private const FuelType.eFuelType k_TruckFuel = FuelType.eFuelType.Soler;
        private const float k_MaxFuelTankVolume = 120f;
        private FuelEngine m_FuelEngine;

        public RegularTruck(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, bool i_IsDrivesRefrigeratedContents, float i_CargoVolume, float i_CurrrntFuel) 
            : base(i_ModelName, i_LicensePlateNumber, i_CurrrntFuel, k_MaxFuelTankVolume, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_IsDrivesRefrigeratedContents, i_CargoVolume)
        {
            m_FuelEngine = new FuelEngine(i_CurrrntFuel, k_MaxFuelTankVolume, k_TruckFuel);
        }

    }
}
