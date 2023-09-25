using System;
using System.Collections.Generic;

namespace OpenDOS.ConsoleGraphic
{
    public static class Read
    {
        public static string AdvanceReadLine()
        {
            string returnText = "";
            int cursorX = 0;
            int cursorY = Console.CursorTop;

            bool continueRun = true;

            while (continueRun)
            {
                ConsoleKeyInfo keyCheck = Console.ReadKey(true);

                if (keyCheck.Key == ConsoleKey.Enter)
                {
                    continueRun = false;
                }
                else if (keyCheck.Key == ConsoleKey.Backspace)
                {
                    if (returnText != string.Empty || cursorX != 0)
                    {
                        string temp = returnText.Substring(0, cursorX);
                        returnText = temp;
                        cursorX--;
                        Console.SetCursorPosition(cursorX + Console.CursorLeft, cursorY + 1);
                        Console.Write(' ');
                    }
                }
                else if (keyCheck.Key == ConsoleKey.LeftArrow)
                {
                    if (cursorX != 0)
                    {
                        cursorX--;
                    }
                    Console.SetCursorPosition(cursorX, cursorY + 1);
                }
                else if (keyCheck.Key == ConsoleKey.RightArrow)
                {
                    if (cursorX != returnText.Length + 1)
                    {
                        cursorX++;
                    }
                    Console.SetCursorPosition(cursorX, cursorY + 1);
                }
                else
                {
                    cursorX++;
                    returnText += keyCheck.KeyChar;
                }

                Console.SetCursorPosition(cursorX - Console.CursorLeft + 1, cursorY);
                Console.Write(returnText);
                Console.SetCursorPosition(cursorX, cursorY);
            }

            return returnText;
        }
    }
}
