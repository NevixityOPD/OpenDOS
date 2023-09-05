using System;
using Cosmos.System.FileSystem.VFS;

namespace OpenDOSLib.LibVFS
{
    public class vFS : LibSystem.SystemFunction.SystemFunction
    {
        public LibSystem.SystemFunction.FunctionStatus currentFunctionStatus => LibSystem.SystemFunction.FunctionStatus.Ok;

        public string functionName => "vFS";
        public string functionDescription => "Virtual File System made for this OS";

        public void InitializingSequence()
        {
            if(currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Ok)
            {
                OS.currentDirectory = @"0:\";
                OS.BootLog($"Starting {functionName} initializing sequence");
                OS.vFS = new Cosmos.System.FileSystem.CosmosVFS();
                if(OS.vFS == null) { OS.BootLog("Failed to initialize vFS"); }
                else { OS.BootLog("vFS initialized succesfully"); }
                OS.BootLog($"Registering {functionName}");
                VFSManager.RegisterVFS(OS.vFS);
            }
            else if (currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Development)
            {
                OS.currentDirectory = @"0:\";
                OS.BootLog($"Starting {functionName} initializing sequence. vFS is still under development, Things meant to change");
                OS.vFS = new Cosmos.System.FileSystem.CosmosVFS();
                if(OS.vFS == null) { OS.BootLog("Failed to initialize vFS"); }
                else { OS.BootLog("vFS initialized succesfully"); }
                OS.BootLog($"Registering {functionName}");
                VFSManager.RegisterVFS(OS.vFS);
            }
            else if (currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Broken)
            {
                OS.BootLog($"{functionName} is broken, Initializing sequence will not start");
            }
        }

        public static void ListDiskPartition()
        {
            Console.WriteLine("\nDisk & Partition Listing");
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            for(int i = 0; i < OS.vFS.Disks.Count; i++)
            {
                Console.WriteLine($"Disk {i} : {OS.vFS.Disks[i].Size} bytes");
                for(int x = 0; x < OS.vFS.Disks[i].Partitions.Count; x++)
                {
                    Console.WriteLine($"\tPartition {x} : {OS.vFS.Disks[i].Partitions[x].MountedFS.Type} - {OS.vFS.Disks[i].Partitions[x].MountedFS.Label} - {OS.vFS.Disks[i].Partitions[x].MountedFS.Size}");
                }
            }
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }
    }
}