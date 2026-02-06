namespace Delivery;

using Enums;
using Interfaces;
using Task;
class Delivery : TaskBase
{
    public PriorityKey Priority { get; set; }
    public Delivery(string title)
    {
        Title = title;
        Priority = this.GetPriorityKey();
    }
}