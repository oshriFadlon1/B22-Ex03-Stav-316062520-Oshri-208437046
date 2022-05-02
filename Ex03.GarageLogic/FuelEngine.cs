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

        public void Refuel(float i_AmountOfFuel)
        {
            if (m_MaxFuel >= m_CurrentFuel + i_AmountOfFuel)
            {
                m_CurrentFuel += i_AmountOfFuel;
            }
            else
            {
                // exception
            }
        }
    }

}
