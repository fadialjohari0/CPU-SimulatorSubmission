namespace CPU
{
    public interface IScheduler
    {
        void InterruptLowTasks(List<Processor> processors, int clockCycle, PriorityQueue<Task, int> LowPriorityWaitingQueue, PriorityQueue<Task, int> HighPriorityQueue);

        void AssignTasksToProcessors(List<Processor> processors, int clockCycle, PriorityQueue<Task, int> LowPriorityWaitingQueue, PriorityQueue<Task, int> HighPriorityQueue, PriorityQueue<Task, int> LowPriorityQueue);

        void CreateTasks(List<Task> tasks, int clockCycle, PriorityQueue<Task, int> HighPriorityQueue, PriorityQueue<Task, int> LowPriorityQueue);
    }
}