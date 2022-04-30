namespace Ex03.GarageLogic
{
    enum eFuelType
    {
        Octan98,
        Octan95,
        Octan96,
        Soler
    }

    internal class RegularVehicle: Vehicle
    {
        private float m_CurrentFuel;
        private float m_MaxFuel;
        private eFuelType m_Fuel;

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
