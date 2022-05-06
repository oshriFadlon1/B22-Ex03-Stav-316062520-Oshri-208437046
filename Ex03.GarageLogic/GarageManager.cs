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

        public void AddNewVehicle(VehicleCreator.eTypeVehicles i_UserVehicle, string i_ModelName, string i_LicensePlateNumber,
            Customer i_Owner, string i_ManufacturerName, float i_CurrentAirPressure, List<object> i_MoreInfoFromUser, float i_CurrentEnergy)
        {
            Vehicle newVehicle;
            newVehicle = VehicleCreator.CreateNewVehicle(i_UserVehicle, i_ModelName, i_LicensePlateNumber,
             i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_MoreInfoFromUser, i_CurrentEnergy);
            if (newVehicle != null)
            {
                m_VehiclesList.Add(newVehicle.LicensePlateNumber, newVehicle);
            }
            else
            {
                throw new Exception("Something went wrong along the way, we're back on the menu.");
            }
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

        public string GetDataOfCurrentVehicle(string i_LisencePlateNumber)
        {
            return m_VehiclesList[i_LisencePlateNumber].ToString();
        }

        public void GetAllLicenseNumbers(ref List<string> io_LicenseNumbers)
        {
            foreach (KeyValuePair<string, Vehicle> license in m_VehiclesList)
            {
                io_LicenseNumbers.Add(license.Key);
            }
        }

        public void GetAllLicenseNumbersByState(ref List<string> io_LicenseNumbers, VehicleState.eVehicleState i_State)
        {
            foreach (KeyValuePair<string, Vehicle> license in m_VehiclesList)
            {
                if (license.Value.Owner.CurrentVehicleState == i_State)
                {
                    io_LicenseNumbers.Add(license.Key);
                }

            }
        }
    }
}
