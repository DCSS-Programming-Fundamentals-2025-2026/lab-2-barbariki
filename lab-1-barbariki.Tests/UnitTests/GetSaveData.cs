namespace program_test.UnitTests;

using Runner;


[TestFixture]
public class GetSaveData
{
    private AppState appState;
    
    [SetUp]
    public void Setup()
    {
        appState = new AppState();
    }
    
    [Test] // - unit test
    public void EnsureDataDirCreated()
    {
        // Act
        appState.EnsureDataDirectoryExists();
        
        // Assert
        Assert.That(Directory.Exists(appState.dataDirectory), Is.True);

    }
    
    [Test] // - unit test
    public void Set_NextDay()
    {
        //Act
        appState.NextDay();
        
        // Assert
        Assert.That(appState.currentDay.DayCounter, Is.EqualTo(2));
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
}