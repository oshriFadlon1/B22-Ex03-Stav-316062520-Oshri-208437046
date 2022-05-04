namespace Ex03.GarageLogic
{
    using System;

    public class RegularTruck : Truck
    {
        private const EnergySourceType.eEnergySourceType k_TruckSource = EnergySourceType.eEnergySourceType.Soler;
        private const float k_MaxFuelTankVolume = 120f;
        private float m_CurrentFuel;

        public RegularTruck(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner, string i_ManufacturerName,
            float i_CurrentAirPressure, bool i_IsDrivesRefrigeratedContents, float i_CargoVolume, float i_CurrrntFuel)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrrntFuel, k_MaxFuelTankVolume, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_IsDrivesRefrigeratedContents, i_CargoVolume, false)
        {
            m_CurrentFuel = i_CurrrntFuel;
        }

        public override void LoadEnergy(float i_AmountOfFuel, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_TruckSource == i_EnergySource)
            {
                Refuel(i_AmountOfFuel);
            }
            else
            {
                throw new ArgumentException("incorrect energy source.");
            }
        }

        public void Refuel(float i_AmountOfFuel)
        {
            if (i_AmountOfFuel < 0)
            {
                if (k_MaxFuelTankVolume >= m_CurrentFuel + i_AmountOfFuel) // have the same fuel and the amount is positive
                {
                    m_CurrentFuel += i_AmountOfFuel;
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MaxFuelTankVolume - m_CurrentFuel, 0);
                }
            }
        }
    }
}
