namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class GarageManager
    {
        private List<Vehicle> m_VehiclesList;

        public List<Vehicle> VehiclesList
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

        public void AddNewVehicle(Vehicle vehicle)
        {
           m_VehiclesList.Add(vehicle);
        }

        public 
    }
}
