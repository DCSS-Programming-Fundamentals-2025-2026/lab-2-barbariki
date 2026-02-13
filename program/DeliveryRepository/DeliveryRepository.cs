namespace DeliveryRepository;

using Delivery;

public class DeliveryRepository
{
    public List<Delivery> deliveries { get; set; } = new List<Delivery>();
    public List<Delivery> departured { get; set; } = new List<Delivery>();
    public List<Delivery> delivered { get; set; } = new List<Delivery>();
    public DeliveryRepository() { }

}