﻿namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public enum eCarColor
    {
        White = 1,
        Red,
        Green,
        Blue
    }

    public enum eNumberOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public abstract class Car : Vehicle
    {
        private const float k_CarMaxAirPressure = 29;
        private const int k_CarNumOfWheels = 4;
        public static Dictionary<string, Type> s_CarInformation = new Dictionary<string, Type>() {{string.Format(@"Press 1 for White color.
Press 2 for Red color.
Press 3 for Green color.
Press 4 for Blue color."), typeof(int)}, { string.Format(@"Enter the number of doors (between 2-5): "), typeof(int) }};

        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_ModelName, string i_LicensePlateNumber, float i_EnergyLeft, float i_MaxEnergy, Customer i_Owner,
             string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicensePlateNumber, i_EnergyLeft, i_MaxEnergy, i_Owner, k_CarNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_CarMaxAirPressure)
        {
            CarColor = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public float CarMaxAirPressure
        {
            get
            {
                return k_CarMaxAirPressure;
            }
        }

        public int CarNumOfWheels
        {
            get
            {
                return k_CarNumOfWheels;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"The color of the car is: {0}.
Number of doors is: {1}.
",m_CarColor,m_NumberOfDoors);
        }
    }
}
