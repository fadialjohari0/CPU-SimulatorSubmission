namespace CPU
{
    public class TasksQueueManagement
    {
        public PriorityQueue<Task, int> HighPriorityQueue { get; set; } = new PriorityQueue<Task, int>();
        public PriorityQueue<Task, int> LowPriorityQueue { get; set; } = new PriorityQueue<Task, int>();

        public PriorityQueue<Task, int> LowPriorityWaitingQueue { get; set; } = new PriorityQueue<Task, int>();
    }
}
