namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryTime = 3.3f;
        private ElectricEngine m_CarElectricEngine;

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, float i_BatteryTimeLeft) 
            : base(i_ModelName, i_LicensePlateNumber, i_BatteryTimeLeft, k_MaxBatteryTime, i_Owner, i_ManufacturerName, i_CurrentAirPressure, i_CarColor, i_NumberOfDoors)
        {
            m_CarElectricEngine = new ElectricEngine(i_BatteryTimeLeft, k_MaxBatteryTime);
        }


    }
}
