namespace program_test;

using Runner;
using Delivery;
using Enums;
using DayData;
using DeliveryRepository;

public class Tests
{

    [Test] // - unit test
    public void Create_DeliveryAndAddsToRepository()
    {
        // Arrange
        AppState appState = new AppState();
        int initialCount = appState.repository.deliveries.Count;

        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));

        // Assert
        Assert.That(appState.repository.deliveries.Count, Is.EqualTo(initialCount + 1));
        Assert.That(appState.repository.deliveries[initialCount].title, Is.EqualTo("Test"));
    }

    [Test] // - integration test
    public void Delete_Delivery()
    {
        // Arrange 
        AppState appState = new AppState();
        string title = "Test";
        
        // Act
        appState.repository.deliveries.Add(new Delivery(title, 1));
        Delivery delivery = appState.FindDelivery(title);
        appState.AddOrDeleteDelivery(delivery, DeliveryAction.Delete);
        
        // Assert
        Assert.That(appState.repository.deliveries.Count, Is.EqualTo(0));
    }

    [Test] // - unit test
    public void QuickSortByPrioritySortsCorrectly()
    {
        // Arrange
        AppState appState = new AppState();
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

    [Test] // - integration test
    public void Find_DeliveryTest_Returns_Delivery()
    {
        // Arrange 
        AppState appState = new AppState();
        string title = "Test";
        
        // Act
        appState.repository.deliveries.Add(new Delivery(title, 1));
        Delivery delivery = appState.FindDelivery(title);
        
        // Assert
        Assert.That(delivery.title, Is.EqualTo(title));
    }
    
    [Test] // - integration test
    public void Save_RepositoryDataInFile()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveRepositoryData();
        
        // Assert
        Assert.That(File.Exists(appState.repositoryFileName), Is.True);
        Assert.That(appState.GetRepositoryData().deliveries[0].title, Is.EqualTo("Test"));
    }
    
    [Test] // - integration test
    public void Save_DayDataInFile()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.currentDay.AmountOfDepartured = 1;
        appState.SaveDayData();
        
        // Assert
        Assert.That(File.Exists(appState.dayFileName), Is.True);
        Assert.That(appState.GetDayData()[0].AmountOfDepartured, Is.EqualTo(1));
    }

    [Test] // - integration test
    public void Get_RepositoryData_Returns_List()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveRepositoryData();
        DeliveryRepository deliveryRepository = appState.GetRepositoryData();
        
        // Assert
        Assert.That(deliveryRepository.deliveries[0].title, Is.EqualTo("Test"));
    }
    
    [Test] // - integration test
    public void Get_DayData_Returns_List()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.currentDay.AmountOfDepartured = 1;
        appState.SaveDayData();
        List<DayData> daysStorage = appState.GetDayData();
        
        // Assert
        Assert.That(daysStorage[0].AmountOfDepartured, Is.EqualTo(1));
    }

    [Test] // - unit test
    public void EnsureDataDirCreated()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.EnsureDataDirectoryExists();
        
        // Assert
        Assert.That(Directory.Exists(appState.dataDirectory), Is.True);

    }
    
    [TearDown]
    public void CleanUp()
    {
        var dataDir = Path.Combine(AppContext.BaseDirectory, "Data");

        if (Directory.Exists(dataDir))
        {
            foreach (var file in Directory.GetFiles(dataDir))
            {
                File.Delete(file);
            }

            Directory.Delete(dataDir, true);
        }
    }

    [Test]
    public void Set_NextDay()
    {
        // Arrange
        AppState appState = new AppState();
        
        //Act
        appState.NextDay();
        
        // Assert
        Assert.That(appState.currentDay.DayCounter, Is.EqualTo(2));
    }
    
}
