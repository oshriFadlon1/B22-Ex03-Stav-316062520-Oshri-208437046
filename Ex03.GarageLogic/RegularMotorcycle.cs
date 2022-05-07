namespace Ex03.GarageLogic
{
    using System;

    public class RegularMotorcycle : Motorcycle
    {
        private const EnergySourceType.eEnergySourceType k_MotorcycleSource = EnergySourceType.eEnergySourceType.Octan98;
        private const float k_MaxFuelTankVolume = 6.2f;
        private float m_CurrentFuel;

        public RegularMotorcycle(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_CurrentFuel)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrentFuel, k_MaxFuelTankVolume, i_Owner,
                  i_ManufacturerName, i_CurrentAirPressure, i_LicenseType, i_EngineVolume)
        {
            if (k_MaxFuelTankVolume >= i_CurrentFuel)
            {
                m_CurrentFuel = i_CurrentFuel;
            }
            else
            {
                throw new ArgumentException(string.Format("the amount of fuel is over the max tank volume of the motorcycle ({0} liters).", k_MaxFuelTankVolume));
            }
        }

        public override void LoadEnergy(float i_AmountOfFuel, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_MotorcycleSource == i_EnergySource)
            {
                Reload(i_AmountOfFuel, ref m_CurrentFuel, k_MaxFuelTankVolume);
            }
            else
            {
                throw new ArgumentException(string.Format("incorrect energy source. You should use {0}", k_MotorcycleSource));
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"Motorcycle fuel is: {0}.
Current amount of fuel is: {1}.
Max volume of the fuel tank is: {2}.
", k_MotorcycleSource,m_CurrentFuel,k_MaxFuelTankVolume);
        }
    }
}
