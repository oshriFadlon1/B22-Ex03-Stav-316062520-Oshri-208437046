namespace Ex03.GarageLogic
{
    internal class ElectricVehicle: Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        float BatteryTimeLeft
        {
            get
            {
                return m_BatteryTimeLeft;
            }

            set
            {
                m_BatteryTimeLeft = value;
            }
        }

        public float MaxBatteryTime
        {
            get
            {
                return m_MaxBatteryTime;
            }

            set
            {
                m_MaxBatteryTime = value;
            }
        }

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
