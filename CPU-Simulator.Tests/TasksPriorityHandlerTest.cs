namespace CPU
{
    [TestClass]
    public class TasksPriorityHandlerTest
    {
        [TestMethod]
        public void SetPriority_ValidTask_AssignsPriority()
        {
            // Arrange
            TasksPriorityHandler tasksPriorityHandler = new TasksPriorityHandler();

            TasksQueue tasksQueue = new TasksQueue();

            int clockCycle = 5;

            List<Task> tasks = new List<Task>()
            {
                new Task { Priority = "High" },
                new Task { Priority ="Low"},
                new Task { Priority = "High" },
                new Task { Priority ="Low"}
            };

            TaskList taskList = new SortByCreationTime(tasks);

            // Act
            tasksPriorityHandler.SeparateTasksByPriority(taskList, tasksQueue, ref clockCycle);

            // Assert
            Assert.IsTrue(tasksQueue.HighPriorityTasks.All(task => task.Priority == "High"));
            Assert.IsTrue(tasksQueue.LowPriorityTasks.All(task => task.Priority == "Low"));

        }
    }
}
