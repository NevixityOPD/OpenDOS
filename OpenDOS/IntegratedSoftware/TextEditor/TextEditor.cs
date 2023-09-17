using System;
using System.IO;

namespace OpenDOS.IntegratedSoftware.TextEditor
{
    public class TextEditor
    {
        TextCanvas canvas;
        bool RunTextEditor;

        public TextEditor()
        {
            canvas = new TextCanvas();
            canvas.fileName = "NewText";
            canvas.filePath = $@"0:\";
            canvas.textLine = new string[1];
            canvas.fileState = FileState.Unsaved;

            RunTextEditor = true;

            if (!File.Exists(@"0:\System\Config\GlobalConfig.cfg"))
            {
                Log.Log.ShowLog("Config is missing. Please run sysprep", Log.LogWarningLevel.Warning);
            }
            else
            {
                for (int i = 0; i < File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg").Length; i++)
                {
                    if (File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg")[i].Split(':')[0] == "textEditorStartPath")
                    {
                        canvas.filePath = File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg")[i].Split(':')[1];
                    }
                }
            }
        }

        public void Start()
        {
            Console.Clear();
            while (RunTextEditor)
            {
                if (canvas.fileState == FileState.Saved)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write($"Text Editor - {canvas.fileName} - Press ESC to enter menu");
                    for (int i = 0; i < Console.WindowWidth - $"Text Editor - {canvas.fileName} - Press ESC to enter menu".Length; i++) { Console.Write(" "); }
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write($"Text Editor - {canvas.fileName}* - Press ESC to enter menu");
                    for (int i = 0; i < Console.WindowWidth - $"Text Editor - {canvas.fileName}* - Press ESC to enter menu".Length; i++) { Console.Write(" "); }
                    Console.ResetColor();
                }

                canvas.Render();
                Console.SetCursorPosition(canvas.cursorX + 2, canvas.cursorY + 1);
                ReadInput();
            }
        }

        private void ReadInput()
        {
            ConsoleKeyInfo keyCheck = Console.ReadKey(true);
            
            if (keyCheck.Key == ConsoleKey.Enter)
            {
                Array.Resize(ref canvas.textLine, canvas.textLine.Length + 1);
                canvas.cursorY++;
                canvas.fileState = FileState.Unsaved;
            }
            else if (keyCheck.Key == ConsoleKey.Backspace)
            {
                if (canvas.textLine[canvas.cursorY] != string.Empty)
                {
                    string temp = canvas.textLine[canvas.cursorY].Substring(0, canvas.cursorX - 1);
                    canvas.textLine[canvas.cursorY] = temp;
                    canvas.cursorX--;
                }
                canvas.fileState = FileState.Unsaved;
            }
            else if(keyCheck.Key == ConsoleKey.UpArrow)
            {
                if (canvas.cursorY != 0)
                {
                    canvas.cursorY--;
                }

                if (canvas.textLine[canvas.cursorY].Length == 0)
                {
                    canvas.cursorX = 0;
                }
                else
                {
                    canvas.cursorX = canvas.textLine[canvas.cursorY].Length;
                }
            }
            else if(keyCheck.Key == ConsoleKey.DownArrow)
            {
                if (canvas.cursorY != canvas.textLine.Length - 1)
                {
                    canvas.cursorY++;
                }

                if (canvas.textLine[canvas.cursorY].Length == 0)
                {
                    canvas.cursorX = 0;
                }
                else
                {
                    canvas.cursorX = canvas.textLine[canvas.cursorY].Length;
                }
            }
            else if(keyCheck.Key == ConsoleKey.LeftArrow)
            {
                if (canvas.cursorX != 0)
                {
                    canvas.cursorX--;
                }
                Console.SetCursorPosition(canvas.cursorX, canvas.cursorY + 1);
            }
            else if(keyCheck.Key == ConsoleKey.RightArrow)
            {
                if (canvas.cursorX != canvas.textLine[canvas.cursorY].Length + 1)
                {
                    canvas.cursorX++;
                }
                Console.SetCursorPosition(canvas.cursorX, canvas.cursorY + 1);
            }
            else if(keyCheck.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                if (canvas.fileState == FileState.Unsaved)
                {
                    Console.Write("Do you want to save the file?(press any key to cancel)[y/n] > ");
                    ConsoleKeyInfo ck = Console.ReadKey();
                    Console.WriteLine();
                    if (ck.Key == ConsoleKey.Y)
                    {
                        File.Create($@"{canvas.filePath}\{canvas.fileName}.txt");
                        File.WriteAllLines($@"{canvas.filePath}\{canvas.fileName}.txt", canvas.textLine);
                        canvas.textLine = null;
                        RunTextEditor = false;
                    }
                    else if (ck.Key == ConsoleKey.N)
                    {
                        canvas.textLine = null;
                        RunTextEditor = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                else if (canvas.fileState == FileState.Saved)
                {
                    canvas.textLine = null;
                    RunTextEditor = false;
                }
            }
            else if((keyCheck.Modifiers == ConsoleModifiers.Control) && keyCheck.Key == ConsoleKey.S)
            {
                File.Create($@"{canvas.filePath}\{canvas.fileName}.txt");
                File.WriteAllLines($@"{canvas.filePath}\{canvas.fileName}.txt", canvas.textLine);
                canvas.fileState = FileState.Saved;
            }
            else
            {
                canvas.fileState = FileState.Unsaved;
                canvas.textLine[canvas.cursorY] += keyCheck.KeyChar;
                canvas.cursorX = canvas.textLine[canvas.cursorY].Length;
            }
        }
    }
}
