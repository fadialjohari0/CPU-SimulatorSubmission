namespace CPU
{
    public class ProcessorManager
    {
        List<Processor> processors = new List<Processor>();

        public List<Processor> InitializeProcessors(int numOfProcessors)
        {
            for (int i = 0; i < numOfProcessors; i++)
            {
                processors.Add(new Processor
                {
                    Id = $"P{i + 1}",
                    State = ProcessorState.IDLE,
                });
            }
            return processors;
        }
    }
}