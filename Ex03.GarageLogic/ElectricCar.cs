namespace Ex03.GarageLogic
{
    using System;

    public class ElectricCar : Car
    {
        private const EnergySourceType.eEnergySourceType k_CarSource = EnergySourceType.eEnergySourceType.Electric;
        private const float k_MaxBatteryTime = 3.3f;
        private float m_BatteryTimeLeft;

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, float i_BatteryTimeLeft)
            : base(i_ModelName, i_LicensePlateNumber, i_BatteryTimeLeft, k_MaxBatteryTime, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_CarColor, i_NumberOfDoors)
        {
            if (k_MaxBatteryTime > i_BatteryTimeLeft)
            {
                m_BatteryTimeLeft = i_BatteryTimeLeft;
            }
            else
            {
                throw new ArgumentException("the amount of Battery time is over the max of the battery in the car.");
            }
        }

        public void ChargeTheBattery(float i_AmountOfTimeToCharge)
        {
            float hoursTocharge = i_AmountOfTimeToCharge / 60f;
            Reload(hoursTocharge, ref m_BatteryTimeLeft, k_MaxBatteryTime);
        }

        public override void LoadEnergy(float i_AmountOfEnergy, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (k_CarSource == i_EnergySource)
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
            return base.ToString() + string.Format(@"the car runs on: {0}.
Battery run time left is: {1}.
Max battery runing time is: {2}.
", k_CarSource, m_BatteryTimeLeft, k_MaxBatteryTime);
        }
    }
}
