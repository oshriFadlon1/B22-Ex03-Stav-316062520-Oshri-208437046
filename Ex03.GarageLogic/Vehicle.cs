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

       public Vehicle(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
       {
           ModelName = i_ModelName;
           LicensePlateNumber = i_LicensePlateNumber;
           PrecentEnergy = i_PrecentEnergy;
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
    }
}
