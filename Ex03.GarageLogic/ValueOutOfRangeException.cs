﻿namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string i_Subject, float i_MaxValue, float i_MinValue)
            : base(string.Format(@"Values out of range! Expected values are between {0} to {1} in the {2}", i_MinValue, i_MaxValue, i_Subject))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }

            set
            {
                m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }

            set
            {
                m_MinValue = value;
            }
        }
    }
}
