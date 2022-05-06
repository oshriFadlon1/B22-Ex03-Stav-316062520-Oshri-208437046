namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public abstract class Truck : Vehicle
    {
        private const float k_TruckMaxAirPressure = 24;
        private const int k_TruckNumOfWheels = 16;
        public static Dictionary<string, Type> s_TruckleInformation = new Dictionary<string, Type>() { { string.Format(@"Press y/n if the truck drives refrigerated stuff."), typeof(char) }, { string.Format(@"Enter cargo volume (in Cubic meter): "), typeof(float) } };
        private bool m_IsDrivesRefrigeratedContents;
        private float m_CargoVolume;

        public Truck(string i_ModelName, string i_LicensePlateNumber, float i_EnergyLeft, float i_MaxEnergy, Customer i_Owner,
             string i_ManufacturerName, float i_CurrentAirPressure, bool i_IsDrivesRefrigeratedContents, float i_CargoVolume)
            : base(i_ModelName, i_LicensePlateNumber, i_EnergyLeft, i_MaxEnergy, i_Owner, k_TruckNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_TruckMaxAirPressure)
        {
            IsDrivesRefrigeratedContents = i_IsDrivesRefrigeratedContents;
            CargoVolume = i_CargoVolume;
        }

        public bool IsDrivesRefrigeratedContents
        {
            get
            {
                return m_IsDrivesRefrigeratedContents;
            }

            set
            {
                m_IsDrivesRefrigeratedContents = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"Cargo volume is: {0}.
If can drives refrigerated stuff: {1}.
", m_CargoVolume,m_IsDrivesRefrigeratedContents);
        }
    }
}
