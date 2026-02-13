using Runner;

namespace program_test;

public class Tests
{

    [Test]
    public void Test1()
    {

        string mes = "ab";
        
        Assert.That(mes, Is.EqualTo("ab"));
        Assert.Pass();
    }
}