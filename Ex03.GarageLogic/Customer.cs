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
    }
}
