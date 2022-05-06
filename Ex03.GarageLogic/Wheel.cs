namespace Ex03.GarageLogic
{
    using System;

    internal class Wheel
    {
        string m_ManufacturerName;
        float  m_CurrentAirPressure;
        float  m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            if (i_CurrentAirPressure < i_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }
            else
            {
                throw new ArgumentException("the air pressure is over the max pressure recommended by the creator.");
            }
        }

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
                InflateWheel(value);
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

        public void InflateWheel(float i_HowMuchAirToAdd)
        {
            if (this.m_MaxAirPressure >= i_HowMuchAirToAdd + this.m_CurrentAirPressure)
            {
                this.m_CurrentAirPressure += i_HowMuchAirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(this.m_MaxAirPressure - this.m_CurrentAirPressure, 0);
            }
        }

        public void InflationWheelAirToMax()
        {
            InflateWheel(this.m_MaxAirPressure - this.m_CurrentAirPressure);
        }

        public override string ToString()
        {
            return string.Format(@"Manufacturer name is: {0}.
Current air pressure is: {1}.
Max air pressure: {2}.
", m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}
