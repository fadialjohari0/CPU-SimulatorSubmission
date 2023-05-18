namespace CPU
{
    [TestClass]
    public class SortByRequestedTimeTest
    {
        [TestMethod]
        public void SortTasks_Tasks_SortedByRequestedTime()
        {
            // Arrange
            List<Task> tasks = new List<Task>
            {
                new Task { Id = "2", RequestedTime = 2 },
                new Task { Id = "1", RequestedTime = 1 },
                new Task { Id = "3", RequestedTime = 3 }
            };
            SortByRequestedTime sortByRequestedTime = new SortByRequestedTime(tasks);

            // Act
            sortByRequestedTime.SortTasks();

            // Assert
            Assert.AreEqual("1", sortByRequestedTime.Tasks[0].Id);
            Assert.AreEqual("2", sortByRequestedTime.Tasks[1].Id);
            Assert.AreEqual("3", sortByRequestedTime.Tasks[2].Id);
        }
    }
}
