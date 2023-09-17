using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdRm : Command
    {
        public cmdRm() : base("rm", "Removes file or directory", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Log.Log.ShowLog("rm: Input an argument!", Log.LogWarningLevel.Error);
            }
            else
            {
                if (args[0] == "-f" || args[0] == "--file")
                {
                    if (!args[1].StartsWith(Kernel.currentDir))
                    {
                        File.Delete($@"{Kernel.currentDir}\{args[1]}");
                    }
                    else if (args[1].StartsWith(Kernel.currentDir))
                    {
                        File.Delete(args[1]);
                    }
                }
                else if (args[0] == "-d" || args[0] == "--dir")
                {
                    if (args[1].StartsWith(Kernel.currentDir))
                    {
                        Directory.Delete($@"{Kernel.currentDir}\{args[1]}", true);
                    }
                    else if (!args[1].StartsWith(Kernel.currentDir))
                    {
                        Directory.Delete(args[1], true);
                    }
                }
            }
        }
    }
}
