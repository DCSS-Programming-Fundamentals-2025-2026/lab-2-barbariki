using Enums;

namespace program_test.UnitTests;

using Runner;
using Delivery;
using System.Linq;

[TestFixture]
public class Sort
{
    private AppState appState;
    
    [SetUp]
    public void Setup()
    {
        appState = new AppState();
    }
    
    [Test] // - unit test
    public void QuickSortByPrioritySortsCorrectly()
    {
        // Arrange
        List<Delivery> deliveries = new List<Delivery>
        {
            new Delivery("Low", 3),
            new Delivery("High", 1),
            new Delivery("Medium", 2)
        };

        // Act
        appState.QuickSortByPriority(deliveries, 0, deliveries.Count - 1);

        // Assert
        Assert.That(deliveries[0].title, Is.EqualTo("High"));
        Assert.That(deliveries[1].title, Is.EqualTo("Medium"));
        Assert.That(deliveries[2].title, Is.EqualTo("Low"));
    }

    [Test] // - unit test (edge-case test)
    public void QuickSortByPrioritySortsCorrectly_When_PriorityIsTheSame()
    {
        // Arrange
        List<Delivery> deliveries = new List<Delivery>
        {
            new Delivery("Low", 1),
            new Delivery("High", 1),
            new Delivery("Medium", 1)
        };

        // Act
        appState.QuickSortByPriority(deliveries, 0, deliveries.Count - 1);

        // Assert
        Assert.That(deliveries.All(d => d.priority == (PriorityKey)1), Is.True);
    }
    

    [Test] // - unit test (edge-case test)
    public void QuickSortByPrioritySortsCorrectly_When_ListIsEmpty()
    {
        // Arrange
        List<Delivery> deliveries = new List<Delivery>();

        // Act
        appState.QuickSortByPriority(deliveries, 0, deliveries.Count - 1);

        // Assert
        Assert.That(deliveries.Count, Is.EqualTo(0));
    }
    
    [Test] // - unit test (edge-case test)
    public void QuickSortByPrioritySortsCorrectly_When_InListOnlyOneElement()
    {
        // Arrange
        List<Delivery> deliveries = new List<Delivery> { new Delivery("Low", 3) };

        // Act
        appState.QuickSortByPriority(deliveries, 0, deliveries.Count - 1);

        // Assert
        Assert.That(deliveries.Count, Is.EqualTo(1));
    }
}