namespace CPU
{
    public class Scheduler : IScheduler
    {
        public void InterruptLowTasks(List<Processor> processors, int clockCycle, PriorityQueue<Task, int> LowPriorityWaitingQueue, PriorityQueue<Task, int> HighPriorityQueue)
        {
            foreach (Processor processor in processors)
            {
                if (processor.CurrentTask?.Priority == "Low")
                {
                    processor.CurrentTask.State = TaskState.WAITING;
                    LowPriorityWaitingQueue.Enqueue(processor.CurrentTask, processor.CurrentTask.RequestedTime);
                    processor.CurrentTask = HighPriorityQueue.Dequeue();
                    processor.CurrentTask.State = TaskState.EXECUTING;
                    break;
                }
            }
        }

        public void AssignTasksToProcessors(List<Processor> processors, int clockCycle, PriorityQueue<Task, int> LowPriorityWaitingQueue, PriorityQueue<Task, int> HighPriorityQueue, PriorityQueue<Task, int> LowPriorityQueue)
        {
            foreach (Processor processor in processors)
            {
                if (processor.State == ProcessorState.IDLE)
                {
                    if (HighPriorityQueue.Count > 0)
                    {
                        processor.AssignTask(HighPriorityQueue.Dequeue());
                        processor.State = ProcessorState.BUSY;
                        processor.CurrentTask!.State = TaskState.EXECUTING;
                    }
                    else if (LowPriorityQueue.Count > 0)
                    {
                        processor.AssignTask(LowPriorityQueue.Dequeue());
                        processor.State = ProcessorState.BUSY;
                        processor.CurrentTask!.State = TaskState.EXECUTING;
                    }
                }
                else if (processor.State == ProcessorState.BUSY)
                {

                    if (processor.CurrentTask?.RequestedTime == 0 && LowPriorityWaitingQueue.Count > 0)
                    {
                        processor.CurrentTask.State = TaskState.COMPLETED;
                        processor.CurrentTask.CompletionTime = clockCycle;
                        processor.CurrentTask = LowPriorityWaitingQueue.Dequeue();
                    }
                    else if (processor.CurrentTask?.RequestedTime == 0)
                    {
                        processor.FinishTask(clockCycle);
                    }
                }
            }

        }

        public void CreateTasks(List<Task> tasks, int clockCycle, PriorityQueue<Task, int> HighPriorityQueue, PriorityQueue<Task, int> LowPriorityQueue)
        {
            int index = 0;
            while (index < tasks.Count)
            {
                Task task = tasks[index];
                int creationTime = tasks[index].CreationTime;

                if (creationTime == clockCycle)
                {
                    if (task.Priority == "High")
                    {
                        HighPriorityQueue.Enqueue(task, task.RequestedTime);
                        task.State = TaskState.WAITING;
                    }
                    else
                    {
                        LowPriorityQueue.Enqueue(task, task.RequestedTime);
                        task.State = TaskState.WAITING;
                    }
                }
                index++;
            }
        }
    }
}