﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_TruckMaxAirPressure = 24;
        private const int k_TruckNumOfWheels = 16;
        private bool m_IsDrivesRefrigeratedContents;
        private float m_CargoVolume;

        public Truck(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,
            int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, bool i_IsDrivesRefrigeratedContents, float i_CargoVolume)
            : base(i_ModelName, i_LicensePlateNumber, i_PrecentEnergy, i_Owner, k_TruckNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_TruckMaxAirPressure)
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
    }
}