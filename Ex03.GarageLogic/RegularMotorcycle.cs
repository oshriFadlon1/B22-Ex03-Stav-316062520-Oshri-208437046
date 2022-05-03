namespace Ex03.GarageLogic
{
    public class RegularMotorcycle : Motorcycle
    {
        private const FuelType.eFuelType CarFuel = FuelType.eFuelType.Octan98;
        private const float MaxFuelTankVolume = 6.2F;
        private FuelEngine m_FuelEngine = new FuelEngine();
    }
}
