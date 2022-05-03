namespace Ex03.GarageLogic
{
    public class RegularTruck : Truck
    {
        private const FuelType.eFuelType k_TruckFuel = FuelType.eFuelType.Soler;
        private const float k_MaxFuelTankVolume = 120f;
        private FuelEngine m_FuelEngine = new FuelEngine();

    }
}
