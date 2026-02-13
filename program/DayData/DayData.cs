namespace DayData;

public class DayData
{
    public int DayCounter { get; set; }
    public int AmountOfDepartured { get; set; }
    public DayData(int number)
    {
        DayCounter = number;
    }
    public DayData() { }
}