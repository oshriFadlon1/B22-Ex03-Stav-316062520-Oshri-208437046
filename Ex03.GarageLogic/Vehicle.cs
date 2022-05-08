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
            int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
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

        public void Reload(float i_AmountOfEnergy, ref float io_CurrentAmountOfEnergy, float i_MaxEnergy)
        {
            if (i_AmountOfEnergy >= 0)
            {
                if (i_MaxEnergy >= io_CurrentAmountOfEnergy + i_AmountOfEnergy)
                {
                    io_CurrentAmountOfEnergy += i_AmountOfEnergy;
                    PrecentEnergy = CalcPrecntageEnergy(io_CurrentAmountOfEnergy, i_MaxEnergy);
                }
                else
                {
                    throw new ValueOutOfRangeException("vehicle energy.", i_MaxEnergy - io_CurrentAmountOfEnergy, 0);
                }
            }
            else
            {
                throw new ArgumentException("invalid input.The amount of energy can`t be negative.");
            }
        }

        private static float CalcPrecntageEnergy(float i_EnergyLeft, float i_MaxEnergy)
        {
            return (i_EnergyLeft / i_MaxEnergy) * 100;
        }

        public override string ToString()
        {
            string currentDataOfVehicle = this.m_Owner.ToString() + string.Format(@"Model name is: {0}.
License plate number is: {1}.
The precent energy is: {2}.
",m_ModelName,m_LicensePlateNumber,m_PrecentEnergy);
            int countWheelInCollection = 1;
            foreach (Wheel wheel in m_CollectionOfWheels)
            {
                currentDataOfVehicle += string.Format("Data of wheel number {0}:\n", countWheelInCollection);
                currentDataOfVehicle += wheel.ToString();
                countWheelInCollection++;
            }

            return currentDataOfVehicle;
        }
    }
}
