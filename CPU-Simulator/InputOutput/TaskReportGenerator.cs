namespace CPU
{
    public class TaskReportGenerator
    {
        public void GenerateReportFile(List<Task> tasks, ref int clockCycle)
        {
            string filePath = Path.Combine("InputOutput", "TasksReport.txt");
            using (StreamWriter writetext = new StreamWriter(filePath))
            {
                writetext.WriteLine("\n---------------------------OUTPUT DATA---------------------------\n");
                writetext.WriteLine("Task ID | Creation Time | Completion Time | Priority | State");
                writetext.WriteLine("--------|---------------|-----------------|----------|-----------");
                foreach (Task task in tasks)
                {
                    writetext.WriteLine($"{task.Id,-7} | {task.CreationTime,-13} | {task.CompletionTime,-15} | {task.Priority,-8} | {task.State}");
                }
                writetext.WriteLine($"\nTotal Clock Cycles: {clockCycle}");
            }
        }
    }
}