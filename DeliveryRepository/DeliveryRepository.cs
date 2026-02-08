namespace DeliveryRepository;

using Delivery;

public class DeliveryRepository
{
    public List<Delivery> Deliveries { get; set; } = new List<Delivery>();
    public List<Delivery> Departured { get; set; } = new List<Delivery>();
    public List<Delivery> Delivered { get; set; } = new List<Delivery>();
    public DeliveryRepository() { }
    public Delivery Find(string title)
    {
        try
        {
            return Deliveries.Find(Delivery => Delivery.Title == title);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Empty list.");
            return null;
        }
    }
    public void Sort()
    {

    }
}