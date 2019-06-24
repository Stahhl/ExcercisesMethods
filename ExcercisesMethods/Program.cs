using System;

namespace ExcercisesMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Creating_Methods_1.Start(true);
        }
        static public void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void Restart()
        {
            Console.WriteLine("Press any key to restart...");
            Console.ReadLine();
            Console.Clear();
            Main(null);
        }
    }
}
