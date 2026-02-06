using Enums;
using Interfaces;

namespace Task;

public abstract class TaskBase : IRoutable
{
    public Guid id = Guid.NewGuid();
    public string Title;
    public PriorityKey GetPriorityKey()
    {
        return (PriorityKey)(new Random()).Next(1, 4);
    }
}