using System;

namespace OpenDOS.Exception
{
    public class ExceptionManager
    {
        public void ThrowException(Exception newException)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("▄ ▄▀  Something went wrong. Exception had been thrown");
            Console.WriteLine("  █");
            Console.WriteLine("▀ ▀▄\n\n");
            Console.WriteLine($"Exception Subject > {newException.Title}");
            switch (newException.ExceptionLevel)
            {
                case ExceptionLevel.Error:
                    Console.WriteLine("Exception Error Code > 0x10");
                    break;
                case ExceptionLevel.Fatal:
                    Console.WriteLine("Exception Error Code > 0x11");
                    break;
            }
            Console.WriteLine($"Exception Message > {newException.ExceptionMessage}");

            Console.WriteLine("OS will restart in ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i + 1} ");
                Cosmos.HAL.Global.PIT.Wait(1000);
            }
            Cosmos.System.Power.Reboot();
        }

        public void ThrowBasicException(string title, string message)
        {
            Log.Log.ShowLog($"{title}: {message}", Log.LogWarningLevel.Error, Log.LogWritter.System);
        }
    }
}
