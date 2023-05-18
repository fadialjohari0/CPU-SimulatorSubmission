using CPU;

namespace CPU_Simlator.Tests
{
    [TestClass]
    public class ProcessorInitializerTest
    {
        [TestMethod]
        public void InitializeProcessors_NumberOfProcessors_InitializedProcessorList()
        {
            // Arrange
            ProcessorInitializer processorInitializer = new ProcessorInitializer();
            int numOfProcessors = 5;

            // Act
            List<Processor> processors = processorInitializer.InitializeProcessors(numOfProcessors);

            // Assert
            Assert.AreEqual(numOfProcessors, processors.Count);
        }

        [TestMethod]
        public void InitializerProcessors_ProcessorsID_CorrectIdFormat()
        {
            // Arrange
            ProcessorInitializer processorInitializer = new ProcessorInitializer();
            int numOfProcessors = 5;

            // Act
            List<Processor> processors = processorInitializer.InitializeProcessors(numOfProcessors);

            // Assert
            for (int i = 0; i < numOfProcessors; i++)
            {
                Assert.AreEqual($"P{i + 1}", processors[i].Id);
            }
        }
    }
}