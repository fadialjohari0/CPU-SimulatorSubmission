namespace CPU
{

    [TestClass]
    public class SortByCreationTimeTest
    {
        [TestMethod]
        public void SortTasks_Tasks_SortedByCreationTime()
        {
            // Arrange
            List<Task> tasks = new List<Task>
            {
                new Task { Id = "2", CreationTime = 2 },
                new Task { Id = "1", CreationTime = 1 },
                new Task { Id = "3", CreationTime = 3 }
            };
            SortByCreationTime sortByCreationTime = new SortByCreationTime(tasks);

            // Act
            sortByCreationTime.SortTasks();

            // Assert
            Assert.AreEqual("1", sortByCreationTime.Tasks[0].Id);
            Assert.AreEqual("2", sortByCreationTime.Tasks[1].Id);
            Assert.AreEqual("3", sortByCreationTime.Tasks[2].Id);
        }
    }
}
