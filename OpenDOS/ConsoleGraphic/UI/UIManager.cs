using System;
using System.Collections.Generic;

namespace OpenDOS.ConsoleGraphic.UI;

public class UIManager
{
    public int winPos_StartsX { get; private set; } = 1;
    public int winPos_EndsX { get; private set; } = Console.WindowWidth - 2;

    public int winPos_StartsY { get; private set; } = 1;
    public int winPos_EndsY { get; private set; } = Console.WindowHeight - 2;

    public int currentWinPos_X { get; private set; } = 1;
    public int currentWinPos_Y { get; private set; } = 1;

    public string windowTitles { get; private set; } = "New Window";
    public ConsoleColor foreGroundColor { get; private set; } = ConsoleColor.White;
    public ConsoleColor backGroundColor { get; private set; } = ConsoleColor.Black;

    public List<SubWindows> subWindows { get; private set; } = new List<SubWindows>();
    public SubWindows currentSubwindowsSelected { get; private set; }

    public void Render(string titleSimulation)
    {
        Console.ForegroundColor = foreGroundColor;
        Console.BackgroundColor = backGroundColor;
        windowTitles = titleSimulation;
        Console.Clear();
        Console.Write($"┌─{windowTitles}");
        for (int i = 0; i < Console.WindowWidth - $"┌─{windowTitles}".Length - 1; i++)
        {
            Console.Write("─");
        }
        Console.Write("┐");
        
        for (int i = 0; i < Console.WindowHeight - 3; i++)
        {
            Console.WriteLine("│");
        }
        Console.Write("└");

        Console.SetCursorPosition(Console.WindowWidth - 1, 2);
        for (int i = 0; i < Console.WindowHeight - 2; i++)
        {
            Console.Write("│");
            Console.SetCursorPosition(Console.WindowWidth - 1, 1 + i);
        }
        Console.Write("┘");

        Console.SetCursorPosition(1, Console.WindowHeight - 2);
        for (int i = 0; i < Console.WindowWidth - 2; i++)
        {
            Console.Write("─");
        }
        Console.SetCursorPosition(currentWinPos_X, currentWinPos_Y);
    }

    public void Render()
    {
        Console.ForegroundColor = foreGroundColor;
        Console.BackgroundColor = backGroundColor;
        Console.Clear();
        Console.Write($"┌─{windowTitles}");
        for (int i = 0; i < Console.WindowWidth - $"┌─{windowTitles}".Length - 1; i++)
        {
            Console.Write("─");
        }
        Console.Write("┐");

        for (int i = 0; i < Console.WindowHeight - 3; i++)
        {
            Console.WriteLine("│");
        }
        Console.Write("└");

        Console.SetCursorPosition(Console.WindowWidth - 1, 2);
        for (int i = 0; i < Console.WindowHeight - 2; i++)
        {
            Console.Write("│");
            Console.SetCursorPosition(Console.WindowWidth - 1, 1 + i);
        }
        Console.Write("┘");

        Console.SetCursorPosition(1, Console.WindowHeight - 2);
        for (int i = 0; i < Console.WindowWidth - 2; i++)
        {
            Console.Write("─");
        }
        Console.SetCursorPosition(currentWinPos_X, currentWinPos_Y);
    }

    public void SetCursor(int x, int y)
    {
        currentWinPos_X = x + winPos_StartsX;
        currentWinPos_Y = y + winPos_StartsY;
        Console.SetCursorPosition(currentWinPos_X, currentWinPos_X);
    }

    public void SetWindowColor(ConsoleColor fore, ConsoleColor back) { foreGroundColor = fore; backGroundColor = back; }
    public void SetWindowTitles(string title) { windowTitles = title; }

    public void NewLine()
    {
        currentWinPos_Y += 1;
        currentWinPos_X = 1;
    }

    public void Return()
    {
        Console.SetCursorPosition(currentWinPos_X, currentWinPos_Y);
    }

    public void DrawText(string text, int x, int y, bool newLine)
    {
        SetCursor(x, y);
        Console.Write(text);
        if (newLine) { NewLine(); }
    }

    public void DrawText(string text, bool newLine)
    {
        SetCursor(currentWinPos_X, currentWinPos_Y);
        Console.Write(text);
        if (newLine) { NewLine(); }
    }

    public void DrawText(string text, int x, int y, bool newLine, ConsoleColor textColor)
    {
        SetCursor(x, y);
        Console.ForegroundColor = textColor;
        Console.Write(text);
        Console.ResetColor();
        if (newLine) { NewLine(); }
    }

    public void DrawText(string text, bool newLine, ConsoleColor textColor)
    {
        SetCursor(currentWinPos_X, currentWinPos_Y);
        Console.ForegroundColor = textColor;
        Console.Write(text);
        Console.ResetColor();
        if (newLine) { NewLine(); }
    }

    public void RenderSubWindows(SubWindows subWin)
    {
        switch (subWin.pos)
        {
            case SubWindowsPosition.Left:
                Console.SetCursorPosition(1, 1);
                Console.Write("┌");
                for (int i = 0; i < (winPos_EndsX / 2) - 1; i++)
                {
                    Console.Write("─");
                }
                Console.Write("┐");
                Console.SetCursorPosition(1, 2);
                for (int i = 0; i < winPos_EndsY - 2; i++)
                {
                    Console.Write("│");
                    Console.SetCursorPosition(1, 2 + i);
                }
                Console.Write("└");
                Console.SetCursorPosition((winPos_EndsX / 2) + 1, 2);
                for (int i = 0; i < winPos_EndsY - 2; i++)
                {
                    Console.Write("│");
                    Console.SetCursorPosition((winPos_EndsX / 2) + 1, 2 + i);
                }
                Console.Write("┘");
                Console.SetCursorPosition(2, winPos_EndsY + 1);

                Console.SetCursorPosition(2, winPos_EndsY - 1);
                for (int i = 0; i < (winPos_EndsX / 2) - 1; i++)
                {
                    Console.Write("─");
                }
                break;
        }
    }

    public string ReadLine()
    {
        string text = Console.ReadLine();
        NewLine();
        return text;
    }
}

public class SubWindows
{
    public string titles;
    public ConsoleColor forefroundColor;
    public ConsoleColor backgroundColor;
    public SubWindowsPosition pos;

    public int posX;
    public int posY;

    public void NewLine()
    {

    }

    
}

public enum SubWindowsPosition { Left, Right, Down, Up }