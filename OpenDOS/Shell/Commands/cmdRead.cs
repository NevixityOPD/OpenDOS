using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;

namespace OpenDOS.Shell.Commands
{
    public class cmdRead : Command
    {
        public cmdRead() : base("read", "Read a file", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Log.Log.ShowLog("read: Input an argument!", Log.LogWarningLevel.Error, Log.LogWritter.System);
            }
            else
            {
                try
                {
                    for (int i = 0; i < File.ReadAllLines($@"{Kernel.currentDir}\{args[0]}").Length; i++)
                    {
                        Console.WriteLine(File.ReadAllLines($@"{Kernel.currentDir}\{args[0]}")[i]);
                    }
                }
                catch (System.Exception ex)
                {
                    Log.Log.ShowLog($"read: Error Occured {ex.Message}", Log.LogWarningLevel.Error, Log.LogWritter.System);
                }
            }
        }
    }
}
