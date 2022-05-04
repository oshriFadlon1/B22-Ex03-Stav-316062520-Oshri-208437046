namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    // to do get wheel and get all the wheels
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlateNumber;
        private float m_PrecentEnergy;
        private List<Wheel> m_CollectionOfWheels;
        private Customer m_Owner;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber, float i_EnergyLeft, float i_MaxEnergy, Customer i_Owner,
            int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, bool i_IsElectricVehicle)
        {
            ModelName = i_ModelName;
            LicensePlateNumber = i_LicensePlateNumber;
            PrecentEnergy = CalcPrecntageEnergy(i_EnergyLeft, i_MaxEnergy);
            Owner = i_Owner;
            m_CollectionOfWheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_CollectionOfWheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }

            m_IsElectricVehicle = i_IsElectricVehicle;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return m_LicensePlateNumber;
            }

            set
            {
                m_LicensePlateNumber = value;
            }
        }

        public float PrecentEnergy
        {
            get
            {
                return m_PrecentEnergy;
            }

            set
            {
                m_PrecentEnergy = value;
            }
        }

        public Customer Owner
        {
            get
            {
                return m_Owner;
            }

            set
            {
                m_Owner = value;
            }
        }

        public int CollectionOfWheelsAmount
        {
            get
            {
                return m_CollectionOfWheels.Count;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_CollectionOfWheels)
            {
                wheel.InflationWheelAirToMax();
            }
        }

        public abstract void LoadEnergy(float i_AmountOfEnergy, EnergySourceType.eEnergySourceType i_EnergySource);

        private static float CalcPrecntageEnergy(float i_EnergyLeft, float i_MaxEnergy)
        {
            return (i_EnergyLeft / i_MaxEnergy) * 100;
        }


    }
}
