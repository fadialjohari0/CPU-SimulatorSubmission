using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPU;
using System.Collections.Generic;

namespace CPUTest
{
    [TestClass]
    public class SchedulerTests
    {
        [TestMethod]
        public void TestAssignTasksToProcessors_HighPriorityQueue()
        {
            // Arrange
            IScheduler scheduler = new Scheduler();
            PriorityQueue<Task, int> highPriorityQueue = new PriorityQueue<Task, int>();
            PriorityQueue<Task, int> lowPriorityQueue = new PriorityQueue<Task, int>();
            PriorityQueue<Task, int> lowPriorityWaitingQueue = new PriorityQueue<Task, int>();
            List<Processor> processors = new List<Processor>();

            Task highPriorityTask = new Task
            {
                Priority = "High",
                RequestedTime = 5,
                CreationTime = 0,
            };
            highPriorityQueue.Enqueue(highPriorityTask, highPriorityTask.RequestedTime);

            Processor idleProcessor = new Processor
            {
                State = ProcessorState.IDLE
            };
            processors.Add(idleProcessor);

            // Act
            scheduler.AssignTasksToProcessors(processors, 0, lowPriorityWaitingQueue, highPriorityQueue, lowPriorityQueue);

            // Assert
            Assert.AreEqual(TaskState.EXECUTING, highPriorityTask.State);
            Assert.AreEqual(ProcessorState.BUSY, idleProcessor.State);
            Assert.AreEqual(highPriorityTask, idleProcessor.CurrentTask);
            Assert.AreEqual(0, highPriorityQueue.Count);
        }

        [TestMethod]
        public void CreateTasks_NewTasks_AddsThemToCorrectQueues()
        {
            // Arrange
            IScheduler scheduler = new Scheduler();
            PriorityQueue<Task, int> highPriorityQueue = new PriorityQueue<Task, int>();
            PriorityQueue<Task, int> lowPriorityQueue = new PriorityQueue<Task, int>();
            List<Task> tasks = new List<Task>();

            Task highPriorityTask = new Task
            {
                Priority = "High",
                RequestedTime = 5,
                CreationTime = 0,
            };

            Task lowPriorityTask = new Task
            {
                Priority = "Low",
                RequestedTime = 3,
                CreationTime = 0,
            };

            tasks.Add(highPriorityTask);
            tasks.Add(lowPriorityTask);

            // Act
            scheduler.CreateTasks(tasks, 0, highPriorityQueue, lowPriorityQueue);

            // Assert
            Assert.AreEqual(1, highPriorityQueue.Count);
            Assert.AreEqual(highPriorityTask, highPriorityQueue.Peek());

            Assert.AreEqual(1, lowPriorityQueue.Count);
            Assert.AreEqual(lowPriorityTask, lowPriorityQueue.Peek());
        }
    }
}
