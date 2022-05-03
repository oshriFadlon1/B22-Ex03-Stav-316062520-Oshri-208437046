namespace Ex03.GarageLogic
{
    public class RegularMotorcycle : Motorcycle
    {
        private const FuelType.eFuelType k_MotorcycleFuel = FuelType.eFuelType.Octan98;
        private const float k_MaxFuelTankVolume = 6.2F;
        private FuelEngine m_FuelEngine;

        public RegularMotorcycle(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_CurrentFuel):
            base(i_ModelName, i_LicensePlateNumber, i_CurrentFuel, k_MaxFuelTankVolume, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_LicenseType, i_EngineVolume)
        {
            m_FuelEngine = new FuelEngine(i_CurrentFuel, k_MaxFuelTankVolume, k_MotorcycleFuel);
        }
    }
}
