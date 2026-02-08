namespace Runner;

using Menu;

public class DemoRunner
{
    public static void Run()
    {
        AppState data = new AppState();
        while (true)
        {
            Menu.printMenu();
            string answer = Console.ReadLine();
            Console.WriteLine("----------------------");
            switch (answer)
            {
                case ("1"):
                    Console.Clear();
                    data.createDelivery(); break;
                case ("2"): data.updateDelivery(); break;
                case ("3"): data.ShowAllDeliviries(); break;
                case ("4"): data.showDeliveries(data.Repository.Deliveries, "packing"); break;
                case ("5"): data.sendDelivery(); break;
                case ("6"): break;
                case ("7"): data.showDayResult(data.CurrentDay); break;
                case ("8"): data.NextDay(); break;
                case ("9"): data.showAllDaysResult(); break;
                case ("10"): data.SaveRepositoryData(); return;
            }
        }
    }
}