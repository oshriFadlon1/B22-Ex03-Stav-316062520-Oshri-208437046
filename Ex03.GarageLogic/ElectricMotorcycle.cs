namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 2.5f;
        private ElectricEngine m_ElectricMotorcycleEngine;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, Customer i_Owner,
            string i_ManufacturerName, float i_CurrentAirPressure, eMotorcycleLicense i_LicenseType, int i_EngineVolume, float i_BatteryTimeLeft)
            : base(i_ModelName, i_LicensePlateNumber, CalcPrecntageEnergy(i_BatteryTimeLeft), i_Owner, i_ManufacturerName,
                  i_CurrentAirPressure, i_LicenseType, i_EngineVolume)
        {
            m_ElectricMotorcycleEngine = new ElectricEngine(i_BatteryTimeLeft, k_MaxBatteryTime);
        }

        private static float CalcPrecntageEnergy(float i_BatteryTimeLeft)
        {
            return (i_BatteryTimeLeft / k_MaxBatteryTime) * 100;
        }

    }
}
