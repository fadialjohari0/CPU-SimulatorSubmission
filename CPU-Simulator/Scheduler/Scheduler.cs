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

                    Console.WriteLine($"{processor.CurrentTask.Id} was interrupted with {processor.CurrentTask.Priority} at clockCycle {clockCycle} with requested time {processor.CurrentTask.RequestedTime}");

                    LowPriorityWaitingQueue.Enqueue(processor.CurrentTask, processor.CurrentTask.RequestedTime);

                    processor.CurrentTask = HighPriorityQueue.Dequeue();

                    processor.CurrentTask.State = TaskState.EXECUTING;



                    Console.WriteLine($"{processor.CurrentTask.Id} was added instead with {processor.CurrentTask.Priority} at clockCycle {clockCycle}");

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
                        Console.WriteLine($"Task {processor.CurrentTask!.Id} is ASSIGNED to processor {processor.Id} at clockCycle {clockCycle}");
                        processor.State = ProcessorState.BUSY;
                        processor.CurrentTask.State = TaskState.EXECUTING;
                    }
                    else if (LowPriorityQueue.Count > 0)
                    {
                        processor.AssignTask(LowPriorityQueue.Dequeue());
                        Console.WriteLine($"Task {processor.CurrentTask!.Id} is ASSIGNED to processor {processor.Id} at clockCycle {clockCycle}");
                        processor.State = ProcessorState.BUSY;
                        processor.CurrentTask.State = TaskState.EXECUTING;
                    }
                }
                else if (processor.State == ProcessorState.BUSY)
                {

                    if (processor.CurrentTask?.RequestedTime == 0 && LowPriorityWaitingQueue.Count > 0)
                    {
                        Console.WriteLine($"{processor.Id} Finished with {processor.CurrentTask.Id}! {processor.CurrentTask.Priority}");

                        processor.CurrentTask.State = TaskState.COMPLETED;
                        processor.CurrentTask.CompletionTime = clockCycle;


                        processor.CurrentTask = LowPriorityWaitingQueue.Dequeue();
                        Console.WriteLine($"{processor.CurrentTask.Id} is back from the low priority waiting queue at clockCycle {clockCycle} with requested time {processor.CurrentTask.RequestedTime}");

                    }
                    else if (processor.CurrentTask?.RequestedTime == 0)
                    {
                        Console.WriteLine($"{processor.Id} Finished with {processor.CurrentTask.Id}! {processor.CurrentTask.Priority} at clockCycle {clockCycle}");
                        processor.FinishTask(clockCycle);
                    }
                }
            }

        }

        public void CreateTasks(List<Task> tasks, int clockCycle, PriorityQueue<Task, int> HighPriorityQueue, PriorityQueue<Task, int> LowPriorityQueue)
        {
            foreach (Task task in tasks)
            {
                if (task.CreationTime == clockCycle)
                {
                    if (task.Priority == "High")
                    {
                        Console.WriteLine($"Task {task.Id} is CREATED in the HIGH priority queue at clockCycle {clockCycle}");
                        HighPriorityQueue.Enqueue(task, task.RequestedTime);
                        task.State = TaskState.WAITING;
                    }
                    else
                    {
                        Console.WriteLine($"Task {task.Id} is CREATED in the LOW priority queue at clockCycle {clockCycle}");
                        LowPriorityQueue.Enqueue(task, task.RequestedTime);
                        task.State = TaskState.WAITING;
                    }
                }
            }
        }

    }
}