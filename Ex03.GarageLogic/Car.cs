namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        White,
        Red,
        Green,
        Blue
    }

    public enum eNumberOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public class Car : Vehicle
    {
        private const float k_CarMaxAirPressure = 29;
        private const int k_CarNumOfWheels = 4;
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_ModelName, string i_LicensePlateNumber, float i_PrecentEnergy, Customer i_Owner,
            int i_NumOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicensePlateNumber, i_PrecentEnergy, i_Owner, k_CarNumOfWheels, i_ManufacturerName, i_CurrentAirPressure, k_CarMaxAirPressure)
        {
            CarColor = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public float CarMaxAirPressure
        {
            get
            {
                return k_CarMaxAirPressure;
            }
        }

        public int CarNumOfWheels
        {
            get
            {
                return k_CarNumOfWheels;
            }
        }
    }
}
