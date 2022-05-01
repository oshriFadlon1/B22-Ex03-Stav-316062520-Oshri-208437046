using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using Ex03.ConsoleUI;
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
    }
}
