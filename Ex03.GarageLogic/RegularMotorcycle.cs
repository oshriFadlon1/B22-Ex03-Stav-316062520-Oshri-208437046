namespace Ex03.GarageLogic
{
    public class RegularMotorcycle : Motorcycle
    {
        private const FuelType.eFuelType k_MotorcycleFuel = FuelType.eFuelType.Octan98;
        private const float k_MaxFuelTankVolume = 6.2F;
        private FuelEngine m_FuelEngine = new FuelEngine();
    }
}
