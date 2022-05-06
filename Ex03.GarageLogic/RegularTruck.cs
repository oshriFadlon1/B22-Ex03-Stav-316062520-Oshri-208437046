namespace Ex03.GarageLogic
{
    using System;

    public class RegularTruck : Truck
    {
        private const EnergySourceType.eEnergySourceType k_TruckSource = EnergySourceType.eEnergySourceType.Soler;
        private const float k_MaxFuelTankVolume = 120f;
        private float m_CurrentFuel;

        public RegularTruck(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner, string i_ManufacturerName,
            float i_CurrentAirPressure, bool i_IsDrivesRefrigeratedContents, float i_CargoVolume, float i_CurrentFuel)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrentFuel, k_MaxFuelTankVolume, i_Owner,
                  i_ManufacturerName, i_CurrentAirPressure, i_IsDrivesRefrigeratedContents, i_CargoVolume)
        {
            if (k_MaxFuelTankVolume > i_CurrentFuel)
            {
                m_CurrentFuel = i_CurrentFuel;
            }
            else
            {
                throw new ArgumentException("the amount of fuel is over the max tank volume of the truck.");
            }
        }

        public override void LoadEnergy(float i_AmountOfFuel, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_TruckSource == i_EnergySource)
            {
                Reload(i_AmountOfFuel, ref m_CurrentFuel, k_MaxFuelTankVolume);
            }
            else
            {
                throw new ArgumentException("incorrect energy source.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"The fuel for the truck is: {0}.
Current amount of fuel is: {1}.
Max volume of the fuel tank is: {2}.
", k_TruckSource,m_CurrentFuel,k_MaxFuelTankVolume);
        }
    }
}
