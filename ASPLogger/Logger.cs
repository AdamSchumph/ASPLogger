using System;
using System.IO;

namespace ASPLogger
{
    /// <summary>
    /// A simple class library to log information to the Console and/or Text File simulteaneously
    /// </summary>
    public class Logger
    {

        /// <summary>Indicates if logging should be directed to the Console or not</summary>
        public bool ToConsole { get; set; } = true;

        /// <summary>The name of the text file to generate</summary>
        public string FileName { get; set; } = "LogFile.log";

        /// <summary>The folder to save the text file in</summary>
        public string Folder { get; set; } = "./";

        /// <summary>The full path of the text file</summary>
        public string FullPath => Path.Combine(Folder,FileName);

        private TextWriter textWriter = null;
        /// <summary>Indicates if logging is currently directed to a text file or not</summary>
        public bool ToTextFile => textWriter != null;

        public Logger()
        {
        }

        /// <summary>Start logging messages to the text file</summary>
        public void StartLoggingToTextFile()
        {
            if (textWriter == null)
                textWriter = new StreamWriter(FullPath);
        }

        /// <summary>Stop logging messages to the text file</summary>
        public void StopLoggingToTextFile()
        {
            if (textWriter != null)
            {
                textWriter.Close();
                textWriter = null;
            }
        }

        /// <summary>Write a message to the log</summary>
        public void Write(string message)
        {
            if (ToConsole)
                Console.Write(message);

            if (ToTextFile)
                textWriter.Write(message);
        }

        /// <summary>Write a message to the log, followed by the current line terminator</summary>
        public void WriteLine(string message)
        {

            if (ToConsole)
                Console.WriteLine(message);

            if (ToTextFile)
                textWriter.WriteLine(message);
        }

    }
}