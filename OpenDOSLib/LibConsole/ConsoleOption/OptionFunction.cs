using System;
using System.Collections.Generic;

namespace OpenDOSLib.LibConsole.ConsoleOption
{
    public static class OptionFunction
    {
        public delegate void functionDelegate();
        private static List<functionDelegate> functionList = new List<functionDelegate>();
        private static int pointer = 0;


        public static void ShowOption(List<Option> optionList, string title, char pointerChar, OptionPosition pos)
        {
            switch(pos)
            {
                // ! Up Section
                case OptionPosition.UpLeft:
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine(title+"\n");
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;
                case OptionPosition.UpMid:
                    while(true)
                    {
                        Console.Clear();
                        Console.CursorTop = 0;
                        Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
                        Console.WriteLine(title);
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.SetCursorPosition((Console.WindowWidth - $"{pointerChar} {optionList[i].optionName} {pointerChar}".Length) / 2, Console.CursorTop);
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.SetCursorPosition((Console.WindowWidth - optionList[i].optionName.Length) / 2, Console.CursorTop);
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                            Console.CursorTop++;
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;
                case OptionPosition.UpRight:
                    while(true)
                    {
                        Console.Clear();
                        Console.CursorTop = 0;
                        Console.SetCursorPosition(Console.WindowWidth - title.Length, Console.CursorTop);
                        Console.WriteLine(title);
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.SetCursorPosition(Console.WindowWidth - $"{pointerChar} {optionList[i].optionName} {pointerChar}".Length, Console.CursorTop);
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.WindowWidth - optionList[i].optionName.Length, Console.CursorTop);
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                            Console.CursorTop++;
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;

                // ! Mid Section

                case OptionPosition.MidLeft:
                    while(true)
                    {
                        Console.Clear();
                        Console.CursorTop = Console.WindowHeight / 2;
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine(title);
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                            Console.CursorTop++;
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;
                case OptionPosition.Mid:
                    while(true)
                    {
                        Console.Clear();
                        Console.CursorTop = Console.WindowHeight / 2;
                        Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
                        Console.WriteLine(title);
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.SetCursorPosition((Console.WindowWidth - $"{pointerChar} {optionList[i].optionName} {pointerChar}".Length) / 2, Console.CursorTop);
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.SetCursorPosition((Console.WindowWidth - optionList[i].optionName.Length) / 2, Console.CursorTop);
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                            Console.CursorTop++;
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;
                case OptionPosition.MidRight:
                    while(true)
                    {
                        Console.Clear();
                        Console.CursorTop = Console.WindowHeight / 2;
                        Console.SetCursorPosition(Console.WindowWidth - title.Length, Console.CursorTop);
                        Console.WriteLine(title);
                        for(int i = 0; i < optionList.Count; i++)
                        {
                            if(i == pointer)
                            {
                                Console.SetCursorPosition(Console.WindowWidth - $"{pointerChar} {optionList[i].optionName} {pointerChar}".Length, Console.CursorTop);
                                Console.WriteLine($"{pointerChar} {optionList[i].optionName} {pointerChar}");
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.WindowWidth - optionList[i].optionName.Length, Console.CursorTop);
                                Console.WriteLine($"{optionList[i].optionName}");
                            }
                            Console.CursorTop++;
                        }
                        ConsoleKeyInfo ck = Console.ReadKey();
                        if(ck.Key == ConsoleKey.UpArrow)
                        {
                            if(pointer != 0)
                            {
                                pointer--;
                            }
                        }
                        else if(ck.Key == ConsoleKey.DownArrow)
                        {
                            if(pointer != optionList.Count)
                            {
                                pointer++;
                            }
                        }
                        else if(ck.Key == ConsoleKey.Enter)
                        {
                            functionList.Add(optionList[pointer].optionFunction);
                            functionList.ForEach(x => x.Invoke());
                            Console.Clear();
                            break;
                        }
                    }
                    break;
            }
        }
    }
}