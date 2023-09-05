using System;
using System.Collections.Generic;
using Cosmos.System.ScanMaps;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib.LibShell.Commands
{
    public class cmdSystemCommand : Command
    {
        public string commandName => "sys";
        public string commandDescription => "System command";
        public Elevation commandElevation => Elevation.Root;
        public void executeCommand(List<string> args)
        {
            if(args[0] == "disk")
            {
                if(OS.initializevFS)
                {
                    if(args[1] == "format")
                    {
                        OS.vFS.Disks[0].CreatePartition(536870912);
                        OS.vFS.Disks[0].FormatPartition(0, "FAT32", true);
                    }
                    else if(args[1] == "list")
                    {
                        LibVFS.vFS.ListDiskPartition();
                    }
                }
                else
                {
                    OS.Log("vFS is not initialized", "sys", true);
                }
            }
            else
            {
                Console.WriteLine("sys: Invalid use of this command\nUsage: sys [option]");
            }
        }
    }
}