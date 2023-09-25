using System;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdMk : Command
    {
        public cmdMk() : base("mk", "Creates file or directory", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Log.Log.ShowLog("mk: Input an argument!", Log.LogWarningLevel.Error, Log.LogWritter.System);
            }
            else
            {
                if (args[0] == "-f" || args[0] == "--file")
                {
                    if (!args[1].StartsWith(Kernel.currentDir))
                    {
                        File.Create($@"{Kernel.currentDir}\{args[1]}");
                    }
                    else if (args[1].StartsWith(Kernel.currentDir))
                    {
                        File.Create(args[1]);
                    }
                }
                else if (args[0] == "-d" || args[0] == "--dir")
                {
                    if (!args[1].StartsWith(Kernel.currentDir))
                    {
                        Directory.CreateDirectory($@"{Kernel.currentDir}\{args[1]}");
                    }
                    else if (args[1].StartsWith(Kernel.currentDir))
                    {
                        Directory.CreateDirectory(args[1]);
                    }
                }
            }
        }
    }
}
