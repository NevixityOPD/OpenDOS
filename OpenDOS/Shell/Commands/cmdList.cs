using System;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdList : Command
    {
        public cmdList() : base("ls", "List any directory and files inside current directorys", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            try
            {
                for (int i = 0; i < Directory.GetDirectories(Kernel.currentDir).Length; i++)
                {
                    Console.WriteLine($"<Dir>: {Directory.GetDirectories(Kernel.currentDir)[i]}");
                }
                for (int i = 0; i < Directory.GetFiles(Kernel.currentDir).Length; i++)
                {
                    Console.WriteLine($"<File>: {Directory.GetFiles(Kernel.currentDir)[i]}");
                }
                Console.WriteLine($"\n Dir(s) : {Directory.GetDirectories(Kernel.currentDir).Length}");
                Console.WriteLine($" File(s) : {Directory.GetFiles(Kernel.currentDir).Length}");
            }
            catch
            {
                Log.Log.ShowLog("ls: Something went wrong", Log.LogWarningLevel.Error);
                Log.Log.ShowLog(@"Changing directory back to : 0:\", Log.LogWarningLevel.Information);
                Kernel.currentDir = @"0:\";
            }
        }
    }
}
