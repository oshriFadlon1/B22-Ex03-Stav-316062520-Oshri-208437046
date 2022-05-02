namespace Ex03.GarageLogic
{
    internal class ElectricEngine
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        public ElectricEngine(float i_BatteryTimeLeft, float i_MaxBatteryTime)
        {
            m_BatteryTimeLeft = i_BatteryTimeLeft;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        float BatteryTimeLeft
        {
            get
            {
                return m_BatteryTimeLeft;
            }

            set
            {
                ChargeTheBattery(value);
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
            float hoursTocharge = i_AmountOfTimeToCharge / 60f;
            if (m_MaxBatteryTime >= m_BatteryTimeLeft + hoursTocharge)
            {
                m_BatteryTimeLeft += hoursTocharge;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxBatteryTime - m_BatteryTimeLeft, 0);
            }
        }
    }
}
