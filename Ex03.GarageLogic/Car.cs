namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        WHITE,
        RED,
        GREEN,
        BLUE
    }

    public enum eNumberOfDoors
    {
        two,
        three,
        four,
        five
    }

    internal class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
    }
}
