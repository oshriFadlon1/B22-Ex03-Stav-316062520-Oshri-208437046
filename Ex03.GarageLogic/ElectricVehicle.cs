namespace Ex03.GarageLogic
{
    internal class ElectricVehicle: Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        public void ChargeTheBattery(float i_AmountOfTimeToCharge)
        {
            if (m_MaxBatteryTime >= m_BatteryTimeLeft + i_AmountOfTimeToCharge)
            {
                m_BatteryTimeLeft += i_AmountOfTimeToCharge;
            }
            else
            {
                // exception
            }
        }
    }
}
