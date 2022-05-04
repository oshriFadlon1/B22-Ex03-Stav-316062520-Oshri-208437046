namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string m_Name; // contain only letter upper and lower
        private string m_PhoneNumber; // length == 10 and contain only numbers
        private VehicleState.eVehicleState m_CurrentVehicleState = VehicleState.eVehicleState.InRepair;

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

        public VehicleState.eVehicleState CurrentVehicleState
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

        public override string ToString()
        {
            return string.Format(@"Nmae Owne: {0}.
Phone number: {1}.
Vehicle state is :{2}.
",m_Name,m_PhoneNumber,m_CurrentVehicleState);
        }
    }
}
