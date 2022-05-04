using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eMotorcycleLicense
    {
        A,
        A1,
        B1,
        BB
    }

    public abstract class Motorcycle : Vehicle
    {
        private const float k_MotorcycleMaxAirPressure = 31;
        private const int k_MotorcycleNumOfWheels = 2;
        private eMotorcycleLicense m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicensePlateNumber, float i_EnergyLeft, float i_MaxEnergy, Customer i_Owner,
             string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, bool i_IsElectricVehicle)
            : base(i_ModelName, i_LicensePlateNumber, i_EnergyLeft, i_MaxEnergy, i_Owner, k_MotorcycleNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_MotorcycleMaxAirPressure, i_IsElectricVehicle)
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
    }
}
