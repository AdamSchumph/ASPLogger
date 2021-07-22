using ASPLogger;
using System;

namespace ASPLoggerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ASP Logger Console App");
            Console.WriteLine("A simple console app to validate the behaviour of the ASPLogger class.");
            Console.WriteLine();

            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("Testing to Console Only");
                Logger logger = new();
                logger.Write("WriteToConsole!");
                logger.Write("WriteToConsole!");
                logger.WriteLine("WriteLineToConsole!");
                logger.WriteLine("WriteLineToConsole!");
                Console.WriteLine();
            }

            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("Testing to File and Console");
                Logger logger = new();
                Console.WriteLine($"Output to: {logger.FullPath}");

                logger.StartLoggingToTextFile();
                logger.Write("WriteToFileAndConsole!");
                logger.Write("WriteToFileAndConsole!");
                logger.WriteLine("WriteToFileAndConsole!");
                logger.WriteLine("WriteToFileAndConsole!");
                logger.StopLoggingToTextFile();

                Console.WriteLine();
                Console.WriteLine($"Displaying contents of {logger.FullPath}...");

                string[] lines = System.IO.File.ReadAllLines(logger.FullPath);
                foreach (string line in lines)
                    Console.WriteLine(line);

            }

        }
    }
}
