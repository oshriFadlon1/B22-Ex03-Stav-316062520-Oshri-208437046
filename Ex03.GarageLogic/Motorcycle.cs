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

    internal class Motorcycle : Vehicle
    {
        private eMotorcycleLicense m_License;
        private int m_EngineCapacity;

    }
}
