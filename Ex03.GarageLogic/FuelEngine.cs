namespace Ex03.GarageLogic
{
    enum eFuelType
    {
        Octan98,
        Octan95,
        Octan96,
        Soler
    }

    internal class FuelEngine
    {
        private float m_CurrentFuel;
        private float m_MaxFuel;
        private eFuelType m_Fuel;

        public FuelEngine(float i_CurrentFuel, float i_MaxFuel, eFuelType i_Fuel)
        {
            m_CurrentFuel = i_CurrentFuel;
            m_MaxFuel = i_MaxFuel;
            this.m_Fuel = i_Fuel;
        }

        public float CurrentFuel
        {
            get
            {
                return m_CurrentFuel;
            }

            set
            {
                m_CurrentFuel = value;
            }
        }

        public float MaxFuel
        {
            get
            {
                return m_MaxFuel;
            }

            set
            {
                m_MaxFuel = value;
            }
        }

        public eFuelType Fuel
        {
            get
            {
                return m_Fuel;
            }

            set
            {
                m_Fuel = value;
            }
        }

        public void Refuel(float i_AmountOfFuel, eFuelType i_FuelToFill)
        {
            if (this.m_Fuel != i_FuelToFill || i_AmountOfFuel < 0)
            {
                throw new System.ArgumentException();
            }
            else if (m_MaxFuel >= m_CurrentFuel + i_AmountOfFuel) // have the same fuel and the amount is positive
            {
                m_CurrentFuel += i_AmountOfFuel;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxFuel - m_CurrentFuel, 0);
            }
        }
    }

}
