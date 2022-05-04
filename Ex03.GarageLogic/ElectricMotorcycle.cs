namespace Ex03.GarageLogic
{
    using System;

    public class ElectricMotorcycle : Motorcycle
    {
        private const EnergySourceType.eEnergySourceType k_MotorcycleSource = EnergySourceType.eEnergySourceType.Electric;
        private const float k_MaxBatteryTime = 2.5f;
        private float m_BatteryTimeLeft;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_BatteryTimeLeft)
            : base(i_ModelName, i_LicensePlateNumber, i_BatteryTimeLeft, k_MaxBatteryTime, i_Owner, i_ManufacturerName,
                  i_CurrentAirPressure, i_LicenseType, i_EngineVolume, true)
        {
            m_BatteryTimeLeft = i_BatteryTimeLeft;
        }

        public void ChargeTheBattery(float i_AmountOfTimeToCharge)
        {
            float hoursTocharge = i_AmountOfTimeToCharge / 60f;
            Reload(hoursTocharge, ref m_BatteryTimeLeft, k_MaxBatteryTime);
        }

        public override void LoadEnergy(float i_AmountOfEnergy, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_MotorcycleSource == i_EnergySource)
            {
                ChargeTheBattery(i_AmountOfEnergy);
            }
            else
            {
                throw new ArgumentException("incorrect energy source.");
            }
        }

        public override string ToString()
        {
           return base.ToString() + string.Format(@"the motorcycle runs on: {0}.
Battery run time left is: {1}.
Max battery runing time is: {2}.
", k_MotorcycleSource, m_BatteryTimeLeft, k_MaxBatteryTime);
        }
    }
}
