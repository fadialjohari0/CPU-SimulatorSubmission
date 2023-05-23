using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CPU
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = FileReader.ReadFromFile("Tasks.json", content => content);
            var data = JsonConvert.DeserializeObject<Data>(json);

            int numOfProcessors = data!.NumOfProcessors; // Number Of Processors.
            List<Task> tasks = data.Tasks!; // List Of Tasks.

            /*****************************/

            ProcessorManager processorManager = new ProcessorManager();
            List<Processor> processors = processorManager.InitializeProcessors(numOfProcessors); // List Of Processors.

            /*****************************/

            Simulator simulator = new Simulator();
            simulator.StartSimulation(tasks, processors, ref clockCycle); // Starting The Simulation.

            /*****************************/

            TaskReportGenerator taskReportGenerator = new TaskReportGenerator();
            taskReportGenerator.GenerateReportFile(tasks, ref clockCycle); // Generating The Report File.
        }
        public static int clockCycle = 0;
    }
}
