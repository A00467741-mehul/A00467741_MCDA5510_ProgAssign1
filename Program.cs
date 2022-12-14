// See https://aka.ms/new-console-template for more information

using ProgAssign1;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        string outFilePath = @"..\\..\\..\\Output\\Output.csv";
        string exceptionAndSummary = @"..\\..\\..\\logs\\logs.txt";
        try
        {
            File.WriteAllText(outFilePath, string.Empty);
            File.WriteAllText(exceptionAndSummary, string.Empty);
            List<int> liVal = new List<int>();
            liVal.Add(0);
            liVal.Add(0);
            Console.WriteLine("Program execution started..");
            DateTime start = DateTime.Now;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            DirWalker dirWalker = new DirWalker();
            dirWalker.walk(@"..\\..\\..\\Sample Data", liVal);
            DateTime end = DateTime.Now;
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                    ts.Hours, ts.Minutes, ts.Seconds,
                                    ts.Milliseconds / 10);

            Console.WriteLine("Program execution ended..");
            Console.WriteLine("Please check the summary of the executed program in the logs.txt file in logs folder!");
            using (StreamWriter writerSummary = new StreamWriter(exceptionAndSummary))
            {
                writerSummary.WriteLine("Program start time: " + start.ToString("HH:mm:ss tt"));
                writerSummary.WriteLine("Program total execution time: " + elapsedTime);
                writerSummary.WriteLine("Program end time: " + end.ToString("HH:mm:ss tt"));
                writerSummary.WriteLine("Number of skipped rows: " + liVal[0]);
                writerSummary.WriteLine("Number of success rows: " + liVal[1]);
            }
        }
        catch (Exception ex)
        {
            using (StreamWriter writerSummary = new StreamWriter(exceptionAndSummary))
            {
                writerSummary.WriteLine("--------------------------------------------------------------");
                writerSummary.WriteLine("--------------------------------------------------------------");
                writerSummary.WriteLine("Error Message:", ex.Message);
            }
        }
    }
}
