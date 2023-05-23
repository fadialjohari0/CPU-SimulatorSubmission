namespace CPU
{
    public class Simulator
    {
        public void StartSimulation(List<Task> tasks, List<Processor> processors, ref int clockCycle)
        {
            IScheduler scheduler = new Scheduler();
            scheduler.Schedule(tasks!, processors, ref clockCycle);


        }
    }
}
