using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
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
                if (o_DesiredResult == eVehicleState.InRepair || o_DesiredResult == eVehicleState.Fixed || o_DesiredResult == eVehicleState.PaidUp)
                {
                    o_DesiredResult = (eVehicleState)vehicleState;
                    isTryParsing = true;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, Enum.GetNames(typeof(VehicleState.eVehicleState)).Length);
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
