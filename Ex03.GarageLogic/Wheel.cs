namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        string m_ManufacturerName;
        float  m_CurrentAirPressure;
        float  m_MaxAirPressure;

        string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        float MaxAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        void InflateWheel(float i_HowMuchAirToAdd)
        {
            if (m_MaxAirPressure >= i_HowMuchAirToAdd + m_CurrentAirPressure)
            {
                m_CurrentAirPressure += i_HowMuchAirToAdd;
            }
            else
            {
                // Exception
            }
        }
    }
}
