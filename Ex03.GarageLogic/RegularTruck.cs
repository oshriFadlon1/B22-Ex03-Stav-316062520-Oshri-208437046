namespace Ex03.GarageLogic
{
    public class RegularTruck : Truck
    {
        private const FuelType.eFuelType CarFuel = FuelType.eFuelType.Soler;
        private const float MaxFuelTankVolume = 120f;
        private FuelEngine m_FuelEngine = new FuelEngine();

    }
}
