using Cosmos.Core.Memory;
using System;
using System.Collections.Generic;

namespace OpenDOS.IntegratedSoftware.TextEditor
{
    public class TextCanvas
    {
        public string fileName;
        public string filePath;

        public FileState fileState;

        public int cursorY = 0;
        public int cursorX = 0;

        public string[] textLine;       

        public void Render()
        {
            Console.SetCursorPosition(0, 1);

            for(int i = 0; i < textLine.Length; i++)
            {
                if (i == cursorY)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{i + 1} {textLine[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{i + 1} {textLine[i]}");
                    Console.ResetColor();
                }
            }
        }
    }
}
