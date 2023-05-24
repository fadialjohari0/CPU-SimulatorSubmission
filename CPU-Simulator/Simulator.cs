namespace CPU
{
    public class Simulator
    {
        private List<Task> tasks;
        private List<Processor> processors;
        private int clockCycle;

        public PriorityQueue<Task, int> HighPriorityQueue { get; set; } = new PriorityQueue<Task, int>();
        public PriorityQueue<Task, int> LowPriorityQueue { get; set; } = new PriorityQueue<Task, int>();
        public PriorityQueue<Task, int> LowPriorityWaitingQueue { get; set; } = new PriorityQueue<Task, int>();


        public Simulator(List<Task> tasks, List<Processor> processors, int clockCycle)
        {
            this.tasks = tasks;
            this.processors = processors;
            this.clockCycle = clockCycle;
        }

        public void StartSimulation()
        {
            IScheduler scheduler = new Scheduler();

            while (tasks.Any(task => task.State != TaskState.COMPLETED))
            {
                clockCycle++;

                bool allProcessorsBusy = processors.All(processor => processor.State == ProcessorState.BUSY);
                bool anyProcessorHasLowPriorityTask = processors.Any(processor => processor.CurrentTask?.Priority == "Low");

                if (allProcessorsBusy && HighPriorityQueue.Count > 0 && anyProcessorHasLowPriorityTask)
                {
                    scheduler.InterruptLowTasks(processors, clockCycle, LowPriorityWaitingQueue, HighPriorityQueue);

                }
                else
                {
                    scheduler.AssignTasksToProcessors(processors, clockCycle, LowPriorityWaitingQueue, HighPriorityQueue, LowPriorityQueue);

                    foreach (Processor processor in processors)
                    {
                        if (processor.State == ProcessorState.BUSY)
                        {
                            processor.ExecuteTask();
                        }
                    }
                    scheduler.CreateTasks(tasks, clockCycle, HighPriorityQueue, LowPriorityQueue);
                }
            }
        }
    }
}
