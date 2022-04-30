namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class Vehicle
    {
       private string m_ModelName;
       private string m_LicensePlateNumber;
       private float m_PrecentEnergy;
       private List<Wheel> m_CollectionOfWheels;
       private Customer m_Owner;
    }
}
