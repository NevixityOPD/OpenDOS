using System;
using System.Collections.Generic;

namespace OpenDOS.ConsoleGraphic.UI;

public class UIManager
{
    public int windowTeritoryStarts_X = 1;
    public int windowTeritoryStarts_Y = 1;

    public int windowTeritoryEnds_X = Console.WindowWidth - 2;
    public int windowTeritoryEnds_Y = Console.WindowHeight - 2;

    public int currentWindowPos_X = 1;
    public int currentWindowPos_Y = 1;

    public void Render(string titleSimulation)
    {
        Console.Write($"┌─{titleSimulation}");
        for (int i = 0; i < Console.WindowWidth - $"┌─{titleSimulation}".Length - 1; i++)
        {
            Console.Write("─");
        }
        Console.Write("┐\n");
        for (int i = 0; i < Console.WindowHeight - 2; i++)
        {
            Console.WriteLine("│");
        }
        Console.Write("└");

        Console.SetCursorPosition(Console.WindowWidth - 1, 1);
        for (int i = 0; i < Console.WindowHeight - 1; i++)
        {
            Console.Write("│");
            Console.SetCursorPosition(Console.WindowWidth - 1, i + 1);
        }
        Console.Write("┘");

        Console.SetCursorPosition(1, Console.WindowHeight - 1);
        for (int i = 0; i < Console.WindowWidth - 2; i++)
        {
            Console.Write("─");
        }

        Console.SetCursorPosition(currentWindowPos_X, currentWindowPos_Y);
    }

    public void WriteTextAtWindow(string[] textToWrite)
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            for (int x = 0; x < textToWrite[i].Length; x++)
            {
                Console.Write(textToWrite[i][x]);
            }
            NewLine();
        }
    }

    public void WriteTextAtWindow(string textToWrite)
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            Console.Write(textToWrite[i]);
        }
        NewLine();
    }

    public void WriteTextAtWindowNoNewLine(string textToWrite)
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            Console.Write(textToWrite[i]);
        }
    }

    public string ReadInputTest()
    {
        string? text = Console.ReadLine();
        NewLine();
        return text;
    }

    public void NewLine()
    {
        if (currentWindowPos_Y != windowTeritoryEnds_Y)
        {
            currentWindowPos_Y += 1;
            currentWindowPos_X = 1;
        }

        Console.SetCursorPosition(currentWindowPos_X, currentWindowPos_Y);
    }

    public void SetCursor(int x, int y)
    {
        Console.SetCursorPosition(x + windowTeritoryStarts_X, y + windowTeritoryStarts_Y);
        currentWindowPos_X = x + windowTeritoryStarts_X;
        currentWindowPos_Y = y + windowTeritoryStarts_Y;
    }
}
