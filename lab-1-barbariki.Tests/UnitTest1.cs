namespace program_test;

using Runner;
using Delivery;
using Enums;

public class Tests
{

    [Test]
    public void CreateDeliveryAndAddsToRepository()
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

    [Test]
    public void DeleteDelivery()
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

    [Test]
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

    [Test]
    public void FindDeliveryTest()
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
    
    [Test]
    public void saveRepositoryDataTest()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveRepositoryData();
        
        // Assert
        Assert.That(File.Exists(appState.repositoryFileName), Is.True);
    } // 
    
    [Test]
    public void saveDayDataTest()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveDayData();
        
        // Assert
        Assert.That(File.Exists(appState.dayFileName), Is.True); // 
    }

    [Test]
    public void GetRepositoryDataTest()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveRepositoryData();
        appState.GetRepositoryData();
        
        // Assert
        Assert.That(appState.repository.deliveries[0].title, Is.EqualTo("Test"));
    }
    
    [Test]
    public void GetDayDataTest()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.repository.deliveries.Add(new Delivery("Test", 1));
        appState.SaveDayData();
        appState.GetDayData();
        
        // Assert
        Assert.That(appState.daysStorage.Count, !Is.EqualTo(0)); // 
    }

    [Test] // - unit test
    public void EnsureDataDirCreatedTest()
    {
        // Arrange
        AppState appState = new AppState();
        
        // Act
        appState.EnsureDataDirectoryExists();
        
        // Assert
        Assert.That(Directory.Exists(appState.dataDirectory), Is.True);

    }
    
    [TearDown]
    public void Cleanup()
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
    public void Next_Day_Test()
    {
        // Arrange
        AppState appState = new AppState();
        
        //Act
        appState.NextDay();
        
        // Assert
        Assert.That(appState.currentDay.DayCounter, Is.EqualTo(2));
    }
    
}
