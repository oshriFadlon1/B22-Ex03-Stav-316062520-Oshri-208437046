namespace Ex03.GarageLogic
{
    using System;

    public class RegularMotorcycle : Motorcycle
    {
        private const EnergySourceType.eEnergySourceType k_MotorcycleSource = EnergySourceType.eEnergySourceType.Octan98;
        private const float k_MaxFuelTankVolume = 6.2F;
        private float m_CurrentFuel;

        public RegularMotorcycle(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_CurrentFuel)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrentFuel, k_MaxFuelTankVolume, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_LicenseType, i_EngineVolume, false)
        {
            m_CurrentFuel = i_CurrentFuel;
        }

        public override void LoadEnergy(float i_AmountOfFuel, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_MotorcycleSource == i_EnergySource)
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
