using System.Diagnostics;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PerformansTesti()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Deneme.Metot();
        sw.Stop();
        var sure = sw.ElapsedMilliseconds;
        if(sure < 5000)Assert.Pass();
        else Assert.Fail($"Çok yavaş {sure}");
    }
}