using System;
using System.Collections.Generic;
using Cosmos.System.FileSystem;
using OpenDOSLib.LibConsole.ConsoleOption;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib;

public static class OS
{
    public static CosmosVFS vFS;
    public static bool initializevFS;

    public static LibShell.CommandManager cmdMgr;

    public static LibVFS.vFS virtualFS;
    public static string currentDirectory;

    public static User[] systemUser;

    public static User loggedUser = new User()
    {
        userName = "guest",
        userElevation = Elevation.Guest,
    };
    public static void InitOS()
    {
        Console.Clear();
        List<Option> vFSOption = new()
        {
            new Option()
            {
                optionName = "Initialize with vFS",
                optionFunction = delegate()
                {
                    initializevFS = true;
                }
            },
            new Option()
            {
                optionName = "Initialize without vFS",
                optionFunction = delegate()
                {
                    initializevFS = false;
                }
            },
        };

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        OptionFunction.ShowOption(vFSOption, "Entry Option", '*', OptionPosition.UpMid);
        Console.ResetColor();
        Console.Clear();

        BootLog("Adding system user");
        systemUser = new User[]
        {
            new User()
            {
                userName = "root",
                passWord = "root",
                userElevation = Elevation.Root,
            },
            new User()
            {
                userName = "user",
                passWord = "user",
                userElevation = Elevation.User,
            }
        };

        if(initializevFS)
        {
            BootLog("Initializing System Function");
            LibSystem.CodePage.Write("          └> Command Manager - V2\n");
            cmdMgr = new LibShell.CommandManager();
            LibSystem.CodePage.Write("          └> Virtual File System\n");
            virtualFS = new LibVFS.vFS();

            BootLog("Starting System function initializing sequence");
            virtualFS.InitializingSequence();
        }
        else
        {
            BootLog("Initializing System Function");
            LibSystem.CodePage.Write("          └> Command Manager\n");
            cmdMgr = new LibShell.CommandManager();
        }

        Console.WriteLine("\n\nPress any key to continue to login sequence...");
        Console.ReadKey();

        Console.Clear();

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    public static void BootLog(string log)
    {
        Console.WriteLine($"[bootlog] {log}");
    }

#nullable enable
    public static void showTitleBar(string? activities)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write($"OpenDOS | v1.0 | {activities}" + new string(' ', Console.WindowWidth - $"OpenDOS | v1.0 | {activities}".Length));
        Console.ResetColor();
        Console.WriteLine("\n\n");
    }

    public static void showTitleBar()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        Console.Write("OpenDOS | v1.0" + new string(' ', Console.WindowWidth - "OpenDOS | v1.0".Length));
        Console.ResetColor();
        Console.WriteLine("\n\n");
    }

    public static void Log(string log, string source, bool NewLine)
    {
        if(NewLine)
        {
            Console.WriteLine($"[{source}] {log}");
        }
        else
        {
            Console.Write($"[{source}] {log}");
        }
    }
}