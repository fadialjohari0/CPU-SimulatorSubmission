namespace CPU
{
    public class Processor
    {
        public string? Id { get; set; }
        public ProcessorState State { get; set; }
        public Task? CurrentTask { get; set; }
        public int numOfProcessors { get; set; }

        public void AssignTask(Task task)
        {
            CurrentTask = task;
            State = ProcessorState.BUSY;
        }

        public void ExecuteTask()
        {
            CurrentTask!.RequestedTime--;
        }

        public void FinishTask()
        {
            CurrentTask!.State = TaskState.COMPLETED;
            CurrentTask.CompletionTime = Program.clockCycle;
            CurrentTask = null;
            State = ProcessorState.IDLE;
        }
    }
}