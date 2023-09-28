using System;
using System.Collections.Generic;

namespace OpenDOS.ConsoleGraphic.UI;

public class UIManager
{
    public int winPosStart_X { get; private set; } = 1;
    public int winPosStart_Y { get; private set; } = 1;

    public int winPosEnds_X { get; private set; } = Console.WindowWidth - 2;
    public int winPosEnds_Y { get; private set; } = Console.WindowHeight - 3;

    public int currentWinPos_X = 1;
    public int currentWinPos_Y = 1;

    public bool AutoReturn = false;

    public string WindowTitle { get; private set; } = string.Empty;

    public void Render(string titleSimulation)
    {
        Console.Clear();
        WindowTitle = titleSimulation;

        Console.SetCursorPosition(0, 0);

        Console.Write($"┌─{WindowTitle}");
        for (int i = 0; i < Console.WindowWidth - $"┌─{WindowTitle}".Length - 1; i++) { Console.Write("─"); }
        Console.Write("┐");

        for (int i = 0; i < Console.WindowHeight - 3; i++) { Console.WriteLine("│"); }
        Console.Write("└");

        Console.SetCursorPosition(Console.WindowWidth - 1, 2);
        for (int i = 0; i < Console.WindowHeight - 2; i++)
        {
            Console.Write("│");
            Console.SetCursorPosition(Console.WindowWidth - 1, 1 + i);
        }
        Console.Write("┘");

        Console.SetCursorPosition(1, Console.WindowHeight - 2);
        for (int i = 0; i < Console.WindowWidth - 2; i++) { Console.Write("─"); }
        SetCursor(0, 0);
    }

    public void SetCursor(int x, int y)
    {
        currentWinPos_X = x; currentWinPos_Y = y;

        if (currentWinPos_X == 0) { currentWinPos_X = 1; } else { if (currentWinPos_X >= winPosEnds_X) { currentWinPos_X = winPosEnds_X; } else { currentWinPos_X = x; } }
        if (currentWinPos_Y == 0) { currentWinPos_Y = 1; } else { if (currentWinPos_Y >= winPosEnds_Y) { currentWinPos_Y = winPosEnds_Y; } else { currentWinPos_Y = y; } }

        if (currentWinPos_X >= winPosEnds_X) { currentWinPos_X = winPosEnds_X; }
        if (currentWinPos_Y >= winPosEnds_Y) { currentWinPos_Y = winPosEnds_Y; }

        if (AutoReturn) { Return(); }
    }

    public void Return()
    {
        Console.SetCursorPosition(currentWinPos_X, currentWinPos_Y);
    }

    public void NewLine()
    {
        currentWinPos_X = 1; currentWinPos_Y += 1;
        if (currentWinPos_Y >= winPosEnds_Y)
        {
            currentWinPos_Y = winPosEnds_Y;
        }

        if (AutoReturn) { Return(); }
    }

    public void Write(string text)
    {
        Return();
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            currentWinPos_X++;
        }

        if (AutoReturn) { Return(); }
    }

    public void WriteLine(string text)
    {
        Return();
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            currentWinPos_X++;
        }
        NewLine();

        if (AutoReturn) { Return(); }
    }

    public string ReadLine()
    {
        Return();

        string text = string.Empty;
        bool ContinueLoop = true;

        int x = currentWinPos_X;

        while (ContinueLoop)
        {
            SetCursor(x, currentWinPos_Y);
            for (int i = 0; i < text.Length; i++)
            {
                Kernel.uimgr.Write(text[i].ToString());
            }

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                ContinueLoop = false;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (text.Length != 0)
                {
                    string temp = text.Substring(0, text.Length - 1);
                    SetCursor(currentWinPos_X - 1, currentWinPos_Y);
                    Write(" ");
                    text = temp;
                }
            }
            else
            {
                if (text.Length != winPosEnds_X - 2) { text += key.KeyChar; }
            }
        }

        NewLine();
        return text;
    }

    public void Clear()
    {
        Render(WindowTitle);
    }
}