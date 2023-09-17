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

        public static void WriteTopBar(string activities, ConsoleColor tobbarColor)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = tobbarColor;
            Console.Write($"OpenDOS | {activities}");
            for (int i = 0; i < Console.WindowWidth - $"OpenDOS | {activities}".Length; i++)
            {
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WriteBottomBar(string Text, ConsoleColor bottomBarColor)
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = bottomBarColor;
            Console.Write(Text);
            for (int i = 0; i < Console.BufferWidth - Text.Length; i++)
            {
                Console.Write(' ');
            }
        }
    }
}
