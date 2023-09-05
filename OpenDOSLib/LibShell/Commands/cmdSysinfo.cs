using System;
using System.Collections.Generic;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib.LibShell.Commands
{
    public class cmdSysinfo : Command
    {
        public string commandName => "sysinfo";

        public string commandDescription => "Shows system info";

        public Elevation commandElevation => Elevation.User;

        public void executeCommand(List<string> args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            LibSystem.CodePage.Write("█▀█ █▀█ █▀▀ █▄░█ █▀▄ █▀█ █▀\n█▄█ █▀▀ ██▄ █░▀█ █▄▀ █▄█ ▄█ v1.0\n");
            Console.WriteLine($"Ram : {Cosmos.Core.CPU.GetAmountOfRAM()} mb");
            Console.WriteLine($"-Disk Listing-");
            LibVFS.vFS.ListDiskPartition();
            Console.ReadKey();
            Console.Clear();
        }
    }
}