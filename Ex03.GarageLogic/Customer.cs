namespace Ex03.GarageLogic
{
    enum eState
    {
        InRepair,
        Fixed,
        PaidUp
    }

    public class Customer
    {
        private string m_Name; // contain only letter upper and lower
        private string m_PhoneNumber; // length == 10 and contain only numbers
        private eState m_CurrentVehicleState = eState.InRepair;

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }

        public eState CurrentVehicleState
        {
            get
            {
                return m_CurrentVehicleState;
            }

            set
            {
                m_CurrentVehicleState = value;
            }
        }
    }
}
