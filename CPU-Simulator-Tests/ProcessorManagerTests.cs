using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPU;

[TestClass]
public class ProcessorManagerTests
{
    [TestMethod]
    public void InitializeProcessors_NumberOfProcessors_CreatesCorrectAmountOfProcessors()
    {
        // Arrange
        ProcessorManager processorManager = new ProcessorManager();
        int numOfProcessors = 5;

        // Act
        var result = processorManager.InitializeProcessors(numOfProcessors);

        // Assert
        Assert.AreEqual(numOfProcessors, result.Count);
    }

    [TestMethod]
    public void InitializeProcessors_NumberOfProcessors_CreatesCorrectProcessorsId()
    {
        // Arrange
        ProcessorManager processorManager = new ProcessorManager();
        int numOfProcessors = 5;

        // Act
        var result = processorManager.InitializeProcessors(numOfProcessors);

        // Assert
        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual($"P{i + 1}", result[i].Id);
        }
    }
}