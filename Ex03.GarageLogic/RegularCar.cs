namespace Ex03.GarageLogic
{
    using System;

    public class RegularCar : Car
    {
        private const EnergySourceType.eEnergySourceType k_CarSource = EnergySourceType.eEnergySourceType.Octan95;
        private const float k_MaxFuelTankVolume = 38f;
        private float m_CurrentFuel;

        public RegularCar(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, float i_CurrentFuel)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrentFuel, k_MaxFuelTankVolume, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_CarColor, i_NumberOfDoors)
        {
            if (k_MaxFuelTankVolume >= i_CurrentFuel)
            {
                m_CurrentFuel = i_CurrentFuel;
            }
            else
            {
                throw new ArgumentException(string.Format("the amount of fuel is over the max tank volume of the car ({0} liters).", k_MaxFuelTankVolume));
            }
        }

        public override void LoadEnergy(float i_AmountOfFuel, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_CarSource == i_EnergySource)
            {
                Reload(i_AmountOfFuel, ref m_CurrentFuel, k_MaxFuelTankVolume);
            }
            else
            {
                throw new ArgumentException(string.Format("incorrect energy source. You should use {0}", k_CarSource));
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"Car fuel is: {0}.
Current amount of fuel is: {1}.
Max volume of the fuel tank is: {2}.
", k_CarSource, m_CurrentFuel, k_MaxFuelTankVolume);
        }
    }
}
