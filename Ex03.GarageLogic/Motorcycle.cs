namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public enum eMotorcycleLicense
    {
        A = 1,
        A1,
        B1,
        BB
    }

    public abstract class Motorcycle : Vehicle
    {
        private const float k_MotorcycleMaxAirPressure = 31;
        private const int k_MotorcycleNumOfWheels = 2;
        public static Dictionary<string, Type> s_MotorcycleInformation = new Dictionary<string, Type>() { { string.Format(@"Press 1 for license type A.
Press 2 for license type A1.
Press 3 for license type B1.
Press 4 for license type BB."), typeof(int) }, { string.Format(@"Enter engine volume (in Cubic Centimeter): "), typeof(int) } };

        private eMotorcycleLicense m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicensePlateNumber, float i_EnergyLeft, float i_MaxEnergy, Customer i_Owner,
             string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicensePlateNumber, i_EnergyLeft, i_MaxEnergy, i_Owner, k_MotorcycleNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_MotorcycleMaxAirPressure)
        {
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }

        public int EngineVolume
        {
           get
           {
                return m_EngineVolume;
           }

           set
           {
                m_EngineVolume = value;
           }
        }

        public eMotorcycleLicense LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"License type is: {0}.
The volume of the engine is: {1}.
",m_LicenseType,m_EngineVolume);
        }
    }
}
