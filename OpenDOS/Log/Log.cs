using System;

namespace OpenDOS.Log
{
    public static class Log
    {
        public static void ShowLog(string title, LogWarningLevel warninglevel)
        {
            switch (warninglevel)
            {
                case LogWarningLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[Info] ");
                    Console.ResetColor();
                    Console.WriteLine(title);
                    break;
                case LogWarningLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[Warning] ");
                    Console.ResetColor();
                    Console.WriteLine(title);
                    break;
                case LogWarningLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[Error] ");
                    Console.ResetColor();
                    Console.WriteLine(title);
                    break;
            }
        }
    }
}
