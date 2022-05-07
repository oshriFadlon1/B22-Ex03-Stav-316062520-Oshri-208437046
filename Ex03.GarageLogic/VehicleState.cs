namespace Ex03.GarageLogic
{
    using System;

    public class VehicleState
    {
        public enum eVehicleState
        {
            InRepair,
            Fixed,
            PaidUp
        }

        public static bool TryParse(string i_UserInput, out eVehicleState o_DesiredResult)
        {
            bool isTryParsing = false;
            o_DesiredResult = eVehicleState.InRepair;
            if (int.TryParse(i_UserInput, out int vehicleState))
            {
                if (vehicleState == (int)eVehicleState.InRepair || vehicleState == (int)eVehicleState.Fixed || vehicleState == (int)eVehicleState.PaidUp)
                {
                    o_DesiredResult = (eVehicleState)vehicleState;
                    isTryParsing = true;
                }
                else
                {
                    throw new ValueOutOfRangeException("vehicle state.", Enum.GetNames(typeof(VehicleState.eVehicleState)).Length, 1);
                }
            }
            else
            {
                throw new FormatException("you didn't insert correct digit");
            }

            return isTryParsing;
        }
    }
}
