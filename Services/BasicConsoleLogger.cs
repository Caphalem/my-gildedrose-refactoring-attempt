using csharp.Interfaces;
using System;

namespace csharp.Services
{
    public class BasicConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}
