namespace Ex03.GarageLogic
{
    public class RegularCar : Car
    {
        private const FuelType.eFuelType CarFuel = FuelType.eFuelType.Octan95;
        private const float MaxFuelTankVolume = 38f;
        private FuelEngine m_Engine = new FuelEngine();
    }
}
