using System;
using System.Collections.Generic;

namespace OpenDOS.ConsoleGraphic
{
    public static class Write
    {
        public static void WriteInColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
