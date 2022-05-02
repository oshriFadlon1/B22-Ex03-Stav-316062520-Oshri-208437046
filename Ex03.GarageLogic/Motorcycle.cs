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

    public class Motorcycle : Vehicle
    {
        private const float k_MotorcycleMaxAirPressure = 31;
        private const int k_MotorcycleNumOfWheels = 2;
        private eMotorcycleLicense m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,
            int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicensePlateNumber, i_PrecentEnergy, i_Owner, k_MotorcycleNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_MotorcycleMaxAirPressure)
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
