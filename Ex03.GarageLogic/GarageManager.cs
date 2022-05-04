namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class GarageManager
    {

        private Dictionary<string, Vehicle> m_VehiclesList;

        public GarageManager()
        {
            m_VehiclesList = new Dictionary<string, Vehicle>();
        }

        public Dictionary<string, Vehicle> VehiclesList
        {
            get
            {
                return m_VehiclesList;
            }

            set
            {
                m_VehiclesList = value;
            }
        }

        public void AddNewVehicle(Vehicle i_Vehicle)
        {
           m_VehiclesList.Add(i_Vehicle.LicensePlateNumber,i_Vehicle);
        }

        public void ChangeVehicleState(string i_LisencePlateNumber, VehicleState.eVehicleState i_NewState)
        {
            m_VehiclesList[i_LisencePlateNumber].Owner.CurrentVehicleState = i_NewState;
        }

        public void InflateWheels(string i_LisencePlateNumber)
        {
            m_VehiclesList[i_LisencePlateNumber].InflateAllWheelsToMax();
        }

        public void LoadEnergySource(string i_LisencePlateNumber, float i_AmountOfEnergy, bool i_LegalInput, EnergySourceType.eEnergySourceType i_EnergySource)
        {
            if (i_LegalInput)
            {
                m_VehiclesList[i_LisencePlateNumber].LoadEnergy(i_AmountOfEnergy, i_EnergySource);
            }
            else
            {
                throw new FormatException("Incorrect choice.");
            }
        }

        public bool IsLisencePlateNumberExist(string i_LisencePlateNumber)
        {
           return m_VehiclesList.ContainsKey(i_LisencePlateNumber);
        }

        //public bool IsHaveElectricEngine(string i_LisencePlateNumber)
        //{
        //   return m_VehiclesList[i_LisencePlateNumber].IsElectricVehicle;
        //}

        //private void FindFuelType()
        //{
           
        //}
    }
}
