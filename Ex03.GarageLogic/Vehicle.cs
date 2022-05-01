namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    // to do get wheel and get all the wheels
    public class Vehicle
    {
       private string m_ModelName;
       private string m_LicensePlateNumber;
       private float m_PrecentEnergy;
       private List<Wheel> m_CollectionOfWheels;
       private Customer m_Owner;

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
    }
}
