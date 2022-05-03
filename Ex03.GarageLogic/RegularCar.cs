namespace Ex03.GarageLogic
{
    public class RegularCar : Car
    {
        private const FuelType.eFuelType k_CarFuel = FuelType.eFuelType.Octan95;
        private const float k_MaxFuelTankVolume = 38f;
        private FuelEngine m_Engine;

        public RegularCar(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, float )
            : base(i_ModelName, i_LicensePlateNumber,)
        {
            m_Engine = new FuelEngine();
        }
    }
}
