using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace OpenDOS.IntegratedSoftware.TextEditor
{
    public class TextEditor
    {
        TextCanvas canvas;

        public TextEditor()
        {
            canvas = new TextCanvas();
            canvas.fileName = "NewText";
            canvas.filePath = $@"0:\";
            canvas.textLine = new List<List<char>>();

            canvas.textLine.Add(new List<char>());
        }

        public void Start()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write($"Text Editor - {canvas.fileName} - Press ESC to enter menu");
                for(int i = 0; i < Console.WindowWidth - $"Text Editor - {canvas.fileName} - Press ESC to enter menu".Length; i++) { Console.Write(" "); }
                Console.ResetColor();

                canvas.Render();
                ReadInput();
            }
        }

        private void ReadInput()
        {
            ConsoleKeyInfo keyCheck = Console.ReadKey(true);

        }
    }
}
