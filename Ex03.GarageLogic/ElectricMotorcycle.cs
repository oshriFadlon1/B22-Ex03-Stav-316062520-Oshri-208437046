namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private ElectricEngine m_ElectricMotorcycleEngine;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_BatteryTimeLeft, float i_MaxBatteryTime)
            : base(i_ModelName, i_LicensePlateNumber, i_PrecentEnergy, i_Owner, i_ManufacturerName, i_CurrentAirPressure,
                 i_LicenseType, i_EngineVolume)
        {
            m_ElectricMotorcycleEngine = new ElectricEngine(i_BatteryTimeLeft, i_MaxBatteryTime);
        }

    }
}
