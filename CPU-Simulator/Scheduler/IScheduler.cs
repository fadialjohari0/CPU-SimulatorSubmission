namespace CPU
{
    public interface IScheduler
    {
        void Schedule(List<Task> tasks, List<Processor> processors, ref int clockCycle);

    }
}