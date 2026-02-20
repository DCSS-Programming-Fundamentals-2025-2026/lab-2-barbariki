using Enums;

namespace program_test.UnitTests;

using Runner;
using Delivery;

[TestFixture]
public class DeliveryTest
{
    private AppState appState;
    
    [SetUp]
    public void Setup()
    {
        appState = new AppState();
    }

    [Test] // - unit test
    public void Create_DeliveryAndAddsToRepository()
    {
        // Arrange

        string title = "Test";
        int priorityKey = (int)PriorityKey.Important;

        // Act
        appState.CreateDelivery(title, priorityKey);

        // Assert

        Assert.That(appState.repository.deliveries.count, Is.EqualTo(1));
        Assert.That(appState.repository.deliveries[0].title, Is.EqualTo("Test"));
    }

    [Test] // - unit test
    public void Send_Delivery()
    {
        // Arrange
        string title = "Test";
        int priorityKey = (int)PriorityKey.Important;

        // Act
        appState.SendDelivery(new Delivery(title, priorityKey));

        // Assert
        Assert.That(appState.repository.departured.count, Is.EqualTo(1));
    }
}